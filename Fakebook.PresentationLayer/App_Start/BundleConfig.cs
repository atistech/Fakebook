using System.Web.Optimization;

namespace Fakebook.PresentationLayer.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/style.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/jquery-3.4.1.min.js",
                     "~/Scripts/bootstrap.min.js"));
        }
    }
}