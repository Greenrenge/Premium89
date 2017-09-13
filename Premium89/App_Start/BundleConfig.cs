using System.Web;
using System.Web.Optimization;

namespace Premium89
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));




            bundles.Add(new ScriptBundle("~/Premium89/Scripts").Include(
                      "~/Scripts/assets/plugins/js/meanmenu.js",
                      "~/Scripts/assets/plugins/js/jquery.ajaxchimp.min.js",
                      "~/Scripts/assets/plugins/js/wow.min.js",
                      "~/Scripts/assets/plugins/js/owl.carousel.js",
                      "~/Scripts/assets/plugins/js/jquery.flexslider-min.js",
                      "~/Scripts/assets/plugins/js/bootstrap-dropdownhover.min.js",
                      "~/Scripts/assets/plugins/js/jquery-ui.min.js",
                      "~/Scripts/assets/plugins/js/validator.min.js",
                      "~/Scripts/assets/plugins/js/smooth-scroll.js",
                      "~/Scripts/assets/plugins/js/jquery.fancybox.min.js",
                      "~/Scripts/assets/plugins/js/standalone/selectize.js",
                      "~/Scripts/assets/js/init.js"
                      ));

            bundles.Add(new ScriptBundle("~/Premium89/jquery").Include(
                    "~/Scripts/assets/plugins/js/jquery-1.11.3.min.js"));
            bundles.Add(new StyleBundle("~/Premium89/CSS").Include(
                      "~/Scripts/assets/icons/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Scripts/assets/fonts/flaticon.css",
                      "~/Scripts/assets/plugins/css/bootstrap.min.css",
                      "~/Scripts/assets/plugins/css/jquery.fancybox.min.css",
                      "~/Scripts/assets/plugins/css/animate.css",
                      "~/Scripts/assets/plugins/css/owl.css",
                      "~/Scripts/assets/plugins/css/flexslider.min.css",
                      "~/Scripts/assets/plugins/css/selectize.css",
                      "~/Scripts/assets/plugins/css//selectize.bootstrap3.css",
                      "~/Scripts/assets/plugins/css/jquery-ui.min.css",
                      "~/Scripts/assets/plugins/css/bootstrap-dropdownhover.min.css",
                      "~/Scripts/assets/plugins/css/meanmenu.css",
                      "~/Scripts/assets/css/style.css",
                      "~/Scripts/assets/css/responsive.css"
                      ));

        }
    }
}
