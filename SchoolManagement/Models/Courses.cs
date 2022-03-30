using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course_code { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
    }
}