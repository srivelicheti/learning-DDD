using DDD.Domain.Common.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandValidationFailedEvent : DomainEvent
    {
        public CommandValidationFailedEvent(Guid commandID, IEnumerable<ValidationError> errors, DateTime eventTime) : base(Guid.NewGuid(), eventTime)
        {
            CommandID = commandID;
            ValidationErrors = errors;
        }

        public Guid CommandID { get; private set; }
        public IEnumerable<ValidationError> ValidationErrors { get; private set; }
    }
}
