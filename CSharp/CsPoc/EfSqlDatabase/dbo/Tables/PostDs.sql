CREATE TABLE [dbo].[PostDs] (
    [PostDId]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (MAX) NULL,
    [Content]        NVARCHAR (MAX) NULL,
    [BlogForeignKey] INT            NOT NULL,
    CONSTRAINT [PK_PostDs] PRIMARY KEY CLUSTERED ([PostDId] ASC),
    CONSTRAINT [FK_PostDs_BlogDs_BlogForeignKey] FOREIGN KEY ([BlogForeignKey]) REFERENCES [dbo].[BlogDs] ([BlogDId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostDs_BlogForeignKey]
    ON [dbo].[PostDs]([BlogForeignKey] ASC);

