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

    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent(Guid id, DateTime eventTime) {
            ID = id;
            EventDateTime = eventTime;
        }
        //public DomainEvent(EventBus bus, Guid id, DateTime eventTime)
        //{
        //    ID = id;
        //    EventDateTime = eventTime;
        //}
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
