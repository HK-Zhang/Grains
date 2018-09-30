CREATE TABLE [dbo].[Picture] (
    [PictureId] INT            IDENTITY (1, 1) NOT NULL,
    [Content]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED ([PictureId] ASC)
);

