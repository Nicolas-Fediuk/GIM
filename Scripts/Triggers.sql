/* trigger para calcular el total en venta de productos*/

create or alter trigger tr_SumaTotal
on DetalleVentasProductos
after insert
as
	begin
	update Ventas set Total_ve = Total_ve +  Cantidad_dvp*Precio_dvp from inserted
	where IdCliente_dvp = (select IdCliente_ve from inserted)
	end
go

/* trigger para calcular el total en venta de cuota*/

create or alter trigger tr_SumaTotalCuota
on DetalleVentasCuotas
after insert
as
	begin
	update Ventas set Total_ve =  Precio_dvc from inserted
	where IdVenta_dvc = IdVenta_ve
	end
go

/* cotrolar el stock al realizar una venta*/

create or alter trigger tr_ControlStock
on DetalleVentasProductos
after insert
as 
	begin 
	update Productos set Stock_p = Stock_p - Cantidad_dvp from inserted
	where CodArticulo_p = (select CodArticulo_dvp from inserted)
	end
go

/* cargar de fechas finales de las cuotas */

/*por dias*/

create or alter trigger tr_CargarFechaClienteXdia
on DetalleVentasCuotas
after insert
as 
	begin
	update DetalleVentasCuotas set FechaFin_dvc = dateadd(day,1,getdate()) from inserted
	where DetalleVentasCuotas.IdTipoCuota_dvc = 1
	end
go

/*por semana*/

create or alter trigger tr_CargarFechaClienteXsemana
on DetalleVentasCuotas
after insert
as 
	begin
	update DetalleVentasCuotas set FechaFin_dvc = dateadd(week,1,getdate()) from inserted
	where DetalleVentasCuotas.IdTipoCuota_dvc = 2
	end
go

/*por meses*/

create or alter trigger tr_CargarFechaClienteXmes
on DetalleVentasCuotas
after insert
as 
	begin
	update DetalleVentasCuotas set FechaFin_dvc = dateadd(month,1,getdate()) from inserted
	where DetalleVentasCuotas.IdTipoCuota_dvc = 3
	end
go



enable TRIGGER tr_CargarFechaClienteXmes
ON DetalleVentasCuotas
GO

enable TRIGGER tr_CargarFechaClienteXdia
ON DetalleVentasCuotas
GO

enable TRIGGER tr_CargarFechaClienteXsemana
ON DetalleVentasCuotas
GO