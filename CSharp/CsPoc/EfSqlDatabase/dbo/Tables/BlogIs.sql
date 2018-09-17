CREATE TABLE [dbo].[BlogIs] (
    [BlogIId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogIs] PRIMARY KEY CLUSTERED ([BlogIId] ASC)
);

