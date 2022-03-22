using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Class
    {
        public int id { get; set; }
        public string  class_code { get; set; }
        public string  name { get; set; }
        public string description { get; set; }
    }
}