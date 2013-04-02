using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Datos.Persistencia
{
    class LinqEntidades: ILinqEntidades
    {
        Contendor_LGP _contenedor;
        ILinqEntidades ThisAsConsulta { get { return (ILinqEntidades) this; } }
        internal LinqEntidades(Contendor_LGP contenedor)
        {
            _contenedor = contenedor;
        }


        IQueryable<EB> ILinqEntidades.Entidades()
        {
            return ThisAsConsulta.Entidades<EB>().Where(e => e.Baja == null).AsQueryable();
        }

        IQueryable<TEntidad> ILinqEntidades.Entidades<TEntidad>()
        {
            return _contenedor.EB.OfType<TEntidad>().Where(e => e.Baja == null).AsQueryable();
        }

        IQueryable<Reg_encab> ILinqEntidades.Encabezados()
        {
            return ThisAsConsulta.Encabezados<Reg_encab>().Where(e => e.FechaBaja == null).AsQueryable();
        }

        IQueryable<TEntidad> ILinqEntidades.Encabezados<TEntidad>()
        {
            return _contenedor.Reg_encab.OfType<TEntidad>().Where(e => e.FechaBaja == null).AsQueryable();
        }

        IQueryable<Reg_Det> ILinqEntidades.Lineas()
        {
            return ThisAsConsulta.Lineas<Reg_Det>().Where(e => e.FechaBaja == null).AsQueryable();
        }

        IQueryable<TEntidad> ILinqEntidades.Lineas<TEntidad>()
        {
            return _contenedor.Reg_Det.OfType<TEntidad>().Where(e => e.FechaBaja == null).AsQueryable();
        }



        IQueryable<EB> ILinqEntidades.EntidadesConBajas()
        {
            return ThisAsConsulta.Entidades<EB>();
        }

        IQueryable<TEntidad> ILinqEntidades.EntidadesConBajas<TEntidad>()
        {
            return _contenedor.EB.OfType<TEntidad>();
        }

        IQueryable<Reg_encab> ILinqEntidades.EncabezadosConBajas()
        {
            return ThisAsConsulta.Encabezados<Reg_encab>();
        }

        IQueryable<TEntidad> ILinqEntidades.EncabezadosConBajas<TEntidad>()
        {
            return _contenedor.Reg_encab.OfType<TEntidad>();
        }

        IQueryable<Reg_Det> ILinqEntidades.LineasConBajas()
        {
            return ThisAsConsulta.Lineas<Reg_Det>();
        }

        IQueryable<TEntidad> ILinqEntidades.LineasConBajas<TEntidad>()
        {
            return _contenedor.Reg_Det.OfType<TEntidad>();
        }

        IQueryable<ConfMenu> ILinqEntidades.ConfigMenu()
        {
            return _contenedor.ConfMenu.AsQueryable();
        }
    }
}
