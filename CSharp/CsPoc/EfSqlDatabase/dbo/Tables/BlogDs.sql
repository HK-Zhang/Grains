CREATE TABLE [dbo].[BlogDs] (
    [BlogDId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogDs] PRIMARY KEY CLUSTERED ([BlogDId] ASC)
);

