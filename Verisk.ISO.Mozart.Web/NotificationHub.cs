using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Verisk.ISO.Mozart.Web
{
    [HubName("NotificationHub")]
    public class NotificationHub : Hub
    {
        public void SendNotification()
        {

        }
    }
}