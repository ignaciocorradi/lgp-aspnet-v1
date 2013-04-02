using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Datos.Persistencia
{
    public interface ILinqEntidades
    {
        IQueryable<ConfMenu> ConfigMenu();
        IQueryable<EB> Entidades();
        IQueryable<EB> EntidadesConBajas();
        IQueryable<TEntidad> Entidades<TEntidad>()
            where TEntidad : EB;

        IQueryable<TEntidad> EntidadesConBajas<TEntidad>()
            where TEntidad : EB;

        IQueryable<Reg_encab> Encabezados();
        IQueryable<Reg_encab> EncabezadosConBajas();
        IQueryable<TEntidad> Encabezados<TEntidad>()
            where TEntidad : Reg_encab;
        IQueryable<TEntidad> EncabezadosConBajas<TEntidad>()
            where TEntidad : Reg_encab;

        IQueryable<Reg_Det> Lineas();
        IQueryable<Reg_Det> LineasConBajas();
        IQueryable<TEntidad> Lineas<TEntidad>()
            where TEntidad : Reg_Det;
        IQueryable<TEntidad> LineasConBajas<TEntidad>()
            where TEntidad : Reg_Det;
    }
}
