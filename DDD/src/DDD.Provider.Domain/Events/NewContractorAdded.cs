using DDD.Domain.Common.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Events
{
    public class NewContractorAdded : DomainEvent
    {
        public NewContractorAdded( DateTime eventDateTime, Guid contractorId, string contractorEin, DomainEventBus eventBus) : base(Guid.NewGuid(), eventDateTime )
        {
            ContractorId = contractorId;
            ContractorEin = contractorEin;
        }

        public Guid ContractorId { get; set; }
        public string ContractorEin { get; set; }
    }
}
