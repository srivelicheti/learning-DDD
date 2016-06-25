using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.Hubs
{
    [HubName("notifications")]
    public class NotificationsHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.messageReceived(message);
        }
    }
}
