USE [GD2C2017]
GO

-------------------------------DROP PROCEDURES----------------------------

IF OBJECT_ID('[PUNTO_ZIP].PR_LOGIN') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_LOGIN
GO

IF OBJECT_ID('PUNTO_ZIP.PR_USUARIO_LOGUEADO') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.PR_USUARIO_LOGUEADO;
GO

IF OBJECT_ID('PUNTO_ZIP.SP_Create_Rol') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[SP_Create_Rol]
GO

IF OBJECT_ID('PUNTO_ZIP.SP_Update_Rol') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[SP_Update_Rol]
GO

IF OBJECT_ID('PUNTO_ZIP.SP_Update_Funcionalidad_Por_Rol') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[SP_Update_Funcionalidad_Por_Rol]
GO

IF OBJECT_ID('PUNTO_ZIP.PR_INHABILITAR_ROL') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[PR_INHABILITAR_ROL]
GO

IF OBJECT_ID('PUNTO_ZIP.SP_Get_Funcionalidades_Rol') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[SP_Get_Funcionalidades_Rol]
GO

IF OBJECT_ID('PUNTO_ZIP.PR_Get_Funcionalidades') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[PR_Get_Funcionalidades]
GO

IF OBJECT_ID('PUNTO_ZIP.PR_Get_Roles') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[PR_Get_Roles]
GO
IF OBJECT_ID('PUNTO_ZIP.SP_Get_Usuario_Rol') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[SP_Get_Usuario_Rol]
GO

IF OBJECT_ID('PUNTO_ZIP.[PR_Get_Empresas]') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.[PR_Get_Empresas]
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
DROP TABLE [PUNTO_ZIP].CLIENTE
GO

IF OBJECT_ID('PUNTO_ZIP.EMPRESA') IS NOT NULL
DROP TABLE [PUNTO_ZIP].EMPRESA
GO

IF OBJECT_ID('PUNTO_ZIP.RUBRO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].RUBRO
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

CREATE TABLE PUNTO_ZIP.RUBRO(
	rubro_id int PRIMARY KEY IDENTITY(1,1),
	rubro_descripcion nvarchar(50) NOT NULL
)
GO

CREATE TABLE [PUNTO_ZIP].EMPRESA(
	empresa_id int PRIMARY KEY IDENTITY(1,1),
	empresa_nombre nvarchar(255) NOT NULL,
	empresa_cuit nvarchar(50) NOT NULL,
	empresa_direccion nvarchar(255) NOT NULL,
	empresa_rubro int FOREIGN KEY REFERENCES PUNTO_ZIP.RUBRO NOT NULL,
	empresa_habilitada BIT NOT NULL
)
GO

------------------------------PROCEDURES-------------------------

------------------------------LOGIN------------------------------
INSERT INTO PUNTO_ZIP.USUARIO
(usuario_username, usuario_password, usuario_activo) VALUES ('admin', HASHBYTES('SHA2_256','w23e'),1);
GO

INSERT INTO PUNTO_ZIP.ROL
(rol_habilitado, rol_nombre) VALUES (1, 'Administrador')
GO

INSERT INTO PUNTO_ZIP.ROL
(rol_habilitado, rol_nombre) VALUES (1, 'Cobrador')
GO

INSERT INTO PUNTO_ZIP.ROL_POR_USUARIO
(rol_id, usuario_id) VALUES (1,1)
GO

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

CREATE PROCEDURE [PUNTO_ZIP].PR_USUARIO_LOGUEADO @USERNAME NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE usuario_username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET usuario_intentosLogin = 0, usuario_activo = 1 WHERE usuario_username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].[SP_Get_Usuario_Rol]
  @idUsuario INT
AS
  BEGIN TRY
    SELECT R.rol_nombre Nombre, RU.rol_id ID FROM [PUNTO_ZIP].ROL_POR_USUARIO RU
    INNER JOIN [PUNTO_ZIP].ROL R
        ON RU.rol_id = R.rol_id
    WHERE RU.usuario_id = @idUsuario
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

CREATE PROCEDURE [PUNTO_ZIP].PR_INSERTAR_MODIFICAR_CLIENTE @NOMBRE NVARCHAR (255),@APELLIDO NVARCHAR (255),@DNI BIGINT,@DIRECCION NVARCHAR (255), @CODIGOPOSTAL NVARCHAR (255),@TELEFONO NVARCHAR (255),@MAIL NVARCHAR (255),@FECHANAC DATETIME,@HABILITADO BIT
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM CLIENTE WHERE CLIENTE.cliente_dni = @DNI)) --NUEVO CLIENTE
		INSERT INTO [PUNTO_ZIP].CLIENTE(cliente_nombre,cliente_apellido,cliente_dni,cliente_direccion,cliente_codigo_postal,cliente_telefono,cliente_mail,cliente_fechaNac,cliente_activo) VALUES(@NOMBRE ,@APELLIDO ,@DNI,@DIRECCION,@CODIGOPOSTAL,@TELEFONO,@MAIL,@FECHANAC,@HABILITADO)
	ELSE
		UPDATE [PUNTO_ZIP].CLIENTE SET cliente_apellido = @APELLIDO,cliente_direccion = @DIRECCION,cliente_codigo_postal=@CODIGOPOSTAL,cliente_dni = @DNI,cliente_fechaNac = @FECHANAC,cliente_mail = @MAIL,cliente_nombre = @NOMBRE,cliente_telefono = @TELEFONO,cliente_activo = @HABILITADO WHERE cliente_dni = @DNI
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
------------------------------ABM ROL------------------------------

