CREATE TABLE [dbo].[BlogJs] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [Author] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogJs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

