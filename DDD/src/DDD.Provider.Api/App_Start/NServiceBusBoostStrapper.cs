using DDD.Domain.Common.Event;
//using DDD.Provider.Domain.CommandHandlers;
using DDD.Provider.Messages.Commands;
using log4net;
using Newtonsoft.Json;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Container;
using NServiceBus.Faults;
using NServiceBus.Features;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{

    public static class NServiceBusBootStrapper
    {



        private static readonly object _syncLock = new object();
        private static IEndpointInstance _bus = null;
        public static IEndpointInstance Bus
        {
            get
            {

                return _bus;
            }
            private set { _bus = value; }
        }
        public static IEndpointInstance Init(Container iocContainer)
        {
            if (Bus != null)
                return Bus;
            lock (_syncLock)
            {
                if (Bus != null)
                    return Bus;


                //var endPointConfig = new EndpointConfiguration

                var cfg = new EndpointConfiguration("ProviderApi");
                cfg.CustomConfigurationSource(new NServiceBusConfigurationSource());
                cfg.UseContainer<StructureMapBuilder>(x => x.ExistingContainer(iocContainer));
                cfg.ExcludeAssemblies("System", "mscorlib", "AutoMapper", "Castle.Core", "lesi.Collections", "libuv",
                    "log4net", "Microsoft.*");
                //cfg.AssembliesToScan(GetAssembliesToScan());
                cfg.UseTransport<MsmqTransport>();
                cfg.UsePersistence<InMemoryPersistence>();
               // cfg.EndpointName("ProviderDomain");
                cfg.PurgeOnStartup(true);
                cfg.EnableInstallers();

                //cfg.
                Bus = Endpoint.Start(cfg).Result;
                return Bus;
            }
        }

        private static Assembly[] GetAssembliesToScan()
        {
            var domainCommonAssembly = typeof(CommandCompletedEvent).Assembly;
            var providerMessages = typeof(AddNewContractorCommand).Assembly;
            var apiAssembly = typeof(NServiceBusBootStrapper).Assembly;
            //var providerDomain = typeof(AddNewContractorCommandHandler).Assembly;
            return new Assembly[] { domainCommonAssembly, providerMessages,  apiAssembly };
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
                    Messages = "DDD.Provider.Domain.Contracts",
                });

                //coll.Add(new MessageEndpointMapping
                //{
                //    //AssemblyName = "DDD.Provider.Messages",
                //    Endpoint = "ProviderDomain",
                //    //Namespace = "DDD.Provider.Messages.Commands",
                //    Messages = "DDD.Provider.Domain",

                //    //  TypeFullName= "DDD.Provider.Messages.Commands.AddNewContractorCommand, DDD.Provider.Messages"
                //});
                //coll.Add(new MessageEndpointMapping
                //{
                //    AssemblyName = "DDD.Provider.Messages",
                //    Endpoint = "ProviderDomain",
                //    Messages = "DDD.Provider.Messages",
                //    //Namespace = "DDD.Provider.Messages.Events"
                //});

                return config as T;
            }
            if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
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


    //TODO: NSB Update
    /// <summary>
    
    /// </summary>
    //public class SubscribeToNotifications :
    // IWantToRunWhenBusStartsAndStops,
    // IDisposable
    //{
    //    static ILog log = log4net.LogManager.GetLogger(typeof(SubscribeToNotifications));
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

    public class FailedMessageObserver : IObserver<FailedMessage>
    {
        static ILog log = log4net.LogManager.GetLogger(typeof(FailedMessageObserver));
        public void OnCompleted()
        {
            log.Info("Mesage sent to error queue competed");
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            log.Info("Mesage sent to error queue" + error.ToString());
        }

        public void OnNext(FailedMessage value)
        {
            log.Info("Mesage sent to error queue " + JsonConvert.SerializeObject(value));

        }
    }


    //TODO:NSB Update
    //class AuthorizeSubscriptions : IAuthorizeSubscriptions
    //{

    //    public bool AuthorizeSubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    //    {
    //        return true;
    //        //string lowerEndpointName = clientEndpoint.ToLowerInvariant();
    //        //return lowerEndpointName.StartsWith("samples.pubsub.subscriber1") ||
    //        //       lowerEndpointName.StartsWith("samples.pubsub.subscriber2");
    //    }

    //    public bool AuthorizeUnsubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    //    {
    //        return true;
    //    }
    //}
}
