CREATE TABLE [dbo].[QPost] (
    [PostId]      INT IDENTITY (1, 1) NOT NULL,
    [AuthorRenId] INT NULL,
    [BlogId]      INT NULL,
    CONSTRAINT [PK_QPost] PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_QPost_QBlogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[QBlogs] ([BlogId]),
    CONSTRAINT [FK_QPost_Ren_AuthorRenId] FOREIGN KEY ([AuthorRenId]) REFERENCES [dbo].[Ren] ([RenId])
);


GO
CREATE NONCLUSTERED INDEX [IX_QPost_BlogId]
    ON [dbo].[QPost]([BlogId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_QPost_AuthorRenId]
    ON [dbo].[QPost]([AuthorRenId] ASC);

