CREATE TABLE [dbo].[PostSs] (
    [PostSId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    [BlogSId] INT            NOT NULL,
    CONSTRAINT [PK_PostSs] PRIMARY KEY CLUSTERED ([PostSId] ASC),
    CONSTRAINT [ForeignKey_PostS_BlogS] FOREIGN KEY ([BlogSId]) REFERENCES [dbo].[BlogSs] ([BlogSId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostSs_BlogSId]
    ON [dbo].[PostSs]([BlogSId] ASC);

