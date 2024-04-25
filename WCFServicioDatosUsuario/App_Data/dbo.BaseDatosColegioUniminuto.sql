
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/21/2024 17:51:37
-- Generated from EDMX file: D:\Proyectos_Visual_Studio\PROYECTO_FINAL_ENTREGA\WCFServicioDatosUsuario\App_Code\DatosEmpresaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LoginDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Asistencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asistencias];
GO
IF OBJECT_ID(N'[dbo].[Calificaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calificaciones];
GO
IF OBJECT_ID(N'[dbo].[EmployeeDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeDetails];
GO
IF OBJECT_ID(N'[dbo].[Materias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materias];
GO
IF OBJECT_ID(N'[dbo].[Materias_docentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materias_docentes];
GO
IF OBJECT_ID(N'[dbo].[Materias_estudiantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materias_estudiantes];
GO
IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[Trabajos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trabajos];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmployeeDetails'
CREATE TABLE [dbo].[EmployeeDetails] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Age] int  NULL,
    [Salary] decimal(18,0)  NULL,
    [WorkType] varchar(50)  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Password] varchar(25)  NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Apellido] varchar(50)  NULL,
    [Email] varchar(50)  NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Id] int  NOT NULL,
    [Descripcion] varchar(50)  NULL,
    [Precio] float  NULL,
    [Stock] int  NULL
);
GO

-- Creating table 'Asistencias'
CREATE TABLE [dbo].[Asistencias] (
    [id_asistencia] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int  NULL,
    [id_materia] int  NULL,
    [fecha] datetime  NULL,
    [asistio] varchar(5)  NOT NULL
);
GO

-- Creating table 'Calificaciones'
CREATE TABLE [dbo].[Calificaciones] (
    [id_calificacion] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int  NULL,
    [id_materia] int  NULL,
    [tipo_actividad] varchar(100)  NULL,
    [calificacion] decimal(5,2)  NULL
);
GO

-- Creating table 'Materias'
CREATE TABLE [dbo].[Materias] (
    [id_materia] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NULL,
    [codigo] varchar(50)  NULL,
    [descripcion] varchar(max)  NULL
);
GO

-- Creating table 'Materias_docentes'
CREATE TABLE [dbo].[Materias_docentes] (
    [id_materia_docente] int IDENTITY(1,1) NOT NULL,
    [id_materia] int  NULL,
    [id_usuario] int  NULL
);
GO

-- Creating table 'Materias_estudiantes'
CREATE TABLE [dbo].[Materias_estudiantes] (
    [id_materia_estudiante] int IDENTITY(1,1) NOT NULL,
    [id_materia] int  NULL,
    [id_usuario] int  NULL
);
GO

-- Creating table 'Trabajos'
CREATE TABLE [dbo].[Trabajos] (
    [id_trabajo] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int  NULL,
    [id_materia] int  NULL,
    [tipo_trabajo] varchar(100)  NULL,
    [archivo] varchar(255)  NULL,
    [fecha_entrega] datetime  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NULL,
    [apellido] varchar(255)  NULL,
    [rol] varchar(30)  NOT NULL,
    [login] varchar(50)  NULL,
    [clave] varbinary(8000)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmpId] in table 'EmployeeDetails'
ALTER TABLE [dbo].[EmployeeDetails]
ADD CONSTRAINT [PK_EmployeeDetails]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id_asistencia] in table 'Asistencias'
ALTER TABLE [dbo].[Asistencias]
ADD CONSTRAINT [PK_Asistencias]
    PRIMARY KEY CLUSTERED ([id_asistencia] ASC);
GO

-- Creating primary key on [id_calificacion] in table 'Calificaciones'
ALTER TABLE [dbo].[Calificaciones]
ADD CONSTRAINT [PK_Calificaciones]
    PRIMARY KEY CLUSTERED ([id_calificacion] ASC);
GO

-- Creating primary key on [id_materia] in table 'Materias'
ALTER TABLE [dbo].[Materias]
ADD CONSTRAINT [PK_Materias]
    PRIMARY KEY CLUSTERED ([id_materia] ASC);
GO

-- Creating primary key on [id_materia_docente] in table 'Materias_docentes'
ALTER TABLE [dbo].[Materias_docentes]
ADD CONSTRAINT [PK_Materias_docentes]
    PRIMARY KEY CLUSTERED ([id_materia_docente] ASC);
GO

-- Creating primary key on [id_materia_estudiante] in table 'Materias_estudiantes'
ALTER TABLE [dbo].[Materias_estudiantes]
ADD CONSTRAINT [PK_Materias_estudiantes]
    PRIMARY KEY CLUSTERED ([id_materia_estudiante] ASC);
GO

-- Creating primary key on [id_trabajo] in table 'Trabajos'
ALTER TABLE [dbo].[Trabajos]
ADD CONSTRAINT [PK_Trabajos]
    PRIMARY KEY CLUSTERED ([id_trabajo] ASC);
GO

-- Creating primary key on [id_usuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id_usuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------