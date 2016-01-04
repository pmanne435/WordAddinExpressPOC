using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Verisk.ISO.Mozart.Web.Models;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;


namespace Verisk.ISO.Mozart.Web.Controllers
{
	public class LoginController : ApiController
	{
       // public ISendOnlyBus Bus { get; set; }
		// GET: api/Login
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Login/5
		public string Get(int id)
		{
            Login loginObj = new Login() { UserName = "sudheer", Password = "alliance" };
            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("Verisk.Mozart.Backend");
            busConfiguration.UseSerialization<XmlSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            
            using (IBus busObj = Bus.Create(busConfiguration).Start())
            {
                    busObj.Send(loginObj);
            }

            return "User Authenticated....";
        }


        [HttpGet]
        public string UserValidate(string userName)
        {
            Login loginObj = new Login() { UserName = userName, Password = "alliance" };
           // Bus.Send(loginObj);
            return "User Authenticated....";
        }

		// POST: api/Login
		public bool Post(User user)
		{
			//TODO: Need to remove below temp logic and credentials have to be validated against persistent database.
			if(user.UserName.ToLower() == "alliance" && user.Password.ToLower() == "alliance")
			{
				return true;
			}
			return false;
		}

		// PUT: api/Login/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Login/5
		public void Delete(int id)
		{
		}
	}

    class ConfigErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }
}
