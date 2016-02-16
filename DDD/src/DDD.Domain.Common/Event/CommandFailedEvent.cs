using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandFailedEvent : DomainEvent
    {
        public CommandFailedEvent(Guid commandId,Exception exception ,DateTime eventDateTime):base(Guid.NewGuid(),eventDateTime)
        {
            CommandId = commandId;
            Error = exception;
        }

        public Guid CommandId
        {
            get; private set;
        }

        public Exception Error
        {
            get; private set;
        }
    }
}
