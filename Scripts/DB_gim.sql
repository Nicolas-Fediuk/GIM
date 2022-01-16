create database DB_Gim
go

drop database DB_Gim
go


use DB_Gim
go

create table Admin
(
Nombre_ad varchar(30) not null,
Contraseña_ad varchar(30) not null,

constraint PK_Admin primary key (Nombre_ad)
)
go

create table Rutinas
(
IdRutina_ru int not null identity(1,1),
Nombre_ru varchar(50) not null unique,
Estado_ru bit default '1',

constraint PK_Rutinas primary key (IdRutina_ru)
)
go

drop table Rutinas
go

create table Clientes
(
IdCliente_cli bigint identity(1,1),
Nombre_cli varchar(30) not null,
Apellido_cli varchar(30) not null,
Edad_cli char(2) not null,
Telefono_cli char(10) null unique default 'sin telefono',
Email_cli varchar(30) null unique default 'sin email',
Direccion_cli varchar(40) not null,
ProblemasDeSalud_cli text not null,
IdRutina_cli int not null,
Estado_cli bit default '1' not null,

constraint PK_Clientes  primary key (IdCliente_cli),
constraint FK_Clientes_Rutinas foreign key (IdRutina_cli) references Rutinas(IdRutina_ru)
)
go

drop table Clientes
go

create table  Tarjetas(
IdTarjetaUsuario_tar bigint not null,
TitularTarjeta_tar varchar(50) not null,
NombreTarjeta_tar varchar(20) not null,
TipoTarjeta_tar bit not null,
NumeroTarjeta_tar bigint not null,
FechaVencimiento_tar date not null,
CodigoSeguridad_tar int not null,

constraint Ck_Tarjetas_FechaVencimiento check (FechaVencimiento_tar > getdate()),

constraint PK_Tarjetas primary key (IdTarjetaUsuario_tar,CodigoSeguridad_tar),

constraint FK_Tarjetas_Clientes foreign key (IdTarjetaUsuario_tar) references Clientes(IdCliente_cli)
)
go

drop table Tarjetas
go

create table Ventas
(
IdVenta_ve bigint identity(1,1),
IdCliente_ve bigint not null,
Total_ve decimal not null default 0,
FechaVenta_ve date not null default getdate(),
MetodoDePago bit not null,

constraint CK_Ventas_Total_ve check (Total_ve > 0),

constraint PK_Ventas primary key (IdVenta_ve),

constraint FK_Ventas_Clientes foreign key (IdCliente_ve) references Clientes(IdCliente_cli)
)
go

alter table Ventas
nocheck constraint CK_Ventas_FechaVenta_ve
go

exec sp_helpconstraint Ventas
go

drop table Ventas
go

create table Cuotas
(
IdTipoCuota_cuo int not null identity(1,1),
DescripcionCuota_cuo varchar(30) not null unique,
Precio_cuo decimal not null,
Estado_cuo bit default '1',

constraint CK_Cuotas_Precio check (Precio_cuo > 0),

constraint PK_Cuotas primary key (IdTipoCuota_cuo)
)
go

drop table Cuotas
go

create table DetalleVentasCuotas
(
IdVenta_dvc bigint not null,
IdCliente_dvc bigint not null,
IdTipoCuota_dvc int not null,
Precio_dvc decimal not null,
FechaInicio_dvc date not null default getdate(),
FechaFin_dvc date not null,

constraint CK_DetalleVentasCuotas_Precio check (Precio_dvc > 0),

constraint CK_DetalleVentasCuotas_FechaFin check (FechaFin_dvc > getdate()),

constraint PK_DetalleVentasCuotas primary key (IdVenta_dvc,IdCliente_dvc,IdTipoCuota_dvc),

constraint FK_DetalleVentasCuotas_Ventas foreign key (IdVenta_dvc) references Ventas(IdVenta_ve),

constraint FK_DetalleVentasCuotas_Clientes foreign key (IdCliente_dvc) references Clientes(IdCliente_cli),

constraint FK_DetalleVentasCuotas_Cuotas foreign key (IdTipoCuota_dvc) references Cuotas(IdTipoCuota_cuo),
)
go

drop table DetalleVentasCuotas
go

create table CategoriasProductos
(
IdCategoria_cp bigint identity(1,1) not null,
Descripcion_cp varchar(30) not null unique,
Estado_co bit not null default '1',

constraint PK_CategoriasProductos primary key (IdCategoria_cp)
)
go

drop table CategoriasProductos
go

create table Productos
(
CodArticulo_p char(10) not null,
Categoria_p bigint not null,
Descripcion_p varchar(255) not null unique,
Stock_p bigint not null,
Precio_p decimal not null,
Imagen_p varchar(100) null default 'sin imagen',
Estado bit not null default '1',

constraint CK_Productos_Stock check (Stock_p > 0),

constraint CK_Productos_Precio check (Precio_p > 0),

constraint PK_Productos primary key (CodArticulo_p),

constraint FK_Productos_CategoriasProductos foreign key (Categoria_p) references CategoriasProductos (IdCategoria_cp)
)
go

drop table Productos
go

create table DetalleVentasProductos
(
IdVenta_dvp bigint not null,
IdCliente_dvp bigint not null,
CodArticulo_dvp char(10) not null,
Cantidad_dvp bigint not null,
Precio_dvp decimal not null,

constraint CK_DetalleVentasProductos_Cantidad check (Cantidad_dvp > 0),

constraint CK_DetalleVentasProductos_Precio check (Precio_dvp > 0),

constraint PK_DetalleVentasProductos primary key (IdVenta_dvp,IdCliente_dvp,CodArticulo_dvp),

constraint FK_DetalleVentasProductos_Productos foreign key (CodArticulo_dvp) references Productos(CodArticulo_p),

constraint FK_DetalleVentasProductos_Ventas foreign key (IdVenta_dvp) references Ventas(IdVenta_ve),

constraint FK_DetalleVentasProductos_Clientes foreign key (IdCliente_dvp) references Clientes(IdCliente_cli)
)
go


