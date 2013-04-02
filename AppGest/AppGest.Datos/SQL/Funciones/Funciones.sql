USE [PROD_LGP]
GO

/****** Object:  UserDefinedFunction [dbo].[fx_EstadoClientesMensuales]    Script Date: 20/12/2012 06:26:21 p.m. ******/
DROP FUNCTION [dbo].[fx_EstadoClientesMensuales]
GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_PERIODO_DIA]    Script Date: 20/12/2012 06:26:21 p.m. ******/
DROP FUNCTION [dbo].[APERTURA_PERIODO_DIA]
GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_PERIODO]    Script Date: 20/12/2012 06:26:21 p.m. ******/
DROP FUNCTION [dbo].[APERTURA_PERIODO]
GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_FINPERIODO]    Script Date: 20/12/2012 06:26:21 p.m. ******/
DROP FUNCTION [dbo].[APERTURA_FINPERIODO]
GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_FINPERIODO]    Script Date: 20/12/2012 06:26:21 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Function [dbo].[APERTURA_FINPERIODO](@inicio datetime, @fin datetime)
returns @rdo TABLE (fecha datetime)
as

/*
	Devuelve la colección de todos los 
	meses contenidos en el período especificado
*/

begin
		
	INSERT INTO @rdo 
		SELECT dateadd(day, -1, dateadd(month, 1, fecha))
			FROM APERTURA_PERIODO(@inicio,@fin)
	
	RETURN
END




GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_PERIODO]    Script Date: 20/12/2012 06:26:21 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE Function [dbo].[APERTURA_PERIODO](@inicio datetime, @fin datetime)
returns @rdo TABLE (fecha datetime)
as

/*
	Devuelve la colección de todos los 
	meses contenidos en el período especificado
*/

begin
	declare @fecha_i datetime, @fecha_hasta datetime
	set @fecha_i = dbo.SinDia(@inicio)
	set @fecha_hasta = dbo.SinDia(@fin)

	while (@fecha_i <= @fecha_hasta)
	begin
		insert into @rdo values(@fecha_i)
		set @fecha_i = dateadd(month, 1, @fecha_i)
	end
	return
end

GO

/****** Object:  UserDefinedFunction [dbo].[APERTURA_PERIODO_DIA]    Script Date: 20/12/2012 06:26:21 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create Function [dbo].[APERTURA_PERIODO_DIA](@inicio datetime, @fin datetime)
returns @rdo TABLE (fecha datetime)
as

/*
	Devuelve la colección de todos los 
	meses contenidos en el período especificado
*/

begin
	declare @fecha_i datetime, @fecha_hasta datetime
	set @fecha_i = dbo.SinHora(@inicio)
	set @fecha_hasta = dbo.SinHora(@fin)

	while (@fecha_i <= @fecha_hasta)
	begin
		insert into @rdo values(@fecha_i)
		set @fecha_i = dateadd(day, 1, @fecha_i)
	end
	return
end



GO

/****** Object:  UserDefinedFunction [dbo].[fx_EstadoClientesMensuales]    Script Date: 20/12/2012 06:26:21 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Function [dbo].[fx_EstadoClientesMensuales](@desde datetime, @hasta datetime)
returns @rdo TABLE 
(
		NroCliente int
		, Cliente varchar(255)
		, Periodo int
		, PeriodoAbonado int
		, MES varchar(50)
		, Año int
		, fecha datetime
		, Estado varchar(10) 
		, FechaPago datetime
		, FechaAltaServicio datetime
		, ImporteAbonado decimal
		, Bonificacion decimal
		, ImporteCpto decimal
		, Deuda decimal
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
				 , cm.fecha
				 , case when pm.idRegistro is null then 'I' else 'P' end 'Estado' 
				 , pm.FechaPago
				 , cm.FechaAltaServicio
				 , isnull(pm.Importe,0) 'ImporteAbonado'
				 , isnull(pm.Bonificacion, 0) 'Bonificacion'
				 , isnull(vp.Precio,0) 'ImporteCpto'
				 , case when DATEDIFF(MONTH,cm.fecha, cm.FechaAltaServicio) <= 0  
						then isnull(vp.Precio,0)- (isnull(pm.Importe,0) + isnull(pm.Bonificacion, 0))  
						else 0 
					end 'Deuda'
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

GO


