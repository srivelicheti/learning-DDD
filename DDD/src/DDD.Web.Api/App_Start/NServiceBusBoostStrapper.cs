using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public static class NServiceBusBootStrapper
    {
        private static readonly object _syncLock = new object();
        private static IBus _bus = null;
        public static IBus Bus { get {
                if (_bus == null)
                    Init();
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

                var cfg = new BusConfiguration();
                cfg.UseTransport<MsmqTransport>();
                cfg.UsePersistence<InMemoryPersistence>();
                cfg.EndpointName("ProviderDomain");
                cfg.PurgeOnStartup(true);
                cfg.EnableInstallers();
                Bus = NServiceBus.Bus.Create(cfg).Start();
                return Bus;
            }
        }
    }
}
