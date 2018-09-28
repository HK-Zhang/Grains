CREATE TABLE [dbo].[BlogSs] (
    [BlogSId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogSs] PRIMARY KEY CLUSTERED ([BlogSId] ASC)
);

