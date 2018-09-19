CREATE TABLE [dbo].[PostLs] (
    [Title]    NVARCHAR (MAX) NULL,
    [Content]  NVARCHAR (MAX) NULL,
    [PostedOn] DATETIME2 (7)  NOT NULL,
    [Blog_id]  INT            NULL,
    [_id]      INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_PostLs] PRIMARY KEY CLUSTERED ([_id] ASC),
    CONSTRAINT [FK_PostLs_BlogLs_Blog_id] FOREIGN KEY ([Blog_id]) REFERENCES [dbo].[BlogLs] ([_id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostLs_Blog_id]
    ON [dbo].[PostLs]([Blog_id] ASC);

