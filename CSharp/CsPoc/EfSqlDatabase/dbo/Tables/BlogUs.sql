CREATE TABLE [dbo].[BlogUs] (
    [BlogUId]   INT            IDENTITY (1, 1) NOT NULL,
    [Url]       NVARCHAR (MAX) NULL,
    [blog_type] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_BlogUs] PRIMARY KEY CLUSTERED ([BlogUId] ASC)
);

