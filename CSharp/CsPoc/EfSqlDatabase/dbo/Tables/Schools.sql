CREATE TABLE [dbo].[Schools] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED ([Id] ASC)
);

