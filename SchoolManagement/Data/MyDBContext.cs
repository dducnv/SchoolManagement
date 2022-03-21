using Microsoft.AspNet.Identity.EntityFramework;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManage.Data
{
    public class MyDBContext : IdentityDbContext<Account>
    {
        public MyDBContext():base("name=SchoolManageDB")
        {

        }
        public DbSet<Class> classes { get; set; }
    }
}