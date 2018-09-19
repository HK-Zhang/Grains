CREATE TABLE [dbo].[BlogLs] (
    [Name]   NVARCHAR (MAX) NULL,
    [Author] NVARCHAR (MAX) NULL,
    [_id]    INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_BlogLs] PRIMARY KEY CLUSTERED ([_id] ASC)
);

