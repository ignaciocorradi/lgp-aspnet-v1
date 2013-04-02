using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Util;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpPersona<TPersona> : ExpertoEntidad<TPersona>
        where TPersona: Persona, new()
    {


        public IList<Persona> ListaTodos(string nombre = null, string apellido = null, bool? activos = null)
        {

            var lstEntidades = Persistidor.Lista<Persona>()
                .Where(c => String.IsNullOrEmpty(nombre) ? true : c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .Where(c => String.IsNullOrEmpty(apellido) ? true : c.Apellido.Contains(apellido, StringComparison.OrdinalIgnoreCase))
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null));
            
            return lstEntidades.ToList();
        }

        protected override void Inicializar(TPersona entidad)
        {
            entidad.Alta = DateTime.Now;
        }

        public override void ValidarNuevo(TPersona entidad)
        {
            
            ValidarAtributos(entidad);

            if (entidad.Usuario != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpUsuarios>(this))
                    exp.ValidarNuevo(entidad.Usuario);
            }
        }

        protected virtual void ValidarAtributos(TPersona entidad)
        {

            string rdo = "";
            rdo += entidad.Nombre != string.Empty ? string.Empty : "\nNombre vacío: Debe ingresar un nombre.";
            rdo += entidad.Apellido != string.Empty ? string.Empty : "\nApellido vacío: Debe ingresar un nombre de usuario.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);
        }

        internal override void ValidarModificar(TPersona entidad)
        {
            base.ValidarModificar(entidad);
            ValidarAtributos(entidad);

            if (entidad.Usuario != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpUsuarios>(this))
                    exp.ValidarModificar(entidad.Usuario);
            }
        }


        /// <summary>
        /// Crea un usuario a la persona especificada.
        /// </summary>
        /// <param name="persona">Persona propietaria del usuario</param>
        public void CrearUsuario(Persona persona)
        {
            if (persona.Usuario == null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpUsuarios>(this))
                    persona.SetUsuario(exp.Nuevo());

                persona.Usuario.SetPersona(persona);
            }
        }

        /// <summary>
        /// Inicializa una instancia de persona, alternativamente inicializa un usuario asociado a esta.
        /// </summary>
        /// <param name="entidad">Persona a inicializar</param>
        /// <param name="crearUsuario">Indica si se requiere la creación de un usuario para la persona</param>
        protected virtual void Inicializar(TPersona entidad, bool crearUsuario)
        {
            Inicializar(entidad);
            if (crearUsuario)
                CrearUsuario(entidad);
        }

        /// <summary>
        /// Crea una persona. Opcionalmente crea y asocia un nuevo usuario para esta.
        /// </summary>
        /// <param name="crearUsuario"></param>
        /// <param name="crearUsuario">Indica si se requiere la creación de un usuario para la persona</param>
        public TPersona Nuevo(bool crearUsuario)
        {
            var entidad = Nuevo();
            Inicializar(entidad, crearUsuario);

            return entidad;
        }
    }
}
