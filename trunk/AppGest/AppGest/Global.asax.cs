using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AppGest.Util;
using AppGest.Negocio.Modelo;
using AppGest.Negocio.Modelo.Inicializacion;
using AppGest.Negocio.Core;
using System.Configuration;
using AppGest.Vista.Reportes;

namespace AppGest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            bool? inicializar = (bool?)Helper.Parse(ConfigurationManager.AppSettings["Inicializar"], typeof(bool));
            if (inicializar.HasValue && inicializar.Value)
            {
                var inicializador = FabExpertos.Inst.Obtener<ExpInicializacion>(Guid.Empty);
                inicializador.Inicializar();
            }

            bool? inicializarServerReport = (bool?)Helper.Parse(ConfigurationManager.AppSettings["CargarReportServerAlInicio"], typeof(bool));

            if (inicializarServerReport.HasValue && inicializarServerReport.Value)
            {
                FrmReporteAsp r = new FrmReporteAsp();
                r.InicializarServerReportes();
            }


        }

        /// <summary>
        /// Devuelve la ruta virtual de la aplicación
        /// </summary>
        /// <returns></returns>
        string RutaVirtual()
        {
            return HttpRuntime.AppDomainAppVirtualPath;
        }

        /// <summary>
        /// Asegura que las condiciones de seguridad se aplique correctamente al archivo 
        /// se configuraciones.
        /// </summary>
        void EncriptarArchivoConfiguracion()
        {

            using(var experto = new ExpParametriaGlobal())
            {
                var encriptar = (ConfigurationManager.AppSettings["Web_Config_Asegurar"] ?? "").Trim().ToUpper() == "ENCR";
                if (encriptar)
                    experto.EncriptarArchivoConfiguracion();

                var desencriptar = (ConfigurationManager.AppSettings["Web_Config_Asegurar"] ?? "").Trim().ToUpper() == "DESENCR";
                if (desencriptar)
                    experto.DesencriptarArchivoConfiguracion();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError().GetBaseException();
            Logger.Inst.Error("Unhandled Error:", ex);


            Server.ClearError();
        }
    }
}