CREATE TABLE [dbo].[BlogB] (
    [BlogBId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogB] PRIMARY KEY CLUSTERED ([BlogBId] ASC)
);

