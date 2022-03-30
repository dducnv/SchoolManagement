using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System.Linq;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        private MyDBContext myDBContext = new MyDBContext();
        // GET: ClassRoom
        public ActionResult Index()
        {
            ViewData["Classroom"] = myDBContext.classrooms.ToList();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddClassRoom([Bind(Include = "name,description,status")] ClassRoomViewModel clsr)
        {
            if (ModelState.IsValid)
            {
                Classroom clrModel = new Classroom()
                {
                    Name = clsr.name,
                    Status = clsr.status,
                    Description = clsr.description,
                };
                myDBContext.classrooms.Add(clrModel);
                myDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}