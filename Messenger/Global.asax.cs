using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Messenger.BLL.MapperConfig;

namespace Messenger
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperServiceConfiguration.Configure();

            //TODO: delete this in the future
            using (DAL.Context.MessengerContext db = new DAL.Context.MessengerContext())
            {
                db.Database.Initialize(false);
                db.SaveChanges();
            }
        }
    }
}
