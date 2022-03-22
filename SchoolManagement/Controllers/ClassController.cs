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
    public class ClassController : Controller
    {
        private MyDBContext myDBContext = new MyDBContext();

        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveClass([Bind(Include = "name,description,class_code")] ClassViewModel cls)
        {
            if (ModelState.IsValid)
            {
                Class classModel = new Class()
                {
                    name = cls.name,
                    class_code = cls.class_code,
                    description = cls.description,
                };
                myDBContext.classes.Add(classModel);  
                myDBContext.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(cls);
        }

    }
}