using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AppGest.Datos.Persistencia.Extensiones.Templates
{
    public static class HelperCsClase
    {
        public static Match ObtenerPropiedades(string archivoCs)
        {
            var codigo = File.ReadAllText(archivoCs);
            return null;
        }
    }
}
