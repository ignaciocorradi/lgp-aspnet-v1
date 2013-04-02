using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Funcionalidad que extienede la clase Dictionay
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Obtiene el valor bajo la llave proporcionada, convirtiendola al tipo especificado.
        /// Si no la encuentra devuelve el valor por omisión.
        /// </summary>
        /// <typeparam name="TKey">Tipo de la de búsqueda</typeparam>
        /// <typeparam name="TResultado">Tipo del resultado</typeparam>
        /// <param name="_this">Esta instancia</param>
        /// <param name="key">LLave de búsqueda</param>
        /// <param name="omision">Valor por omisión</param>
        /// <returns></returns>
        public static TResultado Obtener<TResultado, TKey, TValue>(this Dictionary<TKey, TValue> _this, TKey key, TResultado omision)
        {
            TValue rdo = default(TValue);
            if (_this.TryGetValue(key, out rdo))
                return (TResultado) ((object) rdo);
            else
                return omision;
        }
    }
}
