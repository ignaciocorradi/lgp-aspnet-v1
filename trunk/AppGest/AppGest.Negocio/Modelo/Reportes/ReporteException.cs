using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Negocio.Modelo.Reportes
{
    /// <summary>
    /// Representa un error en la configuración o ejecución de reportes.
    /// </summary>
    public class ReporteException: Exception
    {
        internal ReporteException(string mensaje, Exception inner) : base(mensaje, inner) { }
        internal ReporteException(string mensaje) : base(mensaje, null) { }
        internal ReporteException() : this("Se produjeron errores en el procesamiento de la información de reportes.") { }
    }
}
