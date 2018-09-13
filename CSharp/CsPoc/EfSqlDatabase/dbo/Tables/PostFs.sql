CREATE TABLE [dbo].[PostFs] (
    [PostFId] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Content] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PostFs] PRIMARY KEY CLUSTERED ([PostFId] ASC)
);

