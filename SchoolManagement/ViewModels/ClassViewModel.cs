using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class ClassViewModel
    {
        [DisplayName("name")]
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }
        [DisplayName("class_code")]
        [Required(ErrorMessage = "Please enter class-code")]
        public string class_code { get; set; }
        [DisplayName("description")]
        [Required(ErrorMessage = "Please enter description")]
        public string description { get; set; }
    }
}