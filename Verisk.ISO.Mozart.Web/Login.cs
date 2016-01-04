using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;

namespace Verisk.ISO.Mozart.Web
{
    [TimeToBeReceived("00:00:60")]
    public class Login: IMessage
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }


    }
}