using DDD.Domain.Common.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Events
{
    public class NewContractorAdded : DomainEvent
    {
        public NewContractorAdded( DateTime eventDateTime, Guid contractorID, string contractorEin, DomainEventBus eventBus) : base(Guid.NewGuid(), eventDateTime )
        {
            ContractorID = contractorID;
            ContractorEin = contractorEin;
        }

        public Guid ContractorID { get; set; }
        public string ContractorEin { get; set; }
    }
}
