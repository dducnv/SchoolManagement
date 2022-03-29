using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class CoursesViewModel
    {
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Please enter Course Name")]
        public string name { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Please enter Course Name")]
        public string course_code { get; set; }
    }
}