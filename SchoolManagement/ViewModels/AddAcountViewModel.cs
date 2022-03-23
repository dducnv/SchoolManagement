using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViewModels
{
    public class AddAcountViewModel
    {
        [DisplayName("Firstname")]
        [Required(ErrorMessage = "Please enter firstname")]
        public string firstname { get; set; }
        [DisplayName("Firstname")]
        [Required(ErrorMessage = "Please enter firstname")]
        public string lastname { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string password { get; set; }
        [DisplayName("Roll-Number")]
        [Required(ErrorMessage = "Please enter Roll-Number")]
        public string roll_number { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please choose gender")]
        public string gender { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email invailid.")]
        public string email { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Phone Number invailid.")]
        public string phoneNumber { get; set; }
        [DisplayName("Birthday")]
        [Required(ErrorMessage = "Please enter birthday")]
        public string birthday { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Please choose role")]
        public string Roles { get; set; }
    }
}