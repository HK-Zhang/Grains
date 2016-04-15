namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TblCourse", "DepartmentID", "dbo.Department");
            DropIndex("dbo.TblCourse", new[] { "DepartmentID" });
            AlterColumn("dbo.TblCourse", "DepartmentID", c => c.Int());
            CreateIndex("dbo.TblCourse", "DepartmentID");
            AddForeignKey("dbo.TblCourse", "DepartmentID", "dbo.Department", "DepartmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblCourse", "DepartmentID", "dbo.Department");
            DropIndex("dbo.TblCourse", new[] { "DepartmentID" });
            AlterColumn("dbo.TblCourse", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.TblCourse", "DepartmentID");
            AddForeignKey("dbo.TblCourse", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }
    }
}
