using DDD.Provider.Messages.Commands;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Faults;
using NServiceBus.Features;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public static class NServiceBusBootStrapper
    {
        private static readonly object _syncLock = new object();
        private static IBus _bus = null;
        public static IBus Bus { get {
               
                return _bus;
            } private set { _bus = value; } }
        public static IBus Init()
        {
            if (Bus != null)
                return Bus;
            lock (_syncLock)
            {
                if (Bus != null)
                    return Bus;


                //var endPointConfig = new EndpointConfiguration

                var cfg = new BusConfiguration();
                cfg.CustomConfigurationSource(new MyCustomConfigurationSource());

                cfg.AssembliesToScan(typeof(TestCommand).Assembly);
                cfg.UseTransport<MsmqTransport>();
                cfg.UsePersistence<InMemoryPersistence>();
                cfg.EndpointName("ProviderDomain");
                cfg.PurgeOnStartup(true);
                cfg.EnableInstallers();
                
                //cfg.
                Bus = NServiceBus.Bus.Create(cfg).Start();
                return Bus;
            }
        }
    }

    
    public class MyCustomConfigurationSource : IConfigurationSource
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
                    //AssemblyName = "DDD.Provider.Messages",
                    Endpoint = "ProviderDomain",
                    //Namespace = "DDD.Provider.Messages.Commands",
                    Messages= "DDD.Provider.Messages",
                    
                  //  TypeFullName= "DDD.Provider.Messages.Commands.AddNewContractorCommand, DDD.Provider.Messages"
                });

                coll.Add(new MessageEndpointMapping
                {
                    //AssemblyName = "DDD.Provider.Messages",
                    Endpoint = "ProviderDomain",
                    //Namespace = "DDD.Provider.Messages.Commands",
                    Messages = "DDD.Provider.Domain",

                    //  TypeFullName= "DDD.Provider.Messages.Commands.AddNewContractorCommand, DDD.Provider.Messages"
                });
                //coll.Add(new MessageEndpointMapping
                //{
                //    AssemblyName = "DDD.Provider.Messages",
                //    Endpoint = "ProviderDomain",
                //    Messages = "DDD.Provider.Messages",
                //    //Namespace = "DDD.Provider.Messages.Events"
                //});

                return config as T;
            }
            else if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
            {
                var errorQUeue = new MessageForwardingInCaseOfFaultConfig
                {
                    ErrorQueue = "ProviderErrorQueue"
                };
                return errorQUeue as T;
            }
            // leaving the rest of the configuration as is:
            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }
    }

    //public class SubscribeToNotifications :
    // IWantToRunWhenBusStartsAndStops,
    // IDisposable
    //{
    //    static ILog log = LogManager.GetLogger<SubscribeToNotifications>();
    //    BusNotifications busNotifications;
    //    List<IDisposable> unsubscribeStreams = new List<IDisposable>();

    //    public SubscribeToNotifications(BusNotifications busNotifications)
    //    {
    //        this.busNotifications = busNotifications;
    //    }

    //    public void Start()
    //    {
    //        ErrorsNotifications errors = busNotifications.Errors;
    //        DefaultScheduler scheduler = Scheduler.Default;
    //        unsubscribeStreams.Add(
    //            errors.MessageSentToErrorQueue
    //                .ObserveOn(scheduler)
    //                .Subscribe(LogToConsole)
    //            );
    //        unsubscribeStreams.Add(
    //            errors.MessageHasBeenSentToSecondLevelRetries
    //                .ObserveOn(scheduler)
    //                .Subscribe(LogToConsole)
    //            );
    //        unsubscribeStreams.Add(
    //            errors.MessageHasFailedAFirstLevelRetryAttempt
    //                .ObserveOn(scheduler)
    //                .Subscribe(LogToConsole)
    //            );
    //    }

    //    void LogToConsole(FailedMessage failedMessage)
    //    {
    //        log.Info("Mesage sent to error queue");
    //    }

    //    void LogToConsole(SecondLevelRetry secondLevelRetry)
    //    {
    //        log.Info("Mesage sent to SLR. RetryAttempt:" + secondLevelRetry.RetryAttempt);
    //    }

    //    void LogToConsole(FirstLevelRetry firstLevelRetry)
    //    {
    //        log.Info("Mesage sent to FLR. RetryAttempt:" + firstLevelRetry.RetryAttempt);
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
}
