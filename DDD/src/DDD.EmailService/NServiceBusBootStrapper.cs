using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using NServiceBus.Faults;
using DDD.Domain.Common.Event;
using DDD.Provider.Messages.Commands;
using System.Reflection;
using Newtonsoft.Json;

namespace DDD.EmailService
{
    public static class NServiceBusBootStrapper
    {
        public static IEndpointInstance Init() {
            var cfg = new EndpointConfiguration("EmailService");
            cfg.CustomConfigurationSource(new NServiceBusConfigurationSource());
            //cfg.UseContainer<StructureMapBuilder>(x => x.ExistingContainer(iocContainer));
            //TODO: Check this
            //cfg.AssembliesToScan(GetAssembliesToScan()); 
            cfg.UseTransport<MsmqTransport>();
            cfg.UsePersistence<InMemoryPersistence>();
            //cfg.EndpointName("EmailService");
            cfg.PurgeOnStartup(true);
            cfg.EnableInstallers();

            //cfg.
            var bus = Endpoint.Start(cfg).Result;
            return bus;
        }

        private static Assembly[] GetAssembliesToScan()
        {
            var domainCommonAssembly = typeof(CommandCompletedEvent).Assembly;
            var providerMessages = typeof(AddNewContractorCommand).Assembly;
            var apiAssembly = typeof(NServiceBusBootStrapper).Assembly;
            return new Assembly[] { domainCommonAssembly, providerMessages, apiAssembly };
        }
    }


    public class NServiceBusConfigurationSource : IConfigurationSource
    {
        public T GetConfiguration<T>() where T : class, new()
        {
            // the part you are overriding
            if (typeof(T) == typeof(UnicastBusConfig))
            {
                var config = new UnicastBusConfig();
                var coll = config.MessageEndpointMappings;
                coll.Add(new MessageEndpointMapping
                {
                    Endpoint = "ProviderDomain",
                    Messages = "DDD.Provider.Messages",
                });

                //coll.Add(new MessageEndpointMapping
                //{
                //    Endpoint = "ProviderDomain",
                //    Messages = "DDD.Provider.Domain",
                //});
               

                return config as T;
            }
            else if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
            {
                var errorQUeue = new MessageForwardingInCaseOfFaultConfig
                {
                    ErrorQueue = "EmailServiceErrorQueue"
                };
                return errorQUeue as T;
            }
            // leaving the rest of the configuration as is:
            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }
    }

    //TODO: NSB Update
    //public class SubscribeToNotifications :
    // IWantToRunWhenBusStartsAndStops
    // IDisposable
    //{
    //    //static ILog log = log4net.LogManager.GetLogger(typeof(SubscribeToNotifications));
    //    BusNotifications busNotifications;
    //    List<IDisposable> unsubscribeStreams = new List<IDisposable>();

    //    public SubscribeToNotifications(BusNotifications busNotifications)
    //    {
    //        this.busNotifications = busNotifications;
    //    }

    //    public void Start()
    //    {
    //        ErrorsNotifications errors = busNotifications.Errors;
    //        unsubscribeStreams.Add(errors.MessageSentToErrorQueue.Subscribe(new FailedMessageObserver()));
    //        //DefaultScheduler scheduler = Scheduler.;
    //        //unsubscribeStreams.Add(
    //        //    errors.MessageSentToErrorQueue
    //        //        .ObserveOn(scheduler)
    //        //        .Subscribe(LogToConsole)
    //        //    );
    //        //unsubscribeStreams.Add(
    //        //    errors.MessageHasBeenSentToSecondLevelRetries
    //        //        .ObserveOn(scheduler)
    //        //        .Subscribe(LogToConsole)
    //        //    );
    //        //unsubscribeStreams.Add(
    //        //    errors.MessageHasFailedAFirstLevelRetryAttempt
    //        //        .ObserveOn(scheduler)
    //        //        .Subscribe(LogToConsole)
    //        //    );
    //    }

    //    void LogToConsole(FailedMessage failedMessage)
    //    {
            
    //        Console.WriteLine("Mesage sent to error queue");
    //    }

    //    void LogToConsole(SecondLevelRetry secondLevelRetry)
    //    {
    //        //log.Info("Mesage sent to SLR. RetryAttempt:" + secondLevelRetry.RetryAttempt);
    //    }

    //    void LogToConsole(FirstLevelRetry firstLevelRetry)
    //    {
    //        Console.WriteLine("Mesage sent to FLR. RetryAttempt:" + firstLevelRetry.RetryAttempt);
    //    }

    //    public void Stop()
    //    {
    //        foreach (IDisposable unsubscribeStream in unsubscribeStreams)
    //        {
    //            unsubscribeStream.Dispose();
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Stop();
    //    }
    //}

    public class FailedMessageObserver : IObserver<FailedMessage>
    {
        //static ILog log = log4net.LogManager.GetLogger(typeof(FailedMessageObserver));
        public void OnCompleted()
        {
            Console.WriteLine("Mesage sent to error queue competed");
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Mesage sent to error queue" + error.ToString());
        }

        public void OnNext(FailedMessage value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mesage sent to error queue " + JsonConvert.SerializeObject(value));
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
