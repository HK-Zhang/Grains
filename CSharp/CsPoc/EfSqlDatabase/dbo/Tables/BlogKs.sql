CREATE TABLE [dbo].[BlogKs] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [Author] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogKs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

