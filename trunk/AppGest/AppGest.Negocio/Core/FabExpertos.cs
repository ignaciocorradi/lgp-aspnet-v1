using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos;
using AppGest.Negocio.Modelo.Inicializacion;
using System.Configuration;
using AppGest.Negocio.Modelo;

namespace AppGest.Negocio.Core
{
    public class FabExpertos
    {
        public static FabExpertos Inst = new FabExpertos();

        /// <summary>
        /// Obtiene un experto nuevo que esta compartiendo Persistidor con los demas expertos
        /// </summary>
        /// <typeparam name="TExperto"></typeparam>
        /// <param name="experto"></param>
        /// <returns></returns>
        public TExperto Obtener<TExperto>(Experto experto)
            where TExperto: Experto, new()
        {
            var exp = IoC.Singleton.Experto<TExperto>(experto.IdSesion);
            exp.Persistidor = experto.Persistidor;
            exp.Persistidor.Compartido = true;

            return exp;
        }
        /// <summary>
        /// Obtiene un experto nuevo.
        /// </summary>
        /// <typeparam name="TExperto"></typeparam>
        /// <returns></returns>
        public TExperto Obtener<TExperto>(Guid idSesion)
            where TExperto : Experto, new()
        {
            var exp = IoC.Singleton.Experto<TExperto>(idSesion);
            return exp;
        }
    }
}
