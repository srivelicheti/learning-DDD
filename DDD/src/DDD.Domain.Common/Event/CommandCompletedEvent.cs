using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class CommandCompletedEvent : DomainEvent
    {
        public CommandCompletedEvent(Command.Command command, DateTime eventDateTime) : this(command.Id, eventDateTime)
        {
            Command = command;
        }

        public CommandCompletedEvent(Guid commandId, DateTime eventDateTime) : base(Guid.NewGuid(), eventDateTime)
        {
            CommandId = commandId;
        }

        public Guid CommandId
        {
            get; private set;
        }

        public Command.Command Command { get; private set; }
    }
}
