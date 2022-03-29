using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }

    }
}