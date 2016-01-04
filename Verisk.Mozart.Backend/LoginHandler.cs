using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Verisk.ISO.Mozart.Web;

namespace Verisk.Mozart.Backend
{
    public class LoginHandler : IHandleMessages<Login>
    {
        public void Handle(Login message)
        {
            Console.WriteLine("Login Request Received: " + message.UserName);
        }
    }
}
