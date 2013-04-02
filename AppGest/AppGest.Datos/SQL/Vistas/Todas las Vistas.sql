USE [PROD_LGP]
GO

/****** Object:  View [dbo].[ObtenerSqlImportConfMenu]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[ObtenerSqlImportConfMenu]
GO

/****** Object:  View [dbo].[v_RegPrecios]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_RegPrecios]
GO

/****** Object:  View [dbo].[v_REP_PreciosConcepto]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_REP_PreciosConcepto]
GO

/****** Object:  View [dbo].[Detalles_REG]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[Detalles_REG]
GO

/****** Object:  View [dbo].[v_Empleado]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Empleado]
GO

/****** Object:  View [dbo].[v_RegistrosMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_RegistrosMensuales]
GO

/****** Object:  View [dbo].[v_Vehiculo]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Vehiculo]
GO

/****** Object:  View [dbo].[v_Empresa]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Empresa]
GO

/****** Object:  View [dbo].[v_Cochera]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Cochera]
GO

/****** Object:  View [dbo].[v_Cliente]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Cliente]
GO

/****** Object:  View [dbo].[v_REP_RegMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_REP_RegMensuales]
GO

/****** Object:  View [dbo].[v_REP_PagosMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_REP_PagosMensuales]
GO

/****** Object:  View [dbo].[v_Reg_Encab]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Reg_Encab]
GO

/****** Object:  View [dbo].[v_Usuario]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Usuario]
GO

/****** Object:  View [dbo].[v_Reg_Detalle]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Reg_Detalle]
GO

/****** Object:  View [dbo].[v_Persona]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Persona]
GO

/****** Object:  View [dbo].[v_Conceptos]    Script Date: 20/12/2012 06:25:38 p.m. ******/
DROP VIEW [dbo].[v_Conceptos]
GO

