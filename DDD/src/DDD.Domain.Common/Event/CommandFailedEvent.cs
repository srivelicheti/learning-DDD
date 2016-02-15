using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandFailedEvent : DomainEvent
    {
        public CommandFailedEvent(Guid commandID,Exception exception ,DateTime eventDateTime):base(Guid.NewGuid(),eventDateTime)
        {
            CommandID = commandID;
            Error = exception;
        }

        public Guid CommandID
        {
            get; private set;
        }

        public Exception Error
        {
            get; private set;
        }
    }
}
