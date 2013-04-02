using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpCocheras:ExpertoEntidad<Cochera>
    {
        protected override void Inicializar(Cochera entidad)
        {
            var nroCocheraProx = Persistidor.Lista<Cochera>().Max(c => Convert.ToInt32(c.Nombre.Substring(1, c.Nombre.Length - 1))) + 1;
            entidad.NroCochera = "C" + nroCocheraProx.ToString();
            entidad.Abreviatura = entidad.NroCochera;
            entidad.Alta = DateTime.Now.Truncar(DateInterval.Day);
        }

        /// <summary>
        /// Regresa la lista de cocheras no asociadas a un cliente
        /// </summary>
        /// <returns></returns>
        public List<Cochera> ListaCocherasDisponibles()
        {
            
            Concepto cptoRelCochera = HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_COCHERA);
            
            var lstEntidades = Persistidor.Lista<Cochera>().Where(ent => ent.Baja == null).ToList();

           
            List<Reg_Det> lstRegistrosAsoc = Persistidor.ListaRegDet<Reg_Det>().Where(reg => reg.FechaBaja == null
                                                                                              && reg.ValLista1 != null
                                                                                              && reg.Concepto.Id == cptoRelCochera.Id
                                                                                              && reg.ValFecha2 == null).ToList();


            var cocherasDisp = from e in lstEntidades
                               where !lstRegistrosAsoc.Any(r => r.ValLista1.Id == e.Id)
                               select e;

            return cocherasDisp.ToList();
        }

        public override void ValidarNuevo(Cochera entidad)
        {
            base.ValidarNuevo(entidad);
            var lstRdo = new List<EstructuraValidacion>();

            var rdo = Persistidor.Linq.Entidades<Cochera>().Where(c => c.Nombre.Equals(entidad.Nombre) 
                                                                  && c.Id != entidad.Id
                                                                  && !c.Baja.HasValue 
                                                                  ).Count();
            if (rdo > 0)
                lstRdo.Add(new EstructuraValidacion() 
                        { Tipo = EnumTipoError.Error
                        , Mensage = "Ya existe una cochera con el nro " + entidad.Nombre }
                        );

            if(lstRdo.Count>0)
                throw new ValidacionException("No se puede crear la cochera", lstRdo  ); 
            
        }
        protected override void ValidarAtributos(Cochera entidad)
        {
            string rdo = "";
            rdo += entidad.NroCochera != string.Empty ? string.Empty : "\nNro de cochera vacío: Debe ingresar un Nro de cochera.";
            //rdo += entidad.Descripcion != string.Empty ? string.Empty : "\nMarca vacío: Debe ingresar la Marca del vehículo.";

            if (rdo.Length != 0)
                throw new InvalidOperationException(rdo);
            else
                base.ValidarAtributos(entidad);

        }

        public IList<Cochera> ListaTodos(string cochera = null, string desc = null, bool? activos = null)
        {

            var lst = Persistidor.Lista<Cochera>()
                .Where(c => String.IsNullOrEmpty(cochera) ? true : c.Nombre.Contains(cochera, StringComparison.OrdinalIgnoreCase))
                .Where(c => String.IsNullOrEmpty(desc) ? true : c.Descripcion.Contains(desc, StringComparison.OrdinalIgnoreCase))
                .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                .OrderBy(c => c.NroCochera);

            return lst.ToList();
        }
    }
}
