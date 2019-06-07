using System.Web;
using System.Web.Optimization;

namespace Aghsat.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/uikit.js",
                        "~/Scripts/uikit-icons.js",
                        //"~/Scripts/Fulldatatables.min.js",
                        "~/Scripts/Custom-datatables.min.js",

                        "~/Scripts/persianDatePicker.js"


            //"~/Scripts/pwt-date.js",
            //"~/Scripts/pwt-datepicker.js",
            //"~/Scripts/Custom-datatables.min.js"
            //"~/Scripts/jquery.md.bootstrap.datetimepicker.js"


            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/CustomScripts").Include(
                "~/Scripts/CustomScript.js",
                "~/Scripts/CustomShowMessage.js"

            ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/toastr.config.js"
                      //"~/Content/MDB/js/mdb.js"
                      //"~/Content/MDB/js/addons/datatables.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Fulldatatables.min.css",
                      "~/Content/uikit-rtl.css",
                      "~/Content/persianDatePicker-default.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Assets/fontawesome-free-5.6.3/css/all.css",
                      "~/Assets/persian_fonts_override.css",
                      "~/Content/toastr.css"
                      //"~/Content/MDB/css/mdb.css",
                      //"~/Content/MDB/css/style.css"
                      //"~/Content/Custom-datatables.min.css",
                      //"~/Content/css/addons/datatables.css"
                      ));
        }
    }
}
