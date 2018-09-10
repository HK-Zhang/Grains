CREATE TABLE [dbo].[PostBs] (
    [PostBId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    [BlogBId] INT            NULL,
    CONSTRAINT [PK_PostBs] PRIMARY KEY CLUSTERED ([PostBId] ASC),
    CONSTRAINT [FK_PostBs_BlogB_BlogBId] FOREIGN KEY ([BlogBId]) REFERENCES [dbo].[BlogB] ([BlogBId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostBs_BlogBId]
    ON [dbo].[PostBs]([BlogBId] ASC);

