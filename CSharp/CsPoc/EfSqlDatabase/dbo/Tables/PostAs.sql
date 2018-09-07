CREATE TABLE [dbo].[PostAs] (
    [PostAId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    [BlogAId] INT            NULL,
    CONSTRAINT [PK_PostAs] PRIMARY KEY CLUSTERED ([PostAId] ASC),
    CONSTRAINT [FK_PostAs_BlogAs_BlogAId] FOREIGN KEY ([BlogAId]) REFERENCES [dbo].[BlogAs] ([BlogAId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostAs_BlogAId]
    ON [dbo].[PostAs]([BlogAId] ASC);

