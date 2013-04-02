using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Datos.Persistencia
{
 
    
    #region -- Clases de Listas parámetros ---

    public partial class Cochera : Entidad
    {
        public string NroCochera
        {
            get
            {
                return this.Nombre;
            }
            set
            {
                this.Nombre = value;
            }
        }
        
        public override bool Equals(object obj)
        {
            Cochera cObj = obj as Cochera;
            bool rdo = false;
            if (cObj != null)
            {
                rdo = this.Id == cObj.Id;
            }
            return rdo;
        }
    }

    public partial class Vehiculo : Entidad
    {
        public string Detalle
        {
            get
            {
                return (Marca + " - " + Nombre + " - " + Modelo).Trim();
            }
        }
    }
    
    #endregion

    #region -- Clases de Movimientos ---

    #endregion

}