CREATE PROCEDURE [PUNTO_ZIP].[SP_Create_Rol]
  @nombre_rol VARCHAR(255),
  @habilitado BIT
AS
  BEGIN TRY
    INSERT INTO [PUNTO_ZIP].ROL (rol_habilitado, rol_nombre) VALUES(@habilitado, @nombre_rol);

	SELECT SCOPE_IDENTITY();
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].[SP_Update_Rol]
  @ID NVARCHAR(255),
  @habilitado BIT,
  @nuevo_nombre VARCHAR(255)
AS
  BEGIN TRY
	 UPDATE [PUNTO_ZIP].ROL SET rol_habilitado = @habilitado, rol_nombre = @nuevo_nombre WHERE rol_id = @ID
	  IF(@habilitado = 0 )
		DELETE FROM [PUNTO_ZIP].ROL_POR_USUARIO WHERE rol_id = @ID
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
 GO
 
CREATE PROCEDURE [PUNTO_ZIP].[SP_Update_Funcionalidad_Por_Rol]
  @ID_Rol INTEGER,
  @funcionalidad_nombre VARCHAR(255),
  @habilitado bit
AS
  BEGIN TRY
    DECLARE @ID_Funcionalidad NUMERIC(18)
    DECLARE @ID_Rol_Aux NUMERIC(18)
    DECLARE @ID_Funcionalidad_Aux NUMERIC(18)

    SELECT @ID_Funcionalidad = funcionalidad_id FROM [PUNTO_ZIP].FUNCIONALIDAD WHERE funcionalidad_descripcion = @funcionalidad_nombre

    SELECT @ID_Rol_Aux = rol_id, @ID_Funcionalidad_Aux = funcionalidad_id FROM [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD WHERE rol_id = @ID_Rol AND funcionalidad_id = @ID_Funcionalidad

    IF @ID_Rol_Aux IS NOT NULL AND @ID_Funcionalidad_Aux IS NOT NULL
	BEGIN
	  IF(@habilitado = 0)
		 DELETE FROM [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD WHERE funcionalidad_id = @ID_Funcionalidad_Aux AND rol_id = @ID_Rol_Aux
    END
	ELSE IF @habilitado = 1
      INSERT INTO [PUNTO_ZIP].[ROL_POR_FUNCIONALIDAD](funcionalidad_id, rol_id) VALUES (@ID_Funcionalidad, @ID_Rol)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].PR_INHABILITAR_ROL @ID_ROL INT
AS
DECLARE @NOMBRE_ROL NVARCHAR(50)
BEGIN TRY
	UPDATE [PUNTO_ZIP].ROL SET rol_habilitado = 0 WHERE rol_id = @ID_ROL

	DELETE FROM [PUNTO_ZIP].ROL_POR_USUARIO WHERE rol_id = @ID_ROL
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].[SP_Get_Funcionalidades_Rol]
  @nombre_rol VARCHAR(255)
AS
  BEGIN TRY
    SELECT f.funcionalidad_descripcion AS Funcionalidad FROM [PUNTO_ZIP].ROL_POR_FUNCIONALIDAD AS rf
      INNER JOIN [PUNTO_ZIP].FUNCIONALIDAD AS f
      ON f.funcionalidad_id = rf.funcionalidad_id
      INNER JOIN [PUNTO_ZIP].ROL AS r
      ON rf.rol_id = r.rol_id
        WHERE r.rol_nombre = @nombre_rol
    ORDER BY Funcionalidad
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Funcionalidades]
AS
  BEGIN TRY
	SELECT F.funcionalidad_descripcion AS Funcionalidades FROM [PUNTO_ZIP].FUNCIONALIDAD F
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Roles]
AS
  BEGIN TRY
	SELECT R.rol_id ID, R.rol_nombre Rol,R.rol_habilitado Habilitado FROM [PUNTO_ZIP].ROL R
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
----------------------------------EMPRESAS-----------------------------------------------
CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Empresas]
AS
  BEGIN TRY
	SELECT e.empresa_nombre Nombre, e.empresa_cuit Cuit, e.empresa_direccion Direccion, r.rubro_descripcion Rubro  FROM [PUNTO_ZIP].EMPRESA e
	 INNER JOIN [PUNTO_ZIP].RUBRO AS r
      ON r.rubro_id = e.empresa_rubro
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO