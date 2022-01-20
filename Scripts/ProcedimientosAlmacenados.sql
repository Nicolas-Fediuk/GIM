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

create procedure sp_ModificarCategorias
(
@IDCATEGORIA bigint,
@DESCRIPCION varchar(30)
)
as
update CategoriasProductos
set
Descripcion_cp = @DESCRIPCION
where IdCategoria_cp = @IDCATEGORIA
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

create or alter procedure sp_EliminarRutina
(
@IDRITINA_RU int
)
as
update Rutinas
set
Estado_ru = 'false'
where IdRutina_ru = @IDRITINA_RU
return
go

create procedure sp_ModificarRutina
(
@IDRUTINA_RU int,
@NOMBRE_RU varchar(50)
)
as 
update Rutinas
set
Nombre_ru = @NOMBRE_RU
where IdRutina_ru = @IDRUTINA_RU
return
go

/*---------------------------------------------------*/
			/*			Clientes		*/
/*---------------------------------------------------*/

create procedure sp_AgregarCliente
(
@NOMBRE_CLI varchar(30),
@APELLIDO_CLI varchar(30),
@EDAD_CLI char(2),
@TELEFONO_CLI char(10),
@EMAIL_CLI varchar(30),
@DIRECCION_CLI varchar(40),
@PROBLEMAS_CLI text,
@IDRUTINA_CLI int
)
as 
insert into Clientes(Nombre_cli,Apellido_cli,Edad_cli,Telefono_cli,Email_cli,Direccion_cli,ProblemasDeSalud_cli,IdRutina_cli)
values (@NOMBRE_CLI,@APELLIDO_CLI,@EDAD_CLI,@TELEFONO_CLI,@EMAIL_CLI,@DIRECCION_CLI,@PROBLEMAS_CLI,@IDRUTINA_CLI)
return 
go

create procedure sp_ModificarCliente
(
@IDCLIENTE_CLI bigint,
@NOMBRE_CLI varchar(30),
@APELLIDO_CLI varchar(30),
@EDAD_CLI char(2),
@TELEFONO_CLI char(10),
@EMAIL_CLI varchar(30),
@DIRECCION_CLI varchar(40),
@PROBLEMAS_CLI text,
@IDRUTINA_CLI int
)
as 
update Clientes
set
Nombre_cli = @NOMBRE_CLI,
Apellido_cli = @APELLIDO_CLI,
Edad_cli = @EDAD_CLI,
Telefono_cli = @TELEFONO_CLI,
Email_cli = @EMAIL_CLI,
Direccion_cli = @DIRECCION_CLI,
ProblemasDeSalud_cli = @PROBLEMAS_CLI,
IdRutina_cli = @IDRUTINA_CLI
where IdCliente_cli = @IDCLIENTE_CLI
return 
go

create procedure sp_EliminarCliente
(
@IDCLIENTE_CLI bigint
)
as
update Clientes
set
Estado_cli = 'false'
where IdCliente_cli = @IDCLIENTE_CLI
return
go

/*---------------------------------------------------*/
			/*			Tarjetas		*/
/*---------------------------------------------------*/


create procedure sp_AgregarTarjeta
(
@IDTARJETAUSUARIO_TAR bigint,
@TITULARTARJETA_TAR varchar(50),
@NOMBRETARJETA_TAR varchar(20),
@TIPOTARJETA_TAR bit,
@NUMEROTARJETA_TAR bigint,
@CODIGOSEGURIDAD_TAR int
)
as
insert into Tarjetas(IdTarjetaUsuario_tar,TitularTarjeta_tar,NombreTarjeta_tar,TipoTarjeta_tar,NumeroTarjeta_tar,CodigoSeguridad_tar)
values (@IDTARJETAUSUARIO_TAR,@TITULARTARJETA_TAR,@NOMBRETARJETA_TAR,@TIPOTARJETA_TAR,@NUMEROTARJETA_TAR,@CODIGOSEGURIDAD_TAR)
return 
go

