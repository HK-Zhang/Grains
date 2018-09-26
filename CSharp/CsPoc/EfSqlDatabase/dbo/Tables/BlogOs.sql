CREATE TABLE [dbo].[BlogOs] (
    [blog_id] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     VARCHAR (200)  NULL,
    [Rating]  DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PrimaryKey_BlogId] PRIMARY KEY CLUSTERED ([blog_id] ASC)
);

