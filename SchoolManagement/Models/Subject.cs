using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public  string sub_code { get; set; }
        public  string courses_id { get; set; }
        public  string semester { get; set; }
        public  string description { get; set; }
        public  int status { get; set; }
    }
}