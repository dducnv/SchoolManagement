using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManageASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Teacher()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult LoginPort()
        {
            return View();
        }
    }
}