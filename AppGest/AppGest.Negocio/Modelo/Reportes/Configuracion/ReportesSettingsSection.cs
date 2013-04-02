using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace AppGest.Negocio.Modelo.Reportes.Configuracion
{
    public class ReportesSettingsSection : ConfigurationSection
    {
        /// <summary>
        /// Nombre completo de acceso a la sección en el archivio de configuración.
        /// </summary>
        public static string NOMBRE_SECCION = "AppGest/Reportes";

        public static ReportesSettingsSection GetConfig()
        {
            return (ReportesSettingsSection)ConfigurationManager.GetSection(NOMBRE_SECCION) ?? new ReportesSettingsSection();
        }

        [ConfigurationProperty("url-servidor", IsRequired = true, DefaultValue="http://localhost/ResportServer")]
        public string UrlServidor
        {
            get
            {
                return this["url-servidor"] as string;
            }
        }

        [ConfigurationProperty("reportes", IsRequired = true)]
        public RptItemSettingsCollection Reportes
        {
            get
            {
                return (this["reportes"] as RptItemSettingsCollection) ?? new RptItemSettingsCollection();
            }
        }
    }
}
