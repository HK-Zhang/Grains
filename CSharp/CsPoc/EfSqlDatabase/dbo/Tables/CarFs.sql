CREATE TABLE [dbo].[CarFs] (
    [CarFId]       INT            IDENTITY (1, 1) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarFs] PRIMARY KEY CLUSTERED ([CarFId] ASC),
    CONSTRAINT [AlternateKey_LicensePlate] UNIQUE NONCLUSTERED ([LicensePlate] ASC)
);

