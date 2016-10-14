using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;

namespace DDD.Provider.Messages.Events
{
    public class ContractorAdded : BaseEvent, IEvent
    {
        public ContractorAdded(DateTime eventDateTime, Guid contractorId, string contractorEin) : base(Guid.NewGuid(), eventDateTime)
        {
            ContractorId = contractorId;
            ContractorEin = contractorEin;
        }
        public Guid ContractorId { get; set; }
        public string ContractorEin { get; set; }
    }
}
