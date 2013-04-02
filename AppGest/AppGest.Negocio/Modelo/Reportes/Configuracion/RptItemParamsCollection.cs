using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppGest.Negocio.Modelo.Reportes.Configuracion
{
    [ConfigurationCollection(typeof(RptItemParams),CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class RptItemParamsCollection : ConfigurationElementCollection
    {
        public RptItemParams this[int index]
        {
            get { return BaseGet(index) as RptItemParams; }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public new RptItemParams this[string name]
        {
            get { return BaseGet(name) as RptItemParams; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "prmtr"; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RptItemParams();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var value = element as RptItemParams;
            return value != null ? value.Key : null;
        }
    }
}
