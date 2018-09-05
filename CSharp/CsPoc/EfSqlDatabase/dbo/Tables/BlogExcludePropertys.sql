CREATE TABLE [dbo].[BlogExcludePropertys] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Url] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogExcludePropertys] PRIMARY KEY CLUSTERED ([Id] ASC)
);

