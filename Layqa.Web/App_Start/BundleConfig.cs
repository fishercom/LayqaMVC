using System.Web.Optimization;

namespace Layqa.Web
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

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/cbpAnimatedHeader.js",
                      "~/Scripts/jqBootstrapValidation.js",
                      "~/Scripts/agency.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/agency.css",
                      "~/Content/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/admin/css").Include(
                    "~/Content/admin/bootstrap.css",
                    "~/Content/admin/sb-admin.css",
                    "~/Content/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.js",
                    "~/Scripts/jquery.validate.unobtrusive.js",
                    "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/css/morris").Include(
                    "~/Content/plugins/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/morris").Include(
                    "~/Scripts/plugins/morris/raphael.min.js",
                    "~/Scripts/plugins/morris/morris.min.js",
                    "~/Scripts/plugins/morris/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                    "~/Scripts/plugins/ckeditor/ckeditor.js"));
        }

    }
}
