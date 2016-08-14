using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Events
{
    //public class ContractorAddressChanged : BaseEvent
    //{
    //    public ContractorAddressChanged(Guid id, DateTime eventTime,string einNumber,Address oldAddress,Address newAddress) : base(id, eventTime)
    //    {
    //        EinNumber = einNumber;
    //        OldAddress = oldAddress;
    //        NewAddress = newAddress;
    //    }

    //    public ContractorAddressChanged(string einNumber, Address oldAddress, Address newAddress) : this(Guid.NewGuid(), DateTime.UtcNow,einNumber,oldAddress,newAddress)
    //    {
    //    }

    //    public Address OldAddress { get; set; }

    //    public Address NewAddress { get; set; }

    //    public string EinNumber { get; set; }
    //}
}
