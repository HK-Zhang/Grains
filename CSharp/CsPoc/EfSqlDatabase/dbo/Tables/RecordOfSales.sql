CREATE TABLE [dbo].[RecordOfSales] (
    [RecordOfSaleId]  INT             IDENTITY (1, 1) NOT NULL,
    [DateSold]        DATETIME2 (7)   NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [CarState]        NVARCHAR (450)  NULL,
    [CarLicensePlate] NVARCHAR (450)  NULL,
    CONSTRAINT [PK_RecordOfSales] PRIMARY KEY CLUSTERED ([RecordOfSaleId] ASC),
    CONSTRAINT [FK_RecordOfSales_CarAs_CarState_CarLicensePlate] FOREIGN KEY ([CarState], [CarLicensePlate]) REFERENCES [dbo].[CarAs] ([State], [LicensePlate])
);


GO
CREATE NONCLUSTERED INDEX [IX_RecordOfSales_CarState_CarLicensePlate]
    ON [dbo].[RecordOfSales]([CarState] ASC, [CarLicensePlate] ASC);

