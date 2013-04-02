using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AppGest.Negocio.Modelo.Reportes.Configuracion
{

    [ConfigurationCollection(typeof(RptItemSettings),CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class RptItemSettingsCollection : ConfigurationElementCollection
    {
        public RptItemSettings this[int index]
        {
            get { return BaseGet(index) as RptItemSettings; }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public new RptItemSettings this[string name]
        {
            get { return BaseGet(name) as RptItemSettings; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "reporte"; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RptItemSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var value = element as RptItemSettings;
            return value != null ? value.Key : null;
        }
    }
}