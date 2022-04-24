using ExcelDataReader;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class CoursesController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Courses
        public ActionResult Index()
        {
            ViewBag.CoursesSelect = new SelectList(db.courses.ToList(), "id", "course_code");
            ViewData["Subject"] = db.subjects.ToList();
            ViewData["Courses"] = db.courses.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "name,course_code")] CoursesViewModel courseReq)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Courses courses = new Courses()
                    {
                        Name = courseReq.name,
                        Course_code = courseReq.course_code
                    };
                    db.courses.Add(courses);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Courses");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
               
            } 
            return View(courseReq);
        }

        public ActionResult Subject()
        {
            ViewData["Course"] = db.courses.ToList();
            ViewData["Subject"] = db.subjects.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSubject([Bind(Include = "name,sub_code,Courses_id,semester,slot,status")] SubjectViewModel subjectReq)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject()
                { 
                    Name = subjectReq.name,
                    Sub_code = subjectReq.sub_code,
                    CoursesId = subjectReq.Courses_id,
                    Semester = subjectReq.semester,
                    Slot = subjectReq.slot,
                    Status = subjectReq.status
                
                };
                db.subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Subject", "Courses");
            }
            return View(subjectReq);
        }
        [HttpPost]
        public ActionResult SubjectImport(Subject subject,HttpPostedFileBase subjectfile)
        {
            if (subjectfile != null)
            {
                if (subjectfile.ContentType == "application/vnd.ms-excel" || subjectfile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = subjectfile.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    subjectfile.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
                    {
                        using (var stream = System.IO.File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
                        {

                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                do
                                {
                                    while (reader.Read())
                                    {
                                       if(reader.GetValue(0).ToString() != "Name")
                                        {
                                            var courses_code = reader.GetValue(2).ToString();
                                            var courses = db.courses.FirstOrDefault(cs => cs.Course_code == courses_code);
                                            Subject subjectModel = new Subject()
                                            {
                                                Name = reader.GetValue(0).ToString(),
                                                Sub_code = reader.GetValue(1).ToString(),
                                                CoursesId = courses.Id,
                                                Semester = int.Parse(reader.GetValue(3).ToString()),
                                                Slot = int.Parse(reader.GetValue(4).ToString()),
                                                Status = int.Parse(reader.GetValue(5).ToString())
                                            };
                                            db.subjects.Add(subjectModel);
                                            db.SaveChanges();
                                        }
                                    }
                                    
                                } while (reader.NextResult());
                            }

                        }
                    }
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return RedirectToAction("Index", "Courses");
                }
            }
            return RedirectToAction("Subject", "Courses");
        }
    }
}