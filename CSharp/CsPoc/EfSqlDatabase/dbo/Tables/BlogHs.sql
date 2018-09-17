CREATE TABLE [dbo].[BlogHs] (
    [BlogHId]       INT            IDENTITY (1, 1) NOT NULL,
    [Url]           NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (MAX) NOT NULL,
    [RssUrl]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogHs] PRIMARY KEY CLUSTERED ([BlogHId] ASC)
);

