using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int TimetableId { get; set; }
        public string AccountId  { get; set; }
        public int Attend { get; set; }
        public string Note { get; set; }
        public virtual Timetable Timetable { get; set; }
        public virtual Account Account { get; set; }
    }
}