CREATE TABLE [dbo].[tblBlogNs] (
    [BlogNId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_tblBlogNs] PRIMARY KEY CLUSTERED ([BlogNId] ASC)
);

