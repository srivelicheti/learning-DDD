﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public class DomainEventBus
    {
        private static readonly IList<IEventHandler> _eventHandlers = new List<IEventHandler>();
        private readonly ConcurrentQueue<DomainEvent> _afterCommitEvents = new ConcurrentQueue<DomainEvent>();
        public static void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent
        {
            _eventHandlers.Add(eventHandler);
        }
        public void Publish<TEvent>(TEvent e) where TEvent : DomainEvent
        {
            foreach (var handler in _eventHandlers)
            {
                var eventHandler = handler as IEventHandler<TEvent>;
                if (eventHandler != null)
                {
                    try
                    {
                        eventHandler.Handle(e);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("event handling error: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void QueueForPostCommit<TEvent>(TEvent e) where TEvent : DomainEvent
        {
            _afterCommitEvents.Enqueue(e);
        }

        public void PublishQueuedPostCommitEvents()
        {
            foreach (var e in _afterCommitEvents)
            {
                Publish(e);
            }
        }
    }
}
