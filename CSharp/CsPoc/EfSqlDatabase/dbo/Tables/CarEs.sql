CREATE TABLE [dbo].[CarEs] (
    [CarEId]       INT            IDENTITY (1, 1) NOT NULL,
    [State]        NVARCHAR (450) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarEs] PRIMARY KEY CLUSTERED ([CarEId] ASC),
    CONSTRAINT [AK_CarEs_State_LicensePlate] UNIQUE NONCLUSTERED ([State] ASC, [LicensePlate] ASC)
);

