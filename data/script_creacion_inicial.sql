USE [GD2C2017]
GO

-------------------------------DROP PROCEDURES----------------------------

IF OBJECT_ID('[PUNTO_ZIP].PR_LOGIN') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].PR_LOGIN
GO

IF OBJECT_ID('PUNTO_ZIP.PR_BLOQUEAR_USUARIO') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.PR_BLOQUEAR_USUARIO;
GO


IF OBJECT_ID('PUNTO_ZIP.PR_USUARIO_LOGUEADO') IS NOT NULL
DROP PROCEDURE PUNTO_ZIP.PR_USUARIO_LOGUEADO
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

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Datos') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Datos
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Clientes') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Clientes
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Empresas') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Empresas
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Facturas') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Facturas
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Items_Factura') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Items_Factura
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Medios_Pago') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Medios_Pago
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Pagos') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Pagos
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Rendiciones') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Rendiciones
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Rubros') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Rubros
GO

IF OBJECT_ID('[PUNTO_ZIP].SP_Migrar_Sucursales') IS NOT NULL
DROP PROCEDURE [PUNTO_ZIP].SP_Migrar_Sucursales
GO

------------------------------DROP DE TABLAS------------------------------

IF OBJECT_ID('PUNTO_ZIP.USUARIO_ROL') IS NOT NULL
DROP TABLE [PUNTO_ZIP].USUARIO_ROL
GO


IF OBJECT_ID('PUNTO_ZIP.USUARIO_SUCURSAL') IS NOT NULL
DROP TABLE [PUNTO_ZIP].USUARIO_SUCURSAL
GO

IF OBJECT_ID('PUNTO_ZIP.ROL_FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL_FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.PAGO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].PAGO
GO

IF OBJECT_ID('PUNTO_ZIP.MEDIO_PAGO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].MEDIO_PAGO
GO

IF OBJECT_ID('PUNTO_ZIP.DEVOLUCION_FACTURA') IS NOT NULL
DROP TABLE [PUNTO_ZIP].DEVOLUCION_FACTURA
GO

IF OBJECT_ID('PUNTO_ZIP.DEVOLUCION_RENDICION') IS NOT NULL
DROP TABLE [PUNTO_ZIP].DEVOLUCION_RENDICION
GO

IF OBJECT_ID('PUNTO_ZIP.ITEM_FACTURA') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ITEM_FACTURA
GO

IF OBJECT_ID('PUNTO_ZIP.FACTURA') IS NOT NULL
DROP TABLE [PUNTO_ZIP].FACTURA
GO

IF OBJECT_ID('PUNTO_ZIP.EMPRESA') IS NOT NULL
DROP TABLE [PUNTO_ZIP].EMPRESA
GO

IF OBJECT_ID('PUNTO_ZIP.RUBRO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].RUBRO
GO

IF OBJECT_ID('PUNTO_ZIP.CLIENTE') IS NOT NULL
DROP TABLE [PUNTO_ZIP].CLIENTE
GO

IF OBJECT_ID('PUNTO_ZIP.FUNCIONALIDAD') IS NOT NULL
DROP TABLE [PUNTO_ZIP].FUNCIONALIDAD
GO

IF OBJECT_ID('PUNTO_ZIP.ROL') IS NOT NULL
DROP TABLE [PUNTO_ZIP].ROL
GO

IF OBJECT_ID('PUNTO_ZIP.SUCURSAL') IS NOT NULL
DROP TABLE [PUNTO_ZIP].SUCURSAL
GO

IF OBJECT_ID('PUNTO_ZIP.RENDICION') IS NOT NULL
DROP TABLE [PUNTO_ZIP].RENDICION
GO

IF OBJECT_ID('PUNTO_ZIP.USUARIO') IS NOT NULL
DROP TABLE [PUNTO_ZIP].USUARIO
GO

---- DROP CONSTAINTS -------

IF OBJECT_ID('PUNTO_ZIP.PK_ROL') IS NOT NULL
ALTER TABLE PUNTO_ZIP.ROL  DROP PK_ROL
GO

IF OBJECT_ID('PUNTO_ZIP.PK_Usuario') IS NOT NULL
ALTER TABLE PUNTO_ZIP.USUARIO  DROP PK_Usuario
GO



------------------------------DROP SCHEMA------------------------------------
IF SCHEMA_ID('PUNTO_ZIP') IS NOT NULL
	DROP SCHEMA [PUNTO_ZIP]
GO

CREATE SCHEMA [PUNTO_ZIP]
GO


CREATE PROCEDURE [PUNTO_ZIP].[PR_BAJA_CLIENTE] @DNI nvarchar(50)
AS
BEGIN TRY
	UPDATE [PUNTO_ZIP].CLIENTE SET activo = 0 WHERE CLIENTE.dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_BUSCAR_CLIENTE_POR_DNI]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_BUSCAR_CLIENTE_POR_DNI] @DNI nvarchar(50)
AS
BEGIN TRY
	SELECT *
	FROM [PUNTO_ZIP].CLIENTE C
	WHERE C.dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_Get_Empresas]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Empresas]
