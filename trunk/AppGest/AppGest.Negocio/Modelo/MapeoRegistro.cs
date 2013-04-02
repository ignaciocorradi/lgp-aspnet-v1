using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    internal abstract class KeyEntidad<TProxyEncab, TProxyDet>
        where TProxyEncab : ProxyRegistroEncab<TProxyDet>
        where TProxyDet : ProxyRegistroDet
    {

        public abstract string GetKeyLinea(TProxyDet prxLinea);
        public abstract string GetKeyLinea(Reg_Det linea);

    }


    internal abstract class MapeoRegistroProxy<TProxyEncab, TProxyDet, TKeyEntidad>
        where TProxyEncab : ProxyRegistroEncab<TProxyDet>
        where TProxyDet : ProxyRegistroDet
        where TKeyEntidad : KeyEntidad<TProxyEncab, TProxyDet>, new()
    {

        public static TKeyEntidad Key = new TKeyEntidad();

        internal abstract void LLenarRegistro(Reg_Det destino, TProxyDet origen, PersistidorPredet persistidor);
        internal abstract void LLenarProxy(TProxyDet destino, Reg_Det origen, PersistidorPredet persistidor);

        internal abstract void LLenarRegistro(Reg_encab destino, TProxyEncab origen, PersistidorPredet persistidor);
        internal abstract void LLenarProxy(TProxyEncab destino, Reg_encab origen, PersistidorPredet persistidor);

        protected TEntidad ObtenerAsocEnContexto<TEntidad>(EB origen, TEntidad destino, PersistidorPredet persistidor)
            where TEntidad: EB, new()
        {
            if (destino == null || origen == null
                || destino.Id == 0
                || origen.ContextoId == null
                || origen.ContextoId == null || origen.ContextoId.Equals(destino.ContextoId))

                return destino;
            else
                return persistidor.ObtenerEntidadPorId<TEntidad>(destino.Id);
        }
        protected TEntidad ObtenerAsocEnContexto<TEntidad>(Reg_Det origen, TEntidad destino, PersistidorPredet persistidor)
            where TEntidad : EB, new()
        {
            if (destino == null || origen == null
                || destino.Id == 0
                || origen.ContextoId == null
                || origen.ContextoId == null || origen.ContextoId.Equals(destino.ContextoId))

                return destino;
            else
                return persistidor.ObtenerEntidadPorId<TEntidad>(destino.Id);
        }
        protected TEntidad ObtenerAsocEnContexto<TEntidad>(Reg_encab origen, TEntidad destino, PersistidorPredet persistidor)
            where TEntidad : EB, new()
        {
            if (destino == null || origen == null
                || destino.Id == 0
                || origen.ContextoId == null
                || origen.ContextoId == null || origen.ContextoId.Equals(destino.ContextoId))

                return destino;
            else
                return persistidor.ObtenerEntidadPorId<TEntidad>(destino.Id);
        }


    }
}
