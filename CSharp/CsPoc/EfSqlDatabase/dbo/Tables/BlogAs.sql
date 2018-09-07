CREATE TABLE [dbo].[BlogAs] (
    [BlogAId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogAs] PRIMARY KEY CLUSTERED ([BlogAId] ASC)
);

