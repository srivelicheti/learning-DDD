﻿//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace DDD.Domain.Common.Event
//{
//    public class DomainEventBus
//    {
//        public static IList<IEventHandler> EventHandlers { get; } = new List<IEventHandler>();
//        private readonly ConcurrentDictionary<DomainEvent,IEventHandler> _postCommitEvents = new ConcurrentDictionary<DomainEvent,IEventHandler>();
//        public static void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : DomainEvent
//        {
//            EventHandlers.Add(eventHandler);
//        }
//        public void Publish<TEvent>(TEvent e) where TEvent : DomainEvent
//        {
            
//            foreach (var handler in EventHandlers)
//            {
//                var eventHandler = handler as IEventHandler<TEvent>;
//                if (eventHandler != null)
//                {
//                    try
//                    {
//                        eventHandler.Handle(e);
//                    }
//                    catch (Exception ex)
//                    {
//                        Debug.WriteLine("event handling error: " + ex.Message);
//                        throw;
//                    }
//                }
//                else if (handler is IEventHandler)
//                {
//                    var genericHandler = handler as IEventHandler;
                    
//                }
//            }
//        }

//        public void QueueForPostCommit<TEvent>(TEvent e) where TEvent : DomainEvent
//        {
//            foreach (var handler in EventHandlers)
//            {
//                var eventHandler = handler as IEventHandler<TEvent>;
//                if (eventHandler != null)
//                {
//                    try
//                    {
//                        _postCommitEvents.TryAdd(e, eventHandler);
//                    }
//                    catch (Exception ex)
//                    {
//                        Debug.WriteLine("event handling error: " + ex.Message);
//                        throw;
//                    }
//                }
                
//            }
//        }

//        public void PublishQueuedPostCommitEvents()
//        {
//            foreach (var e in _postCommitEvents)
//            {
//                try {
//                    //dynamic handler = e.Value;
//                    var handlerType = e.Value.GetType();
//                    var method = handlerType.GetMethod("Handle");
//                    method.Invoke(e.Value, new object[] { e.Key });
//                    //handler.Handle(  );
//                }
//                catch (Exception ex)
//                {
//                    Debug.WriteLine("event handling error: " + ex.Message);
//                    throw;
//                }                
//            }
//        }
//    }
//}
