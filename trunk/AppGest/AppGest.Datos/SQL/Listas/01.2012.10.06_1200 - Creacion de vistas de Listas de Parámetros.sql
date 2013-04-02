USE [PROD_LGP]
GO

/****** Object:  View [dbo].[v_Persona]    Script Date: 05/10/2012 11:58:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Persona]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre, LGP.EB_Persona.Nombre2 AS SegundoNombre, LGP.EB_Persona.Apellido, 
						 LGP.EB_Persona.Apellido + ', ' + LGP.EB.Nombre + ISNULL(LGP.EB_Persona.Nombre2, '') AS NombreCompleto, LGP.EB.Alta, LGP.EB.Baja, LGP.EB.Abreviatura, 
						 LGP.EB_Persona.Contacto_Domicilio, LGP.EB_Persona.Contacto_Telefono, LGP.EB_Persona.Contacto_TelefonoTrabajo, LGP.EB_Persona.Contacto_Movil, 
						 LGP.EB_Persona.Contacto_Email
FROM            LGP.EB INNER JOIN
						 LGP.EB_Entidad ON LGP.EB.Id = LGP.EB_Entidad.Id INNER JOIN
						 LGP.EB_Persona ON LGP.EB_Entidad.Id = LGP.EB_Persona.Id

GO

/****** Object:  View [dbo].[v_Usuario]    Script Date: 05/10/2012 11:58:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Usuario]
AS
SELECT        dbo.v_Persona.NombreCompleto, dbo.v_Persona.Alta, LGP.EB.Nombre AS Usuario, LGP.EB_Usuario.Clave, dbo.v_Persona.Abreviatura, 
						 dbo.v_Persona.Contacto_Domicilio AS Domicilio, dbo.v_Persona.Contacto_Telefono AS Telefono, dbo.v_Persona.Contacto_TelefonoTrabajo AS TelefonoTrabajo, 
						 dbo.v_Persona.Contacto_Email AS Email, dbo.v_Persona.Contacto_Movil AS Movil
FROM            LGP.EB_Usuario INNER JOIN
						 LGP.EB ON LGP.EB_Usuario.Id = LGP.EB.Id INNER JOIN
						 dbo.v_Persona ON LGP.EB_Usuario.Persona_Id = dbo.v_Persona.Id

GO

/****** Object:  View [dbo].[v_Cliente]    Script Date: 05/10/2012 11:58:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Cliente]
AS
SELECT        dbo.v_Persona.Id, dbo.v_Persona.NombreCompleto, dbo.v_Persona.Nombre, dbo.v_Persona.SegundoNombre, dbo.v_Persona.Apellido, dbo.v_Persona.Alta, 
						 dbo.v_Persona.Baja, dbo.v_Persona.Contacto_Domicilio, dbo.v_Persona.Contacto_Telefono, dbo.v_Persona.Contacto_TelefonoTrabajo, 
						 dbo.v_Persona.Contacto_Movil, dbo.v_Persona.Contacto_Email, dbo.v_Persona.Abreviatura
FROM            LGP.EB_Cliente INNER JOIN
						 dbo.v_Persona ON LGP.EB_Cliente.Id = dbo.v_Persona.Id

GO

/****** Object:  View [dbo].[v_Empleado]    Script Date: 05/10/2012 11:58:13 p.m. ******/
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

/****** Object:  View [dbo].[v_Cochera]    Script Date: 05/10/2012 11:58:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Cochera]
AS
SELECT        LGP.EB.Id, LGP.EB.Nombre, LGP.EB.Alta, LGP.EB.Descripcion, LGP.EB.Observaciones
FROM            LGP.EB INNER JOIN
						 LGP.EB_Cochera ON LGP.EB.Id = LGP.EB_Cochera.Id

GO

/****** Object:  View [dbo].[v_Vehiculo]    Script Date: 05/10/2012 11:58:13 p.m. ******/
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



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Concepto]
AS

SELECT        
	EB.Id as Id
	, EB.Nombre as Nombre
	, EB.Abreviatura as Abreviatura
	, EB.Descripcion as Descripcion
	, CPT.Clase as Clase
	, CPT.Valor as Valor
	, CPT.DESISTEMA as DESISTEMA
FROM
	LGP.EB EB INNER JOIN LGP.EB_Concepto CPT
		ON EB.Id = CPT.Id

GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_Registro]
as

select
	  encab.Id as Encab_Id
	, cptenc.Id as Cpt_Encab_Id
	, cptenc.Nombre as Cpt_Encab
	, encab.FechaRegistro as FechaR
	, entReg.Nombre as Encab_EntidadReg
	, entRes.Nombre as Encab_EntidadRes
	, entEmp.Nombre as EntidadEmp
	, entAfc.Nombre as Encab_EntidadAfc
	, cptlin.Id as Cpt_Linea_Id
	, cptlin.Nombre as Cpt_Linea
	, linea.*
from 
	LGP.Reg_Det linea 
	inner join v_Concepto cptlin on linea.Concepto_Id = cptlin.Id
	inner join LGP.Reg_encab encab on encab.Id = linea.Reg_encab_Id
	inner join v_Concepto cptenc on encab.Concepto_Id = cptenc.Id
	inner join v_Cliente cli on cli.Id = linea.EntidadAfectada1_Id
	left join LGP.EB entReg on entReg.Id = encab.EntidadRegistro_Id
	left join LGP.EB entRes on entRes.Id = encab.EntidadResp_Id
	left join LGP.EB entEmp on entEmp.Id = encab.EntidadEmpresa_Id
	left join LGP.EB entAfc on entAfc.Id = encab.EntidadAfectada_Id

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_PagoMensual]
AS
SELECT 

	linea.Encab_Id
	, linea.Cpt_Encab
	, linea.FechaR
	, linea.Cpt_Linea
	, cli.Nombre as Cliente
	, coc.Nombre as Cochera
	, ValFecha1 as FechaPago
	, ValFecha1 as Periodo
	, ValNum1 as Precio
	, ValNum2 as Bonificacion
FROM v_Registro linea
	left join v_Cliente cli on cli.Id = linea.EntidadAfectada1_Id
	left join v_Cochera coc on coc.Id = linea.ValLista1_Id

WHERE 
	linea.Cpt_Linea like 'Alquiler Mensual%'
	and linea.Cpt_Encab like 'PAGO_MENSUAL'


GO


