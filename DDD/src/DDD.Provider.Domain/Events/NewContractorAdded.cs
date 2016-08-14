using DDD.Domain.Common.Event;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Events
{
    //public class NewContractorAdded : BaseEvent,IEvent
    //{
    //    public NewContractorAdded( DateTime eventDateTime, Guid contractorId, string contractorEin, IBus eventBus) : base(Guid.NewGuid(), eventDateTime )
    //    {
    //        ContractorId = contractorId;
    //        ContractorEin = contractorEin;
    //    }

    //    public Guid ContractorId { get; set; }
    //    public string ContractorEin { get; set; }
    //}
}
