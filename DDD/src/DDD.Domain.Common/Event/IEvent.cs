using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Event
{
    public interface IDomainEvent
    {
        Guid ID { get; }
    }

    public interface IEventHandler
    { }

    public interface IEventHandler<TEvent> : IEventHandler where TEvent: IDomainEvent
    {
        void Handle(TEvent e);
    }
}
