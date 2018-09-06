CREATE TABLE [dbo].[BlogTimestamps] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Url]       NVARCHAR (MAX) NULL,
    [Timestamp] ROWVERSION     NULL,
    CONSTRAINT [PK_BlogTimestamps] PRIMARY KEY CLUSTERED ([Id] ASC)
);

