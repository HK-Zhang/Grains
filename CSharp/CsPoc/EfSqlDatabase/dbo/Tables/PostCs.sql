CREATE TABLE [dbo].[PostCs] (
    [PostCId]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (MAX) NULL,
    [Content]        NVARCHAR (MAX) NULL,
    [BlogForeignKey] INT            NOT NULL,
    CONSTRAINT [PK_PostCs] PRIMARY KEY CLUSTERED ([PostCId] ASC),
    CONSTRAINT [FK_PostCs_BlogCs_BlogForeignKey] FOREIGN KEY ([BlogForeignKey]) REFERENCES [dbo].[BlogCs] ([BlogCId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostCs_BlogForeignKey]
    ON [dbo].[PostCs]([BlogForeignKey] ASC);

