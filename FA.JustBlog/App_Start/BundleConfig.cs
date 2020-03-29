using System.Web.Optimization;

namespace IdentitySample
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

            ////Theme Clean Blog for font-end
            bundles.Add(new StyleBundle("~/Content/Theme/CleanBlog/css").Include(
                      "~/App_Themes/CleanBlog/vendor/bootstrap/css/bootstrap.min.css",
                      "~/App_Themes/CleanBlog/css/clean-blog.min.css"));

            bundles.Add(new StyleBundle("~/Content/Theme/CleanBlog/font").Include(
                      "~/App_Themes/CleanBlog/vendor/fontawesome-free/css/all.css"));

            bundles.Add(new ScriptBundle("~/Content/Theme/CleanBlog/js").Include(
                "~/App_Themes/CleanBlog/vendor/jquery/jquery.min.js",
              "~/App_Themes/CleanBlog/vendor/bootstrap/js/bootstrap.bundle.js",
              "~/App_Themes/CleanBlog/js/clean-blog.min.js"));

            ////Theme SB-Admin for font-end
            bundles.Add(new StyleBundle("~/Content/Theme/Sb-Admin/font").Include(
            ////Custom fonts for this template
            "~/App_Themes/Sb-Admin/vendor/fontawesome-free/css/all.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Theme/Sb-Admin/css").Include(
                      ////Page level plugin CSS
                      "~/App_Themes/Sb-Admin/vendor/datatables/dataTables.bootstrap4.css",
                      ////Custom styles for this template
                      "~/App_Themes/Sb-Admin/css/sb-admin.css"
                      ));

            bundles.Add(new ScriptBundle("~/Content/Theme/Sb-Admin/js").Include(
                    ////< !--Bootstrap core JavaScript-- >
                    "~/App_Themes/Sb-Admin/vendor/jquery/jquery.min.js",
                    "~/App_Themes/Sb-Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    ////< !--Core plugin JavaScript-- >
                    "~/App_Themes/Sb-Admin/vendor/jquery-easing/jquery.easing.min.js",
                    ////< !--Page level plugin JavaScript-- >
                    
                    "~/App_Themes/Sb-Admin/vendor/datatables/jquery.dataTables.js",
                    "~/App_Themes/Sb-Admin/vendor/datatables/dataTables.bootstrap4.js",
                    ////< !--Custom scripts for all pages-->
                    "~/App_Themes/Sb-Admin/js/sb-admin.min.js",
                    ////< !--Demo scripts for this page-- >
                    "~/App_Themes/Sb-Admin/js/demo/datatables-demo.js"
                      ));

        }
    }
}
