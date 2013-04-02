using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;

using AppGest.Negocio.Core;


namespace AppGest.Negocio.Modelo
{
    public abstract class ExpertoEB<TEntidad> : Experto
        where TEntidad : EB, new()
    {
        internal ExpertoEB()
        {
        }

        public virtual TEntidad Nuevo()
        {
            TEntidad entidad = new TEntidad();
            Inicializar(entidad);

            return entidad;
        }


        protected abstract void Inicializar(TEntidad entidad);


        public virtual IList<TEntidad> Lista()
        {
            return Persistidor.Lista<TEntidad>();
        }

        public TEntidad ObtenerPorId(long id)
        {
            return Persistidor.ObtenerEntidadPorId<TEntidad>(id);
        }
        public void Guardar(TEntidad entidad)
        {
            if (entidad.Id == 0)
            {
                ValidarNuevo(entidad);
                Persistidor.GuardarEntidadNuevo(entidad);
            }
            else
            {

                ValidarModificar(entidad);
                Persistidor.GuardarEntidadModif(entidad);
            }
        }

        protected virtual void ValidarModificar(TEntidad entidad)
        {
        }

        protected virtual void ValidarNuevo(TEntidad entidad)
        {

        }

    }
}
