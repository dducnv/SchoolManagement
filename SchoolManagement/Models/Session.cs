using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Session
    {
        public int id { get; set; }
        public int id_clr { get; set; }
        public int id_cls { get; set; }
        public int id_sub { get; set; }
        public int teacher { get; set; }
        public int mumber_session { get; set; }
        public string lst_student { get; set; }
        public string time_start { get; set; }
        public string time_finish { get; set; }
        public string time_begin { get; set; }
    }
}