﻿using System.Web;
using System.Web.Optimization;

namespace SchoolManagement
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

            bundles.Add(new Bundle("~/bundles/scripts").Include(
                  "~/Scripts/popper.min.js",
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/jquery.dataTables.min.js",
                  "~/Scripts/app.js",
                  "~/Scripts/dataTable.js"));

            bundles.Add(new Bundle("~/bundles/datatable").Include(
                 

                "~/Scripts/jquery.dataTables.min.js"
                ));
            bundles.Add(new Bundle("~/bundles/fullcalendar").Include(
                "~/Scripts/popper.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/moment/js/moment.js",
                "~/Scripts/fullcalendar/js/fullcalendar.js"
                ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/ionicons/css/ionicons.css",
                      "~/Content/all.min.css",
                       "~/Content/jquery.dataTables.css",
                       "~/Content/fullcalendar/css/fullcalendar.css",
                      "~/Content/app.css"
                    ));
        }
    }
}
