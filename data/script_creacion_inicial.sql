------------------------------DROP DE TABLAS------------------------------
IF OBJECT_ID('PUNTO_ZIP.ROL_POR_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.ROL_POR_USUARIO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL_POR_USUARIO
GO

IF OBJECT_ID('PUNTO_ZIP.ROL') IS NOT NULL
DROP TABLE [LOSNOOBS].ROL
GO

IF OBJECT_ID('PUNTO_ZIP.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.USUARIO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].USUARIO
GO

------------------------------DROP SCHEMA------------------------------------
IF SCHEMA_ID('PUNTO_ZIP') IS NOT NULL
	DROP SCHEMA [PUNTO_ZIP]
GO

-----------------------------CREACION SCHEMA --------------------------------
CREATE SCHEMA [PUNTO_ZIP]
GO
------------------------------CREACION DE TABLAS------------------------------

CREATE TABLE [PUNTO_ZIP].ROL(
	rol_id int PRIMARY KEY IDENTITY(1,1),
	rol_habilitado bit DEFAULT 1, 
	rol_nombre nvarchar(255) UNIQUE not null
)
GO

CREATE TABLE [PUNTO_ZIP].USUARIO(
	usuario_id int PRIMARY KEY IDENTITY(1,1),
	usuario_username nvarchar(255) NOT NULL UNIQUE,
	usuario_password binary(32) NOT NULL,
	usuario_intentosLogin int default 0,
	usuario_activo BIT
)
GO

CREATE TABLE [PUNTO_ZIP].ROL_POR_USUARIO(
	rol_id int,
	usuario_id int,
	PRIMARY KEY (rol_id, usuario_id)
)
GO

CREATE TABLE [PUNTO_ZIP].FUNCIONALIDAD(
	funcionalidad_id int PRIMARY KEY IDENTITY (1,1),
	funcionalidad_descripcion nvarchar(255)
)
GO

CREATE TABLE [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD(
	rol_id int,
	funcionalidad_id int,
	PRIMARY KEY(rol_id, funcionalidad_id)	
)
GO

------------------------------LOGIN------------------------------

CREATE PROCEDURE [PUNTO_ZIP].PR_LOGIN @USERNAME NVARCHAR(255),@PASSWORD VARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = usuario_intentosLogin + 1 WHERE usuario_username = @USERNAME;

		SELECT	U.usuario_password Password, 
				U.usuario_username Username, 
				U.usuario_activo Activo, 
				U.usuario_id Id, 
				U.usuario_intentosLogin Intentos,  
				(CASE WHEN U.usuario_password = HashBytes('SHA2_256', @PASSWORD) THEN 1 ELSE 0 END) PasswordMatched
		FROM [PUNTO_ZIP].USUARIO U WHERE usuario_username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO