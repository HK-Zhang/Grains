namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsp : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.T_Post", new[] { "Weibo_WeiboId" });
            //DropColumn("dbo.T_Post", "Weibo_WeiboId");
            DropColumn("dbo.WeiPost", "DateCreated");
            CreateStoredProcedure(
                "dbo.WeiPost_Insert",
                p => new
                    {
                        Title = p.String(),
                        Content = p.String(),
                        TimeStamp = p.Binary(),
                        weibo_id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[WeiPost]([Title], [Content], [TimeStamp], [Weibo_WeiboId])
                      VALUES (@Title, @Content, @TimeStamp, @weibo_id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[WeiPost]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[WeiPost] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.WeiPost_Update",
                p => new
                    {
                        Id = p.Int(),
                        Title = p.String(),
                        Content = p.String(),
                        TimeStamp = p.Binary(),
                        Weibo_WeiboId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[WeiPost]
                      SET [Title] = @Title, [Content] = @Content, [TimeStamp] = @TimeStamp, [Weibo_WeiboId] = @Weibo_WeiboId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.WeiPost_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Weibo_WeiboId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[WeiPost]
                      WHERE (([Id] = @Id) AND (([Weibo_WeiboId] = @Weibo_WeiboId) OR ([Weibo_WeiboId] IS NULL AND @Weibo_WeiboId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.WeiPost_Delete");
            DropStoredProcedure("dbo.WeiPost_Update");
            DropStoredProcedure("dbo.WeiPost_Insert");
            AddColumn("dbo.WeiPost", "DateCreated", c => c.DateTime(nullable: false));
            //AddColumn("dbo.T_Post", "Weibo_WeiboId", c => c.Int());
            //CreateIndex("dbo.T_Post", "Weibo_WeiboId");
        }
    }
}
