CREATE TABLE [dbo].[BlogMaxLengths] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Url] NVARCHAR (500) NULL,
    CONSTRAINT [PK_BlogMaxLengths] PRIMARY KEY CLUSTERED ([Id] ASC)
);

