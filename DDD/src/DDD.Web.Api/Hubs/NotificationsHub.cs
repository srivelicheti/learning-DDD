using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
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
