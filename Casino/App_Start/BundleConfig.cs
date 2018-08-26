using System.Web;
using System.Web.Optimization;

namespace Casino
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));


            bundles.Add(new ScriptBundle("~/Script/js").Include(
                      "~/Scripts/jquery-1.10.2.min.js",
                      "~/Scripts/Chart.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/dataTables.bootstrap4.js",
                      "~/Scripts/sb-admin.js",
                      "~/Scripts/sb-admin-datatables.js",
                      "~/Scripts/sb-admin-charts.js",
                      "~/Scripts/Newsletter/Newsletter.js",
                      "~/Scripts/jquery.validate*",
                       "~/Scripts/modernizr-*"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/dataTables.bootstrap4.css",
                      "~/css/font-awesome.min.css",
                      "~/css/sb-admin.css"
                      ));
        }
    }
}
