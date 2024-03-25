use [Pagina Web _ Martes];

-- --------------------------------------------------------------------------------------------------
-- PROCEDURE DE REGISTRAR USUARIO

CREATE PROCEDURE RegistrarUsuario
	@Identificacion varchar(20),
	@Contrasenna varchar(10),
	@Nombre varchar(200),
	@CorreoElectronico varchar(200)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM dbo.tUsuario WHERE Identificacion = @Identificacion)
	BEGIN
		DECLARE @Estado INT = 1

		Insert into dbo.tUsuario (Identificacion, Contrasenna, Nombre, CorreoElectronico, Estado)
		Values (@Identificacion, @Contrasenna, @Nombre, @CorreoElectronico, @Estado)
	END
END
GO

-- --------------------------------------------------------------------------------------------------
-- PROCEDURE DE INICIAR SESION DE USUARIO

CREATE PROCEDURE IniciarSesionUsuario
	@Identificacion varchar(20),
	@Contrasenna varchar(10)
AS
BEGIN

	DECLARE @ESTADO INT = 1

	SELECT Consecutivo, Identificacion, Contrasenna, Nombre, CorreoElectronico, Estado
	FROM dbo.tUsuario
	WHERE Identificacion = @Identificacion 
	and Contrasenna = @Contrasenna 
	AND Estado = @Estado
END
GO

-- --------------------------------------------------------------------------------------------------
-- PROCEDURE DE RECUPERAR ACCESO DE USUARIO

CREATE PROCEDURE [dbo].[RecuperarAccesoUsuario]
	@Identificacion		varchar(20),
    @CorreoElectronico	varchar(200)
AS
BEGIN

	DECLARE @Consecutivo BIGINT

	SELECT	@Consecutivo = Consecutivo
	FROM	dbo.tUsuario WHERE	Identificacion = @Identificacion 
						AND CorreoElectronico = @CorreoElectronico
						AND Estado = 1

	IF @Consecutivo IS NOT NULL
	BEGIN
		UPDATE	tUsuario
		SET		Contrasenna = LEFT(NEWID(),8),
				Temporal = 1,
				Vencimiento = DATEADD(HOUR, 1, GETDATE())  
		WHERE	Consecutivo = @Consecutivo
	END

	SELECT	Consecutivo,Identificacion,Contrasenna,Nombre,CorreoElectronico,Estado,Temporal,Vencimiento
	FROM	dbo.tUsuario
	WHERE	Consecutivo = @Consecutivo

END
GO

-- --------------------------------------------------------------------------------------------------
-- PROCEDURE DE CONSULTAR PRODUCTOS

CREATE PROCEDURE [dbo].[ConsultarProductos]
	@MostrarTodos BIT
AS
BEGIN

	IF(@MostrarTodos = 1)
	BEGIN
		SELECT	Consecutivo, P.Nombre 'NombreProducto', Precio, Inventario, Estado, RutaImagen, P.IdCategoria, C.Nombre 'NombreCategoria'
		FROM	tProducto P
		INNER JOIN	tCategoria C ON P.IdCategoria = C.IdCategoria
	END
	ELSE
	BEGIN
		SELECT	Consecutivo, P.Nombre 'NombreProducto', Precio, Inventario, Estado, RutaImagen, P.IdCategoria, C.Nombre 'NombreCategoria'
		FROM	tProducto P
		INNER JOIN	tCategoria C ON P.IdCategoria = C.IdCategoria
		WHERE	Inventario > 0
			AND Estado = 1
	END
END
GO

-- --------------------------------------------------------------------------------------------------
-- CREACION DE USUARIOS

CREATE TABLE [dbo].[tUsuario](
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[CorreoElectronico] [varchar](200) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Temporal] [bit] NOT NULL,
	[Vencimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- --------------------------------------------------------------------------------------------------
-- CREACION DE CATEGORIAS

CREATE TABLE [dbo].[tCategoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tCategorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- --------------------------------------------------------------------------------------------------
-- CREACION DE PRODUCTOS

CREATE TABLE [dbo].[tProducto](
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Inventario] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[RutaImagen] [varchar](200) NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_tProducto] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- --------------------------------------------------------------------------------------------------
-- INSERTS

SET IDENTITY_INSERT [dbo].[tCategoria] ON 
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (1, N'Periféricos')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (2, N'Procesadores')
GO
INSERT [dbo].[tCategoria] ([IdCategoria], [Nombre]) VALUES (3, N'Almacenamiento')
GO
SET IDENTITY_INSERT [dbo].[tCategoria] OFF
GO

SET IDENTITY_INSERT [dbo].[tProducto] ON 
GO
INSERT [dbo].[tProducto] ([Consecutivo], [Nombre], [Precio], [Inventario], [Estado], [RutaImagen], [IdCategoria]) VALUES (1, N'Mouse', CAST(5000.00 AS Decimal(10, 2)), 5, 1, N'PRUEBA', 1)
GO
INSERT [dbo].[tProducto] ([Consecutivo], [Nombre], [Precio], [Inventario], [Estado], [RutaImagen], [IdCategoria]) VALUES (2, N'Intel', CAST(30000.00 AS Decimal(10, 2)), 3, 1, N'PRUEBA', 2)
GO
INSERT [dbo].[tProducto] ([Consecutivo], [Nombre], [Precio], [Inventario], [Estado], [RutaImagen], [IdCategoria]) VALUES (3, N'SSD', CAST(15000.00 AS Decimal(10, 2)), 0, 1, N'PRUEBA', 3)
GO
SET IDENTITY_INSERT [dbo].[tProducto] OFF
GO