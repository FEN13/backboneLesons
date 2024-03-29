﻿using System.Web;
using System.Web.Optimization;

namespace BacboneExample
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/extLibs").Include(
                       "~/Scripts/backbone.js", 
                       "~/Scripts/underscore.js",
                       "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/app/app.js",
                      "~/app/router.js",
                      "~/app/models/todo.js",
                      "~/app/models/todos.js",
                      "~/app/views/app-view.js", 
                      "~/app/views/todo-view.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/jquery.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css", "~/Content/font-awesome.css")
                .Include("~/Content/site.css"));
        }
    }
}