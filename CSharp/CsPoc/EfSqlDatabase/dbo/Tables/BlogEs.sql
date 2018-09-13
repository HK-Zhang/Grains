CREATE TABLE [dbo].[BlogEs] (
    [BlogEId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogEs] PRIMARY KEY CLUSTERED ([BlogEId] ASC)
);

