CREATE TABLE [dbo].[BlogImageS] (
    [BlogImageId]    INT             IDENTITY (1, 1) NOT NULL,
    [Image]          VARBINARY (MAX) NULL,
    [Caption]        NVARCHAR (MAX)  NULL,
    [BlogForeignKey] INT             NOT NULL,
    CONSTRAINT [PK_BlogImageS] PRIMARY KEY CLUSTERED ([BlogImageId] ASC),
    CONSTRAINT [FK_BlogImageS_BlogEs_BlogForeignKey] FOREIGN KEY ([BlogForeignKey]) REFERENCES [dbo].[BlogEs] ([BlogEId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BlogImageS_BlogForeignKey]
    ON [dbo].[BlogImageS]([BlogForeignKey] ASC);

