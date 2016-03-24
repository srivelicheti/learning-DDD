using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
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
                cfg.UseTransport<MsmqTransport>();
                cfg.UsePersistence<InMemoryPersistence>();
                cfg.EndpointName("ProviderDomain");
                cfg.PurgeOnStartup(true);
                cfg.EnableInstallers();
                cfg.CustomConfigurationSource(new MyCustomConfigurationSource());
                //cfg.
                Bus = NServiceBus.Bus.Create(cfg).Start();
                return Bus;
            }
        }
    }

    //public class NServiceBusConfigSource : IConfigurationSource
    //{
    //    public T GetConfiguration<T>() where T : class, new()
    //    {
    //        if(typeof(T) == )
    //        throw new NotImplementedException();
    //    }
    //}

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

    public class EndPointConfig : IProvideConfiguration<MessageEndpointMappingCollection>
    {
        public MessageEndpointMappingCollection GetConfiguration()
        {
            var coll = new MessageEndpointMappingCollection();
            coll.Add(new MessageEndpointMapping {
                 AssemblyName= "DDD.Provider.Messages",
                  Endpoint= "ProviderDomain",
            } );

            return coll;
        }
    }

    public class ErrorQueueConfig : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig {
                 ErrorQueue="ProviderErrorQueue"
            };
        }
    }
}
