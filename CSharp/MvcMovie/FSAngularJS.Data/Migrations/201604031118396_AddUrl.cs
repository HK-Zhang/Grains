namespace FSAngularJS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "foursquare.BookmarkedPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        VenueID = c.String(nullable: false, maxLength: 50),
                        VenueName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 100),
                        Category = c.String(maxLength: 100),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        TS = c.DateTime(storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("foursquare.BookmarkedPlaces");
        }
    }
}
