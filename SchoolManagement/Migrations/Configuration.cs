namespace SchoolManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SchoolManagement.Models;
    using StudentManage.Data;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManage.Data.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManage.Data.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            // Clear data.
            ClearData(context);
            // Reset auto increment.
            ResetAutoIncrement(context);
            // Add role.
            AddRoles(context);
            // Add student.
            AddUsersAsync(context);
            // Add class room.
            AddClassRoom(context);
            // Add student group, class.
            AddStudentGroup(context);
            // Add course.
            AddCourse(context);
            // Add subject.
/*            AddSubject(context);
*/            // Save changes database.
            context.SaveChanges();
        }

        private async Task AddUsersAsync(MyDBContext context)
        {
            var userStore = new UserStore<Account>(context);
            var userManager = new UserManager<Account>(userStore);
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0001",
                roll_number = "AD0001",
                Firstname = "Admin",
                Lastname = "Mr",
                UserName = "admin",
                Email = "amin@admin.com",
                PhoneNumber = "0381234544",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0002",
                roll_number = "th2009055",
                Firstname = "Quang",
                Lastname = "Nguyễn Hồng",
                UserName = "hqth2009055",
                Email = "hqth2009055@fpt.edu.vn",
                PhoneNumber = "0381234555",
                PasswordHash = userManager.PasswordHasher.HashPassword("user")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0003",
                roll_number = "th2008033",
                Firstname = "Quân",
                Lastname = "Trần Duy",
                UserName = "dqth2008033",
                Email = "dqth2008033@fpt.edu.vn",
                PhoneNumber = "0381234566",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0004",
                roll_number = "th2008011",
                Firstname = "Anh",
                Lastname = "Dương Quỳnh",
                UserName = "qath2008011",
                Email = "qath2008011@fpt.edu.vn",
                PhoneNumber = "0381234576",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0006",
                roll_number = "th2008028",
                Firstname = "Hoàng",
                Lastname = "Đinh Việt Hoàng",
                UserName = "vhth2008028",
                Email = "vhth2008028@fpt.edu.vn",
                PhoneNumber = "0381234588",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0007",
                roll_number = "th2008789",
                Firstname = "Đăng",
                Lastname = "Nguyễn Hải",
                UserName = "hdth2008789",
                Email = "hdth2008789@fpt.edu.vn",
                PhoneNumber = "0381234588",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0008",
                roll_number = "th2008781",
                Firstname = "Linh",
                Lastname = "Nguyễn Thị",
                UserName = "nlinhth2008781",
                Email = "nlinhth2008781@fpt.edu.vn",
                PhoneNumber = "0381234577",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0009",
                roll_number = "th200808",
                Firstname = "Đức",
                Lastname = "Nguyễn Văn",
                UserName = "ducnvth200808",
                Email = "ducnvth200808@fpt.edu.vn",
                PhoneNumber = "0381234572",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            context.Users.AddOrUpdate(new Models.Account()
            {
                Id = "U0010",
                roll_number = "th2008043",
                Firstname = "Hoàng",
                Lastname = "Ngô Viết",
                UserName = "vhoangth2008043",
                Email = "vhoangth2008043@fpt.edu.vn",
                PhoneNumber = "0381234552",
                PasswordHash = userManager.PasswordHasher.HashPassword("admin")
            });
            userManager.AddToRole("U0001", "ADMIN");
            userManager.AddToRole("U0002", "STUDENT");
            userManager.AddToRole("U0003", "STUDENT");
            userManager.AddToRole("U0004", "STUDENT");
            userManager.AddToRole("U0005", "STUDENT");
            userManager.AddToRole("U0006", "STUDENT");
            userManager.AddToRole("U0007", "STUDENT");
            userManager.AddToRole("U0008", "STUDENT");
            userManager.AddToRole("U0009", "STUDENT");
            userManager.AddToRole("U0010", "STUDENT");
        }

        private void AddRoles(MyDBContext context)
        {
            context.Roles.AddOrUpdate(new Models.Role()
            {
                Id = "R00001",
                Name = "TEACHER"
            });
            context.Roles.AddOrUpdate(new Models.Role()
            {
                Id = "R00002",
                Name = "STUDENT"
            });
            context.Roles.AddOrUpdate(new Models.Role()
            {
                Id = "R00003",
                Name = "ADMIN"
            });
            context.Roles.AddOrUpdate(new Models.Role()
            {
                Id = "R00004",
                Name = "EMPLOYEE"
            });
        }

        private void AddCourse(MyDBContext context)
        {
            context.courses.AddOrUpdate(new Models.Courses()
            {
                Id = 1,
                Name = "Design Website",
                Course_code = "DWB",
            });
            context.courses.AddOrUpdate(new Models.Courses()
            {
                Id = 2,
                Name = "Design Database Basic",
                Course_code = "DDB",
            });
            context.courses.AddOrUpdate(new Models.Courses()
            {
                Id = 3,
                Name = "Java Programming and Software Engineering Fundamentals Specialization",
                Course_code = "JPSEFS",
            });
            context.courses.AddOrUpdate(new Models.Courses()
            {
                Id = 4,
                Name = "Introduction to Programming with Python and Java Specialization",
                Course_code = "ITPWPAJS",
            });
        }

        private void AddStudentGroup(MyDBContext context)
        {
            context.studentGroups.AddOrUpdate(new Models.StudentGroup()
            {
                Id = 1,
                ClassName = "T2009M",
                Session = "MORNING",
                Shift = "MWF",
                OpeningDate = "2020-09-18",
                CoursesId = 1,
            });
            context.studentGroups.AddOrUpdate(new Models.StudentGroup()
            {
                Id = 2,
                ClassName = "T2008M",
                Session = "AFTERNOON",
                Shift = "TTS",
                OpeningDate = "2020-06-16",
                CoursesId = 2,
            });
            context.studentGroups.AddOrUpdate(new Models.StudentGroup()
            {
                Id = 3,
                ClassName = "T1911E",
                Session = "NIGHT",
                Shift = "TTS",
                OpeningDate = "2020-03-16",
                CoursesId = 1,
            });
            context.studentGroups.AddOrUpdate(new Models.StudentGroup()
            {
                Id = 4,
                ClassName = "T2203M",
                Session = "MORNING",
                Shift = "MWF",
                OpeningDate = "2022-09-18",
                CoursesId = 2,
            });
        }

        private void ClearData(MyDBContext context)
        {
            context.Attendances.Clear();
            context.courses.Clear();
            context.subjects.Clear();
            context.Timetables.Clear();
            context.Students_StudentGroups.Clear();
            context.studentGroups.Clear();
            context.classrooms.Clear();
            // Clear users.
            var users = context.Users.ToList();
            foreach (var item in users)
            {
                context.Users.Remove(item);
            }
            // Clear roles.
            var roles = context.Roles.ToList();
            foreach (var item in roles)
            {
                context.Roles.Remove(item);
            }
            Debug.WriteLine(roles.Count);
            context.SaveChanges();
        }

        private void ResetAutoIncrement(MyDBContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Classrooms', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Timetables', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Subjects', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Students_StudentGroup', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.StudentGroups', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Courses', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Attendances', RESEED, 0);");
        }

        private void AddClassRoom(MyDBContext context)
        {
            // add classroom
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 1,
                Name = "B5",
                Description = "Đối diện thư viện",
                Status = 1
            });
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 2,
                Name = "B2",
                Description = "Phòng Kính",
                Status = 1
            });
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 3,
                Name = "B4",
                Description = "Chung điều hoà B2",
                Status = 1
            });
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 4,
                Name = "A8",
                Description = "Wifi mạnh",
                Status = 1
            });
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 5,
                Name = "A6",
                Description = "Cạnh phòng giáo viên",
                Status = 1
            });
            context.classrooms.AddOrUpdate(new Models.Classroom()
            {
                Id = 5,
                Name = "B9",
                Description = "Hội trường",
                Status = 1
            });
        }
        private void AddSubject(MyDBContext context)
        {
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 1,
                Name = "Learn HTML&CSS by example",
                CoursesId = 1,
                Semester = 1,
                Sub_code = "LWD",
                Slot = 10,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 2,
                Name = "Learn Javascrip",
                CoursesId = 1,
                Semester = 1,
                Sub_code = "LJS",
                Slot = 10,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 3,
                Name = "Learn ReactJS",
                CoursesId = 1,
                Semester = 2,
                Sub_code = "LRJS",
                Slot = 10,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 4,
                Name = "Learn Angular",
                CoursesId = 1,
                Semester = 3,
                Sub_code = "LAJS",
                Slot = 12,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 5,
                Name = "Spring Boot",
                CoursesId = 1,
                Semester = 4,
                Sub_code = "SBJAVA",
                Slot = 12,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 6,
                Name = "Basic Commands SQL",
                CoursesId = 2,
                Semester = 1,
                Sub_code = "BCD",
                Slot = 5,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 7,
                Name = "Basic Relationships SQL",
                CoursesId = 2,
                Semester = 2,
                Sub_code = "BRD",
                Slot = 8,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 8,
                Name = "Design Database with SQL Server Management Studio",
                CoursesId = 2,
                Semester = 3,
                Sub_code = "DD",
                Slot = 8,
                Status = 1
            });
            context.subjects.AddOrUpdate(new Models.Subject()
            {
                Id = 9,
                Name = "Microservice",
                CoursesId = 2,
                Semester = 4,
                Sub_code = "MS",
                Slot = 10,
                Status = 1
            });
        }
    }
    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
