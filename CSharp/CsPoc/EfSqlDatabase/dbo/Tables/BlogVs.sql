CREATE TABLE [dbo].[BlogVs] (
    [BlogVId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Url]      NVARCHAR (MAX) NULL,
    [TenantId] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogVs] PRIMARY KEY CLUSTERED ([BlogVId] ASC)
);

