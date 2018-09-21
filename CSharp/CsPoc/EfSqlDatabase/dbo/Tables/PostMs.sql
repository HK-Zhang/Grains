CREATE TABLE [dbo].[PostMs] (
    [PostMId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    [BlogMId] INT            NOT NULL,
    CONSTRAINT [PK_PostMs] PRIMARY KEY CLUSTERED ([PostMId] ASC),
    CONSTRAINT [FK_PostMs_BlogMs_BlogMId] FOREIGN KEY ([BlogMId]) REFERENCES [dbo].[BlogMs] ([BlogMId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostMs_BlogMId]
    ON [dbo].[PostMs]([BlogMId] ASC);

