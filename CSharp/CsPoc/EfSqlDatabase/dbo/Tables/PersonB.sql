CREATE TABLE [dbo].[PersonB] (
    [PersonBId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (450) NULL,
    [LastName]  NVARCHAR (450) NULL,
    CONSTRAINT [PK_PersonB] PRIMARY KEY CLUSTERED ([PersonBId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonB_FirstName_LastName]
    ON [dbo].[PersonB]([FirstName] ASC, [LastName] ASC);

