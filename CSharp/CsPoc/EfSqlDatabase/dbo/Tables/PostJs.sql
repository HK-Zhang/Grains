CREATE TABLE [dbo].[PostJs] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX) NULL,
    [Content]  NVARCHAR (MAX) NULL,
    [PostedOn] DATETIME2 (7)  NOT NULL,
    [BlogId]   INT            NULL,
    CONSTRAINT [PK_PostJs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PostJs_BlogJs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[BlogJs] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostJs_BlogId]
    ON [dbo].[PostJs]([BlogId] ASC);

