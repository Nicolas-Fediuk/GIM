use DB_Gim
go

/*---------------------------------------------------*/
			/*			Admin		*/
/*---------------------------------------------------*/

create procedure sp_ModificarAdmin
(
@NOMBRE varchar(30),
@CONTRASEÑA varchar(30)
)
as
update Admin
set
Nombre_ad = @NOMBRE,
Contraseña_ad = @CONTRASEÑA
return
go

/*---------------------------------------------------*/
	/*			Categorias Productos		*/
/*---------------------------------------------------*/

create procedure sp_AgregarCategoriasProductos
(
@DESCRIPCION varchar(30)
)
as
insert into CategoriasProductos(Descripcion_cp)
values (@DESCRIPCION)
return
go

create procedure sp_EliminarCategoriasProductos
(
@IDCATEGORIA bigint
)
as
update CategoriasProductos
set
Estado_co = 'false'
where IdCategoria_cp = @IDCATEGORIA
return
go

create procedure sp_AgregarCategoriaProductos
(
@DESCRIPCION varchar(30)
)
as 
insert into CategoriasProductos(Descripcion_cp)
values(@DESCRIPCION)
return
go

/*---------------------------------------------------*/
		/*			Productos		*/
/*---------------------------------------------------*/

create procedure sp_AgregarProducto
(
@CODARTICULO_P char(10),
@CATEGORIA_P bigint,
@DESCRIPCION_P varchar(255),
@STOCK_P bigint,
@PRECIO_P decimal,
@IMAGEN_P varchar(100)
)
as
insert into Productos(CodArticulo_p,Categoria_p,Descripcion_p,Stock_p,Precio_p,Imagen_p)
values (@CODARTICULO_P,@CATEGORIA_P,@DESCRIPCION_P,@STOCK_P,@PRECIO_P,@IMAGEN_P)
return 
go

create procedure sp_ModificarArticulo
(
@CODARTICULO_P char(10),
@CATEGORIA_P bigint,
@DESCRIPCION_P varchar(255),
@STOCK_P bigint,
@PRECIO_P decimal,
@IMAGEN_P varchar(100)
)
as
update Productos
set
CodArticulo_p = @CODARTICULO_P,
Categoria_p = @CATEGORIA_P,
Descripcion_p = @DESCRIPCION_P,
Stock_p = @STOCK_P,
Precio_p =  @PRECIO_P,
Imagen_p = @IMAGEN_P
where CodArticulo_p = @CODARTICULO_P
return 
go

create procedure sp_EliminarProducto
(
@CODPRODUCTO_P char(10)
)
as
update Productos
set
Estado = 'false'
where CodArticulo_p = @CODPRODUCTO_P
return
go

/*---------------------------------------------------*/
			/*			Rutinas		*/
/*---------------------------------------------------*/

create procedure sp_AgregarRutina
(
@NOMBRE_RU varchar(50)
)
as
insert into Rutinas(Nombre_ru)
values (@NOMBRE_RU)
return
go

create procedure sp_EliminarRutina
(
@NOMBRE_RU varchar(50)
)
as
update Rutinas
set
Estado_ru = 'false'
where Nombre_ru = @NOMBRE_RU
return
go

create procedure sp_ModificarRutina
(
@NOMBRE_RU varchar(50)
)
as 
update Rutinas
set
Nombre_ru = @NOMBRE_RU
return
go

/*---------------------------------------------------*/
			/*			Clientes		*/
/*---------------------------------------------------*/

create procedure sp_AgregarCliente
(
@NOMBRE_CLI varchar(30),
@APELLIDO_CLI varchar(30),
)
