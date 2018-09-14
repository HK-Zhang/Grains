CREATE TABLE [dbo].[BlogFs] (
    [BlogFId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_BlogFs] PRIMARY KEY CLUSTERED ([BlogFId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_BlogFs_Url]
    ON [dbo].[BlogFs]([Url] ASC);

