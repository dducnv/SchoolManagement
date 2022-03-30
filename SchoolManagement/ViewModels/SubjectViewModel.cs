using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class SubjectViewModel
    {
        [DisplayName("Subject Name")]
        [Required(ErrorMessage = "Please enter subject name")]
        public string name { get; set; }
        [DisplayName("Subject Code")]
        [Required(ErrorMessage = "Please enter subject code")]
        public string sub_code { get; set; }
        [DisplayName("Course")]
        [Required(ErrorMessage = "Please choose course")]
        public int Courses_id { get; set; }
        [DisplayName("Semester")]
        [Required(ErrorMessage = "Please choose semester")]
        public int semester { get; set; }
        [DisplayName("Slot")]
        [Required(ErrorMessage = "Please enter slot")]
        public int slot { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Please choose status")]
        public int status { get; set; }
    }
}