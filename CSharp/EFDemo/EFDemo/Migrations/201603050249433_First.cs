namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        PrimaryTrackingKey = c.Int(nullable: false),
                        Title = c.String(),
                        BlogName = c.String(nullable: false, maxLength: 50, unicode: false),
                        BlogDetail_DateCreated = c.DateTime(),
                        BlogDetail_Description = c.String(maxLength: 1000),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.PrimaryTrackingKey);
            
            CreateTable(
                "dbo.T_Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 8000, unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                        Content = c.String(),
                        TimeStamp = c.Binary(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.TblCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Credit = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DepartmentID = c.Int(nullable: false),
                        URL = c.String(),
                        Location = c.String(),
                        Days = c.String(),
                        Time = c.DateTime(),
                        Details_Time = c.DateTime(),
                        Details_Location = c.String(),
                        Details_Days = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblCourse", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.T_Post", "BlogId", "dbo.Blog");
            DropIndex("dbo.TblCourse", new[] { "DepartmentID" });
            DropIndex("dbo.T_Post", new[] { "BlogId" });
            DropTable("dbo.Department");
            DropTable("dbo.TblCourse");
            DropTable("dbo.T_Post");
            DropTable("dbo.Blog");
        }
    }
}
