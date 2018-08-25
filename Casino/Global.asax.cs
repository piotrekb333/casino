using Casino.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Casino
{
    public class MvcApplication : Umbraco.Web.UmbracoApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterServices();
        }
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            AutofacConfig.RegisterServices();
            base.OnApplicationStarted(sender, e);
        }
    }
}
