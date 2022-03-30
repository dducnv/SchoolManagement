using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class StudentGroupViewModel
    {
        [DisplayName("ClassName")]
        [Required(ErrorMessage = "Please enter ClassName")]
        public string ClassName { get; set; }
        [DisplayName("Courses")]
        [Required(ErrorMessage = "Please enter Courses")]
        public int Courses_id { get; set; }
        [DisplayName("Session")]
        [Required(ErrorMessage = "Please enter Session")]
        public string Session { get; set; }
        [DisplayName("Shift")]
        [Required(ErrorMessage = "Please enter Shift")]
        public string Shift { get; set; }
        [DisplayName("OpeningDate")]
        [Required(ErrorMessage = "Please enter OpeningDate")]
        public string OpeningDate { get; set; }
    }
}