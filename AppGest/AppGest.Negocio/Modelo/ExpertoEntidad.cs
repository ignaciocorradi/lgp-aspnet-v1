using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;

using AppGest.Negocio.Core;


namespace AppGest.Negocio.Modelo
{
    public abstract class ExpertoEntidad<TEntidad>: Experto
        where TEntidad: Entidad, new()
    {
        public Usuario ObtenerUsuario(Guid idBorrar)
        {
            var id = ExpSeguridad.Instancia.ObtenerUsuarioId(this.IdSesion);
            var usuario = Persistidor.ObtenerEntidadPorId<Usuario>(id);
            return usuario;
        }     

        internal ExpertoEntidad()
        {
        }

        public TEntidad Nuevo()
        {
            TEntidad entidad = new TEntidad();
            entidad.Alta = DateTime.Now;
            Inicializar(entidad);

            return entidad;
        }
        protected abstract void Inicializar(TEntidad entidad);

        public IList<TEntidad> Lista()
        {
            return Persistidor.Linq.Entidades<TEntidad>().OrderBy(e => e.Nombre).ToList();

        }
        public TEntidad ObtenerPorId(long id)
        {
            return Persistidor.ObtenerEntidadPorId<TEntidad>(id);
        }

        public virtual void Guardar(TEntidad entidad)
        {
            if (entidad.Id == 0)
            {
                ValidarNuevo(entidad);
                entidad.Alta = (entidad.Alta == null || entidad.Alta == DateTime.MinValue) ? DateTime.Now : entidad.Alta;
                Persistidor.GuardarEntidadNuevo(entidad);
                if (_commit)
                    Persistidor.Confirmar();
            }
            else
            {
                ValidarModificar(entidad);
                Persistidor.GuardarEntidadModif(entidad);
                if (_commit)
                    Persistidor.Confirmar();
            }
        }

        internal virtual void ValidarModificar(TEntidad entidad)
        {
            ValidarAtributos(entidad);
        }

        public virtual void ValidarNuevo(TEntidad entidad)
        {
            ValidarAtributos(entidad);
        }

        protected virtual void ValidarAtributos(TEntidad entidad)
        {
            string rdo = "";

            rdo += entidad.Nombre != string.Empty ? string.Empty : "\nNombre vacío: Debe ingresar un nombre.";
            rdo += entidad.Abreviatura != string.Empty ? string.Empty : "\nSe debe proporconar una abreviatura.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);
        }

    }
}
