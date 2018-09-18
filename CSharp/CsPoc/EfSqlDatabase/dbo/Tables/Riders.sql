CREATE TABLE [dbo].[Riders] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Mount] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Riders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

