using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo
{
    public class ExpVehiculos:ExpertoEntidad<Vehiculo>
    {

        protected override void ValidarAtributos(Vehiculo entidad)
        {
            string rdo = "";
            rdo += entidad.Nombre != string.Empty ? string.Empty : "\nDebe proporcionar el Dominio del vehículo.";
            rdo += entidad.Marca != string.Empty ? string.Empty : "\nDebe proporcionar la Marca del vehículo.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);
        }

        protected override void Inicializar(Vehiculo entidad)
        {
            entidad.Alta = DateTime.Now;
            entidad.Baja = null;
        }

        public string ObtenerInfoVehiculo(long idVehiculo)
        {
            string rdo ="";
            var cptoRelVehiculo = HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_VEHICULO).Id;

            var lineas = from linea in Persistidor.Linq.Lineas<Reg_Det>()
                         orderby linea.ValFecha2 descending
                         where (linea.Concepto.Id == cptoRelVehiculo) && (linea.ValLista1.Id == idVehiculo)
                         select new
                         {
                             Cliente = linea.EntidadAfectada1 as Cliente,
                             Baja = linea.ValFecha2
                         };

            foreach (var item in lineas)
            {
                rdo += "\n\tCliente: " + item.Cliente.Apellido + ", " + item.Cliente.Nombre
                     +" - Estado: " + (item.Baja.HasValue ? " Baja: " + item.Baja.Value.ToShortDateString() : " Activo.");
            }
           
            return rdo.Length>0? "Vehículo relacionado con: " + rdo : "Vehículo no asociado a ningún cliente.";

            
        }

        public IList<Vehiculo> ListaTodos(string dominio, string marca, bool? activos)
        {
            var lst = Persistidor.Lista<Vehiculo>()
                .Where(c => String.IsNullOrEmpty(dominio) ? true : c.Nombre.Contains(dominio, StringComparison.OrdinalIgnoreCase))
                .Where(c => String.IsNullOrEmpty(marca) ? true : c.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase))
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                .OrderBy(c => c.Nombre);

            return lst.ToList();
        }
    }
}
