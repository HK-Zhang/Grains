CREATE TABLE [dbo].[Blogs] (
    [BlogId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED ([BlogId] ASC)
);

