using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Students_StudentGroup
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int StudentGroupId { get; set; }
        public virtual Account Account { get; set; } // tài khoản nào
        public virtual StudentGroup StudentGroup { get; set; } // lớp nào
    }
}