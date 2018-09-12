CREATE TABLE [dbo].[CarCs] (
    [CarCId]       INT            IDENTITY (1, 1) NOT NULL,
    [State]        NVARCHAR (450) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarCs] PRIMARY KEY CLUSTERED ([CarCId] ASC),
    CONSTRAINT [AK_CarCs_State_LicensePlate] UNIQUE NONCLUSTERED ([State] ASC, [LicensePlate] ASC)
);

