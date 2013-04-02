using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace AppGest.Negocio.Modelo.Reportes.Configuracion
{
    public class RptItemSettings : ConfigurationElement
    {
        public string UrlServidor
        {
            get
            {
                return _urlServidor;
            }
            set
            {
                //Solo se carga una unica vez
                if (String.IsNullOrWhiteSpace(_urlServidor))
                {
                    _urlServidor = value;
                }
            }
        }private static string _urlServidor = string.Empty;

        [ConfigurationProperty("Key", IsRequired = true)]
        public string Key
        {
            get
            {
                return this["Key"] as string;
            }
        }

        [ConfigurationProperty("nombre", IsRequired = true)]
        public string Nombre
        {
            get
            {
                return (this["nombre"] ?? string.Empty) as string;
            }
        }

        [ConfigurationProperty("reporte", IsRequired = true)]
        public string Reporte
        {
            get
            {
                return (this["reporte"] ?? string.Empty).ToString();
            }
        }

        [ConfigurationProperty("prms", IsRequired = true)]
        public string Permiso
        {
            get
            {
                return (this["prms"] ?? string.Empty).ToString();
            }
        }

        [ConfigurationProperty("prmtrs", IsDefaultCollection = true)]
        public RptItemParamsCollection Parametros
        {

            get { return (RptItemParamsCollection)base["prmtrs"]; }

        } 
    }
}
