using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        private MyDBContext myDBContext = new MyDBContext();
        // GET: ClassRoom
        public ActionResult AddClassRoom()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddClassRoom([Bind(Include = "name,description,status")] ClassRoomViewModel clsr)
        {
            if (ModelState.IsValid)
            {
                Classroom classModel = new Classroom()
                {
                    name = clsr.name,
                    status = clsr.status,
                    description = clsr.description,
                };
                myDBContext.Classrooms.Add(classModel);
                myDBContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}