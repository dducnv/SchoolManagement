using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StudentGroup
    {

        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Session { get; set; }
        public int CoursesId { get; set; }
        public string Shift { get; set; } // thứ ngày tháng, ví dụ: MWF, TTS
        public string OpeningDate { get; set; }
        public virtual Courses Courses { get; set; }
        public virtual ICollection<Students_StudentGroup> Students_StudentGroups { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }


    }
}