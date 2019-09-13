using Fakebook.PresentationLayer.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Fakebook.PresentationLayer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
