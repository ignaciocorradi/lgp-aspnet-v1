using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Util;

namespace AppGest.Negocio.Modelo
{
    public class ExpClientes: ExpPersona<Cliente>
    {

        public IList<Cliente> ListaTodos(int? nrocliente = null, string nombre = null, bool? activos = null)
        {

            var lstEntidades = Persistidor.Lista<Cliente>()
                .Where(e =>(string.IsNullOrEmpty(nombre) || (e.Nombre.ToUpper().Contains(nombre.ToUpper())
                                                || e.Apellido.ToUpper().Contains(nombre.ToUpper()))))
                .Where(c => !nrocliente.HasValue ? true : c.NroCliente == nrocliente.Value)
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                .OrderBy(c => c.NombreCompleto);

            return lstEntidades.ToList();
        }
        public IList<Cliente> ListaTodos(int? nrocliente = null, string nombre = null, string apellido = null, bool? activos = null)
        {

            var lstEntidades = Persistidor.Lista<Cliente>()
                .Where(c => String.IsNullOrEmpty(nombre) ? true : c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .Where(c => String.IsNullOrEmpty(apellido) ? true : c.Apellido.Contains(apellido, StringComparison.OrdinalIgnoreCase))
                .Where(c => !nrocliente.HasValue ? true : c.NroCliente == nrocliente.Value)
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                .OrderBy(c => c.NombreCompleto);

            return lstEntidades.ToList();
        }
       
        protected override void ValidarAtributos(Cliente entidad)
        {
            string rdo = "";
            rdo += entidad.Nombre != string.Empty ? string.Empty : "\nNombre vacío: Debe ingresar un nombre.";
            rdo += entidad.Apellido != string.Empty ? string.Empty : "\nApellido vacío: Debe ingresar un nombre de usuario.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);

            base.ValidarAtributos(entidad);
        }
        
        public override void Guardar(Cliente entidad)
        {
            if (Persistidor.Lista<Cliente>().Count > 0)
            {
                if (entidad.Id == 0 && entidad.NroCliente == 0)
                    entidad.NroCliente = Persistidor.Lista<Cliente>().Max(c => c.NroCliente) + 1;
            }
            else
                entidad.NroCliente = 1;

            base.Guardar(entidad);
        }
    }


}
