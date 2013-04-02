using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;

using AppGest.Negocio.Core;
using System.Collections;
using AppGest.Util;




namespace AppGest.Negocio.Modelo
{

    /// <summary>
    /// Experto para el alta de clientes mensuales, autos y asognacion de cocheras
    /// </summary>
    public partial class ExpMensuales: ExpertoRegistro
    {
        #region -- Propiedades --
        public Concepto cptoTransaccion { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.ALTA_CLIENTE_MENSUAL); } }
        public Concepto cptoRelVehiculo { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_VEHICULO); } }
        public Concepto cptoRelCochera { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_COCHERA); } }
        #endregion

        #region -- Metodos para Nuevo Mensual --
        public Vehiculo NuevoVehiculo()
        {
            Vehiculo nuevo;
            using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(this))
                nuevo = exp.Nuevo();

            return nuevo;
        }
        public Reg_encab NuevoMensual(Cliente cliente, List<Proxy_LineaAsocCocheraMensual> cocheras, List<Vehiculo> vehiculos)
        {
            return NuevoMensual(cliente, cocheras, vehiculos, true);
        }
        public Reg_encab NuevoMensual(Cliente cliente, List<Proxy_LineaAsocCocheraMensual> cocheras, List<Vehiculo> vehiculos, bool notificarExcepcion)
        {

            // IC: Hice esto porque no guardaba ya que las cocheras se obtenian en otro contexto. Ver si se puede mejorar. 
            var coOtras = (from c in cocheras select c.Cochera).ToList();
            var todas = Persistidor.Linq.Entidades<Cochera>().ToList();
            var listaCocheras = (from cnueva in todas
                                join cvieja in coOtras on cnueva.Id equals cvieja.Id
                                select cnueva).ToList();
            foreach (var item in cocheras)
                item.Cochera = (from c in listaCocheras where c.Id == item.Cochera.Id select c).FirstOrDefault();
            
            

            var transaccion = CrearEncabezado(cptoTransaccion, cliente);

            ValidarNuevo(transaccion, cocheras, vehiculos, notificarExcepcion);

            Guardar(cliente, false);
            Guardar(vehiculos, false);

            CrearLineas(transaccion, cliente, vehiculos, cptoRelVehiculo);
            CrearLineas(transaccion, cliente, cocheras, cptoRelCochera);

            Guardar(transaccion);
            Persistidor.Confirmar();

            return transaccion;
        }

        

        private Reg_encab CrearEncabezado(Concepto concepto, Cliente cliente)
        {
            var transaccion = Nuevo(concepto);
            var mapeo = new MapeoMensuales();
            Usuario usu = ObtenerUsuario(IdSesion);
            Empresa emp = Persistidor.Linq.Entidades<Empresa>().FirstOrDefault();
            mapeo.LLenarEncabezado(transaccion, cliente, usu, emp);
            return transaccion;

        }
        private Reg_encab ModificarEncabezado(long id, Cliente cliente)
        {
            var transaccion = ObtenerMensual(id);
            var mapeo = new MapeoMensuales();
            mapeo.LLenarEncabezado(transaccion, cliente);
            return transaccion;

        }

        private void CrearLineas(Reg_encab transaccion, Cliente cliente, IEnumerable<Proxy_LineaAsocCocheraMensual> LineaAsocCocheras, Concepto concepto)
        {
            var mapeo = new MapeoMensuales();
            foreach (var cochera in LineaAsocCocheras)
            {
                var linea = this.Nuevo(transaccion, concepto);
                mapeo.LLenarLinea(transaccion, linea, cliente, cochera);
            }
        }
        private void CrearLineas(Reg_encab transaccion, Cliente cliente, IEnumerable<Vehiculo> vehiculos, Concepto concepto)
        {
            var mapeo = new MapeoMensuales();
            foreach (var vehiculo in vehiculos)
            {
                var linea = this.Nuevo(transaccion, concepto);
                mapeo.LLenarLinea(transaccion, linea, cliente, vehiculo);
            }
        }

        #endregion

        #region -- Metodos para Modificacion --
        public Reg_encab ModificarMensual(Proxy_Mensuales proxy, Cliente cliente, List<Proxy_LineaAsocCocheraMensual> cocherasAsociadas, List<Vehiculo> lstVehiculosAsignados)
        {

            var transaccion = ModificarEncabezado(proxy.Encabezado.Id, cliente);

            ValidarModificar(transaccion, cocherasAsociadas, lstVehiculosAsignados);

            // Obtengo la lista de vehiculos nuevos
            var vehiculosNuevos = from v in lstVehiculosAsignados
                                    where v.Id == 0
                                   select v;

            // Creo las nuevas lineas de vehiculos asociados
            CrearLineas(transaccion, cliente, vehiculosNuevos, cptoRelVehiculo);
            
            //Actualizo los vehiculos modificados
            ModicarLineas(transaccion, lstVehiculosAsignados, cptoRelVehiculo);

            var cocherasNuevas = from c in cocherasAsociadas
                                    where c.EsNuevo select c;

            //Creo las lineas nuevas de asociacion de cocheras
            CrearLineas(transaccion, cliente, cocherasNuevas, cptoRelCochera);

            // Modifico las lineas
            ModicarLineas(transaccion, cocherasAsociadas, cptoRelCochera);

            Guardar(transaccion);
            Persistidor.Confirmar();

            return transaccion;
        }

        private void ModicarLineas(Reg_encab transaccion, List<Proxy_LineaAsocCocheraMensual> cocherasAsociadas, Concepto cptoRelCochera)
        {

            foreach (var linea in transaccion.Reg_Det.Where(x => x.Concepto.Id == cptoRelCochera.Id && x.Id !=0))
            {
                Proxy_LineaAsocCocheraMensual p = cocherasAsociadas.FirstOrDefault(g => g.Linea.Id == linea.Id && linea.Id != 0);
                linea.SetValLista1(p.Cochera);
                linea.SetValLista2(p.CptoIngresoMensual);
                linea.CopiarDesde(p.Linea);
            }

        }

        private void ModicarLineas(Reg_encab transaccion, IEnumerable<Vehiculo> vehiculosAsignados, Concepto cptoRelVehiculo)
        {

            foreach (var linea in transaccion.Reg_Det.Where(x => x.Concepto.Id == cptoRelVehiculo.Id && x.ValLista1.Id !=0))
            {
                Vehiculo v = vehiculosAsignados.FirstOrDefault(g => g.Id == linea.ValLista1.Id && g.Id != 0);
                if(v != null)
                linea.ValLista1.CopiarDesde(v);
            }
            
        }
        #endregion

        #region --- Validaciones --

        private void ValidarNuevo(Reg_encab transaccion, List<Proxy_LineaAsocCocheraMensual> listaCocheras, List<Vehiculo> vehiculos)
        {
            ValidarNuevo(transaccion, listaCocheras, vehiculos, true);
        }
        /// <summary>
        /// Valida un nuevo registro de mensuales
        /// </summary>
        /// <param name="transaccion"></param>
        /// <param name="listaCocheras"></param>
        /// <param name="vehiculos"></param>
        private void ValidarNuevo(Reg_encab transaccion, List<Proxy_LineaAsocCocheraMensual> listaCocheras, List<Vehiculo> vehiculos, bool notificarExcepcion)
        {
            var lstRdo = new List<EstructuraValidacion>();

            ValidarEncabezado(lstRdo, transaccion);

            ValidarVehiculos(vehiculos, lstRdo);

            ValidarCocheras(listaCocheras, lstRdo);

            ValidarCliente(lstRdo, transaccion.EntidadAfectada as Cliente);

            if (lstRdo.Count > 0)
            {
                if (notificarExcepcion)
                    throw new ValidacionException("No se pueden guardar los datos. Verifique los datos siguientes e intente nuevamente", lstRdo);
                else
                {
                    var x = new ValidacionException("No se pueden guardar los datos. Verifique los datos siguientes e intente nuevamente", lstRdo);
                    Logger.Inst.Error(x.MessageCompleteConTitulo);
                }
            }
        }

        void ValidarEncabezado(List<EstructuraValidacion> lstRdo, Reg_encab encabezado )
        {
           
            if (encabezado.ConceptoReference == null)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - No se puede guardar un encabezado de asociación mensual sin un concepto asociado.",
                    Tipo = EnumTipoError.Error
                });

            if (!encabezado.FechaRegistro.HasValue)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - El encabezado debe tener una Fecha de registro.",
                    Tipo = EnumTipoError.Error
                });

            if (encabezado.FechaAlta == null)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - El encabezado debe tener una Fecha de alta.",
                    Tipo = EnumTipoError.Error
                });

        }

        private void ValidarModificar(Reg_encab transaccion, List<Proxy_LineaAsocCocheraMensual> cocherasAsociadas, List<Vehiculo> lstVehiculosAsignados)
        {
            var lstRdo = new List<EstructuraValidacion>();

            ValidarEncabezado(lstRdo, transaccion);

            ValidarVehiculos(lstVehiculosAsignados, lstRdo);

            ValidarCocheras(cocherasAsociadas, lstRdo);

            ValidarCliente(lstRdo, transaccion.EntidadAfectada as Cliente);

            if (lstRdo.Count > 0)
                throw new ValidacionException("No se pueden modificar los datos. Verifique los datos siguientes e intente nuevamente", lstRdo);
        }

        private void ValidarVehiculos(List<Vehiculo> lstVehiculosAsignados, List<EstructuraValidacion> lstRdo)
        {
            var cantBajaVehiculo = (from v in lstVehiculosAsignados
                                    where v.Baja != null
                                    select v).Count();

            if (cantBajaVehiculo == lstVehiculosAsignados.Count)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - Todos los vehículos asociados estan dados de baja. Debe asociar al menos un vehículo activo.",
                    Tipo = EnumTipoError.Error
                });
        }

        private void ValidarCocheras(List<Proxy_LineaAsocCocheraMensual> cocherasAsociadas, List<EstructuraValidacion> lstRdo)
        {
            var cantCocheras = (from v in cocherasAsociadas
                                where v.Baja
                                select v).Count();
            if (cantCocheras == cocherasAsociadas.Count)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - Todas las cocheras asociadas están dadas de baja. Debe indicar al menos una cochera Activa.",
                    Tipo = EnumTipoError.Error
                });
        }

        private void ValidarCliente(List<EstructuraValidacion> lstRdo, Cliente cliente)
        {

            if (cliente == null)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - No hay un Cliente asociado.",
                    Tipo = EnumTipoError.Error
                });

            if (cliente.Nombre.Length == 0)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - El 'Nombre' del cliente no puede estar vacio.",
                    Tipo = EnumTipoError.Error
                });

            if (cliente.Apellido.Length == 0)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - El 'Apellido' del cliente no puede estar vacio.",
                    Tipo = EnumTipoError.Error
                });



        }

        protected override void ValidarModificar(Reg_encab transaccion)
        {
            base.ValidarModificar(transaccion);

            if (transaccion.Reg_Det.Count == 0)
                throw new InvalidOperationException("No hay asociado ningun vehículo y cochera.");

        }

        protected override void ValidarNuevo(Reg_encab transaccion)
        {
            base.ValidarNuevo(transaccion);

            if (transaccion.Reg_Det.Count == 0)
                throw new InvalidOperationException("No hay asociado ningun vehículo y cochera.");

        }

        protected override void ValidarLinea(Reg_Det linea, bool transaccionNueva)
        {
            base.ValidarLinea(linea, transaccionNueva);
        }
        #endregion

        #region --- Inicializadores --
        protected override void Inicializar(Reg_encab transaccion, Concepto concepto)
        {
            // indicar aqui la logica especifica de inicializacion del registro de encabezado de operaciones.
            base.Inicializar(transaccion, concepto);
        }

        protected override void Inicializar(Reg_encab transaccion, Reg_Det linea, Concepto concepto)
        {
            // inicializa la linea segun el concepto que corresponda
            Enum valorEnum = concepto.ValorEnum;

            if (valorEnum is ConceptoRelaciones)
            {
                switch ((ConceptoRelaciones)valorEnum)
                {
                    case ConceptoRelaciones.ASOC_CLIENTE_COCHERA: // linea que asocia cochera con cliente
                        InicializarAsocCochera(transaccion, concepto, linea);
                        break;
                    case ConceptoRelaciones.ASOC_CLIENTE_VEHICULO: // linea que asocia cliente con vehículo
                        InicializarAsocVehiculo(transaccion, concepto, linea);
                        break;
                }
            }
            else if (valorEnum is ConceptoTransacciones)
            {
                if (((ConceptoTransacciones)valorEnum).Equals(ConceptoTransacciones.ALTA_CLIENTE_MENSUAL))
                {
                    throw new NotImplementedException("Falta implementar la inicializcion de la linea para la asocicion de mensisales");
                }
            }

            base.Inicializar(transaccion, linea, concepto);
        }

        private void InicializarAsocVehiculo(Reg_encab transaccion, Concepto concepto, Reg_Det linea)
        {
            linea.Cantidad = 1;
            linea.FechaAlta = DateTime.Now;
            linea.FechaModif = DateTime.Now;
            linea.SetEntidadAfectada1(transaccion.EntidadAfectada); // cliente
            linea.SetConcepto(concepto);
            linea.Importe = 0;
            linea.Precio = 0;

        }

        private void InicializarAsocCochera(Reg_encab transaccion, Concepto concepto, Reg_Det linea)
        {
            linea.Cantidad = 1;
            linea.FechaAlta = DateTime.Now;
            linea.FechaModif = DateTime.Now;
            linea.SetValLista1(concepto);
            linea.SetEntidadAfectada1(transaccion.EntidadAfectada); // cliente
            linea.Importe = 0;
            linea.Precio = 0;

        }
        #endregion

        #region --- Metodos Guardado --
        private bool Guardar(Cliente cliente, bool forzar)
        {
            if (forzar || cliente.Id == 0)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(this))
                    exp.Guardar(cliente);

                return true;
            }
            else
                return false;
        }

        private bool Guardar(IEnumerable<Cochera> cocheras, bool forzar)
        {
            var rdo = false;
            foreach(var cochera in cocheras)
                rdo |= Guardar(cochera, forzar);

            return rdo;
        }

        private bool Guardar(Cochera cochera, bool forzar)
        {
            if (forzar || cochera.Id == 0)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpCocheras>(this))
                    exp.Guardar(cochera);

                return true;
            }
            else
                return false;
        }

        private bool Guardar(IEnumerable<Vehiculo> vehiculos, bool forzar)
        {
            var rdo = false;
            foreach (var vehiculo in vehiculos)
                rdo |= Guardar(vehiculo, forzar);

            return rdo;
        }
        
        private bool Guardar(Vehiculo vehiculo, bool forzar)
        {
            if (forzar || vehiculo.Id == 0)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(this))
                    exp.Guardar(vehiculo);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region --- Metodos de recuperación de datos --

        public List<Proxy_Mensuales> ObtenerMensuales()
        {
            List<Proxy_Mensuales> rdo = new List<Proxy_Mensuales>();

            
        
            

            var lineas = from linea in Persistidor.Linq.Lineas<Reg_Det>()
                    where (linea.Concepto.Id == cptoRelCochera.Id) || (linea.Concepto.Id == cptoRelVehiculo.Id)
                    select linea;

            var proxies = (from linea in lineas select linea).ToList()
                                .GroupBy(l => l.Reg_encab)
                                .Select(x => new Proxy_Mensuales(this.IdSesion) 
                                            { Cliente = x.Key.EntidadAfectada as Cliente
                                              , Encabezado = x.Key as Reg_encab
                                              , Cocheras = x.Where(c => c.Concepto.Id == cptoRelCochera.Id).ToList()
                                              , Vehiculos = x.Where(c => c.Concepto.Id == cptoRelVehiculo.Id).ToList() 
                                            }
                                        );



            return proxies.ToList();
        }

        public Reg_encab ObtenerMensual(Cliente cliente)
        {
            Reg_encab registro = Persistidor.ObtenerTransaccionPorKey(reg => reg.EntidadAfectada.Id == cliente.Id);

            return registro;
        }
        public Reg_encab ObtenerMensual(long idEncabezado)
        {
            Reg_encab registro = Persistidor.ObtenerTransaccionPorKey(reg => reg.Id == idEncabezado);

            return registro;
        }

        public Vehiculo ObtenerVehiculo(long idEntidad)
        {
            Vehiculo existente;
            using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(this))
                existente = exp.ObtenerPorId(idEntidad);

            return existente;
        }

        public Cliente ObtenerCliente(long idEntidad)
        {
            Cliente existente;
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(this))
                existente = exp.ObtenerPorId(idEntidad);

            return existente;
        }
        /// <summary>
        /// Obtiene la lista de cocheras disponibles para ser asociadas a un mensual.
        /// </summary>
        /// <returns>Lista de cocheras</returns>
        public List<Cochera> ListaCocherasDisponibles()
        {
            
            using (var exp = FabExpertos.Inst.Obtener<ExpCocheras>(IdSesion))
                return exp.ListaCocherasDisponibles();

        }

        public string InfoMensualesRegistrados()
        {

            var rdo = Persistidor.Linq.Encabezados()
                            .Where(e => e.Concepto.Id == cptoTransaccion.Id
                                    ||
                                    e.Reg_Det.Any(l => l.Concepto.Id == cptoRelVehiculo.Id)
                                    ||
                                    e.Reg_Det.Any(l => l.Concepto.Id == cptoRelCochera.Id)
                                    ).Count();
            
            return rdo > 0 ? rdo.ToString() + " registros de clientes mensuales." : "No hay datos registrados."; 

        }

        public List<Proxy_Mensuales> ObtenerMensuales(int? nroCliente = null, string nombre = null, string dominio = null, string cochera = null, bool? activos = null)
        {
            List<Proxy_Mensuales> rdo = new List<Proxy_Mensuales>();
            Cliente clienteBuscado = null;
            long idClienteBuscado = -1;
         
            //.Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
            if (nroCliente.HasValue && nroCliente.Value != -1)
            {
                clienteBuscado = Persistidor.Linq.Entidades<Cliente>().Where(cli => cli.NroCliente == nroCliente)
                    .Where(c => activos == null ? true : (activos.Value ? c.Baja.Equals(null) : c.Baja != null))
                    .FirstOrDefault();
                if (clienteBuscado != null)
                    idClienteBuscado = clienteBuscado.Id;
                else
                    idClienteBuscado = -2;
            }
            var encabezados = Persistidor.Linq.Encabezados()
                            .Where(e => e.Concepto.Id == cptoTransaccion.Id
                                    ||
                                    e.Reg_Det.Any(l => l.Concepto.Id == cptoRelVehiculo.Id)
                                    ||
                                    e.Reg_Det.Any(l => l.Concepto.Id == cptoRelCochera.Id)
                                    )
                            .Where(e =>
                                    (string.IsNullOrEmpty(nombre) || e.EntidadAfectada != null && (e.EntidadAfectada.Nombre.ToUpper().Contains(nombre.ToUpper()) 
                                            || e.EntidadAfectada.Nombre2.ToUpper().Contains(nombre.ToUpper()) 
                                            || e.EntidadAfectada.Apellido.ToUpper().Contains(nombre.ToUpper()))
                                    )
                                    && 
                                    (idClienteBuscado == -1 || e.EntidadAfectada.Id == idClienteBuscado)
                                    &&
                                    (activos == null ? true : (activos.Value ? e.EntidadAfectada.Baja.Equals(null) : e.EntidadAfectada.Baja != null))
                                    && e.Reg_Det.Any(l => 
                                        l.Concepto.Id == cptoRelCochera.Id && ( 
                                        string.IsNullOrEmpty(cochera) || l.ValLista1 != null && (l.ValLista1.Nombre.ToUpper().Contains(cochera.ToUpper()) 
                                        || l.ValLista1.Descripcion.ToUpper().Contains(cochera.ToUpper()) 
                                        || l.ValLista1.Observaciones.ToUpper().Contains(cochera.ToUpper()))
                                       ))
                                    
                                    && e.Reg_Det.Any(l => l.Concepto.Id == cptoRelVehiculo.Id && (
                                        string.IsNullOrEmpty(dominio) || l.ValLista1 != null && (l.ValLista1.Nombre.ToUpper().Contains(dominio.ToUpper())
                                        || l.ValLista1.Descripcion.ToUpper().Contains(dominio.ToUpper())
                                        || l.ValLista1.Observaciones.ToUpper().Contains(dominio.ToUpper()))
                                        ))
                                    )
                                    .ToList()
                            .Select(x => new Proxy_Mensuales()
                            {
                                Cliente = x.EntidadAfectada as Cliente
                              ,
                                Encabezado = x as Reg_encab
                              ,
                                Cocheras = x.Reg_Det.Where(c => c.Concepto.Id == cptoRelCochera.Id).ToList()
                              ,
                                Vehiculos = x.Reg_Det.Where(c => c.Concepto.Id == cptoRelVehiculo.Id).ToList()
                            });
                      
  
            return encabezados.OrderBy(pr => pr.NombreCliente).ToList();
       
        }
        #endregion




        /// <summary>
        /// Da de baja un cliente mensual
        /// </summary>
        /// <param name="proxy_Mensuales"></param>
        public void DarDeBajaMensual(Proxy_Mensuales m, DateTime fechaBaja)
        {
            var enc = ObtenerPorId(m.Encabezado.Id);
            ValidarBajaMensual(enc);
            DateTime fBaja = fechaBaja.Superior(DateInterval.Day);
            
            // Da de baja el cliente
            enc.EntidadAfectada.Baja = fBaja;
            enc.FechaModif = DateTime.Now;

            // Da de baja los vehículos.
            var lineasCocheras = (from linea in enc.Reg_Det
                                 where linea.Concepto.Id == cptoRelCochera.Id
                                 select linea).ToList();
            foreach (var lineaC in lineasCocheras)
            {
                lineaC.ValFecha2 = fBaja;
            }
            // Da de baja las asociaciones con las cocheras.
            var lineasVehiculos = (from linea in enc.Reg_Det
                                  where linea.Concepto.Id == cptoRelVehiculo.Id
                                  select linea).ToList();
            foreach (var lineaV in lineasVehiculos)
            {
                lineaV.ValLista1.Baja = fBaja;
            }

            Guardar(enc);
            Persistidor.Confirmar();
        }

        public void ActivarClienteMensual(Proxy_Mensuales m)
        {
            var enc = ObtenerPorId(m.Encabezado.Id);
            ValidarActivacionMensual(enc);

            // Setea en null la baja el cliente
            enc.EntidadAfectada.Baja = null;
            enc.FechaModif = DateTime.Now;
            
            Guardar(m.Encabezado);
            Persistidor.Confirmar();
        }

        private void ValidarActivacionMensual(Reg_encab m)
        {
            //TODO: [IC] Implementar la validación de la Activacion de vehículos.
            var lstrdo = new List<ValidacionException>();


            //throw new NotImplementedException();
        }
        private void ValidarBajaMensual(Reg_encab m)
        {
            //TODO: [IC] Implementar la validación de la baja de vehículos.
            var lstrdo = new List<ValidacionException>();
           
            //throw new NotImplementedException();
        }
    }
}
