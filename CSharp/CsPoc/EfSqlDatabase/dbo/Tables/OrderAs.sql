CREATE TABLE [dbo].[OrderAs] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ShipsToStreet] NVARCHAR (MAX) NULL,
    [ShipsToCity]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OrderAs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

