using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentGroupController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: StudentGroup
        public ActionResult Index()
        {
            var roleResult = db.Roles.Where(x => x.Name == "STUDENT").FirstOrDefault();
            ViewBag.Courses = new SelectList(db.courses.ToList(), "id", "course_code");
            ViewData["StudentGroup"] = db.studentGroups.ToList();
            ViewData["Student"] = db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList();
            ViewData["StudentChecked"] = db.Students_StudentGroups.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveStudentGroup([Bind(Include = "ClassName,Courses_id,Session,Shift,OpeningDate")] StudentGroupViewModel studentGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                StudentGroup studentGroup = new StudentGroup()
                {
                    ClassName = studentGroupViewModel.ClassName,
                    CoursesId = studentGroupViewModel.Courses_id,
                    Session = studentGroupViewModel.Session,
                    Shift = studentGroupViewModel.Shift,
                    OpeningDate = studentGroupViewModel.OpeningDate
                 };
         
                db.studentGroups.Add(studentGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(db.courses.ToList(), "id", "course_code");
            ViewData["StudentGroup"] = db.studentGroups.ToList();
            return View("Index");
        }
        [HttpPost]
        public ActionResult AddStudent(string []student,int studentgr_id)
        {
            var studentInGr = db.Students_StudentGroups.Where(m => m.StudentGroupId == studentgr_id).ToList();
            foreach (var item in studentInGr)
            {
                if(item.StudentGroupId == studentgr_id)
                {
                    db.Students_StudentGroups.Remove(item);
                    db.SaveChanges();
                }
            }
            foreach (var item in student)
            {
                Debug.WriteLine(item);
                Students_StudentGroup students_StudentGroup = new Students_StudentGroup()
                {
                    AccountId = item,
                    StudentGroupId = studentgr_id
                };
                db.Students_StudentGroups.Add(students_StudentGroup);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}