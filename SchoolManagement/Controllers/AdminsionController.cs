using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class AdminsionController : Controller
    {
        // GET: Adminsion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddAccount()
        {
            return View();
        }
        public ActionResult ImportFile()
        {
            return View();
        }
    }
}