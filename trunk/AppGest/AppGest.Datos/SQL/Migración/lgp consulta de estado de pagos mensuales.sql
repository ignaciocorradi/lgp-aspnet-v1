
Set language spanish

--declare @desde datetime = null, @hasta datetime=null;

----select @desde = '20120101', @hasta = '20121231';
--select @desde = '20070101', @hasta = '20121231';

select * from dbo.fx_EstadoClientesMensuales('20070101','20121231')

alter Function dbo.fx_EstadoClientesMensuales(@desde datetime, @hasta datetime)
returns @rdo TABLE 
(
		NroCliente int
		, Cliente varchar(255)
		, Periodo int
		, PeriodoAbonado int
		, MES varchar(50)
		, Año int
		, Estado varchar(50) 
		, FechaPago datetime
		, FechaAltaServicio datetime
		, ImporteAbonado decimal
		, Bonificacion decimal
		, ImporteCpto decimal
		, Servicio varchar(255)
		, idServicio bigint
		, idCliente bigint
)
as

begin
	

		with ClientesM as
		(
			select 
				p.fecha
				, year(p.fecha)*100 + MONTH(p.fecha) 'Periodo'
				, cli.NroCliente
				, rm.idCliente
				, rm.Cliente
				, rm.Servicio
				, rm.idServicio
				, rm.Desde 'FechaAltaServicio'
				, rm.Precio
	

			from dbo.APERTURA_FINPERIODO(@desde, @hasta) p
				 join v_RegistrosMensuales rm on p.fecha >= rm.Desde 
													and rm.idServicio <> 0
				join dbo.v_Cliente cli on cli.ID = rm.idCliente
		)
			INSERT INTO @rdo
			select distinct
				   cm.NroCliente
				 , cm.Cliente
				 , cm.Periodo 
				 , pm.Periodo 'PeriodoAbonado'
				 , datename(month, cm.fecha) 'MES'
				 , year(cm.fecha) 'Año'
				 , case when pm.idRegistro is null then 'Impago' else 'Pago' end 'Estado' 
				 , pm.FechaPago
				 , cm.FechaAltaServicio
				 , isnull(pm.Importe,0) 'ImporteAbonado'
				 , isnull(pm.Bonificacion, 0) 'Bonificacion'
				 , isnull(vp.Precio,0) 'ImporteCpto'
				 , cm.Servicio
				 , cm.idServicio
				 , cm.idCliente
				from clientesM cm
					 left join v_REP_PagosMensuales pm on cm.Periodo = pm.periodo
											and cm.idCliente = pm.idCliente
											and cm.idServicio = pm.Concepto_Id
					left join v_REP_PreciosConcepto vp on cm.idServicio = vp.Concepto_Id
								and cm.Periodo between vp.PeriodoDesde and vp.PeriodoHasta
				--where cm.NroCliente = 50
				order by 2 
			return
	end
