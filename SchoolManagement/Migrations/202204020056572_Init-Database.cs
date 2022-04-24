namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimetableId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        Attend = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Timetables", t => t.TimetableId, cascadeDelete: true)
                .Index(t => t.TimetableId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        roll_number = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Birthday = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Students_StudentGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.String(maxLength: 128),
                        StudentGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.StudentGroupId);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Session = c.String(),
                        CoursesId = c.Int(nullable: false),
                        Shift = c.String(),
                        OpeningDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CoursesId, cascadeDelete: true)
                .Index(t => t.CoursesId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sub_code = c.String(),
                        CoursesId = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        Slot = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CoursesId, cascadeDelete: true)
                .Index(t => t.CoursesId);
            
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.String(),
                        Semester = c.Int(nullable: false),
                        Date = c.String(),
                        ClassroomId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        StudentGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: false)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .Index(t => t.ClassroomId)
                .Index(t => t.SubjectId)
                .Index(t => t.AccountId)
                .Index(t => t.StudentGroupId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Students_StudentGroup", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.Timetables", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Timetables", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.Timetables", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Attendances", "TimetableId", "dbo.Timetables");
            DropForeignKey("dbo.Timetables", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "CoursesId", "dbo.Courses");
            DropForeignKey("dbo.StudentGroups", "CoursesId", "dbo.Courses");
            DropForeignKey("dbo.Students_StudentGroup", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Timetables", new[] { "StudentGroupId" });
            DropIndex("dbo.Timetables", new[] { "AccountId" });
            DropIndex("dbo.Timetables", new[] { "SubjectId" });
            DropIndex("dbo.Timetables", new[] { "ClassroomId" });
            DropIndex("dbo.Subjects", new[] { "CoursesId" });
            DropIndex("dbo.StudentGroups", new[] { "CoursesId" });
            DropIndex("dbo.Students_StudentGroup", new[] { "StudentGroupId" });
            DropIndex("dbo.Students_StudentGroup", new[] { "AccountId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Attendances", new[] { "AccountId" });
            DropIndex("dbo.Attendances", new[] { "TimetableId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Timetables");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.Students_StudentGroup");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Attendances");
        }
    }
}
