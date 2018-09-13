CREATE TABLE [dbo].[PostTag] (
    [PostFId] INT            NOT NULL,
    [TagId]   NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_PostTag] PRIMARY KEY CLUSTERED ([PostFId] ASC, [TagId] ASC),
    CONSTRAINT [FK_PostTag_PostFs_PostFId] FOREIGN KEY ([PostFId]) REFERENCES [dbo].[PostFs] ([PostFId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTag_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([TagId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostTag_TagId]
    ON [dbo].[PostTag]([TagId] ASC);

