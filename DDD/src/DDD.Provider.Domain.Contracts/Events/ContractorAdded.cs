using System;
using DDD.Domain.Common.Event;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Events
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
