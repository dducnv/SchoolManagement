using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Teacher()
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            var dateNow = DateTime.Now;
            ViewBag.WeekNumber = cul.Calendar.GetWeekOfYear(new DateTime(int.Parse(dateNow.ToString("yyyy")), int.Parse(dateNow.ToString("MM")), int.Parse(dateNow.ToString("dd"))), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            ViewData["Attendance"] = db.Timetables.ToList();
            ViewData["Complete"] = db.Attendances.ToList();
            return View();
        }
        public ActionResult Parent()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }
    }
}