Use GestionUno
Create TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Hash] [varchar](100) NULL,
	[Salt] [varchar](100) NULL
PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
) 
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[CategoriaId] [int] NULL,
	[Habilitado] [bit] NULL
	
PRIMARY KEY CLUSTERED ([ProductoId] ASC)
) 

CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL
	
PRIMARY KEY CLUSTERED ([CategoriaId] ASC)
) 

CREATE TABLE [dbo].[Compra](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [DateTime] NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NULL,
	[UsuarioId] [int] NULL
PRIMARY KEY CLUSTERED ([CompraId] ASC)
) 
CREATE TABLE [dbo].[Venta](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [DateTime] NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NULL,
	[UsuarioId] [int] NULL
PRIMARY KEY CLUSTERED ([VentaId] ASC)
) 
GO


