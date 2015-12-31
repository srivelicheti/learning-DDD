using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandCompletedEvent : IDomainEvent
    {
        public CommandCompletedEvent(Guid commandID, DateTime eventDateTime)
        {
            ID = Guid.NewGuid();
            EventDateTime = eventDateTime;
            CommandID = commandID;
        }

        public DateTime EventDateTime
        {
            get; private set;
        }

        public Guid ID
        {
            get; private set;
        }

        public Guid CommandID
        {
            get;private set;
        } 
    }
}
