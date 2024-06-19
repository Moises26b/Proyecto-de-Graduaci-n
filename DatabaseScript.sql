CREATE DATABASE Fundacion
GO

USE Fundacion
GO

CREATE TABLE USUARIO (
IdUsuario Int PRIMARY KEY IDENTITY,
NombreCompleto VARCHAR(50) NOT NULL,
Username VARCHAR(20) NOT NULL,
Edad INT NOT NULL,
Correo VARCHAR(50) NOT NULL, 
Domicilio VARCHAR(100) NOT NULL, 
Pwd VARCHAR(MAX) NOT NULL,
UltimaConexion DATE NOT NULL, 
EstadoUsuario BIT NOT NULL
)
GO

Use Fundacion;

INSERT INTO dbo.Usuarios(NombreCompleto,Username, Edad, Correo,Domicilio,Pwd,UltimaConexion,EstadoUsuario)
VALUES ('ADMIN', 'ADMIN', 25, 'admin@admin.com','Heredia','12345','2024/06/18',2);

INSERT INTO Roles (NombreRol, Descripcion, EstadoRol)
VALUES('', 'Rol ',1);

INSERT INTO UsuarioRoles (IdUsuario,IdRol)
VALUES (1,1);

DELETE FROM Usuarios
WHERE Username = 'ADMIN';

CREATE DATABASE Fundacion
GO
