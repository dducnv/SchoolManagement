using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Semester { get; set; }
        public string Date { get; set; }
        public int ClassroomId { get; set; }
        public int SubjectId { get; set; }
        public string AccountId { get; set; }
        public int StudentGroupId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Account Account { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}