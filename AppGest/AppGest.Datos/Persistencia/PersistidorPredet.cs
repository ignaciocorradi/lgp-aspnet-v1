using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using AppGest.Datos.Persistencia;
using System.Data.Objects.DataClasses;
using AppGest.Util;
using AppGest.Datos.Persistencia.Conversion;
using System.Data.Objects;
using System.Configuration;


namespace AppGest.Datos
{
    public class PersistidorPredet:IDisposable
    {
        /// <summary>
        /// Contenedor Entity Framework, para la recuperación y persistencia de entidades.
        /// </summary>
        Contendor_LGP _contenedor = null;
        LinqEntidades _linq;

        public ILinqEntidades Linq
        {
            get
            {
                if (null == _linq)
                    _linq = new LinqEntidades(Contenedor);

                return _linq;
            }
        }
        protected virtual Contendor_LGP Contenedor
        {
            get 
            {
                if (null == _contenedor)
                {
                    var strConexion = ObtenerConexion();
                    if (strConexion.Length == 0)
                        _contenedor = new Contendor_LGP();
                    else
                        _contenedor = new Contendor_LGP(strConexion);
                    _contenedor.Aux();
                }

                return _contenedor;
            }
        }
        public virtual void Inicializar()
        {
        }
        internal static string ObtenerConexion()
        {
            if (_conexionBD == null)
            {
                var conexion = (ConfigurationManager.AppSettings["Conexion"] ?? "").Trim();
                if (conexion == "")
                {
                    _conexionBD = string.Empty;
                }
                else
                {
                    var stringCnn = ConfigurationManager.ConnectionStrings[conexion];
                    if (stringCnn == null)
                        _conexionBD = string.Empty;
                    else
                        _conexionBD = stringCnn.ConnectionString;
                }
            }

            return _conexionBD;

        }   static string _conexionBD;

        public PersistidorPredet()
        {
            // _adptRptListadoUsuarios.Connection = null;
        }


        /// <summary>
        /// Obtiene la lista de registros segun el tipo de T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> ListaRegEncab<T>()
            where T: Reg_encab, new()
        {
            try
            {
                return Contenedor.Reg_encab.OfType<T>().ToList();
            }
            catch (Exception ex)
            {
                Logger.Inst.Error("Error obtieniendo datos desde la base de datos.", ex);
                return null;
            }
        }

        /// <summary>
        /// Obtiene la lista de registros segun el tipo de T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> ListaRegEncab<T>(Func<T, bool> filtro)
            where T : Reg_encab, new()
        {
            try
            {
                return Contenedor.Reg_encab.OfType<T>().ToList();
            }
            catch (Exception ex)
            {
                Logger.Inst.Error("Error obtieniendo datos desde la base de datos.", ex);
                return null;
            }
        }

        public IList<T> ListaRegDet<T>()
            where T: Reg_Det
        {
            try
            {
                return Contenedor.Reg_Det.OfType<T>().ToList();
            }
            catch (Exception ex)
            {
                Logger.Inst.Error("Error obtieniendo datos desde la base de datos.", ex);
                return null;
            }
        }

        public IList<T> ListaRegDet<T>(Expression<Func<T, bool>> condicion)
            where T: Reg_Det
        {
            try
            {
                return Contenedor.Reg_Det.OfType<T>().Where<T>(condicion).ToList();
            }
            catch (Exception ex)
            {
                Logger.Inst.Error("Error obtieniendo datos desde la base de datos.", ex);
                return null;
            }
        }
        
        public IList<T> Lista<T>()
            where T: EB, new()
        {
            try
            {
                var rdo = Contenedor.EB.OfType<T>().ToList();
                return rdo;
            }
            catch (Exception ex)
            {
                Logger.Inst.Error("Error obtieniendo datos desde la base de datos.", ex);
                return null;
            }
        }
        public bool Compartido { get; set; }
        public IList<T> Lista<T>(Func<T, bool> condicion)
            where T: EB, new()
        {
            return Contenedor.EB.OfType<T>().ToList();
        }

        public int Contar<T>()
            where T: EB
        {
            return Contenedor.EB.OfType<T>().Count();
        }

        public int Contar<T>(Expression<Func<T, bool>> condicion)
            where T: EB, new()
        {
            

            return Contenedor.EB.OfType<T>().Where<T>(condicion).Count();
        }

        public T Primero<T>(Expression<Func<T, bool>> condicion)
            where T: EB, new()
        {
            return Contenedor.EB.OfType<T>().FirstOrDefault<T>(condicion);
        }

        public void Eliminar<TEntidad>(long id)
            where TEntidad: EB
        {
            var entidadBD = Contenedor.EB.OfType<TEntidad>().FirstOrDefault();
            if (entidadBD != null)
            {
                Contenedor.EB.DeleteObject(entidadBD);
                Contenedor.SaveChanges();
            }

        }





