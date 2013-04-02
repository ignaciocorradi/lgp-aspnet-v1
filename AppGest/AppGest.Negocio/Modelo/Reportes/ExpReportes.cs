using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.Negocio.Core;
using System.Configuration;

namespace AppGest.Negocio.Modelo.Reportes
{
    /// <summary>
    /// Representa un experto en gestión de reportes
    /// </summary>
    public class ExpReportes: Experto
    {
        void ValidarPermisos()
        {
        }

        public string UrlServidorReportes()
        {

            var configuracion = Configuracion();
            return configuracion.UrlServidor;
        }

        public ReportesSettingsSection Configuracion()
        {
            var configuracion = (ReportesSettingsSection) ConfigurationManager.GetSection(ReportesSettingsSection.NOMBRE_SECCION) ?? new ReportesSettingsSection();
            if (configuracion == null || string.IsNullOrWhiteSpace(configuracion.UrlServidor))
                throw new ReporteException("No se ha configurado un servidor de reportes. Comuníquese con el administrador del sistema.");

            return configuracion;
        }

        public string UrlReporte(string nombreRpt)
        {
            ValidarPermisos();
            var configuracion = Configuracion();

            var rpt = configuracion.Reportes[nombreRpt];
            if (rpt == null)
                throw new ReporteException(string.Format("El reporte especificado no se encuentra configurado ({0}). Comuníquese con el adminitrador del sistema."));

            return rpt.Reporte;
        }

        public RptItemSettings ItemReporte(string nombreRpt)
        {
            ValidarPermisos();
            var configuracion = Configuracion();
            
            var rpt = configuracion.Reportes[nombreRpt];
            if (rpt == null)
                throw new ReporteException(string.Format("El reporte especificado no se encuentra configurado ({0}). Comuníquese con el adminitrador del sistema."));

            return rpt;
        }

    }
}
