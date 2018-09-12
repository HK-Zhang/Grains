CREATE TABLE [dbo].[CarBs] (
    [CarBId]       INT            IDENTITY (1, 1) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarBs] PRIMARY KEY CLUSTERED ([CarBId] ASC),
    CONSTRAINT [AK_CarBs_LicensePlate] UNIQUE NONCLUSTERED ([LicensePlate] ASC)
);

