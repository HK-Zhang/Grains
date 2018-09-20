CREATE TABLE [dbo].[OrderCs] (
    [Id]                                  INT            IDENTITY (1, 1) NOT NULL,
    [OrderDetails_BillingAddress_Street]  NVARCHAR (MAX) NULL,
    [OrderDetails_BillingAddress_City]    NVARCHAR (MAX) NULL,
    [OrderDetails_ShippingAddress_Street] NVARCHAR (MAX) NULL,
    [OrderDetails_ShippingAddress_City]   NVARCHAR (MAX) NULL,
    [Status]                              INT            NOT NULL,
    CONSTRAINT [PK_OrderCs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

