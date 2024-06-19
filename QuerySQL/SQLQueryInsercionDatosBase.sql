--INSERT dbo.Categoria ([Nombre] ) 
--VALUES ( 'Bebidas' )

--INSERT dbo.Categoria ([Nombre] ) 
--VALUES ( 'Comestibles' )

--INSERT dbo.Categoria ([Nombre] ) 
--VALUES ( 'Lacteos' )

--INSERT dbo.Categoria ([Nombre] ) 
--VALUES ( 'Art. Limpieza' )

--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Coca Cola', 1, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Sprite', 1, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Fanta', 1, 1)

--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Fideos', 2, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Galletitas', 2, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Arroz', 2, 1)

--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Leche', 3, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Yogurt', 3, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Manteca', 3, 1)

--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Jabón', 4, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Lavandina', 4, 1)
--INSERT [dbo].[Producto] ([Nombre], [CategoriaId], [Habilitado] ) 
--VALUES ('Perfumina Poett', 4, 1)

--La contraseña para ambos casos es 123456

--bebidas
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 1, 5, 1)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 2, 3, 1)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 3, 3, 1)
--Comestibles
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 4, 10, 2)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 5, 8, 2)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240610', 6, 6, 2)
--Lacteos
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 7, 10, 3)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 8, 5, 3)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 9, 7, 3)

--Art Limpieza
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 10, 10, 3)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 11, 12, 3)
INSERT [dbo].[Compra] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 12, 16, 3)

--Ventas----------------------------------------------------
--bebidas
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 1, 2, 1)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 2, 1, 1)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 3, 1, 1)
--Comestibles
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 4, 7, 2)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 5, 8, 2)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 6, 3, 2)
--Lacteos
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 7, 8, 3)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 8, 2, 3)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240612', 9, 3, 3)

--Art Limpieza
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 10, 4, 3)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 11, 1, 3)
INSERT [dbo].[Venta] ([Fecha], [ProductoId], [Cantidad], [UsuarioId]) 
VALUES ('20240611', 12, 2, 3)
