USE [master]
GO
/****** Object:  Database [Pagina Web _ Martes]    Script Date: 4/2/2024 12:11:10 AM ******/
CREATE DATABASE [Pagina Web _ Martes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pagina Web _ Martes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Pagina Web _ Martes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pagina Web _ Martes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Pagina Web _ Martes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Pagina Web _ Martes] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pagina Web _ Martes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pagina Web _ Martes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pagina Web _ Martes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pagina Web _ Martes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pagina Web _ Martes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pagina Web _ Martes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET RECOVERY FULL 
GO
ALTER DATABASE [Pagina Web _ Martes] SET  MULTI_USER 
GO
ALTER DATABASE [Pagina Web _ Martes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pagina Web _ Martes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pagina Web _ Martes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pagina Web _ Martes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pagina Web _ Martes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pagina Web _ Martes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pagina Web _ Martes', N'ON'
GO
ALTER DATABASE [Pagina Web _ Martes] SET QUERY_STORE = ON
GO
ALTER DATABASE [Pagina Web _ Martes] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Pagina Web _ Martes]
GO
/****** Object:  Table [dbo].[tCategoria]    Script Date: 4/2/2024 12:11:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tCategorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProducto]    Script Date: 4/2/2024 12:11:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[tRol]    Script Date: 4/2/2024 12:11:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRol](
	[ConsecutivoRol] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NULL,
 CONSTRAINT [PK_tRol] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsuario]    Script Date: 4/2/2024 12:11:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsuario](
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[CorreoElectronico] [varchar](200) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Temporal] [bit] NOT NULL,
	[Vencimiento] [datetime] NOT NULL,
	[ConsecutivoRol] [bigint] NOT NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
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
INSERT [dbo].[tProducto] ([Consecutivo], [Nombre], [Precio], [Inventario], [Estado], [RutaImagen], [IdCategoria]) VALUES (6, N'Mouse RR', CAST(858.00 AS Decimal(10, 2)), 5, 1, N'/ImgProductos/6.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[tProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[tRol] ON 
GO
INSERT [dbo].[tRol] ([ConsecutivoRol], [NombreRol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[tRol] ([ConsecutivoRol], [NombreRol]) VALUES (2, N'Usuario')
GO
SET IDENTITY_INSERT [dbo].[tRol] OFF
GO
SET IDENTITY_INSERT [dbo].[tUsuario] ON 
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Contrasenna], [Nombre], [CorreoElectronico], [Estado], [Temporal], [Vencimiento], [ConsecutivoRol]) VALUES (1, N'119080132', N'123456', N'NUNEZ CHACON LUIS DANIEL', N'lnunez80132@ufide.ac.cr', 1, 0, CAST(N'2024-04-01T20:06:05.417' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tUsuario] OFF
GO
ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tUsuario_tRol] FOREIGN KEY([ConsecutivoRol])
REFERENCES [dbo].[tRol] ([ConsecutivoRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [FK_tUsuario_tRol]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarImagenProducto]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarImagenProducto]
	@Consecutivo BIGINT,
	@RutaImagen VARCHAR(200)
AS
BEGIN
	UPDATE [dbo].[tProducto]
	SET RutaImagen = @RutaImagen
	WHERE Consecutivo = @Consecutivo
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductos]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[ConsultarTiposCategoria]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTiposCategoria]
AS
BEGIN
	SELECT	IdCategoria, Nombre 'NombreCategoria'
	FROM	tCategoria 
END
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesionUsuario]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesionUsuario]
	@Identificacion varchar(20),
	@Contrasenna varchar(10)
AS
BEGIN

	DECLARE @ESTADO INT = 1

	SELECT Consecutivo,Identificacion,Contrasenna,Nombre,CorreoElectronico,Estado,Temporal,Vencimiento,ConsecutivoRol
	FROM dbo.tUsuario
	WHERE Identificacion = @Identificacion 
	and Contrasenna = @Contrasenna 
	AND Estado = @Estado
END
GO
/****** Object:  StoredProcedure [dbo].[RecuperarAccesoUsuario]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarProducto]
	@NombreProducto varchar(200),
	@Precio decimal(10,2),
	@Inventario int,
	@IdCategoria int
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM dbo.tUsuario WHERE Nombre = @NombreProducto)
	BEGIN
		DECLARE @Estado INT = 1

		Insert into [dbo].[tProducto] (Nombre, Precio, Inventario, Estado, RutaImagen, IdCategoria)
		Values (@NombreProducto, @Precio, @Inventario, @Estado, '', @IdCategoria)

		SELECT CONVERT(BIGINT,@@IDENTITY) Consecutivo
	END
	ELSE
	BEGIN
		SELECT CONVERT(BIGINT,-1) Consecutivo
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 4/2/2024 12:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@Identificacion varchar(20),
	@Contrasenna varchar(10),
	@Nombre varchar(200),
	@CorreoElectronico varchar(200)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM dbo.tUsuario WHERE Identificacion = @Identificacion)
	BEGIN
		DECLARE @Estado INT = 1

		Insert into dbo.tUsuario (Identificacion, Contrasenna, Nombre, CorreoElectronico, Estado, Temporal, Vencimiento,ConsecutivoRol)
		Values (@Identificacion, @Contrasenna, @Nombre, @CorreoElectronico, @Estado, 0, GETDATE(),2)
	END
END
GO
USE [master]
GO
ALTER DATABASE [Pagina Web _ Martes] SET  READ_WRITE 
GO
