using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;


namespace AppGest.Negocio.Modelo.Inicializacion
{
    public class ExpInicializacion: Experto
    {

        public Usuario ObtenerUsuario()
        {
            var id = ExpSeguridad.Instancia.ObtenerUsuarioId(this.IdSesion);
            var usuario = Persistidor.ObtenerEntidadPorId<Usuario>(id);
            return usuario;
        }

        public Usuario ObtenerUsuario(Experto exp)
        {
            var id = ExpSeguridad.Instancia.ObtenerUsuarioId(this.IdSesion);
            var usuario = exp.Persistidor.ObtenerEntidadPorId<Usuario>(id);
            return usuario;
        }

        public bool TryInitDB()
        {
            return Persistidor.TryInitDB();
        }

        public virtual void Inicializar() 
        {
            InicializarOActualizarConceptos();

            if (Persistidor.Contar<Usuario>() == 0)
            {
                
            }
            else
            {
                //No te asustes Mario :)
                // throw new Exception("Base de Datos ya inicializada. Verificar parametro de inicializacion en web.config");
            }
        }

        private void InicializarOActualizarConceptos()
        {
            CrearConceptos();
        }

        protected virtual void CrearConceptos()
        {
            var experto = new ExpConcepto();

            var conceptos = Enumeraciones.CrearConceptos();

            var conceptosBD = (from c in Persistidor.Linq.EntidadesConBajas<Concepto>() select c).ToList();
            conceptosBD = conceptosBD.Where(c => ValorEnumDeUsuarioAttribute.EsDeSistema(c.ValorEnum)).ToList();


            var eliminar = from cBD in conceptosBD
                           where !conceptos.Select(x => x.Key).Contains(cBD.Key)
                           select cBD;

            var insertar = from cNuevo in conceptos
                           where !conceptosBD.Select(x => x.Key).Contains(cNuevo.Key)
                           select cNuevo;

            Persistidor.Compartido = true;
            foreach (var elim in eliminar)
                Persistidor.Eliminar<Concepto>(elim.Id);

            foreach (var ins in insertar)
            {
                ins.Alta = DateTime.Now;
                Persistidor.GuardarEntidadNuevo(ins);
            }

            Persistidor.Confirmar();


        }

        protected virtual void CrearMenuSistema()
        {
            var configs = new List<ConfMenuProxy>();
            using (var exp = FabExpertos.Inst.Obtener<ExpConfSistema>(IdSesion))
            { configs = exp.ObtenerConfMenuInicial(); }

            var confsNuevas = (from conf in configs
                               select new ConfMenu()
                               {
                                   AutoSize = conf.AutoSize,
                                   Grupos = conf.Grupos,
                                   ImagenItem = conf.ImagenItem,
                                   Items = conf.Items,
                                   Orden = conf.Orden,
                                   Paginas = conf.Paginas,
                                   TagItem = conf.TagItem,
                                   ToolTips = conf.ToolTips
                               }).ToList();

            foreach (var item in confsNuevas)
            {


                using (var exp = FabExpertos.Inst.Obtener<ExpConfSistema>(IdSesion))
                {
                    exp.Guardar(item);

                    exp.Persistidor.Confirmar();
                }

            }



        }


    }
}
