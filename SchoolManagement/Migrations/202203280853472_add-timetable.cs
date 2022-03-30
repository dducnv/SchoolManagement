namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtimetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.String(),
                        Date = c.String(),
                        ClassroomId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        StudentGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: false)
                .Index(t => t.ClassroomId)
                .Index(t => t.SubjectId)
                .Index(t => t.AccountId)
                .Index(t => t.StudentGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timetables", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Timetables", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Timetables", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.Timetables", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Timetables", new[] { "StudentGroupId" });
            DropIndex("dbo.Timetables", new[] { "AccountId" });
            DropIndex("dbo.Timetables", new[] { "SubjectId" });
            DropIndex("dbo.Timetables", new[] { "ClassroomId" });
            DropTable("dbo.Timetables");
        }
    }
}
