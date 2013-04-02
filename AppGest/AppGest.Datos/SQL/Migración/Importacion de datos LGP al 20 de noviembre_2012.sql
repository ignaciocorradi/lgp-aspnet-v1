/*
Script para importaciones de LGP
*/

drop table Clientes_Mensuales
go
drop table Pagos_Mensuales
go
set dateformat dmy
select

	 b.id
	, b.NroCliente 
	, left(cliente, IIF(patindex('%,%',cliente) > 0, patindex('%,%',cliente) - 1, 0)) 'Apellido'
		, RIGHT(cliente, Len(cliente) -  patindex('%,%',cliente)) 'Nombre'
	, iif(isdate(b.[Fecha Ingreso])=1, convert(datetime, b.[Fecha Ingreso]), null) 'FechaIngreso'

	, b.Servicio
	, b.dominio
	, b.marca
	, b.Domicilio
	, b.DomFiscal
	, b.Celular
	, b.Telefono
	, b.CUIT
	, b.RazonSocial
	, iif(isdate(b.Baja)=1, convert(datetime, b.Baja), null) 'Baja'
into Clientes_Mensuales
from BD_Mensuales_ActDic20 b	
--where upper(baja) = 'NO'

go
-- Insercion de datos de mayo

with pagos as
(
	select
		id
		, 201205 'Periodo'
		, iif(isdate(b.mayo)=1, convert(datetime, b.Mayo),null) 'FechaPago'
		, iif(isdate(b.mayo)=1, '' ,b.mayo) 'Observaciones' 
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201206 'Periodo'
		, iif(isdate(b.junio)=1, convert(datetime, b.junio),null) 'FechaPago'
		, iif(isdate(b.junio)=1, '' ,b.junio) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201207 'Periodo'
		, iif(isdate(b.julio)=1, convert(datetime, b.julio),null) 'FechaPago'
		, iif(isdate(b.julio)=1, '' ,b.julio) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201208 'Periodo'
		, iif(isdate(b.Agosto)=1, convert(datetime, b.Agosto),null) 'FechaPago'
		, iif(isdate(b.Agosto)=1, '' ,b.Agosto) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201209 'Periodo'
		, iif(isdate(b.[Set])=1, convert(datetime, b.[Set]),null) 'FechaPago'
		, iif(isdate(b.[Set])=1, '' ,b.[Set]) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201210 'Periodo'
		, iif(isdate(b.Oct)=1, convert(datetime, b.Oct),null) 'FechaPago'
		, iif(isdate(b.Oct)=1, '' ,b.Oct) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201211 'Periodo'
		, iif(isdate(b.Nov)=1, convert(datetime, b.Nov),null) 'FechaPago'
		, iif(isdate(b.Nov)=1, '' ,b.Nov) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201212 'Periodo'
		, iif(isdate(b.Dic)=1, convert(datetime, b.Dic),null) 'FechaPago'
		, iif(isdate(b.Dic)=1, '' ,b.Dic) 'Observaciones'
	from BD_Mensuales_ActDic20 b	
	where upper(baja) = 'NO'
)

select p.* 
into Pagos_Mensuales
from pagos p 
