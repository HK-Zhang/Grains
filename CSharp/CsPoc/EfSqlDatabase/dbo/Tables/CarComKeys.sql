CREATE TABLE [dbo].[CarComKeys] (
    [State]        NVARCHAR (450) NOT NULL,
    [LicensePlate] NVARCHAR (450) NOT NULL,
    [Make]         NVARCHAR (MAX) NULL,
    [Model]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CarComKeys] PRIMARY KEY CLUSTERED ([State] ASC, [LicensePlate] ASC)
);

