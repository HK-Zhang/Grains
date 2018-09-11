CREATE TABLE [dbo].[BlogCs] (
    [BlogCId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogCs] PRIMARY KEY CLUSTERED ([BlogCId] ASC)
);