/****** Object:  View [dbo].[v_Conceptos]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Conceptos]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre, LGP.EB.Abreviatura, LGP.EB.Descripcion, LGP.EB.Observaciones, LGP.EB_Concepto.Clase, LGP.EB_Concepto.Valor
FROM            LGP.EB_Concepto INNER JOIN
                         LGP.EB ON LGP.EB_Concepto.Id = LGP.EB.Id

GO

/****** Object:  View [dbo].[v_Persona]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Persona]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre, LGP.EB_Persona.Nombre2 AS SegundoNombre, LGP.EB_Persona.Apellido, 
                         LGP.EB_Persona.Apellido + ', ' + LGP.EB.Nombre + ' ' + ISNULL(LGP.EB_Persona.Nombre2, '') AS NombreCompleto, LGP.EB.Alta, LGP.EB.Baja, LGP.EB.Abreviatura, 
                         LGP.EB_Persona.Contacto_Domicilio, LGP.EB_Persona.Contacto_Telefono, LGP.EB_Persona.Contacto_TelefonoTrabajo, LGP.EB_Persona.Contacto_Movil, 
                         LGP.EB_Persona.Contacto_Email, LGP.EB_Persona.Dni
FROM            LGP.EB INNER JOIN
                         LGP.EB_Entidad ON LGP.EB.Id = LGP.EB_Entidad.Id INNER JOIN
                         LGP.EB_Persona ON LGP.EB_Entidad.Id = LGP.EB_Persona.Id

GO

/****** Object:  View [dbo].[v_Reg_Detalle]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[v_Reg_Detalle]
as 
Select e.Id 'idDetalle' 
	, cpto.Nombre 'Concepto'
	, entA1.NombreCompleto 'EntidadAfectada1'
	, entA2.NombreCompleto 'EntidadAfectada2'
	, entA3.NombreCompleto 'EntidadAfectada3'
	, e.FechaAlta
	, e.FechaBaja
	, e.FechaModif
	, e.Comentario
	, e.Cantidad
	, e.Precio
	, e.Importe
	, vl1.Nombre 'Lista1'
	, vl2.Nombre 'Lista2'
	, vl3.Nombre 'Lista3'
	, vl4.Nombre 'Lista4'
	, e.ValFecha1
	, e.ValFecha2
	, e.ValFecha3
	, e.ValFecha4
	, e.ValNum1
	, e.ValNum2
	, e.ValNum3
	, e.ValNum4
	, e.ValText1
	, e.ValText2
	, e.ValText3
	, e.ValText4
	, e.Concepto_Id
	, e.EntidadAfectada1_Id
	, e.EntidadAfectada2_Id
	, e.EntidadAfectada3_Id
	, e.ValLista1_Id
	, e.ValLista2_Id
	, e.ValLista3_Id
	, e.ValLista4_Id
	, e.Reg_encab_Id 'idRegistro'
	from lgp.Reg_Det e
		left join v_Persona entA1 on e.EntidadAfectada1_Id = entA1.Id
		left join v_Persona entA2 on e.EntidadAfectada2_Id = entA2.Id
		left join v_Persona entA3 on e.EntidadAfectada3_Id = entA3.Id
		left join lgp.EB UM on e.UM_Id = um.Id
		left join v_Conceptos cpto on cpto.Id = e.Concepto_Id
		left join lgp.EB vl1 on e.ValLista1_Id = vl1.Id
		left join lgp.EB vl2 on e.ValLista2_Id = vl2.Id
		left join lgp.EB vl3 on e.ValLista3_Id = vl3.Id
		left join lgp.EB vl4 on e.ValLista4_Id = vl4.Id

GO

/****** Object:  View [dbo].[v_Usuario]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[v_Usuario]
AS
SELECT u.Id
	, u.Tipo 
	, dbo.v_Persona.NombreCompleto
	, dbo.v_Persona.Alta
	, LGP.EB.Nombre AS Usuario
	, u.Clave
	, dbo.v_Persona.Abreviatura
	, dbo.v_Persona.Contacto_Domicilio AS Domicilio
	, dbo.v_Persona.Contacto_Telefono AS Telefono
	, dbo.v_Persona.Contacto_TelefonoTrabajo AS TelefonoTrabajo
	, dbo.v_Persona.Contacto_Email AS Email
	, dbo.v_Persona.Contacto_Movil AS Movil
FROM  LGP.EB_Usuario u
	INNER JOIN LGP.EB ON u.Id = LGP.EB.Id 
	INNER JOIN dbo.v_Persona ON u.Persona_Id = dbo.v_Persona.Id


GO

/****** Object:  View [dbo].[v_Reg_Encab]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[v_Reg_Encab]
as 
Select e.Id 'idRegistro' 
	, cpto.Nombre 'Concepto'
	, entA.Nombre 'EntidadAfectada'
	, emp.Nombre 'EntidadEmpresa'
	, entR.Nombre 'EntidadRegistro'
	, entResp.Nombre 'EntidadResponsable'
	, e.FechaAlta
	, e.FechaBaja
	, e.FechaModif
	, e.FechaRegistro
	, e.Comentario
	, usu.NombreCompleto 'Usuario'
	, e.Concepto_Id
	, e.EntidadAfectada_Id
	, e.EntidadEmpresa_Id
	, e.EntidadRegistro_Id
	, e.EntidadResp_Id
	, e.Usuario_Id
	from lgp.Reg_encab e
		left join v_Persona entA on e.EntidadAfectada_Id = enta.Id
		left join v_Persona emp on e.EntidadEmpresa_Id = emp.Id
		left join v_Persona entR on e.EntidadRegistro_Id = entR.Id
		left join v_Persona entResp on e.EntidadResp_Id = entResp.Id
		left join v_Conceptos cpto on cpto.Id = e.Concepto_Id
		left join v_Usuario usu on usu.Id = e.Usuario_Id


GO

/****** Object:  View [dbo].[v_REP_PagosMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





/*
USE [PROD_LGP]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

*/
CREATE view [dbo].[v_REP_PagosMensuales]
As

select e.idRegistro 
	, e.FechaRegistro
	, e.EntidadEmpresa 'Empresa'
	, d.[EntidadAfectada1] 'Cliente'
	, e.Usuario 'Registro'
	, e.Concepto 'Transaccion'
	, e.Concepto_Id 'IdTransaccion'
	, e.Comentario 'E_Comentario'
	, d.[idDetalle]
	, d.[Concepto]
	, d.[EntidadAfectada1]
	, d.[EntidadAfectada2]
	, d.[EntidadAfectada3]
	, d.[FechaAlta]
	, d.[FechaBaja]
	, d.[FechaModif]
	, d.[Comentario]
	, d.[Cantidad]
	, d.[Precio]
	, d.[Importe]
	, d.ValNum1 'Bonificacion'
	, d.[Lista1]
	, d.[Lista2]
	, d.[Lista3]
	, d.[Lista4]
	, d.[ValFecha1] 'FechaPago'
	, d.[ValFecha2] 'PeriodoPago'
	, d.Concepto_Id 
	, Year(d.[ValFecha2])*100 + MONTH(d.[ValFecha2]) 'Periodo'
	, d.EntidadAfectada1_Id 'idCliente'
from v_Reg_Detalle d
	join v_Reg_Encab e on e.idRegistro = d.idregistro
where e.Concepto_Id = 13







GO

