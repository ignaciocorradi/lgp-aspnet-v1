using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Negocio.Core
{
    /// <summary>
    /// Clase de validaciones utilizadas en los expertos.
    /// </summary>
    public partial class ValidacionException : Exception
    {
        public List<EstructuraValidacion> DatosValidacion { get; set; }

        public ValidacionException(string mensage, List<EstructuraValidacion> datosValidacion = null)
            :base(mensage)
        {
            this.DatosValidacion = datosValidacion ?? new List<EstructuraValidacion>();
        }

        /// <summary>
        /// Regresa un string concatenando todos los mensaje de error.
        /// </summary>
        public string MessageComplete
        {
            get 
            {
                return string.Empty + string.Concat((from e in DatosValidacion select e.Mensage)); 
            }
        }
        /// <summary>
        /// Regresa un string concatenando todos los mensaje de error.
        /// </summary>
        public string MessageCompleteConTitulo
        {
            get
            {
                return string.Empty + this.Message + string.Concat((from e in DatosValidacion select e.Mensage));
            }
        }
    }

    public enum EnumTipoError
    {
        Error = 0,
        Advertencia = 1
    }
    public class EstructuraValidacion
    {
        public EnumTipoError Tipo { get; set; }
        public string Mensage { get; set; }
    }

}
