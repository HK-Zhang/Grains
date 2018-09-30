CREATE TABLE [dbo].[RenMen] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (MAX) NOT NULL,
    [SchoolId]      INT            NULL,
    CONSTRAINT [PK_RenMen] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RenMen_Schools_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_RenMen_SchoolId]
    ON [dbo].[RenMen]([SchoolId] ASC);

