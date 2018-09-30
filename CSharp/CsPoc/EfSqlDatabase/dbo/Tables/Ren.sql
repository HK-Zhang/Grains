CREATE TABLE [dbo].[Ren] (
    [RenId]          INT IDENTITY (1, 1) NOT NULL,
    [PhotoPictureId] INT NULL,
    CONSTRAINT [PK_Ren] PRIMARY KEY CLUSTERED ([RenId] ASC),
    CONSTRAINT [FK_Ren_Picture_PhotoPictureId] FOREIGN KEY ([PhotoPictureId]) REFERENCES [dbo].[Picture] ([PictureId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Ren_PhotoPictureId]
    ON [dbo].[Ren]([PhotoPictureId] ASC);

