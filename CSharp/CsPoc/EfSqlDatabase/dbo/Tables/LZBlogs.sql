CREATE TABLE [dbo].[LZBlogs] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LZBlogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

