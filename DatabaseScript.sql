CREATE DATABASE TAB_VGSTORE
GO

USE TAB_VGSTORE
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

