CREATE TABLE [dbo].[RecordOfSaleBs] (
    [RecordOfSaleBId] INT             IDENTITY (1, 1) NOT NULL,
    [DateSold]        DATETIME2 (7)   NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [CarLicensePlate] NVARCHAR (450)  NULL,
    CONSTRAINT [PK_RecordOfSaleBs] PRIMARY KEY CLUSTERED ([RecordOfSaleBId] ASC),
    CONSTRAINT [FK_RecordOfSaleBs_CarBs_CarLicensePlate] FOREIGN KEY ([CarLicensePlate]) REFERENCES [dbo].[CarBs] ([LicensePlate])
);


GO
CREATE NONCLUSTERED INDEX [IX_RecordOfSaleBs_CarLicensePlate]
    ON [dbo].[RecordOfSaleBs]([CarLicensePlate] ASC);

