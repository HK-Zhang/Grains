CREATE TABLE [dbo].[BlogExculudeTypes] (
    [Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Url] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogExculudeTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

