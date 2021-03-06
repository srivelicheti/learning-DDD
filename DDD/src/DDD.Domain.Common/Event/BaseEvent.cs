﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    //public interface IEvent
    //{
    //    Guid Id { get; }

    //    DateTime EventDateTime { get; }

    //}

    public abstract class BaseEvent : IEvent
    {
        protected BaseEvent(Guid id, DateTime eventTime) {
            Id = id;
            EventDateTime = eventTime;
        }
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


    //public interface IEventHandler
    //{
    //}

    //public interface IEventHandler<in TEvent> : IEventHandler where TEvent: BaseEvent
    //{
    //    void Handle(TEvent e);
    //}
}
