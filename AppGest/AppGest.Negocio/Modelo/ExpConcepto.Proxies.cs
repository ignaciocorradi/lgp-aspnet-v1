using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo
{
    public class ProxyLineaConcepto
    {

        Reg_Det Linea;
        public ProxyLineaConcepto(Reg_Det linea)
        {
            Linea = linea;
        }

        public decimal? Precio
        {
            get
            {
                return Linea.Precio;
            } 
        }
        public DateTime? Desde
        {
            get
            {
                return Linea.ValFecha1;
            }
        }
        public DateTime? Hasta
        {
            get
            {
                return Linea.ValFecha2;
            }
        }

        public Concepto Concepto
        {
            get
            {
                return Linea.Concepto;
            }
        }

        public string DetalleLinea
        {
            get 
            {
                string rdo = string.Empty;
                if (Linea != null)
                {
                    rdo = Linea.Precio.ToString() + " desde " + (Desde.HasValue ? Desde.Value.ToString("MMM yyyy") : string.Empty);
                }
                return rdo;
            }
        }

    }
}
