using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using System.Configuration;

namespace System.Data.Objects.DataClasses
{
    public static class EntityObjectExtensiones
    {
        /// <summary>
        /// Asigna una referencia, teniendo en cuenta el estado de persistencia del objeto.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad asociada</typeparam>
        /// <param name="propEntidad">Nombre de la propiedad que hace referencia a la entidad</param>
        /// <param name="propReferencia">Nombre de la propiedad que hace referencia a EntityKey</param>
        /// <param name="forzarPorInstancia">(Opcional) Fuerza el seteo por referencia.</param>
        /// <param name="entidad">Entidad a asignar</param>
        public static void SetRelacion<TEntity>(this EntityObject _this, string propEntidad, string propReferencia, TEntity entidad, bool forzarPorInstancia = false)
            where TEntity: EntityObject
        {
            var x = ((IObjectContext)_this).ContextoId;
            var y = entidad != null ? ((IObjectContext)entidad).ContextoId : null;

            if (forzarPorInstancia || entidad == null || x == null || y == null || x.Equals(y))
            {
                _this.GetType().GetProperty(propEntidad).SetValue(_this, entidad, null);
            }
            else
            {
                // otro caso
                var reference = _this.GetType().GetProperty(propReferencia).GetValue(_this, null);
                if (reference != null)
                    reference.GetType().GetProperty("EntityKey").SetValue(reference, entidad.EntityKey, null);
            }
        }
    }
}
