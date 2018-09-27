CREATE TABLE [dbo].[PeopleC] (
    [PersonCId]   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [DisplayName] AS             (([LastName]+', ')+[FirstName]),
    CONSTRAINT [PK_PeopleC] PRIMARY KEY CLUSTERED ([PersonCId] ASC)
);

