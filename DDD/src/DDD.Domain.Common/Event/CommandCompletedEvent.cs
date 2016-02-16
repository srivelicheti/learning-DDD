using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandCompletedEvent : DomainEvent
    {
        public CommandCompletedEvent(Guid commandId, DateTime eventDateTime):base(Guid.NewGuid(),eventDateTime)
        {
            CommandId = commandId;
        }

        public Guid CommandId
        {
            get;private set;
        } 
    }
}
