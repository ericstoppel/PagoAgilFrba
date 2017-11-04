USE [GD2C2017]
GO

-------------------------------DROP PROCEDURES----------------------------

IF OBJECT_ID('[PUNTO_ZIP].PR_LOGIN') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_LOGIN
GO

IF OBJECT_ID('[PUNTO_ZIP].PR_BUSCAR_CLIENTE_POR_DNI') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_BUSCAR_CLIENTE_POR_DNI
GO

IF OBJECT_ID('[PUNTO_ZIP].PR_INSERTAR_MODIFICAR_CLIENTE') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_INSERTAR_MODIFICAR_CLIENTE
GO

IF OBJECT_ID('[PUNTO_ZIP].PR_BAJA_CLIENTE') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_BAJA_CLIENTE
GO

IF OBJECT_ID('[PUNTO_ZIP].PR_LISTADO_SELECCION_ABM_CLIENTE') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_LISTADO_SELECCION_ABM_CLIENTE
GO

------------------------------DROP DE TABLAS------------------------------
IF OBJECT_ID('PUNTO_ZIP.ROL_POR_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.ROL_POR_USUARIO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL_POR_USUARIO
GO

IF OBJECT_ID('PUNTO_ZIP.ROL') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL
GO

IF OBJECT_ID('PUNTO_ZIP.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.USUARIO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].USUARIO
GO

IF OBJECT_ID('PUNTO_ZIP.CLIENTE') IS NOT NULL
DROP TABLE [PUNTO.ZIP].CLIENTE
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

CREATE TABLE [PUNTO_ZIP].CLIENTE(
	cliente_id int PRIMARY KEY IDENTITY(1,1),
	cliente_dni numeric(18,0) NOT NULL,
	cliente_apellido nvarchar(255) NOT NULL,
	cliente_nombre nvarchar(255) NOT NULL,
	cliente_fechaNac datetime NOT NULL,
	cliente_mail nvarchar(255) NOT NULL UNIQUE,
	cliente_direccion nvarchar(255) NOT NULL,
	cliente_codigo_postal nvarchar(255) NOT NULL,
	cliente_telefono nvarchar(255) NOT NULL,
	cliente_activo bit default 1
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

------------------------------ABM CLIENTE------------------------------
CREATE PROCEDURE [PUNTO_ZIP].PR_BUSCAR_CLIENTE_POR_DNI @DNI NUMERIC(18,0)
AS
BEGIN TRY
	SELECT *
	FROM [PUNTO_ZIP].CLIENTE C
	WHERE C.cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].PR_INSERTAR_MODIFICAR_CLIENTE @NOMBRE NVARCHAR (255),@APELLIDO NVARCHAR (255),@DNI BIGINT,@DIRECCION NVARCHAR (255),@TELEFONO NVARCHAR (255),@MAIL NVARCHAR (255),@FECHANAC DATETIME,@HABILITADO BIT
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM CLIENTE WHERE CLIENTE.cliente_dni = @DNI)) --NUEVO CLIENTE
		INSERT INTO [PUNTO_ZIP].CLIENTE(cliente_nombre,cliente_apellido,cliente_dni,cliente_direccion,cliente_telefono,cliente_mail,cliente_fechaNac,cliente_activo) VALUES(@NOMBRE ,@APELLIDO ,@DNI,@DIRECCION,@TELEFONO,@MAIL,@FECHANAC,@HABILITADO)
	ELSE
		UPDATE [PUNTO_ZIP].CLIENTE SET cliente_apellido = @APELLIDO,cliente_direccion = @DIRECCION,cliente_dni = @DNI,cliente_fechaNac = @FECHANAC,cliente_mail = @MAIL,cliente_nombre = @NOMBRE,cliente_telefono = @TELEFONO,cliente_activo = @HABILITADO WHERE cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].PR_BAJA_CLIENTE @DNI NUMERIC(18,0)
AS
BEGIN TRY
	UPDATE [PUNTO_ZIP].CLIENTE SET cliente_activo = 0 WHERE CLIENTE.cliente_dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO 

CREATE	 PROCEDURE [PUNTO_ZIP].PR_LISTADO_SELECCION_ABM_CLIENTE @NOMBRE NVARCHAR(255),@APELLIDO NVARCHAR(255),@DNI BIGINT
AS
BEGIN TRY
	SELECT *, cliente_nombre + ' ' + cliente_apellido NombreCompleto
	FROM [PUNTO_ZIP].CLIENTE c 
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(c.cliente_nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(c.cliente_apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR c.cliente_dni = @DNI) AND cliente_activo = 1;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO