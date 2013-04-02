using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public static class HelperModelo
    {
        /// <summary>
        /// Devuelve el concepto de sistema correspondiente al valor pasado como parametro
        /// </summary>
        /// <param name="experto">Instancia de un experto con un persistidor</param>
        /// <param name="valor">Valor del concepto a recuperar</param>
        /// <returns>Concepto</returns>
        public static Concepto ObtenerConceptoSistema(Experto experto, Enum valor)
        {
            var persComp = experto.Persistidor.Compartido;
            var exp = FabExpertos.Inst.Obtener<ExpConcepto>(experto);
            experto.Persistidor.Compartido = persComp;

            return exp.ObtenerConceptoSistema(valor);
        }

        /// <summary>
        /// Devuelve los conceptos de usuario correspondientes al valor pasado como parametro
        /// </summary>
        /// <param name="experto">Instancia de un experto con un persistidor</param>
        /// <param name="valor">Valor de los conceptos de usuario a recuperar</param>
        /// <returns>Lista de Conceptos</returns>
        public static List<Concepto> ObtenerConceptosUsuario(Experto experto, Enum valor)
        {
            var persComp = experto.Persistidor.Compartido;
            var exp = FabExpertos.Inst.Obtener<ExpConcepto>(experto);
            experto.Persistidor.Compartido = persComp;

            return exp.ListaConceptos(null, valor).ToList<Concepto>();
        }
    }
}
