using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sub_code { get; set; }
        public int CoursesId { get; set; }
        public int Semester { get; set; }
        public int Slot { get; set; }
        public  int Status { get; set; }
        public virtual Courses Courses { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }

    }
}