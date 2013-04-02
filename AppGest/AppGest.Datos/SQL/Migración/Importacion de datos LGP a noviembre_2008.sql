/*
Script para importaciones
*/

drop table Clientes_Mensuales
go

drop table Pagos_Mensuales
go
set dateformat dmy
go


select
	b.id
	, b.NroCliente 
	, left(b.cliente, convert(int, dbo.IIF( convert(bit,patindex('%,%', b.cliente)) , patindex('%,%', b.cliente) - 1,0))) 'Apellido'
	, RIGHT(cliente, Len(cliente)-  patindex('%,%',cliente)) 'Nombre'
	, dbo.IIF(isdate(b.[Fecha Ingreso]), convert(datetime, b.[Fecha Ingreso]), null) 'FechaIngreso'

	, b.Servicio
	, b.dominio
	, b.marca
	, b.Domicilio
	, b.DomFiscal
	, b.Celular
	, b.Telefono
	, b.CUIT
	, b.RazonSocial
into Clientes_Mensuales
from BD_Mensuales_ActDic7 b	
where upper(baja) = 'NO'

go

-- Insercion de datos de mayo

with pagos as
(
	select
		id
		, 201205 'Periodo'
		, 'FechaPago' = 
			CASE
				WHEN ISDATE(b.mayo) = 1 THEN convert(datetime, b.Mayo)
				ELSE Null
			END
		, dbo.IIF(isdate(b.mayo), '' ,b.mayo) 'Observaciones' 
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201206 'Periodo'
		, 'FechaPago' = 
			CASE
				WHEN ISDATE(b.junio) = 1 THEN convert(datetime, b.junio)
				ELSE Null
			END
		, dbo.IIF(isdate(b.junio), '' ,b.junio) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201207 'Periodo'
		,'FechaPago'= 
			CASE
				WHEN ISDATE(b.julio) = 1 THEN convert(datetime, b.julio)
				ELSE Null
			END		
		, dbo.IIF(isdate(b.julio), '' ,b.julio) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201208 'Periodo'
		, 'FechaPago'= 
			CASE
				WHEN ISDATE(b.Agosto) = 1 THEN convert(datetime, b.Agosto)
				ELSE Null
			END
		, dbo.IIF(isdate(b.Agosto), '' ,b.Agosto) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201209 'Periodo'
		, 'FechaPago'= 
			CASE
				WHEN ISDATE(b.[Set]) = 1 THEN convert(datetime, b.[Set])
				ELSE Null
			END
		, dbo.IIF(isdate(b.[Set]), '' ,b.[Set]) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201210 'Periodo'
		, 'FechaPago'= 
			CASE
				WHEN ISDATE(b.Oct) = 1 THEN convert(datetime, b.Oct)
				ELSE Null
			END
		, dbo.IIF(isdate(b.Oct), '' ,b.Oct) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201211 'Periodo'
		, 'FechaPago'= 
			CASE
				WHEN ISDATE(b.Nov) = 1 THEN convert(datetime, b.Nov)
				ELSE Null
			END
		, dbo.IIF(isdate(b.Nov), '' ,b.Nov) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
	union all
	select
		id
		, 201212 'Periodo'
		, 'FechaPago'= 
			CASE
				WHEN ISDATE(b.Dic) = 1 THEN convert(datetime, b.Dic)
				ELSE Null
			END
		, dbo.IIF(isdate(b.Dic), '' ,b.Dic) 'Observaciones'
	from BD_Mensuales_ActDic7 b	
	where upper(baja) = 'NO'
)

select p.* 
into Pagos_Mensuales
from pagos p 
