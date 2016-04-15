namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2M : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID })
                .ForeignKey("dbo.TblCourse", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorID);
            
            AddColumn("dbo.Department", "ChairMan_ID", c => c.Int());
            AddColumn("dbo.Department", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.Department", "ChairMan_ID");
            CreateIndex("dbo.Department", "Teacher_ID");
            AddForeignKey("dbo.Department", "ChairMan_ID", "dbo.Person", "ID");
            AddForeignKey("dbo.Department", "Teacher_ID", "dbo.Person", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.TblCourse");
            DropForeignKey("dbo.Department", "Teacher_ID", "dbo.Person");
            DropForeignKey("dbo.Department", "ChairMan_ID", "dbo.Person");
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.Department", new[] { "Teacher_ID" });
            DropIndex("dbo.Department", new[] { "ChairMan_ID" });
            DropColumn("dbo.Department", "Teacher_ID");
            DropColumn("dbo.Department", "ChairMan_ID");
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.Person");
        }
    }
}
