using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace AppGest.Datos.Persistencia.Conversion
{
    interface IConversorEntidades
    {
        EntityObject CrearGenerico<TEspecifico>()
            where TEspecifico : EntityObject;

        EntityObject CrearGenerico(EntityObject especifico, bool llenar);

        EntityObject CrearGenerico(Type tipoEspecifico);

        void LLenarGenerico(EntityObject generico, EntityObject especifico);

        TEspecifico CrearEspecifico<TEspecifico>(EntityObject generico)
            where TEspecifico : EntityObject, new();

        Type TipoGenerico<TEspecifico>()
            where TEspecifico : EntityObject;

        Type TipoGenerico(Type tipoEspecifico);


        //TipoClase TipoClase<TEspecifico>()
        //    where TEspecifico: EntityObject;
        
        //TipoClase Tipoclase(Type tipoEspecifico);

        //bool EsTipo<TEspecifico>(EB entidad)
        //    where TEspecifico : EntityObject;

    }
}
