using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public interface IDomainEvent
    {
        Guid ID { get; }

        DateTime EventDateTime { get; }
    }

    public class DomainEvent : IDomainEvent
    {
        public DomainEvent(Guid id, DateTime eventDateTime) {
            ID = id;
            EventDateTime = eventDateTime;
        }

        public DateTime EventDateTime
        {
            get;private set;
        }

        public Guid ID
        {
            get;private set;
        }
    }
    

    public interface IEventHandler
    { }

    public interface IEventHandler<TEvent> : IEventHandler where TEvent: DomainEvent
    {
        void Handle(TEvent e);
    }
}
