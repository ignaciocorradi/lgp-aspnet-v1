using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Modelo;


namespace AppGest.Negocio.Core
{
    /// <summary>
    /// Interfaz para la funcionalidad de Inyección de Dependencia.
    /// </summary>
    public interface IIoC
    {
        /// <summary>
        /// Obtiene el objeto del tipo especificado, que es convertible al tipo T genérico.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        T Obtener<T>(Type type);

        /// <summary>
        /// Devuelve un experto,
        /// </summary>
        /// <typeparam name="T">Tipo de la interfaz a instanciar</typeparam>
        /// <returns></returns>
        T Obtener<T>() where T : new();
        /// <summary>
        /// Devuelve un experto cuya implementación requiere una sesión como parámetro del constructor.
        /// </summary>
        /// <typeparam name="T">Tipo de la interfaz dle experto solicitado.</typeparam>
        /// <param name="idSesion">ID de la sesión.</param>
        /// <returns></returns>
        T Experto<T>(Guid idSesion) where T: Experto, new();

        
    }
}
