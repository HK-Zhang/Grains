CREATE TABLE [dbo].[BlogGs] (
    [BlogGId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogGs] PRIMARY KEY CLUSTERED ([BlogGId] ASC)
);

