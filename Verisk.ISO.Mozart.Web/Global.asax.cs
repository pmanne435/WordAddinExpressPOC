using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NServiceBus;

namespace Verisk.ISO.Mozart.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
      //  public static ISendOnlyBus BusObj { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //BusConfiguration busConfiguration = new BusConfiguration();
            //busConfiguration.UseTransport<MsmqTransport>();
            //busConfiguration.UseSerialization<XmlSerializer>();
            //busConfiguration.UsePersistence<InMemoryPersistence>();
            //busConfiguration.EnableInstallers();

            //BusObj = Bus.CreateSendOnly(busConfiguration);
        }
    }
}
