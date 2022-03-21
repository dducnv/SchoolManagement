using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string password { get; set; }
    }
}