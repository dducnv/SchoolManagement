using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Teacher()
        {
            return View();
        }
        public ActionResult Parent()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }
    }
}