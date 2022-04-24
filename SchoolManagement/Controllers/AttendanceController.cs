using SchoolManagement.Models;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Attendance
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var attendant = db.Timetables.Find(id);
            if (attendant == null)
            {
                return HttpNotFound();
            }
            ViewData["Student"] = db.Students_StudentGroups.Where(st => st.StudentGroupId == attendant.StudentGroupId).ToList();
            return View(attendant);
        }
        public ActionResult SaveAttendance(string[] studentAttend, int Id, string[] Note)
        {
            var attendanceComp = db.Attendances.Where(m => m.TimetableId == Id).ToList();
            if(attendanceComp != null)
            {
                foreach(var item in attendanceComp)
                {
                    db.Attendances.Remove(item);
                }
            }
            var attendant = db.Timetables.Find(Id);
            var studentInSlot = db.Students_StudentGroups.Where(st => st.StudentGroupId == attendant.StudentGroupId).ToList();
            
            foreach (var st in studentInSlot)
            {
                var isAttend = false;
                foreach (var item in studentAttend)
                {
                    if (item == st.AccountId) {
                        isAttend = true;
                    }
                }
                if (isAttend == true)
                {
                    Attendance attendance = new Attendance()
                    {
                        TimetableId = Id,
                        AccountId = st.AccountId,
                        Attend = 1,
                        Note = null
                    };
                    db.Attendances.Add(attendance);
                }
                else
                {
                    Attendance attendance = new Attendance()
                    {
                        TimetableId = Id,
                        AccountId = st.AccountId,
                        Attend = 2,
                        Note = null
                    };
                    db.Attendances.Add(attendance);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Teacher","Dashboard");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var attendant = db.Timetables.Find(id);
            ViewData["Attendance"] = db.Attendances.Where(m => m.TimetableId == id).ToList();
            if (attendant == null)
            {
                return HttpNotFound();
            }
            return View(attendant);
        }
    }
}