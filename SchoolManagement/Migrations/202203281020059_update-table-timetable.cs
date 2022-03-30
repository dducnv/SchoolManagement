namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabletimetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timetables", "Name", c => c.String());
            AddColumn("dbo.Timetables", "Semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timetables", "Semester");
            DropColumn("dbo.Timetables", "Name");
        }
    }
}
