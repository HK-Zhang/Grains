CREATE TABLE [dbo].[RecordOfSaleCs] (
    [RecordOfSaleCId] INT             IDENTITY (1, 1) NOT NULL,
    [DateSold]        DATETIME2 (7)   NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [CarState]        NVARCHAR (450)  NULL,
    [CarLicensePlate] NVARCHAR (450)  NULL,
    CONSTRAINT [PK_RecordOfSaleCs] PRIMARY KEY CLUSTERED ([RecordOfSaleCId] ASC),
    CONSTRAINT [FK_RecordOfSaleCs_CarCs_CarState_CarLicensePlate] FOREIGN KEY ([CarState], [CarLicensePlate]) REFERENCES [dbo].[CarCs] ([State], [LicensePlate])
);


GO
CREATE NONCLUSTERED INDEX [IX_RecordOfSaleCs_CarState_CarLicensePlate]
    ON [dbo].[RecordOfSaleCs]([CarState] ASC, [CarLicensePlate] ASC);