AS
  BEGIN TRY
	SELECT e.nombre Nombre, e.cuit Cuit, e.direccion Direccion, 
	r.nombre Rubro FROM [PUNTO_ZIP].EMPRESA e
	 INNER JOIN [PUNTO_ZIP].RUBRO AS r
      ON r.id = e.id_rubro
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_Get_Funcionalidades]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Funcionalidades]
AS
  BEGIN TRY
	SELECT F.nombre AS Funcionalidades FROM [PUNTO_ZIP].FUNCIONALIDAD F
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_Get_Roles]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_Get_Roles]
AS
  BEGIN TRY
	SELECT R.id ID, R.nombre Rol,R.activo Habilitado FROM [PUNTO_ZIP].ROL R
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_INHABILITAR_ROL]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_INHABILITAR_ROL] @ID_ROL INT
AS
DECLARE @NOMBRE_ROL NVARCHAR(50)
BEGIN TRY
	UPDATE [PUNTO_ZIP].ROL SET activo = 0 WHERE id = @ID_ROL

	DELETE FROM [PUNTO_ZIP].Usuario_Rol WHERE id_rol = @ID_ROL
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_INSERTAR_MODIFICAR_CLIENTE]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_INSERTAR_MODIFICAR_CLIENTE]
	@NOMBRE NVARCHAR (50),
	@APELLIDO NVARCHAR (50),
	@DNI NVARCHAR (50),
	@DIRECCION NVARCHAR (50),
	 @CODIGOPOSTAL NVARCHAR (50),
	 @MAIL NVARCHAR (50),
	 @FECHANAC DATE,
	 @ACTIVO BIT
AS
BEGIN TRY
	IF(NOT EXISTS(SELECT 1 FROM CLIENTE WHERE CLIENTE.dni = @DNI)) --NUEVO CLIENTE
		INSERT INTO [PUNTO_ZIP].CLIENTE(nombre,apellido,dni,direccion,codigo_postal,mail,fecha_nacimiento,activo) VALUES(@NOMBRE ,@APELLIDO ,@DNI,@DIRECCION,@CODIGOPOSTAL,@MAIL,@FECHANAC,@ACTIVO)
	ELSE
		UPDATE [PUNTO_ZIP].CLIENTE 
		SET apellido = @APELLIDO,direccion = @DIRECCION,codigo_postal=@CODIGOPOSTAL,dni = @DNI,
		fecha_nacimiento = @FECHANAC,mail = @MAIL,nombre = @NOMBRE,activo = @ACTIVO WHERE dni = @DNI
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_LISTADO_SELECCION_ABM_CLIENTE]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE	 PROCEDURE [PUNTO_ZIP].[PR_LISTADO_SELECCION_ABM_CLIENTE] 
	@NOMBRE NVARCHAR(50),@APELLIDO NVARCHAR(50),@DNI NVARCHAR(50)
AS
BEGIN TRY
	SELECT *, nombre + ' ' + apellido NombreCompleto
	FROM [PUNTO_ZIP].CLIENTE c 
	WHERE
	(@NOMBRE = '' OR @NOMBRE is null OR  lower(c.nombre) LIKE '%' + lower(@NOMBRE) + '%') AND
	(@APELLIDO = '' OR @APELLIDO is null OR lower(c.apellido) LIKE '%' + lower(@APELLIDO) + '%') AND
	(@DNI = '' OR @DNI is null OR c.dni = @DNI) AND activo = 1;
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_LOGIN]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_LOGIN] @USERNAME NVARCHAR(50),@PASSWORD VARCHAR(50)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET intentos_login = intentos_login + 1 WHERE username = @USERNAME;

		SELECT	U.password Password, 
				U.username Username, 
				U.activo Activo, 
				U.id Id, 
				U.intentos_login Intentos,  
				(CASE WHEN U.password = HashBytes('SHA2_256', @PASSWORD) THEN 1 ELSE 0 END) PasswordMatched
		FROM [PUNTO_ZIP].USUARIO U WHERE username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH

GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[PR_USUARIO_LOGUEADO]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[PR_USUARIO_LOGUEADO] @USERNAME NVARCHAR(50)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET intentos_login = 0, activo = 1 WHERE username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [PUNTO_ZIP].PR_BLOQUEAR_USUARIO @USERNAME NVARCHAR(255)
AS
BEGIN TRY
	IF (EXISTS(SELECT 1 FROM USUARIO WHERE username = @USERNAME))
	BEGIN
		UPDATE USUARIO SET intentos_login = 0, activo = 0 WHERE username = @USERNAME;
	END
END TRY
BEGIN CATCH
  SELECT 'ERROR', ERROR_MESSAGE()
END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[SP_Create_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Create_Rol]
  @nombre_rol VARCHAR(255),
  @activo BIT
AS
  BEGIN TRY
    INSERT INTO [PUNTO_ZIP].ROL (activo, nombre) VALUES(@activo, @nombre_rol);

	SELECT SCOPE_IDENTITY();
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[SP_Get_Funcionalidades_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Get_Funcionalidades_Rol]
  @nombre_rol VARCHAR(50)
AS
  BEGIN TRY
    SELECT f.nombre AS Funcionalidad FROM [PUNTO_ZIP].Rol_Funcionalidad AS rf
      INNER JOIN [PUNTO_ZIP].FUNCIONALIDAD AS f
      ON f.id = rf.id_funcionalidad
      INNER JOIN [PUNTO_ZIP].ROL AS r
      ON rf.id_rol = r.id
        WHERE r.nombre = @nombre_rol
    ORDER BY Funcionalidad
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[SP_Get_Usuario_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Get_Usuario_Rol]
  @id_usuario INT
AS
  BEGIN TRY
    SELECT R.nombre Nombre, RU.id_rol ID FROM [PUNTO_ZIP].Usuario_Rol RU
    INNER JOIN [PUNTO_ZIP].ROL R
        ON RU.id_rol = R.id
    WHERE RU.id_usuario = @id_usuario
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[SP_Update_Funcionalidad_Por_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Update_Funcionalidad_Por_Rol]
  @ID_Rol int,
  @funcionalidad_nombre VARCHAR(50),
  @activo bit
