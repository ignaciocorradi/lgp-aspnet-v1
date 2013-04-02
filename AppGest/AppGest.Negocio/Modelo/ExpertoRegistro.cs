using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;

using AppGest.Negocio.Core;


namespace AppGest.Negocio.Modelo
{
    public class ExpertoRegistro : Experto
    {
        /// <summary>
        /// Transacción original (de la base de datos).
        /// Tiene valor durante le guardado de una transacción modificada.
        /// </summary>
        protected Reg_encab TransaccionBD { get; private set;}

        #region -- Metodos --

        public Usuario ObtenerUsuario(Guid idUsuario)
        {
            var id = ExpSeguridad.Instancia.ObtenerUsuarioId(this.IdSesion);
            var usuario = Persistidor.ObtenerEntidadPorId<Usuario>(id);
            return usuario;
        }
        
        public Reg_Det Nuevo(Reg_encab transaccion, Concepto concepto)
        {
            Reg_Det linea = this.NuevoDetalle();

            linea.SetReg_encab(transaccion);
            Inicializar(transaccion, linea, concepto);

            return linea;
        }

        protected Reg_Det NuevoDetalle()
        {
            Reg_Det linea = new Reg_Det();
            linea.Id = 0;
            linea.FechaAlta = DateTime.Now;

            return linea;
        }

        public Reg_encab Nuevo(Concepto conceptoTransaccion)
        {
            Reg_encab transaccion = new Reg_encab();
            Inicializar(transaccion, conceptoTransaccion);
            transaccion.FechaAlta = DateTime.Now;
            return transaccion;
        }

        public void AsignarRegistroDetalle(Reg_encab transaccion, Reg_Det linea, Concepto concepto)
        {
            this.Inicializar(transaccion, linea, concepto);
        }

        protected virtual void Inicializar(Reg_encab transaccion, Reg_Det linea, Concepto concepto)
        {
            
            linea.FechaModif = DateTime.Now;
            linea.SetConcepto(concepto);
            transaccion.Reg_Det.Add(linea);
        }
        
        protected virtual void Inicializar(Reg_encab transaccion, Concepto concepto)
        {
            
            transaccion.SetConcepto(concepto);
            transaccion.SetUsuario(this.ObtenerUsuario(this.IdSesion));
            transaccion.SetEntidadEmpresa(Persistidor.Linq.Entidades<Empresa>().FirstOrDefault());
        }
        
        public virtual IList<Reg_encab> Lista(Func<Reg_encab, bool> filtro)
        {
            return Persistidor.ListaRegEncab<Reg_encab>(filtro);
        }

        public Reg_encab ObtenerPorId(long id)
        {
            return Persistidor.ObtenerTransaccionPorId<Reg_encab>(id);
        }
        
        internal void Guardar(Reg_encab transaccion)
        {
            try
            {
                if (transaccion.Id == 0)
                {
                    ValidarNuevo(transaccion);
                    ValidarLineas(transaccion, true);
                    Persistidor.GuardarTransaccionNuevo<Reg_encab>(transaccion);
                }
                else
                {
                    TransaccionBD = Persistidor.ObtenerTransaccionPorId<Reg_encab>(transaccion.Id);
                    ValidarModificar(transaccion);
                    ValidarLineas(transaccion, false);
                    ValidarLineasEliminadas(transaccion);
                    Persistidor.GuardarTransaccionModif<Reg_encab>(transaccion);
                }
            }
            finally
            {
                TransaccionBD = null;
            }
        }

        protected virtual void ValidarLineasEliminadas(Reg_encab transaccion)
        {
            var lineasEliminadas = from linea in TransaccionBD.Reg_Det
                                   where !transaccion.Reg_Det.Select(x => x.Id).Contains(linea.Id)
                                   select linea;

            foreach (var linea in lineasEliminadas)
                ValidarLineaEliminada(linea);
        }

        protected virtual void ValidarLineaEliminada(Reg_Det lineaBD)
        {
        }

        private void ValidarLineas(Reg_encab transaccion, bool transaccionNueva)
        {
            foreach (var linea in transaccion.Reg_Det)
            {
                ValidarLinea(linea, transaccionNueva);
            }
        }

        protected virtual void ValidarLinea(Reg_Det linea, bool transaccionNueva)
        {
        }

        protected virtual void ValidarModificar(Reg_encab transaccion)
        {
        }

        protected virtual void ValidarNuevo(Reg_encab transaccion)
        {
        }

        protected void Copiar1(Reg_encab origen, Reg_encab destino)
        {
            throw new NotImplementedException("Copiar(Reg_encab, Reg_encab) en ExpertoRegistro");
            //destino.Id = origen.Id;
            //destino.abreviatura = origen.abreviatura;
            //destino.apellido = origen.apellido;
            //destino.Contacto = new Contacto();
            //destino.Contacto.domicilio = origen.Contacto.domicilio;
            //destino.Contacto.email = origen.Contacto.email;
            //destino.Contacto.movil = origen.Contacto.movil;
            //destino.Contacto.telefono = origen.Contacto.telefono;
            //destino.Contacto.telefonoTrabajo = origen.Contacto.telefonoTrabajo;
            //destino.fechaalta = destino.fechaalta; //Indica la fecha de alta
            //destino.fechabaja = destino.fechabaja; // Establece a Null la fecha de baja. 
            //destino.idtipo = origen.idtipo;
            //destino.nombre = origen.nombre;
            //destino.segundoNombre = origen.segundoNombre;

        }
        #endregion
    }
}
