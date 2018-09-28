CREATE TABLE [dbo].[BlogRs] (
    [BlogRId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_BlogRs] PRIMARY KEY CLUSTERED ([BlogRId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_BlogRs_Url]
    ON [dbo].[BlogRs]([Url] ASC) WHERE ([Url] IS NOT NULL);

