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
    public class TimetableController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: TimeTable
        public ActionResult Index()
        {
            var roleResult = db.Roles.Where(x => x.Name == "TEACHER").FirstOrDefault();
            ViewBag.Classroom = new SelectList(db.classrooms.ToList(), "Id", "Name");
            ViewBag.Courses = new SelectList(db.courses.ToList(), "id", "course_code");
            ViewBag.StudentGroup = new SelectList(db.studentGroups.ToList(), "Id", "ClassName");
            ViewBag.Lecturer = new SelectList(db.Users.Where(x => x.Roles.Any(role => role.RoleId == roleResult.Id)).ToList(), "Id", "Firstname");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTimetable([Bind(Include = "ClassroomId,CoursesId,AccountId,StudentGroupId,Semester,Date")] TimetableViewModel timetableViewModel)
        {
            var subject = db.subjects.Where(s => s.CoursesId == timetableViewModel.CoursesId && s.Semester == timetableViewModel.Semester).ToList();
            var studentGroup = db.studentGroups.Where(st => st.CoursesId == timetableViewModel.CoursesId && st.Id == timetableViewModel.StudentGroupId).FirstOrDefault();
            DateTime startDate = Convert.ToDateTime(timetableViewModel.Date);
            
            var shift = studentGroup.Shift;
            var session = "";
            if(studentGroup.Session == "MORNING")
            {
                session = "08:00 - 12:00";
            }else if( studentGroup.Session == "AFTERNOON")
            {
                session = "13:30 - 17:30";
            }else if(studentGroup.Session == "NIGHT")
            {
                session = "18:00 - 22:00";
            }
            var slot = 0;
            var i = 0;
            foreach (var sub in subject)
            {
                Debug.WriteLine(sub.Sub_code);

                slot =  sub.Slot;
                var subCode = sub.Sub_code;
                i = 0;
                while (i < slot)
                {
                    Debug.WriteLine(sub.Sub_code);
                    if (shift == "MWF")
                    {
                        if (startDate.ToString("ddd") == "Mon" || startDate.ToString("ddd") == "Wed" || startDate.ToString("ddd") == "Fri")
                        {

                            Debug.WriteLine(startDate.ToString("ddd dd-MM-yyyy"));
                            Timetable timetable = new Timetable
                            {
                                Name = sub.Sub_code,
                                Duration = session,
                                Semester = timetableViewModel.Semester,
                                Date = startDate.ToString("ddd dd-MM-yyyy"),
                                ClassroomId = timetableViewModel.ClassroomId,
                                SubjectId = sub.Id,
                                AccountId = timetableViewModel.AccountId,
                                StudentGroupId = timetableViewModel.StudentGroupId
                            };
                            db.Timetables.Add(timetable);
                            i++;
                        }
                        startDate = startDate.AddDays(1);
                    }
                    else if (shift == "TTS")
                    {
                        if (startDate.ToString("ddd") == "Tue" || startDate.ToString("ddd") == "Thu" || startDate.ToString("ddd") == "Sat")
                        {
                            Timetable timetable = new Timetable
                            {
                                Name = sub.Sub_code,
                                Duration = session,
                                Semester = timetableViewModel.Semester,
                                Date = startDate.ToString("ddd dd-MM-yyyy"),
                                ClassroomId = timetableViewModel.ClassroomId,
                                SubjectId = sub.Id,
                                AccountId = timetableViewModel.AccountId,
                                StudentGroupId = timetableViewModel.StudentGroupId
                            };
                            db.Timetables.Add(timetable);

                            i++;
                        }
                        startDate = startDate.AddDays(1);
                    }
                   

                }
                db.SaveChanges();
            }
            
            
            return RedirectToAction("Index");
        }
        
    }
}