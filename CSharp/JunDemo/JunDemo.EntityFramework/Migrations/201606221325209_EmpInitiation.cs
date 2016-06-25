namespace JunDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpInitiation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APPLEEmp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.APPLEEmp");
        }
    }
}