        public void GuardarEntidadModif(EB entidad)
        {
            try
            {
                //Entidad entidadBD = Contenedor.EB.OfType<Entidad>().FirstOrDefault(e => e.Id == entidad.Id);
                ConfirmarCambios(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos.", ex);
            }

        }

        public void GuardarTransaccionModif<TEspecifico>(TEspecifico transaccion)
                  where TEspecifico : Reg_encab
        {
            try
            {
                //var transaccionBD = Contenedor.Reg_encab.OfType<TEspecifico>().Where(t => t.Id == transaccion.idregEncab && tipoGener.IsInstanceOfType(t)).FirstOrDefault();

                //Contenedor.Attach(transaccion);
                //GenerarGuidNuevos(transaccion);

                ConfirmarCambios(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos.", ex);
            }

        }
        private void GenerarGuidNuevo(EB entidad)
        {
        }
        private void GenerarGuidNuevo(Reg_Det linea)
        {
        }
        private void GenerarGuidNuevos(Reg_encab transaccion)
        {
            foreach (var linea in transaccion.Reg_Det)
                GenerarGuidNuevo(linea);
        }
        public void Confirmar()
        {
            ConfirmarCambios(true);
        }
        private void ConfirmarCambios(bool forzar)
        {
            if (forzar || !Compartido)
            {
                try
                {
                    Contenedor.SaveChanges();
                }
                catch (Exception ex)
                {
                    // deshacer cambios ...


                    throw ex;
                }
                finally
                {
                    Compartido = false;
                }
            }
        }
        

        public void GuardarEntidadNuevo(EB entidad)
            
        {
            try
            {
                GenerarGuidNuevo(entidad);
                Contenedor.EB.AddObject(entidad);
                ConfirmarCambios(false);

            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos.", ex);
            }

        }
        public void GuardarTransaccionNuevo<TRegistroEncab>(TRegistroEncab transaccion)
            where TRegistroEncab : Reg_encab
        {
            try
            {
                GenerarGuidNuevos(transaccion);
                Contenedor.Reg_encab.AddObject(transaccion);
                ConfirmarCambios(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos.", ex);
            }

        }
 
        public TEntidad ObtenerEntidadPorId<TEntidad>(long id)
            where TEntidad: EB, new()
        {
            var entidad = Contenedor.EB.OfType<TEntidad>().FirstOrDefault(u => u.Id == id);
            return entidad;
        }

        public Reg_encab ObtenerTransaccionPorKey(Expression<Func<Reg_encab, bool>> condicion)
        {
            return Contenedor.Reg_encab.Where(condicion).FirstOrDefault();
        }
        public TRegistroEncab ObtenerTransaccionPorId<TRegistroEncab>(long id)
            where TRegistroEncab : Reg_encab, new()
        {
            var transaccion = Contenedor.Reg_encab.OfType<TRegistroEncab>().Where(u => u.Id == id).FirstOrDefault();
            return transaccion;
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            try
            {
                if (_contenedor != null)
                    _contenedor.Dispose();
            }
            finally
            {
                _contenedor = null;
            }
        }

        #endregion



        
        public List<Cochera> ListaCocherasDisponibles()
        {
            
 
            //Concepto cptoRelCochera = HelperModelo.ObtenerConcepto(this, ConceptoRegistro.MVASOCCLICOCH.ToString());
            //List<Entidad> lstEntidades = Persistidor.Lista<Entidad>().Where(ent => ent.fechabaja == null && ent.idtipo == (short)TipoClase.Cochera).ToList();

            //_contenedor.

            //List<Reg_Det> lstRegistros = Persistidor.ListaRegDet<Reg_Det>().Where(reg => reg.fechabaja == null && reg.idlista != null && reg.idlista == cptoRelCochera.Id).ToList();

            //var cocherasDisp = from e in lstEntidades where !lstRegistros.Any(r => r.idlista1 == e.Id) select e;

            ////List<Entidad> lstEntidades = Persistidor.Lista<Entidad>().Where(ent => ent.fechabaja == null && ent.idtipo == (short)TipoClase.Cochera).ToList();
            //List<Cochera> lstRdo = new List<Cochera>();

            //foreach (Entidad e in cocherasDisp)
            //{
            //    Cochera c = new Cochera();
            //    this.Copiar(e, c);
            //    lstRdo.Add(c);
            //}

            return null;

        }


        public bool TryInitDB()
        {
            return this.Contenedor.DatabaseExists();
        }

        #region -- Metodos para Consutlas SQL -- 
        /// <summary>
        /// Metodo para ejecutar una consulta en lenguaje nativo del repositorio de datos
        /// </summary>
        /// <typeparam name="TElement">Tipo del objeto que retorna</typeparam>
        /// <param name="commandText">Comando a ejecutar</param>
        /// <param name="parameters">Parámetros de la consula</param>
        /// <returns>Lista de objetos del tipo TElement</returns>
        public ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            return Contenedor.ExecuteStoreQuery<TElement>(commandText, parameters);
        }


        #endregion

        #region -- Metodos para configuracion --
        /// <summary>
        /// Modifica una configuación de menu
        /// </summary>
        /// <param name="entidad">Configuracion a modificar</param>
        public void GuardarConfiguracionModif(ConfMenu entidad)
        {
            try
            {
                //Entidad entidadBD = Contenedor.EB.OfType<Entidad>().FirstOrDefault(e => e.Id == entidad.Id);
                ConfirmarCambios(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos de configuración.", ex);
            }

        }
        public void GuardarConfiguracionNueva(ConfMenu entidad)
        {
            try
            {
                //GenerarGuidNuevo(entidad);
                Contenedor.ConfMenu.AddObject(entidad);
                ConfirmarCambios(false);

            }
            catch (Exception ex)
            {
                throw new Exception("Error el intentar guardar los datos de configuración.", ex);
            }

        }
        #endregion
    }
}