using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        // GET: ClassRoom
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddClassRoom()
        {
            return View();
        }
    }
}