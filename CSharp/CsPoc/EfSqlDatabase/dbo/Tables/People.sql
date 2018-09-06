CREATE TABLE [dbo].[People] (
    [PersonId]  INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

