CREATE TABLE [dbo].[LZPost] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    [BlogId1] INT            NULL,
    [BlogId]  INT            NULL,
    CONSTRAINT [PK_LZPost] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LZPost_LZBlogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[LZBlogs] ([Id]),
    CONSTRAINT [FK_LZPost_LZBlogs_BlogId1] FOREIGN KEY ([BlogId1]) REFERENCES [dbo].[LZBlogs] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_LZPost_BlogId1]
    ON [dbo].[LZPost]([BlogId1] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LZPost_BlogId]
    ON [dbo].[LZPost]([BlogId] ASC);

