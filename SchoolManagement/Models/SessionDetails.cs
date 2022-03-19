using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class SessionDetails
    {
        public int id { get; set; }
        public int ss_id { get; set; }
        public string date_start { get; set; }
        public int status { get; set; }
    }
}