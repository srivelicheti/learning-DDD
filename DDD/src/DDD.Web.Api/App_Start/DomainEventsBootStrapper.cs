using DDD.Domain.Common.Event;
using DDD.Provider.Domain.Events;
using DDD.Web.Api.EventHandlers;
using Microsoft.AspNet.SignalR.Infrastructure;
using StructureMap;

namespace DDD.Web.Api
{
    public class DomainEventsBootStrapper
    {
        public static void RegisterEvents(Container container)
        {
            var connManager = container.GetInstance<IConnectionManager>();
            //var bus = container.GetInstance<DomainEventBus>();
            DomainEventBus.Subscribe<NewContractorAdded>(new ContractorAddedEventHandler(connManager));
            //DomainEventBus.Subscribe(new );
        }
    }
}
