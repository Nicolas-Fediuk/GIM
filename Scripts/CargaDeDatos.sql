use DB_Gim
go

insert into Admin(Nombre_ad,Contraseña_ad)
select 'admin','admin'
go

insert into Rutinas(Nombre_ru)
select 'Musculacion' union
select 'Aerobico' union
select 'Cardio' union
select 'Fuerza' union
select 'Resistencia' union
select 'Flexibilidad'
go

select * from Rutinas
go

insert into Clientes(Nombre_cli,Apellido_cli,Edad_cli,Telefono_cli,Email_cli,Direccion_cli,ProblemasDeSalud_cli,IdRutina_cli)
select 'Pablo','Cabrebra','34','3329567834','pablo@gmail.com','benecfatora sampedrinas 2110','asma',1 union
select 'Andrea','quinteros','23','3329346974','andrea@gmail.com','benecfatora sampedrinas 2115','ninguno',2
go

select * from Clientes
go

insert into Tarjetas(IdTarjetaUsuario_tar,TitularTarjeta_tar,NombreTarjeta_tar,TipoTarjeta_tar,NumeroTarjeta_tar,FechaVencimiento_tar,CodigoSeguridad_tar)
select 1,'Pablo Esteban Cabrera','Galicia',0,123456789,'01/02/2025',123 union
select 2,'Andrea Paola Quinteros','Frances',1,987654321,'05/05/2028',216 
go

select * from Clientes
go

insert into Cuotas(DescripcionCuota_cuo,Precio_cuo)
select 'Dia',125 
go
insert into Cuotas(DescripcionCuota_cuo,Precio_cuo)
select 'Semanal',975 
go
insert into Cuotas(DescripcionCuota_cuo,Precio_cuo)
select 'Mensual',3000
go

select * from Cuotas;

/* para resetear el identity*/
dbcc checkident('Cuotas',reseed,0);

delete from Cuotas;

insert into CategoriasProductos(Descripcion_cp)
select 'Bebidas' union
select 'Pastillas' union
select 'Polvo'
go

insert into Productos(CodArticulo_p,Categoria_p,Descripcion_p,Stock_p,Precio_p)
select 'b001',1,'Gatorade bebida energetica',45,120 union
select 'c001',2,'Ena creatina',10,1345 union
select 'p001',3,'Pulver protenia',23,956
go

select * from Productos
go

insert into Ventas(IdCliente_ve,Total_ve,MetodoDePago)
select 1,0,0
go

select * from Ventas
go

insert into DetalleVentasProductos(IdVenta_dvp,IdCliente_dvp,CodArticulo_dvp,Cantidad_dvp,Precio_dvp)
select 1,1,'b001',2,120
go

select * from DetalleVentasProductos
go

insert into Ventas(IdCliente_ve,Total_ve,MetodoDePago)
select 2,0,0
go


insert into DetalleVentasCuotas(IdVenta_dvc,IdCliente_dvc,IdTipoCuota_dvc,Precio_dvc)
select 5,1,3,3000
go

select * from DetalleVentasCuotas
go