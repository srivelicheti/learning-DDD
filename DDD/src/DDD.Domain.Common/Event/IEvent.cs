using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime EventDateTime { get; }

    }

    public class DomainEvent : IDomainEvent
    {
        protected DomainEvent(Guid id, DateTime eventTime) {
            Id = id;
            EventDateTime = eventTime;
        }
        //public DomainEvent(EventBus bus, Guid id, DateTime eventTime)
        //{
        //    Id = id;
        //    EventDateTime = eventTime;
        //}
        public DateTime EventDateTime
        {
            get;
        }

        public Guid Id
        {
            get;
        }
        public string EventName => this.GetType().Name;
    }


    public interface IEventHandler
    {

        //void Handle<TEvent>(TEvent e) where TEvent : DomainEvent;
    }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent: DomainEvent
    {
        void Handle(TEvent e);
    }
}
