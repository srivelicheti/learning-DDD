using DDD.Domain.Common.Event;
using DDD.Provider.Domain.Events;
using DDD.Web.Api.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Web.Api.EventHandlers
{
    public class ContractorAddedEventHandler : IHandleMessages<NewContractorAdded>
    {
        private IConnectionManager _connectionManager;

        public ContractorAddedEventHandler(IConnectionManager connectionManager) {
            _connectionManager = connectionManager;
        }
        public void Handle(NewContractorAdded e)
        {
            Task.Factory.StartNew((() => {
                //Simulate some delay
                Thread.Sleep(5000);
                var hub = _connectionManager.GetHubContext<NotificationsHub>();
                hub.Clients.All.messageReceived($"New Contractor Added with {e.ContractorEin} at {e.EventDateTime}");
            }));
           
        }
    }
}
