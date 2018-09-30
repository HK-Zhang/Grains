CREATE TABLE [dbo].[PTag] (
    [PTagId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [PostId] INT            NULL,
    CONSTRAINT [PK_PTag] PRIMARY KEY CLUSTERED ([PTagId] ASC),
    CONSTRAINT [FK_PTag_QPost_PostId] FOREIGN KEY ([PostId]) REFERENCES [dbo].[QPost] ([PostId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PTag_PostId]
    ON [dbo].[PTag]([PostId] ASC);

