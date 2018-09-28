CREATE TABLE [dbo].[BlogPs] (
    [BlogPId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (MAX) NULL,
    [Rating]  INT            DEFAULT ((3)) NOT NULL,
    [Created] DATETIME2 (7)  DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_BlogPs] PRIMARY KEY CLUSTERED ([BlogPId] ASC)
);

