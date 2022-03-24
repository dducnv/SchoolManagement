using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class ClassRoomViewModel
    {
        [DisplayName("name")]
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }
        
        [DisplayName("description")]
        [Required(ErrorMessage = "Please enter description")]
        public string description { get; set; }
        
        [DisplayName("status")]
        [Required(ErrorMessage = "Please enter status")]
        public int status { get; set; }
    }
}