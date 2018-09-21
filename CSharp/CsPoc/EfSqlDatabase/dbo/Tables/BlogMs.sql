CREATE TABLE [dbo].[BlogMs] (
    [BlogMId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogMs] PRIMARY KEY CLUSTERED ([BlogMId] ASC)
);

