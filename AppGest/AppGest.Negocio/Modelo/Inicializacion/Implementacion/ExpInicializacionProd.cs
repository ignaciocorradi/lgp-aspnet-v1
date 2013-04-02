using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo.Inicializacion.Implementacion
{
    public class ExpInicializacionProd: ExpInicializacion
    {
        protected override void CrearConceptos()
        {
            base.CrearConceptos();

            var cpto = new Concepto()
            {
                Alta = DateTime.Now,
                Nombre = "Remuneración",
                Abreviatura = "REMU",
                Descripcion = "Remuneración",
                Clase = (int)TipoConcepto.ConceptoEgresos,
                Valor = (int)ConceptoEgresos.EGRESOS_EMPLEADOS
            };

            Persistidor.GuardarEntidadNuevo(cpto);
            Persistidor.Confirmar();
        }
    }
}
