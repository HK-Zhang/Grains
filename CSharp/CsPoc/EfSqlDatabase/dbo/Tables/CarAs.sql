CREATE TABLE [dbo].[CarAs] (
    [State]        NVARCHAR (450) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarAs] PRIMARY KEY CLUSTERED ([State] ASC, [LicensePlate] ASC)
);

