CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]     VARCHAR (255) DEFAULT (NULL) NULL,
    [apellido]   VARCHAR (255) DEFAULT (NULL) NULL,
    [rol]        VARCHAR (30)  NOT NULL,
    [login] VARCHAR(60) NOT NULL, 
    [clave] VARCHAR(50) NOT NULL DEFAULT (NULL), 
    PRIMARY KEY CLUSTERED ([id_usuario] ASC),
    CHECK ([rol]='Estudiante' OR [rol]='Docente' OR [rol]='Administrador')
);

