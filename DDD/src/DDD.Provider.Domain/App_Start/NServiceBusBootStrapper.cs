using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Config;
using System.Configuration;
using NServiceBus.Faults;
using Newtonsoft.Json;
using DDD.Provider.Domain.Infrastructure.NSB;
using StructureMap;

namespace DDD.Provider.Domain
{
    public static class NServiceBusBootStrapper
    {
        public static IEndpointInstance Init(Container iocContainer)
        {
            var cfg = new EndpointConfiguration("ProviderDomain");
            cfg.CustomConfigurationSource(new NServiceBusConfigurationSource());
            cfg.UseContainer<StructureMapBuilder>(x => x.ExistingContainer(iocContainer));
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
    }


    public class NServiceBusConfigurationSource : NServiceBus.Config.ConfigurationSource.IConfigurationSource
    {
        public T GetConfiguration<T>() where T : class, new()
        {
            // the part you are overriding
            //if (typeof(T) == typeof(UnicastBusConfig))
            //{
            //    //var config = new UnicastBusConfig();
            //    //var coll = config.MessageEndpointMappings;
            //    //coll.Add(new MessageEndpointMapping
            //    //{
            //    //    Endpoint = "ProviderDomain",
            //    //    Messages = "DDD.Provider.Messages",
            //    //});

            //    //coll.Add(new MessageEndpointMapping
            //    //{
            //    //    Endpoint = "ProviderDomain",
            //    //    Messages = "DDD.Provider.Domain",
            //    //});


            //    return config as T;
            //}
            //else
            if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
            {
                var errorQUeue = new MessageForwardingInCaseOfFaultConfig
                {
                    ErrorQueue = "ProviderServiceErrorQueue"
                };
                return errorQUeue as T;
            }
            // leaving the rest of the configuration as is:
            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }
    }

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
