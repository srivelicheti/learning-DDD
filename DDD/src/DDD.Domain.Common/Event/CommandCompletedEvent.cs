using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandCompletedEvent : DomainEvent
    {
        public CommandCompletedEvent(Guid commandID, DateTime eventDateTime):base(Guid.NewGuid(),eventDateTime)
        {
            CommandID = commandID;
        }

        public Guid CommandID
        {
            get;private set;
        } 
    }
}
