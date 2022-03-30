using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Account : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string roll_number { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public virtual ICollection<Students_StudentGroup> Students_StudentGroups { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}