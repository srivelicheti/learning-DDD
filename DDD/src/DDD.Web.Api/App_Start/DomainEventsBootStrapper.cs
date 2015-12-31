using DDD.Domain.Common.Event;
using DDD.Provider.Domain.Events;
using DDD.Web.Api.EventHandlers;
using Microsoft.AspNet.SignalR.Infrastructure;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public class DomainEventsBootStrapper
    {
        public static void RegisterEvents(Container container)
        {
            var connManager = container.GetInstance<IConnectionManager>();
            var bus = container.GetInstance<EventBus>();
            bus.Subscribe<NewContractorAdded>(new ContractorAddedEventHandler(connManager));
            //bus.Subscribe<>
        }
    }
}
