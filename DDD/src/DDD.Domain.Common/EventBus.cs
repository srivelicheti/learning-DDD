using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DDD.Domain.Common
{
    public class EventBus
    {
        private IList<IEventHandler> _eventHandlers = new List<IEventHandler>();
        //private IList<ICommandHandler> _commandHanders = new List<ICommandHandler>();

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IDomainEvent
        {
            _eventHandlers.Add(eventHandler);
        }

        //public void Subscribe<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : ICommand
        //{
        //    _commandHanders.Add(commandHandler);
        //}

        public void Publish<TEvent>(TEvent e) where TEvent : IDomainEvent
        {
            foreach (var handler in _eventHandlers)
            {
                if (handler is IEventHandler<TEvent>)
                {
                    try
                    {
                        ((IEventHandler<TEvent>)handler).Handle(e);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("event handling error: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        //public void Publish<TCommand>(TCommand command) where TCommand : ICommand
        //{
        //    foreach (var handler in _commandHanders)
        //    {
        //        if (handler is IEventHandler<TCommand>)
        //        {
        //            try
        //            {
        //                ((IEventHandler<TCommand>)handler).Handle(command);
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine("event handling error: " + ex.Message);
        //                throw;
        //            }
        //        }
        //    }
        //}
    }
}
