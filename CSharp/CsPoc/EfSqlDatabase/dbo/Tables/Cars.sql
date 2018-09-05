CREATE TABLE [dbo].[Cars] (
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([LicensePlate] ASC)
);

