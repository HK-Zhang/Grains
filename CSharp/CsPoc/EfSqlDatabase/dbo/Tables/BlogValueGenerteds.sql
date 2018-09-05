CREATE TABLE [dbo].[BlogValueGenerteds] (
    [Id]          INT            NOT NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [Inserted]    BIT            NOT NULL,
    [LastUpdated] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BlogValueGenerteds] PRIMARY KEY CLUSTERED ([Id] ASC)
);

