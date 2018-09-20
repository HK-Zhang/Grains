CREATE TABLE [dbo].[Orders] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [ShippingAddress_Street] NVARCHAR (MAX) NULL,
    [ShippingAddress_City]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

