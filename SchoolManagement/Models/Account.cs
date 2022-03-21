using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Account : IdentityUser
    {
        public string roll_number { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
    }
}