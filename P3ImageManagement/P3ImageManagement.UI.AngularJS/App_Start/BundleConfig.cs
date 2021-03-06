﻿using System.Web;
using System.Web.Optimization;

namespace P3ImageManagement.UI.AngularJS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/app/app.module.js",
                      "~/app/controllers/area-controller.js",
                      "~/app/controllers/render-form-controller.js",
                      //"~/app/controllers/public-area.js",
                      "~/app/controllers/category-controller.js",
                      "~/app/controllers/sub-category-controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
