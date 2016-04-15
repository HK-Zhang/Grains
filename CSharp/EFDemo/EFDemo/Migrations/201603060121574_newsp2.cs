namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsp2 : DbMigration
    {
        public override void Up()
        {
            AlterStoredProcedure(
                "dbo.WeiPost_Insert",
                p => new
                    {
                        Title = p.String(),
                        Content = p.String(),
                        TimeStamp = p.Binary(),
                        Weibo_WeiboId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[WeiPost]([Title], [Content], [TimeStamp], [Weibo_WeiboId])
                      VALUES (@Title, @Content, @TimeStamp, @Weibo_WeiboId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[WeiPost]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[WeiPost] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
