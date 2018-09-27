CREATE TABLE [dbo].[OrderDs] (
    [OrderDId] INT            IDENTITY (1, 1) NOT NULL,
    [OrderNo]  INT            DEFAULT (NEXT VALUE FOR [shared].[OrderNumbers]) NOT NULL,
    [Url]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OrderDs] PRIMARY KEY CLUSTERED ([OrderDId] ASC)
);

