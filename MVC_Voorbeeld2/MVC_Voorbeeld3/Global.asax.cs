using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_Voorbeeld3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            

            //standaard
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //modelbinder DecimalModelBinder.CS
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            //App_GlobalResources  Messages.resx
            DefaultModelBinder.ResourceClassKey = "Messages";


            //aantal bezoekers sinds de website online is
            Application.Lock();
            Application.Add("aantalBezoeken", 0);
            Application.UnLock();
        }

        protected void Session_Start()
        {
            Session["aantalBezoeken"] = 0;
        }
        
    }
}