create procedure sp_ModificarTarjeta
(
@IDTARJETAUSUARIO_TAR bigint,
@TITULARTARJETA_TAR varchar(50),
@NOMBRETARJETA_TAR varchar(20),
@TIPOTARJETA_TAR bit,
@NUMEROTARJETA_TAR bigint,
@CODIGOSEGURIDAD_TAR int
)
as
update Tarjetas
set
TitularTarjeta_tar = @TITULARTARJETA_TAR,
NombreTarjeta_tar = @NOMBRETARJETA_TAR,
TipoTarjeta_tar = @TIPOTARJETA_TAR,
NumeroTarjeta_tar = @NUMEROTARJETA_TAR,
CodigoSeguridad_tar = @CODIGOSEGURIDAD_TAR
where IdTarjetaUsuario_tar = @IDTARJETAUSUARIO_TAR
return 
go

create procedure sp_EliminarTarjeta
(
@IDTARJETAUSUARIO_TAR bigint
)
as
delete from Tarjetas where IdTarjetaUsuario_tar = @IDTARJETAUSUARIO_TAR
return
go

/*---------------------------------------------------*/
			/*			Cuotas		*/
/*---------------------------------------------------*/

create procedure sp_AgregarCuota
(
@DESCRIPCIONCUOTA_CUO varchar(30),
@PRECIO_CUO decimal(18,0)
)
as
insert into Cuotas(DescripcionCuota_cuo,Precio_cuo)
values (@DESCRIPCIONCUOTA_CUO,@PRECIO_CUO)
return
go

create procedure sp_ModificarCuota
(
@IDTIPOCUOTA_CUO int,
@DESCRIPCIONCUOTA_CUO varchar(30),
@PRECIO_CUO decimal(18,0)
)
as
update Cuotas
set
DescripcionCuota_cuo = @DESCRIPCIONCUOTA_CUO,
Precio_cuo = @PRECIO_CUO
where IdTipoCuota_cuo = @IDTIPOCUOTA_CUO
return
go

create procedure sp_EliminarCuota
(
@IDTIPOCUOTA_CUO int
)
as
update Cuotas
set
Estado_cuo = 'false'
where Estado_cuo = @IDTIPOCUOTA_CUO
return
go

/*---------------------------------------------------*/
			/*			Ventas		*/
/*---------------------------------------------------*/

create procedure sp_AgregarVenta
(
@IDCLIENTE_VE bigint,
@METODODEPAGO_VE bit
)
as
insert into Ventas(IdCliente_ve,MetodoDePago)
values (@IDCLIENTE_VE,@METODODEPAGO_VE)
return 
go

/*---------------------------------------------------*/
	/*			Detalle de Ventas		*/
/*---------------------------------------------------*/

create procedure sp_AgregarDetalleVentaCuotas
(
@IDVENTA_DVC bigint,
@IDCLIENTE_DVC bigint,
@IDTIPOCUOTA_DVC int,
@PRECIO_DVC decimal(18,0),
@FECHAFIN_DVC date
)
as
insert into DetalleVentasCuotas(IdVenta_dvc,IdCliente_dvc,IdTipoCuota_dvc,Precio_dvc,FechaFin_dvc)
values (@IDVENTA_DVC,@IDCLIENTE_DVC,@IDTIPOCUOTA_DVC,@PRECIO_DVC,@FECHAFIN_DVC)
return
go

create procedure sp_AgregarDetalleVentaProducto
(
@IDVENTA_DVP bigint,
@IDCLIENTE_DVP bigint,
@CODARTICULO_DVP char(10),
@CANTIDAD_DVP bigint,
@PRECIO_DVP decimal(18,0)
)
as
insert into DetalleVentasProductos(IdVenta_dvp,IdCliente_dvp,CodArticulo_dvp,Cantidad_dvp,Precio_dvp)
values (@IDVENTA_DVP,@IDCLIENTE_DVP,@CODARTICULO_DVP,@CANTIDAD_DVP,@PRECIO_DVP)
return
go
