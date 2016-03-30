using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Messages.Events
{
    public class ContractorAddedEvent : IEvent
    {
        public string ContractorEin { get; set; }

    }
}
