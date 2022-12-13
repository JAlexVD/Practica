IF OBJECT_ID(N'[__EFMigrationHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'practica') IS NULL EXEC(N'CREATE SCHEMA [practica];');
GO

CREATE TABLE [practica].[Autores] (
    [AutorId] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [Doi] nvarchar(max) NOT NULL,
    [Apellidos] nvarchar(max) NOT NULL,
    [FechaNacimiento] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Updated] datetime2 NULL,
    [Deleted] datetime2 NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([AutorId])
);
GO

CREATE TABLE [practica].[Libros] (
    [LibroId] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Version] nvarchar(max) NOT NULL,
    [AutorId] uniqueidentifier NOT NULL,
    [Created] datetime2 NOT NULL,
    [Updated] datetime2 NULL,
    [Deleted] datetime2 NULL,
    CONSTRAINT [PK_Libros] PRIMARY KEY ([LibroId]),
    CONSTRAINT [FK_Libros_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [practica].[Autores] ([AutorId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Libros_AutorId] ON [practica].[Libros] ([AutorId]);
GO

INSERT INTO [__EFMigrationHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221213023815_initial', N'7.0.0');
GO

COMMIT;
GO

