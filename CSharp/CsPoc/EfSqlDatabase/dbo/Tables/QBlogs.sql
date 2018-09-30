CREATE TABLE [dbo].[QBlogs] (
    [BlogId]     INT            IDENTITY (1, 1) NOT NULL,
    [Url]        NVARCHAR (MAX) NULL,
    [OwnerRenId] INT            NULL,
    CONSTRAINT [PK_QBlogs] PRIMARY KEY CLUSTERED ([BlogId] ASC),
    CONSTRAINT [FK_QBlogs_Ren_OwnerRenId] FOREIGN KEY ([OwnerRenId]) REFERENCES [dbo].[Ren] ([RenId])
);


GO
CREATE NONCLUSTERED INDEX [IX_QBlogs_OwnerRenId]
    ON [dbo].[QBlogs]([OwnerRenId] ASC);

