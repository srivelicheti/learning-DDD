using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;

namespace DDD.Provider.Domain.Events
{
    public class ContractorNameChanged : DomainEvent
    {
        public ContractorNameChanged(Guid id, DateTime eventTime, string einNumber, string oldName, string changedName) : base(id, eventTime)
        {
            EinNumber = einNumber;
            OldName = oldName;
            NewName = changedName;
        }

        public ContractorNameChanged(string einNumber, string oldName, string changedName) : this(Guid.NewGuid(), DateTime.UtcNow, einNumber, oldName, changedName)
        {
        }

        public string NewName { get; set; }

        public string OldName { get; set; }

        public string EinNumber { get; set; }
    }

    public class ContractorBusinessNameChanged : DomainEvent
    {
        public ContractorBusinessNameChanged(Guid id, DateTime eventTime, string einNumber, string oldName, string changedName) : base(id, eventTime)
        {
            EinNumber = einNumber;
            OldName = oldName;
            NewName = changedName;
        }

        public ContractorBusinessNameChanged(string einNumber, string oldName, string changedName) : this(Guid.NewGuid(), DateTime.UtcNow, einNumber, oldName, changedName)
        {
        }

        public string NewName { get; set; }

        public string OldName { get; set; }

        public string EinNumber { get; set; }
    }
}
