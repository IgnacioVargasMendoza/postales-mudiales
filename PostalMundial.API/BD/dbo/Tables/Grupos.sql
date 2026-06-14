CREATE TABLE [dbo].[Grupos] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nombre]      VARCHAR (MAX)    NOT NULL,
    [Descripcion] VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

