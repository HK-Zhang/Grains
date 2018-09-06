CREATE TABLE [dbo].[BlogShadowPropertys] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [LastUpdated] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BlogShadowPropertys] PRIMARY KEY CLUSTERED ([Id] ASC)
);

