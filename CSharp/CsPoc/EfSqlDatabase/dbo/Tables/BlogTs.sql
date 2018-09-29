CREATE TABLE [dbo].[BlogTs] (
    [BlogTId]   INT            IDENTITY (1, 1) NOT NULL,
    [Url]       NVARCHAR (MAX) NULL,
    [blog_type] NVARCHAR (MAX) NOT NULL,
    [RssUrl]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogTs] PRIMARY KEY CLUSTERED ([BlogTId] ASC)
);

