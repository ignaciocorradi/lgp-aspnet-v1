using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppGest.Negocio.Modelo.Reportes.Configuracion
{
    public class RptItemParams : ConfigurationElement
    {
        [ConfigurationProperty("Key", IsRequired = true)]
        public string Key
        {
            get
            {
                return this["Key"] as string;
            }
        }

        [ConfigurationProperty("Value", IsRequired = true)]
        public string Valor
        {
            get
            {
                return (this["Value"] ?? string.Empty) as string;
            }
        }
    }
}