/****** Object:  View [dbo].[v_REP_RegMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create view [dbo].[v_REP_RegMensuales]
As
select e.FechaRegistro
	, e.EntidadEmpresa
	, e.EntidadAfectada 'Cliente'
	, e.Usuario 'Registro'
	, d.[idDetalle]
	, d.[Concepto]
	, d.[EntidadAfectada1]
	, d.[EntidadAfectada2]
	, d.[EntidadAfectada3]
	, d.[FechaAlta]
	, d.[FechaBaja]
	, d.[FechaModif]
	, d.[Comentario]
	, d.[Cantidad]
	, d.[Precio]
	, d.[Importe]
	, d.[Lista1]
	, d.[Lista2]
	, d.[Lista3]
	, d.[Lista4]
	, d.[ValFecha1]
	, d.[ValFecha2]
	, d.[Concepto] 'CptoDetalle'
from v_Reg_Detalle d
	join v_Reg_Encab e on e.idRegistro = d.idregistro
where e.Concepto_Id = 11


GO

/****** Object:  View [dbo].[v_Cliente]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[v_Cliente]
AS
SELECT dbo.v_Persona.Id
	, LGP.EB_Cliente.NroCliente, dbo.v_Persona.NombreCompleto, dbo.v_Persona.Nombre, dbo.v_Persona.SegundoNombre, dbo.v_Persona.Apellido 
	, dbo.v_Persona.Alta, dbo.v_Persona.Baja, dbo.v_Persona.Contacto_Domicilio, dbo.v_Persona.Contacto_Telefono, dbo.v_Persona.Contacto_TelefonoTrabajo
    , dbo.v_Persona.Contacto_Movil, dbo.v_Persona.Contacto_Email, dbo.v_Persona.Abreviatura, dbo.v_Persona.Dni
	, lgp.EB_Cliente.CUIT, lgp.EB_Cliente.RazonSocial, lgp.EB_Cliente.DomicilioFiscal
FROM LGP.EB_Cliente INNER JOIN
     dbo.v_Persona ON LGP.EB_Cliente.Id = dbo.v_Persona.Id


GO

/****** Object:  View [dbo].[v_Cochera]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Cochera]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre, LGP.EB.Alta, LGP.EB.Baja, LGP.EB.Abreviatura, LGP.EB.Descripcion, LGP.EB.Observaciones
FROM            LGP.EB INNER JOIN
                         LGP.EB_Cochera ON LGP.EB.Id = LGP.EB_Cochera.Id

GO

/****** Object:  View [dbo].[v_Empresa]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Empresa]
AS
SELECT        dbo.v_Persona.Id, dbo.v_Persona.NombreCompleto, dbo.v_Persona.Nombre, dbo.v_Persona.SegundoNombre, dbo.v_Persona.Apellido AS RazonSocial, 
                         dbo.v_Persona.Alta, dbo.v_Persona.Baja, dbo.v_Persona.Abreviatura, dbo.v_Persona.Contacto_Domicilio, dbo.v_Persona.Contacto_Telefono, 
                         dbo.v_Persona.Contacto_TelefonoTrabajo, dbo.v_Persona.Contacto_Movil, dbo.v_Persona.Contacto_Email
FROM            dbo.v_Persona INNER JOIN
                         LGP.EB_Empresa ON dbo.v_Persona.Id = LGP.EB_Empresa.Id

GO

/****** Object:  View [dbo].[v_Vehiculo]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Vehiculo]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre AS Dominio, LGP.EB_Vehiculo.Modelo, LGP.EB_Vehiculo.Marca, LGP.EB.Descripcion, LGP.EB.Observaciones, LGP.EB.Alta, 
                         LGP.EB.Baja
FROM            LGP.EB_Vehiculo INNER JOIN
                         LGP.EB_Entidad ON LGP.EB_Vehiculo.Id = LGP.EB_Entidad.Id INNER JOIN
                         LGP.EB ON LGP.EB_Entidad.Id = LGP.EB.Id

GO

/****** Object:  View [dbo].[v_RegistrosMensuales]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


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


GO

/****** Object:  View [dbo].[v_Empleado]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Empleado]
AS
SELECT        dbo.v_Persona.Id, dbo.v_Persona.NombreCompleto, dbo.v_Persona.Nombre, dbo.v_Persona.SegundoNombre, dbo.v_Persona.Apellido, dbo.v_Persona.Alta, 
                         dbo.v_Persona.Baja, dbo.v_Persona.Abreviatura, dbo.v_Persona.Contacto_Domicilio, dbo.v_Persona.Contacto_Telefono, dbo.v_Persona.Contacto_TelefonoTrabajo, 
                         dbo.v_Persona.Contacto_Movil, dbo.v_Persona.Contacto_Email
FROM            dbo.v_Persona INNER JOIN
                         LGP.EB_Empleado ON dbo.v_Persona.Id = LGP.EB_Empleado.Id

GO

/****** Object:  View [dbo].[Detalles_REG]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Detalles_REG]
AS
SELECT
	  LGP.Reg_Det.FechaAlta
	, LGP.Reg_Det.FechaModif
	, LGP.Reg_Det.EntidadAfectada1_Id AS idCliente
	, dbo.v_Cliente.NombreCompleto AS Cliente
	, LGP.Reg_Det.ValLista1_Id AS idCpto
	, dbo.v_Conceptos.Nombre AS Concepto
	, LGP.Reg_Det.Cantidad
	, LGP.Reg_Det.Precio
	, LGP.Reg_Det.Importe
FROM LGP.Reg_Det 
	INNER JOIN dbo.v_Cliente ON LGP.Reg_Det.EntidadAfectada1_Id = dbo.v_Cliente.Id 
	INNER JOIN dbo.v_Conceptos ON LGP.Reg_Det.ValLista1_Id = dbo.v_Conceptos.Id


GO

/****** Object:  View [dbo].[v_REP_PreciosConcepto]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[v_REP_PreciosConcepto]
As

select e.idRegistro 
	, e.Concepto 'Transaccion'
	, e.FechaRegistro
	, e.EntidadEmpresa 'Empresa'
	, d.[EntidadAfectada1] 'Responsable'
	, e.Usuario 'Usuario'
	, e.Comentario 'E_Comentario'
	, d.[idDetalle]
	, d.[Concepto]
	, d.[Cantidad]
	, d.[Precio]
	, d.[Importe]
	, d.[ValFecha1] 'Desde'
	, d.[ValFecha2] 'Hasta'
	, isnull(Year(d.[ValFecha1])*100 + MONTH(d.[ValFecha1]), 0) 'PeriodoDesde'
	, isnull(Year(d.[ValFecha2])*100 + MONTH(d.[ValFecha2]), 999999) 'PeriodoHasta'
	, d.[FechaAlta]
	, d.[FechaBaja]
	, d.[FechaModif]
	, d.[Comentario]
	, d.EntidadAfectada1_Id 'idCliente'
	, d.Concepto_Id
	, e.Concepto_Id 'IdTransaccion'
from v_Reg_Detalle d
	join v_Reg_Encab e on e.idRegistro = d.idregistro
	join v_Conceptos cptos on cptos.Id = e.Concepto_Id
where cptos.Clase = 4 and cptos.Valor = 2 -- Transacción Alta de precios. 



GO

/****** Object:  View [dbo].[v_RegPrecios]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[v_RegPrecios]
As

select e.idRegistro 
	, e.FechaRegistro
	, e.EntidadEmpresa 'Empresa'
	, d.[EntidadAfectada1] 'Cliente'
	, e.Usuario 'Registro'
	, e.Concepto 'Transaccion'
	, e.Concepto_Id 'IdTransaccion'
	, e.Comentario 'E_Comentario'
	, d.[idDetalle]
	, d.[Concepto]
	, d.[EntidadAfectada1]
	, d.[EntidadAfectada2]
	, d.[EntidadAfectada3]
	, d.[FechaAlta]
	, d.[FechaBaja]
	, d.[FechaModif]
	, d.[Comentario]
	, d.[Cantidad]
	, d.[Precio]
	, d.[Importe]
	, d.[Lista1]
	, d.[Lista2]
	, d.[Lista3]
	, d.[Lista4]
	, d.[ValFecha1] 'FechaPago'
	, d.[ValFecha2] 'PeriodoPago'
	, Year(d.[ValFecha2])*100 + MONTH(d.[ValFecha2]) 'Periodo'
	, d.EntidadAfectada1_Id 'idCliente'
from v_Reg_Detalle d
	join v_Reg_Encab e on e.idRegistro = d.idregistro
	--where e.Concepto_Id = 12
GO

/****** Object:  View [dbo].[ObtenerSqlImportConfMenu]    Script Date: 20/12/2012 06:25:38 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[ObtenerSqlImportConfMenu]
	as
select 
 'INSERT INTO [LGP].[ConfMenu] ([Orden],[Paginas],[Grupos],[Items],[ImagenItem],[TagItem],[ToolTips],[AutoSize]) values ('
	+ CHAR(39) + [Orden] + CHAR(39) + ','+ CHAR(39) + [Paginas] + CHAR(39)+ ','
	+ CHAR(39) + [Grupos] +CHAR(39) + ','+ CHAR(39) + [Items]+ CHAR(39) + ',' + CHAR(39) +[ImagenItem]
	+ CHAR(39) + ',' +CHAR(39)+[TagItem]+CHAR(39)+','+CHAR(39)+[ToolTips]+CHAR(39)+ ','+CHAR(39)+[AutoSize]+CHAR(39)+ ')'
	as Linea
  FROM [dbo].[ConfMenu]


GO


