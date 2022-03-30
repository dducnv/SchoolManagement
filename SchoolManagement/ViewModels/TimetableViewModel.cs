using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class TimetableViewModel
    {
        [DisplayName("Open Date")]
        [Required(ErrorMessage = "Please choose Open Date")]
        public string Date { get; set; }
        [DisplayName("Classroom")]
        [Required(ErrorMessage = "Please choose Classroom")]
        public int ClassroomId { get; set; }
        [DisplayName("Courses")]
        [Required(ErrorMessage = "Please choose Courses")]
        public int CoursesId { get; set; }
        [DisplayName("Semester")]
        [Required(ErrorMessage = "Please choose Semester")]
        public int Semester { get; set; }
        [DisplayName("Lecturer")]
        [Required(ErrorMessage = "Please choose Lecturer")]
        public string AccountId { get; set; }
        [DisplayName("Student Group")]
        [Required(ErrorMessage = "Please choose Student Group")]
        public int StudentGroupId { get; set; }
    }
}