using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpRegistroTest: Experto
    {
        public void Guardar(string cNombre, string eNombre)
        {

            using (var expC = FabExpertos.Inst.Obtener<ExpClientes>(this))
            {
                using (var expE = FabExpertos.Inst.Obtener<ExpEmpleado>(this))
                {
                    var c = expC.Nuevo();
                    c.Nombre = cNombre;
                    expC.Guardar(c);

                    var e = expE.Nuevo();
                    e.Nombre = eNombre;
                    expE.Guardar(e);

                }
            }

        }
    }
}
