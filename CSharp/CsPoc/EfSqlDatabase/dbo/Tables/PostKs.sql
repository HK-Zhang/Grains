CREATE TABLE [dbo].[PostKs] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX) NULL,
    [Content]  NVARCHAR (MAX) NULL,
    [PostedOn] DATETIME2 (7)  NOT NULL,
    [BlogId]   INT            NULL,
    CONSTRAINT [PK_PostKs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PostKs_BlogKs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[BlogKs] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostKs_BlogId]
    ON [dbo].[PostKs]([BlogId] ASC);