AS
  BEGIN TRY
    DECLARE @ID_Funcionalidad NUMERIC(18)
    DECLARE @ID_Rol_Aux NUMERIC(18)
    DECLARE @ID_Funcionalidad_Aux NUMERIC(18)

    SELECT @ID_Funcionalidad = id FROM [PUNTO_ZIP].FUNCIONALIDAD WHERE nombre = @funcionalidad_nombre

    SELECT @ID_Rol_Aux = id_rol, @ID_Funcionalidad_Aux = id_funcionalidad FROM [PUNTO_ZIP].Rol_Funcionalidad 
	WHERE id_rol = @ID_Rol AND id_funcionalidad = @ID_Funcionalidad

    IF @ID_Rol_Aux IS NOT NULL AND @ID_Funcionalidad_Aux IS NOT NULL
	BEGIN
	  IF(@activo = 0)
		 DELETE FROM [PUNTO_ZIP].Rol_Funcionalidad
		 WHERE id_funcionalidad = @ID_Funcionalidad_Aux AND id_rol = @ID_Rol_Aux
    END
	ELSE IF @activo = 1
      INSERT INTO [PUNTO_ZIP].Rol_Funcionalidad(id_funcionalidad, id_rol) VALUES (@ID_Funcionalidad, @ID_Rol)
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO
/****** Object:  StoredProcedure [PUNTO_ZIP].[SP_Update_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Update_Rol]
  @ID NVARCHAR(50),
  @activo BIT,
  @nuevo_nombre VARCHAR(50)
AS
  BEGIN TRY
	 UPDATE [PUNTO_ZIP].ROL SET activo = @activo, nombre = @nuevo_nombre WHERE id = @ID
	  IF(@activo = 0 )
		DELETE FROM [PUNTO_ZIP].Usuario_Rol WHERE id_rol = @ID
  END TRY
  BEGIN CATCH
    SELECT 'ERROR', ERROR_MESSAGE()
  END CATCH
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Clientes]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Cliente (nombre, apellido, dni, mail, direccion, codigo_postal, fecha_nacimiento, activo)
	(SELECT DISTINCT [Cliente-Nombre], [Cliente-Apellido],CAST([Cliente-Dni] AS nvarchar(255)),
					Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, [Cliente-Fecha_Nac], 1 activo
	FROM gd_esquema.Maestra
	GROUP BY [Cliente-Nombre], [Cliente-Apellido],CAST([Cliente-Dni] AS nvarchar(255)),
						  Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, [Cliente-Fecha_Nac])
				
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Empresas]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Empresa (nombre, direccion, cuit, activo, id_rubro)
	SELECT DISTINCT
		Empresa_Nombre, Empresa_Direccion, Empresa_Cuit, 1,
		(SELECT id FROM PUNTO_ZIP.Rubro WHERE nombre = m.Rubro_Descripcion)
	FROM gd_esquema.Maestra m
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Facturas]

AS
BEGIN
	INSERT INTO PUNTO_ZIP.Factura (numero_factura, fecha_alta, fecha_vencimiento, total, id_cliente , id_empresa)
	SELECT DISTINCT
		Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, Factura_Total,
		(SELECT id FROM PUNTO_ZIP.Cliente c WHERE c.dni = ma.[Cliente-Dni]) id_cliente,
		(SELECT id FROM PUNTO_ZIP.Empresa e WHERE e.cuit = ma.Empresa_Cuit AND e.nombre = ma.Empresa_Nombre) id_empresa
	FROM gd_esquema.Maestra ma;
	UPDATE PUNTO_ZIP.Factura
	SET id_rendicion = (SELECT DISTINCT TOP 1 id FROM PUNTO_ZIP.Rendicion r
						  INNER JOIN gd_esquema.Maestra m ON r.numero = m.Rendicion_Nro
						  WHERE m.Nro_Factura = numero_factura);
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Items_Factura]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Item_Factura (monto, cantidad, id_factura)
	SELECT ItemFactura_Monto, ItemFactura_Cantidad,
	  (SELECT id FROM PUNTO_ZIP.Factura f where f.numero_factura = m.Nro_Factura) id_factura
	FROM gd_esquema.Maestra m
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Medios_Pago]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Medio_Pago(nombre) 
	SELECT DISTINCT FormaPagoDescripcion FROM gd_esquema.Maestra WHERE FormaPagoDescripcion IS NOT NULL
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Pagos]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Pago (numero, fecha, importe, id_factura, id_medio_pago, id_sucursal, id_cliente)
	SELECT DISTINCT Pago_nro, Pago_Fecha, Total,
			(SELECT id FROM PUNTO_ZIP.Factura f WHERE f.numero_factura = m.Nro_Factura) id_factura,
			(SELECT id FROM PUNTO_ZIP.Medio_Pago mp WHERE mp.nombre = m.FormaPagoDescripcion) id_medio_pago,
			(SELECT id FROM PUNTO_ZIP.Sucursal s WHERE s.nombre = m.Sucursal_Nombre) id_sucursal,
			(SELECT id FROM PUNTO_ZIP.Cliente c WHERE c.dni = m.[Cliente-Dni]) id_cliente
	FROM gd_esquema.Maestra m
	WHERE Pago_nro IS NOT NULL
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Rendiciones]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Rendicion (numero, fecha_rendicion, porcentaje_comision)
	(SELECT DISTINCT Rendicion_Nro, Rendicion_Fecha , (( ItemRendicion_Importe / Factura_Total) * 100) comision
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro IS NOT NULL);
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Rubros]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Rubro (nombre)
	SELECT DISTINCT Rubro_Descripcion FROM gd_esquema.Maestra GROUP BY Rubro_Descripcion
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Sucursales]
AS
BEGIN
	INSERT INTO PUNTO_ZIP.Sucursal (nombre, direccion, codigo_postal, activo)
	SELECT DISTINCT Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal, 1 activo
	FROM gd_esquema.Maestra
	WHERE Sucursal_Nombre IS NOT NULL
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PUNTO_ZIP].[SP_Migrar_Datos]
AS
BEGIN
	EXEC PUNTO_ZIP.SP_Migrar_Rubros;
	EXEC PUNTO_ZIP.SP_Migrar_Empresas;
	EXEC PUNTO_ZIP.SP_Migrar_Sucursales;
	EXEC PUNTO_ZIP.SP_Migrar_Medios_Pago;
	EXEC PUNTO_ZIP.SP_Migrar_Clientes;
	EXEC PUNTO_ZIP.SP_Migrar_Rendiciones;
	EXEC PUNTO_ZIP.SP_Migrar_Facturas;
	EXEC PUNTO_ZIP.SP_Migrar_Items_Factura;
	EXEC PUNTO_ZIP.SP_Migrar_Pagos;
END

/****** Object:  Table [PUNTO_ZIP].[Cliente]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[dni] [nvarchar](255) NOT NULL,
	[mail] [nvarchar](255) NOT NULL,
	[direccion] [nvarchar](255) NOT NULL,
	[codigo_postal] [nvarchar](255) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[activo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Devolucion_Factura]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Devolucion_Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[motivo] [text] NULL,
	[informacion_adicional] [text] NULL,
	[id_usuario] [int] NULL,
	[id_factura] [int] NULL,
 CONSTRAINT [PK_Devolucion_Factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Devolucion_Rendicion]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Devolucion_Rendicion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[motivo] [text] NULL,
	[informacion_adicional] [text] NULL,
	[id_usuario] [int] NULL,
	[id_rendicion] [int] NULL,
 CONSTRAINT [PK_Devolucion_Rendicion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Empresa]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Empresa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[cuit] [nvarchar](30) NOT NULL,
	[activo] [tinyint] NOT NULL,
	[id_rubro] [int] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Factura]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero_factura] [nvarchar](50) NOT NULL,
	[fecha_alta] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[total] [decimal](18, 0) NULL,
	[id_empresa] [int] NOT NULL,
	[id_rendicion] [int] NULL,
	[id_cliente] [int] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Funcionalidad]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Funcionalidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Item_Factura]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Item_Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[monto] [decimal](18, 0) NULL,
	[cantidad] [int] NULL,
	[id_factura] [int] NULL,
 CONSTRAINT [PK_Item_Factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Medio_Pago]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Medio_Pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Medio_Pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Pago]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [numeric](18, 0) NOT NULL,
	[fecha] [date] NOT NULL,
	[importe] [decimal](18, 0) NOT NULL,
	[id_usuario] [int] NULL,
	[id_sucursal] [int] NOT NULL,
	[id_medio_pago] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Rendicion]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Rendicion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [nvarchar](50) NOT NULL,
	[fecha_rendicion] [date] NOT NULL,
	[porcentaje_comision] [float] NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[activo] [tinyint] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Rol_Funcionalidad]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Rol_Funcionalidad](
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL,
 CONSTRAINT [PK_Rol_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_funcionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Rubro]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Rubro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Sucursal]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Sucursal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[codigo_postal] [nvarchar](50) NOT NULL,
	[activo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Usuario]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[intentos_login] [int] NOT NULL,
	[activo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Usuario_Rol]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Usuario_Rol](
	[id_usuario] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Rol] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [PUNTO_ZIP].[Usuario_Sucursal]    Script Date: 19/11/2017 10:56:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PUNTO_ZIP].[Usuario_Sucursal](
	[id_usuario] [int] NOT NULL,
	[id_sucursal] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Sucursal] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Factura_Factura] FOREIGN KEY([id_factura])
REFERENCES [PUNTO_ZIP].[Factura] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Factura] CHECK CONSTRAINT [FK_Devolucion_Factura_Factura]
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Factura_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [PUNTO_ZIP].[Usuario] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Factura] CHECK CONSTRAINT [FK_Devolucion_Factura_Usuario]
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Rendicion_Rendicion] FOREIGN KEY([id_rendicion])
REFERENCES [PUNTO_ZIP].[Rendicion] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Rendicion] CHECK CONSTRAINT [FK_Devolucion_Rendicion_Rendicion]
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Rendicion_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [PUNTO_ZIP].[Usuario] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Devolucion_Rendicion] CHECK CONSTRAINT [FK_Devolucion_Rendicion_Usuario]
GO
ALTER TABLE [PUNTO_ZIP].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Rubro] FOREIGN KEY([id_rubro])
REFERENCES [PUNTO_ZIP].[Rubro] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Empresa] CHECK CONSTRAINT [FK_Empresa_Rubro]
GO
ALTER TABLE [PUNTO_ZIP].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [PUNTO_ZIP].[Cliente] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [PUNTO_ZIP].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empresa] FOREIGN KEY([id_empresa])
REFERENCES [PUNTO_ZIP].[Empresa] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Factura] CHECK CONSTRAINT [FK_Factura_Empresa]
GO
ALTER TABLE [PUNTO_ZIP].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Rendicion] FOREIGN KEY([id_rendicion])
REFERENCES [PUNTO_ZIP].[Rendicion] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Factura] CHECK CONSTRAINT [FK_Factura_Rendicion]
GO
ALTER TABLE [PUNTO_ZIP].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura] FOREIGN KEY([id_factura])
REFERENCES [PUNTO_ZIP].[Factura] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura]
GO
ALTER TABLE [PUNTO_ZIP].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [PUNTO_ZIP].[Cliente] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Pago] CHECK CONSTRAINT [FK_Pago_Cliente]
GO
ALTER TABLE [PUNTO_ZIP].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Factura] FOREIGN KEY([id_factura])
REFERENCES [PUNTO_ZIP].[Factura] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Pago] CHECK CONSTRAINT [FK_Pago_Factura]
GO
ALTER TABLE [PUNTO_ZIP].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Medio_Pago] FOREIGN KEY([id_medio_pago])
REFERENCES [PUNTO_ZIP].[Medio_Pago] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Pago] CHECK CONSTRAINT [FK_Pago_Medio_Pago]
GO
ALTER TABLE [PUNTO_ZIP].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Sucursal] FOREIGN KEY([id_sucursal])
REFERENCES [PUNTO_ZIP].[Sucursal] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Pago] CHECK CONSTRAINT [FK_Pago_Sucursal]
GO
ALTER TABLE [PUNTO_ZIP].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [PUNTO_ZIP].[Usuario] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Pago] CHECK CONSTRAINT [FK_Pago_Usuario]
GO
ALTER TABLE [PUNTO_ZIP].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES [PUNTO_ZIP].[Funcionalidad] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad]
GO
ALTER TABLE [PUNTO_ZIP].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Rol] FOREIGN KEY([id_rol])
REFERENCES [PUNTO_ZIP].[Rol] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Rol]
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Rol] FOREIGN KEY([id_rol])
REFERENCES [PUNTO_ZIP].[Rol] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Rol]
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [PUNTO_ZIP].[Usuario] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Usuario]
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Sucursal_Sucursal] FOREIGN KEY([id_sucursal])
REFERENCES [PUNTO_ZIP].[Sucursal] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Sucursal] CHECK CONSTRAINT [FK_Usuario_Sucursal_Sucursal]
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Sucursal_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [PUNTO_ZIP].[Usuario] ([id])
GO
ALTER TABLE [PUNTO_ZIP].[Usuario_Sucursal] CHECK CONSTRAINT [FK_Usuario_Sucursal_Usuario]
GO

EXEC PUNTO_ZIP.SP_Migrar_Datos;

USE [master]
GO

INSERT INTO PUNTO_ZIP.Usuario (username, password, nombre, intentos_login, activo)
VALUES ('admin', HashBytes('SHA2_256', 'w23e'), 'Administrador', 0, 1)
GO

INSERT INTO PUNTO_ZIP.Rol (nombre, activo)
VALUES ('Administrador', 1)
GO

INSERT INTO PUNTO_ZIP.Rol (nombre, activo)
VALUES ('Cobrador', 1)
GO

INSERT INTO PUNTO_ZIP.Usuario_Rol (id_usuario, id_rol)
VALUES (1,1)
GO

ALTER DATABASE [GD2C2017] SET  READ_WRITE 
GO

USE [GD2C2017]
GO
