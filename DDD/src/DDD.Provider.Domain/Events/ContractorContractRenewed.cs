using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Events
{
    //public class ContractorContractRenewed : BaseEvent
    //{
    //    public ContractorContractRenewed(Guid id, DateTime eventTime, string einNumber, DateTimeRange oldDuration, DateTimeRange newDuration ) : base(id, eventTime)
    //    {
    //        EinNumber = einNumber;
    //        OldDuration = oldDuration;
    //        NewDuration = newDuration;
    //    }

    //    public ContractorContractRenewed(string einNumber, DateTimeRange oldDuration, DateTimeRange newDuration) : this(Guid.NewGuid(), DateTime.UtcNow, einNumber, oldDuration, newDuration)
    //    {
    //    }

    //    public DateTimeRange NewDuration { get; set; }

    //    public DateTimeRange OldDuration { get; set; }

    //    public string EinNumber { get; private set; }
        
    //}
}
