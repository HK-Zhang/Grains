CREATE TABLE [dbo].[CarDs] (
    [CarDId]       INT            IDENTITY (1, 1) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarDs] PRIMARY KEY CLUSTERED ([CarDId] ASC),
    CONSTRAINT [AK_CarDs_LicensePlate] UNIQUE NONCLUSTERED ([LicensePlate] ASC)
);

