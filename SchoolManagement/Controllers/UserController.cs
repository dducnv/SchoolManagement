using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class UserController : Controller
    {
        private MyDBContext db = new MyDBContext();
        public ActionResult Student()
        {
            var roleResult = db.Roles.Where(x => x.Name == "STUDENT").FirstOrDefault();
            var result = db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList();
            return View(result);
        }
        public ActionResult Teacher()
        {
            var roleResult = db.Roles.Where(x => x.Name == "TEACHER").FirstOrDefault();
            var result = db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList();
            return View(result);
        }
        public ActionResult Employee()
        {
            var roleResult = db.Roles.Where(x => x.Name == "EMPLOYEE").FirstOrDefault();
            var result = db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList();
            return View(result);
        }
        public ActionResult Admin()
        {
            var roleResult = db.Roles.Where(x => x.Name == "ADMIN").FirstOrDefault();
            var result = db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList();
            return View(result);
        }
    }
}