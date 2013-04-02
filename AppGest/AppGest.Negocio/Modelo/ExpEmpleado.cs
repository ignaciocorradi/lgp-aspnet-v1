using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpEmpleado : ExpPersona<Empleado>
    {

        public IList<Empleado> ListaTodos(string nombre = null, string apellido = null, bool? activos = null)
        {

            var lstEntidades = Persistidor.Lista<Empleado>()
                .Where(c => String.IsNullOrEmpty(nombre) ? true : c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .Where(c => String.IsNullOrEmpty(apellido) ? true : c.Apellido.Contains(apellido, StringComparison.OrdinalIgnoreCase))
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                .Where(c => c.Lock == false)
                .OrderBy(c => c.NombreCompleto);

            return lstEntidades.ToList();
        }

        /// <summary>
        /// Obtiene los empleados activos que tienen Asignación de remuneraciones y no están dados de baja. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="activos"></param>
        /// <returns></returns>
        public IList<Empleado> EmpleadosALiquidar(string nombre = null, string apellido = null, bool? activos = null)
        {
            var cptoTran = HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_PARAM_EGRESO_EMPLEADO);

            var lstEntidades = Persistidor.Linq.Encabezados<Reg_encab>()
                .Where(enc => enc.Concepto.Id == cptoTran.Id)
                .Select(enc => enc.EntidadAfectada as Empleado)
                .Where(ent => ent.Baja == null && ent.Lock == false)

                .ToList()
                .OrderBy(ent => ent.NombreCompleto);

            return lstEntidades.ToList();
        }


        public override void ValidarNuevo(Empleado entidad)
        {
            base.ValidarNuevo(entidad);
            var lstRdo = new List<EstructuraValidacion>();
            if (entidad.Usuario != null)
            {
                var rdo = (from u in Persistidor.Linq.Entidades<Usuario>()
                           where u.Nombre == entidad.Usuario.Nombre
                           select u).Count();

                if (rdo > 0)
                    lstRdo.Add(new EstructuraValidacion()
                    {
                        Mensage = "\n\t - El nombre de usuario no está disponible.",
                        Tipo = EnumTipoError.Error
                    });

            }
            
            if (lstRdo.Count > 0)
                throw new ValidacionException("Revise los datos ingresados", lstRdo);
        }
        protected override void  ValidarAtributos(Empleado entidad)
        {
            string rdo = "";
            rdo += entidad.Nombre != string.Empty ? string.Empty : "\nNombre vacío: Debe ingresar un nombre.";
            rdo += entidad.Apellido != string.Empty ? string.Empty : "\nApellido vacío: Debe ingresar un nombre de usuario.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);
        }

        internal override void ValidarModificar(Empleado entidad)
        {
            base.ValidarModificar(entidad);
            ValidarAtributos((Empleado)entidad);
        }

        public override void Guardar(Empleado entidad)
        {
            if (entidad.Usuario != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpUsuarios>(this))
                {
                    exp.Proteger(entidad.Usuario);
                }
            }
            base.Guardar(entidad);
        }
    }
}
