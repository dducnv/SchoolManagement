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

        public MyDBContext():base("SchoolManageDB")
        {

        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Classroom> classrooms { get; set; }
        public DbSet<StudentGroup> studentGroups { get; set; }
        public DbSet<Students_StudentGroup> Students_StudentGroups { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}