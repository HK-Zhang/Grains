namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapToSP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weibo",
                c => new
                    {
                        WeiboId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.WeiboId);
            
            CreateTable(
                "dbo.WeiPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Content = c.String(),
                        TimeStamp = c.Binary(),
                        Weibo_WeiboId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weibo", t => t.Weibo_WeiboId)
                .Index(t => t.Weibo_WeiboId);
            
            AddColumn("dbo.T_Post", "Weibo_WeiboId", c => c.Int());
            CreateIndex("dbo.T_Post", "Weibo_WeiboId");
            AddForeignKey("dbo.T_Post", "Weibo_WeiboId", "dbo.Weibo", "WeiboId");
            CreateStoredProcedure(
                "dbo.insert_Weibo",
                p => new
                    {
                        weibo_name = p.String(),
                        weibo_url = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Weibo]([Name], [Url])
                      VALUES (@weibo_name, @weibo_url)
                      
                      DECLARE @WeiboId int
                      SELECT @WeiboId = [WeiboId]
                      FROM [dbo].[Weibo]
                      WHERE @@ROWCOUNT > 0 AND [WeiboId] = scope_identity()
                      
                      SELECT t0.[WeiboId] AS generated_weibo_identity, t0.[Timestamp]
                      FROM [dbo].[Weibo] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[WeiboId] = @WeiboId"
            );
            
            CreateStoredProcedure(
                "dbo.modify_Weibo",
                p => new
                    {
                        weibo_id = p.Int(),
                        weibo_name = p.String(),
                        weibo_url = p.String(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[Weibo]
                      SET [Name] = @weibo_name, [Url] = @weibo_url
                      WHERE (([WeiboId] = @weibo_id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Weibo] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[WeiboId] = @weibo_id"
            );
            
            CreateStoredProcedure(
                "dbo.delete_Weibo",
                p => new
                    {
                        weibo_id = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Weibo]
                      WHERE (([WeiboId] = @weibo_id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.delete_Weibo");
            DropStoredProcedure("dbo.modify_Weibo");
            DropStoredProcedure("dbo.insert_Weibo");
            DropForeignKey("dbo.WeiPost", "Weibo_WeiboId", "dbo.Weibo");
            DropForeignKey("dbo.T_Post", "Weibo_WeiboId", "dbo.Weibo");
            DropIndex("dbo.WeiPost", new[] { "Weibo_WeiboId" });
            DropIndex("dbo.T_Post", new[] { "Weibo_WeiboId" });
            DropColumn("dbo.T_Post", "Weibo_WeiboId");
            DropTable("dbo.WeiPost");
            DropTable("dbo.Weibo");
        }
    }
}
