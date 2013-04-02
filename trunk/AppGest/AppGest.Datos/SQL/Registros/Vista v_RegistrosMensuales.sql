
drop view [dbo].[v_RegistrosMensuales]
go

CREATE view [dbo].[v_RegistrosMensuales]
as

with LineasCocheras as
(
	select
		enc.Id
		, cpto_enc.Nombre 'Operacion'
		, cli.NombreCompleto 'Cliente'
		, emp.Nombre 'Empresa'
		, c.Nombre 'Concepto'
		, serv.Nombre 'Servicio'
		, co.Nombre 'Cochera'
		, det.Cantidad 
		, det.Precio
		, det.Importe
		, det.ValFecha1 'Desde'
		, det.ValFecha2 'Hasta'
		, det.FechaAlta
		, det.FechaBaja
		, c.id 'idConcepto'
		, serv.id 'idServicio'
		, co.id 'idCochera'
		, cli.Id 'idCliente'

		from LGP.Reg_Det det
			inner join v_Conceptos c on det.Concepto_Id = c.Id
			inner join v_Cliente cli on det.EntidadAfectada1_Id = cli.Id
			inner join lgp.Reg_encab enc on enc.Id = det.Reg_encab_Id
			inner join v_Conceptos cpto_enc on enc.Concepto_Id = cpto_enc.Id
			inner join v_Cochera co on co.Id = det.ValLista1_Id
			inner join v_Empresa emp on emp.Id = enc.EntidadEmpresa_Id
			inner join v_Conceptos serv on serv.Id = det.ValLista2_Id
)
,
LineasVehiculo as
(
	select
		enc.Id
		, cpto_enc.Nombre 'Operacion'
		, cli.NombreCompleto 'Cliente'
		, emp.Nombre 'Empresa'
		, c.Nombre 'Concepto'
		, null 'Servicio'
		, co.Dominio + ' ' + co.Marca 'Vehiculo'
		, det.Cantidad 
		, det.Precio
		, det.Importe
		, det.ValFecha1 'Desde'
		, det.ValFecha2 'Hasta'
		, det.FechaAlta
		, det.FechaBaja
		, c.id 'idConcepto'
		, 0 'idServicio'
		, co.id 'idCochera'
		, cli.Id 'idCliente'

		from LGP.Reg_Det det
			inner join v_Conceptos c on det.Concepto_Id = c.Id
			inner join v_Cliente cli on det.EntidadAfectada1_Id = cli.Id
			inner join lgp.Reg_encab enc on enc.Id = det.Reg_encab_Id
			inner join v_Conceptos cpto_enc on enc.Concepto_Id = cpto_enc.Id
			inner join v_Vehiculo co on co.Id = det.ValLista1_Id
			inner join v_Empresa emp on emp.Id = enc.EntidadEmpresa_Id
			
)
select * from LineasCocheras
union all
select * from LineasVehiculo

