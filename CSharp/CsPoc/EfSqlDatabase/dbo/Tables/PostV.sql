CREATE TABLE [dbo].[PostV] (
    [PostVId]   INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [Content]   NVARCHAR (MAX) NULL,
    [IsDeleted] BIT            NOT NULL,
    [BlogVId]   INT            NOT NULL,
    CONSTRAINT [PK_PostV] PRIMARY KEY CLUSTERED ([PostVId] ASC),
    CONSTRAINT [FK_PostV_BlogVs_BlogVId] FOREIGN KEY ([BlogVId]) REFERENCES [dbo].[BlogVs] ([BlogVId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostV_BlogVId]
    ON [dbo].[PostV]([BlogVId] ASC);

