namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultDataTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "DateCreated", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
