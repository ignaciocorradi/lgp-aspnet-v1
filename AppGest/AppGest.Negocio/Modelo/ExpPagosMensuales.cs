using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Util;
using System.Reflection;


namespace AppGest.Negocio.Modelo
{
    public partial class ExpPagosMensuales: ExpertoRegistro
    {
        protected override void Inicializar(Reg_encab transaccion, Concepto concepto)
        {
            base.Inicializar(transaccion, concepto);
            using (var expCpto = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion)) 
                transaccion.SetConcepto(concepto);

            transaccion.FechaRegistro = DateTime.Now;
        }
        protected override void Inicializar(Reg_encab transaccion, Reg_Det linea, Concepto concepto)
        {
            base.Inicializar(transaccion, linea, concepto);
                
        }

        public void Guardar(string comentario, IList<ProxyExpPagosMensLinea> pagos)
        {
            var transaccion = LLenarPago(comentario, pagos);

            ValidarSaldosLineas(pagos, transaccion.Id == 0);

            this.Guardar(transaccion);
            Persistidor.Confirmar();
        }

        private Reg_encab LLenarPago(string comentario, IList<ProxyExpPagosMensLinea> carga)
        {
            using (var expCpto = FabExpertos.Inst.Obtener<ExpConcepto>(this))
            {
                var mapeo = new MapeoExpPagosMensuales();
                var transaccion = Nuevo(expCpto.ObtenerConceptoSistema(ConceptoTransacciones.PAGO_MENSUAL));
                transaccion.Comentario = string.IsNullOrWhiteSpace(comentario) ? null : comentario;

                foreach(var pago in carga)
                {
                
                    var linea = Nuevo(transaccion, expCpto.ObtenerPorId(pago.Concepto.Id));
                    mapeo.LLenarRegistro(linea, pago, Persistidor);

                }

                return transaccion;
            }

        }

        public IList<ProxyExpPagosMensLinea> ObtenerPagosRegistrados(DateTime? ini, DateTime? fin, DateTime? fechaPago, string cliente = null, long? idServicio = null, string cochera = null, long? idLineaExcl = null)
        {
            var rdo = ObtenerPagosRegistrados(ini, fin, null, idServicio, null, idLineaExcl);
            if (!string.IsNullOrEmpty(cliente))
                rdo = rdo.Where(x => x.EntidadAfectada1 != null && (x.EntidadAfectada1.Nombre.ToUpper().Contains(cliente.ToUpper()) || x.EntidadAfectada1.Nombre2.ToUpper().Contains(cliente.ToUpper()) || x.EntidadAfectada1.Apellido.ToUpper().Contains(cliente.ToUpper())));

            if (!string.IsNullOrEmpty(cochera))
                rdo = rdo.Where(x => x.ValLista1 != null && x.ValLista1.Nombre.ToUpper().Contains(cochera.ToUpper()));

            if (fechaPago.HasValue)
            {
                var fpIni = fechaPago.Value.Inferior(DateInterval.Day, DateInterval.Second);
                var fpFin = fechaPago.Value.Superior(DateInterval.Day,DateInterval.Second);
                rdo = rdo.Where(x => x.ValFecha1 != null && x.ValFecha1.Value >= fpIni && x.ValFecha1.Value <= fpFin);
            }
            var proxies = ProxyRegistroDet.CrearDesde<ProxyExpPagosMensLinea, ProxyExpPagosMensEncab, MapeoExpPagosMensuales, KeyEntidadPagoMensual>(rdo.ToList().OrderBy(r => r.EntidadAfectada1.NombreCompleto).ToList(), Persistidor);

            return proxies;
        }


        IQueryable<Reg_Det> ObtenerPagosRegistrados(DateTime? ini, DateTime? fin, long? idCliente = null, long? idServicio = null, long? idCochera = null, long? idLineaExcl = null)
        {
            int CL_PAGO;
            int VL_PAGO;

            Concepto.ObtenerClaseYValor(ConceptoTransacciones.PAGO_MENSUAL, out CL_PAGO, out VL_PAGO);

            var rdo = from regPago in Persistidor.Linq.Lineas<Reg_Det>()
                      where regPago.Reg_encab.Concepto.Clase == CL_PAGO && regPago.Reg_encab.Concepto.Valor == VL_PAGO
                             && regPago.ValFecha2.HasValue
                            && (!idLineaExcl.HasValue || regPago.Id != idLineaExcl.Value)
                            && (!idCliente.HasValue || regPago.EntidadAfectada1 != null && regPago.EntidadAfectada1.Id == idCliente.Value)
                            && (!idServicio.HasValue || regPago.Concepto != null && regPago.Concepto.Id == idServicio.Value)
                            && (!idCochera.HasValue || regPago.ValLista1 != null && regPago.ValLista1.Id == idCochera.Value)
                            && (!ini.HasValue || regPago.ValFecha2.HasValue && regPago.ValFecha2.Value >= ini)
                            && (!fin.HasValue || regPago.ValFecha2.HasValue && regPago.ValFecha2.Value <= fin)
                      select regPago;

            return rdo ;
        }

        Concepto _cptoTranPrecio { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.ALTA_LISTA_PRECIOS); } }
        Concepto cptoRelVehiculo { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_VEHICULO); } }
        public IDictionary<string, decimal> ObtenerTotalesPagados(DateTime? fini, DateTime? ffin, long? idCliente = null, long? idLineaExcl = null)
        {
            var pagados = ObtenerPagosRegistrados(fini, ffin, idCliente, null, null, idLineaExcl).ToList();
            return ObtenerTotalesPagados(pagados);
        }

        public IDictionary<string, decimal> ObtenerTotalesPagados(IList<Reg_Det> pagos)
        {
            return pagos.GroupBy(y => MapeoExpPagosMensuales.Key.GetKeyLinea(y))
                        .ToDictionary(  gK => gK.Key,
                                        gV => gV.Sum(lin => lin.Precio.GetValueOrDefault() + lin.ValNum1.GetValueOrDefault() - lin.ValNum3.GetValueOrDefault())   // Abonado + Bonificado - Recargo
                                     );
        }

        public IList<ProxyExpPagosMensLinea> ObtenerPagosPendientes(DateTime per, string likeNombre = null, long? idCliente = null, long? idLineaExcl = null)
        {
            var iniPer = per.Inferior(DateInterval.Month);
            var finPer = per.Superior(DateInterval.Month);

            IList<Reg_Det> precios = ObtenerPreciosPeriodo(iniPer, finPer);
            IQueryable<Reg_Det> contratado = ObtenerContratosMensuales(iniPer, finPer, likeNombre, idCliente);
            IDictionary<string, decimal> totalPagado = ObtenerTotalesPagados(iniPer, finPer, idCliente, idLineaExcl);


//#if DEBUG
//            precios.ForEach(x => Console.WriteLine("precio: " + x.ValFecha1.Value.ToString() + " - " + (x.ValFecha2.HasValue? x.ValFecha2.Value.ToString():"Sin fecha")));
//#endif
            



            var periodos = (from precio in precios
                           join cont in (from cont in contratado select cont)
                                     on  precio.Concepto.Id equals cont.ValLista2.Id
                           from p in DateTimeExtension.ExpandirIntervalo(iniPer, finPer, DateInterval.Month).ToList()
                           
                           where p >= precio.ValFecha1.Value
                                 && ( !precio.ValFecha2.HasValue || p <= precio.ValFecha2.Value)
                                 && ((!cont.ValFecha1.HasValue) || p >= cont.ValFecha1.Value.Inferior(DateInterval.Month))
                                 && ((!cont.ValFecha2.HasValue) || p <= cont.ValFecha2.Value.Superior(DateInterval.Month))
                           
                           select new { Precio = precio
                                       , Contratado = cont 
                                       , Periodo = p
                                       , Key =  Convert.ToString(p.Year * 100 + p.Month)                        // periodo
                                                + "|" + Convert.ToString(cont.ValLista2.Id)                     // sercicio
                                                + "|" + Convert.ToString(cont.Reg_encab.EntidadAfectada.Id)     // cliente
                                                + "|" + Convert.ToString(cont.ValLista1.Id)                     // cochera
                                      }
                            
                            ).ToList();

            var pendientes = periodos.ToList()
                                .Where(x => !totalPagado.ContainsKey(x.Key) || totalPagado[x.Key] < x.Precio.Precio)
                                .Select(p => new {  Periodo = p, 
                                                    Saldo = !totalPagado.ContainsKey(p.Key) ? p.Precio.Precio.Value : p.Precio.Precio.Value - totalPagado[p.Key] , 
                                                 });


            if (pendientes.Count() == 0)
                return new List<ProxyExpPagosMensLinea>();
            
           

            var resultado =  pendientes
                .Select(x => 
                                                    new ProxyExpPagosMensLinea()   {  Linea = null
                                                                                    , Encabezado = null
                                                                                    , Cliente = (Cliente) x.Periodo.Contratado.EntidadAfectada1
                                                                                    , Cochera = (Cochera) x.Periodo.Contratado.ValLista1
                                                                                    , Concepto = (Concepto) x.Periodo.Contratado.ValLista2
                                                                                    , Periodo = x.Periodo.Periodo
                                                                                    , LineaPrecio = x.Periodo.Precio
                                                                                    , LineaContratado = x.Periodo.Contratado
                                                                                    , PrecioOrig = x.Periodo.Precio.Precio ?? 0
                                                                                    , FechaPago = DateTime.Now
                                                                                    , CptoRelVehiculo = cptoRelVehiculo
                                                                                    , Abonado = x.Saldo
                                                                                    , Saldo = 0
                                                                                    , SaldoOrig = x.Saldo
                                                                                    }
                                            ).ToList();
            return resultado;
        }

        private IList<Reg_Det> ObtenerPreciosPeriodo(DateTime iniPer, DateTime finPer)
        {
            var ini = iniPer.Year * 10000 + iniPer.Month * 100 + iniPer.Day;
            var fin = finPer.Year * 10000 + finPer.Month * 100 + finPer.Day;

            int CL_SERV;
            int VL_SERV;

            Concepto.ObtenerClaseYValor(ConceptoIngresos.ALQUILER_MENSUAL, out CL_SERV, out VL_SERV);


            IList<Reg_Det> precios = (from
                                    regPrecio in Persistidor.Linq.Lineas<Reg_Det>()
                       where
                               regPrecio.Reg_encab.Concepto.Id == _cptoTranPrecio.Id
                               && regPrecio.Concepto.Clase == CL_SERV
                               && regPrecio.Concepto.Valor == VL_SERV
                               && (!regPrecio.ValFecha1.HasValue || ini >= (regPrecio.ValFecha1.Value.Year * 10000
                                                                           + regPrecio.ValFecha1.Value.Month * 100
                                                                           + regPrecio.ValFecha1.Value.Day)
                               && (!regPrecio.ValFecha2.HasValue || fin <= (regPrecio.ValFecha2.Value.Year * 10000
                                                                           + regPrecio.ValFecha2.Value.Month * 100
                                                                           + regPrecio.ValFecha2.Value.Day)))
                       select regPrecio
                             ).ToList();

            return precios;
        }

        private IQueryable<Reg_Det> ObtenerContratosMensuales(DateTime ini, DateTime fin, string likeCliente = null, long? idCliente = null, long? idServicio = null, long? idCochera = null)
        {
            int CL_ASOC;
            int VL_ASOC;

            Concepto.ObtenerClaseYValor(ConceptoRelaciones.ASOC_CLIENTE_COCHERA, out CL_ASOC, out VL_ASOC);

            var contratado = from regCochera in Persistidor.Linq.Lineas<Reg_Det>()
                         where regCochera.Concepto.Clase == CL_ASOC && regCochera.Concepto.Valor == VL_ASOC
                            //&& (!regCochera.ValFecha1.HasValue || ini >= regCochera.ValFecha1.Value.Inferior(DateInterval.Month, DateInterval.Maxima))
                            //&& (!regCochera.ValFecha2.HasValue || fin <= regCochera.ValFecha2.Value.Superior(DateInterval.Month, DateInterval.Maxima))
                            && (!idCliente.HasValue || regCochera.EntidadAfectada1!= null && regCochera.EntidadAfectada1.Id == idCliente.Value)
                            && (!idServicio.HasValue || regCochera.ValLista2 != null && regCochera.ValLista2.Id == idServicio.Value)
                            && (!idCochera.HasValue || regCochera.ValLista1 != null && regCochera.ValLista1.Id == idCochera.Value)
                            && (string.IsNullOrEmpty(likeCliente) || regCochera.EntidadAfectada1 != null && (regCochera.EntidadAfectada1.Nombre.ToUpper().Contains(likeCliente.ToUpper()) || regCochera.EntidadAfectada1.Nombre2.ToUpper().Contains(likeCliente.ToUpper()) || regCochera.EntidadAfectada1.Apellido.ToUpper().Contains(likeCliente.ToUpper())))
                             select regCochera;

            return contratado
                                .ToList()
                                .Where
                                    (regCochera => 
                                        (!regCochera.ValFecha1.HasValue || ini >= regCochera.ValFecha1.Value.Inferior(DateInterval.Month))
                                        && (!regCochera.ValFecha2.HasValue || fin <= regCochera.ValFecha2.Value.Superior(DateInterval.Month))
                                    )
                                .AsQueryable<Reg_Det>();
        }


        void ValidarSaldosLineas(IList<ProxyExpPagosMensLinea> pagos, bool nueva)
        {
            var lstRdo = new List<EstructuraValidacion>();
            foreach (var pago in pagos)
                ValidarSaldoLinea(pago, nueva, lstRdo);

            if (lstRdo.Count > 0)
                throw new ValidacionException("No es posible guardar los pagos. Revise lo siguiente:\n\n", lstRdo);

        }

        private void ValidarSaldoLinea(ProxyExpPagosMensLinea linea, bool nueva, List<EstructuraValidacion> lstRdo)
        {
            var periodo = linea.Periodo.Inferior(DateInterval.Month);
            var pagosPendientes = ObtenerPagosPendientes(periodo, null, linea.Cliente.Id, linea.IdRegDet);

            if (pagosPendientes.Count == 0)
            {
                lstRdo.Add(new EstructuraValidacion {
                    Mensage = string.Format("La linea para el cliente '{0}' en el período '{1}': \n\t- No hay pago pendiente para el cliente en este período."
                                            , linea.Cliente.NombreCompleto.ToUpper(), linea.Periodo.ToString(FormatHelper.MonthShortNameYearFormat)),
                                            Tipo = EnumTipoError.Advertencia
                                                    });
            }
            else
            {
                var pendiente = pagosPendientes.Single();
                if (pendiente.SaldoOrig < (linea.Abonado - linea.Recargo + linea.Bonificacion))
                {
                    lstRdo.Add(new EstructuraValidacion
                    {
                        Mensage = string.Format("La linea para el cliente '{0}' en el período '{1}': \n\t- El pago supera el saldo pendiente para el período."
                                                , linea.Cliente.NombreCompleto.ToUpper(), linea.Periodo.ToString(FormatHelper.MonthShortNameYearFormat)),
                        Tipo = EnumTipoError.Advertencia
                    });
                }

            }
        }

        protected override void ValidarLinea(Reg_Det linea, bool transaccionNueva)
        {
            base.ValidarLinea(linea, transaccionNueva);
            var lstRdo = new List<EstructuraValidacion>();
            var bonificacion = linea.ValNum1 ?? (decimal?)0M;
            var precioOri = linea.ValNum2;
            var recargo = linea.ValNum3 ?? (decimal?)0M;
            var abonado = linea.Precio ?? (decimal?)0M;

            // Si el precio y la bonificación es igual a cero,
            if ((abonado + bonificacion) == 0)
                lstRdo.Add(new EstructuraValidacion
                {
                    Mensage = string.Format("La linea para el cliente '{0}' en el período '{1}': \n\t- Lo abonado mas la bonificación ({2}) son igual a cero. Ingrese algún valor para Importe o Bonificación."
                                            , linea.EntidadAfectada1.NombreCompleto.ToUpper()
                                            , linea.ValFecha2.Value.ToString(FormatHelper.MonthShortNameYearFormat)
                                            , (linea.Precio + linea.ValNum1).Value.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)
                                            , linea.ValNum2.Value.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)),
                    Tipo = EnumTipoError.Advertencia
                });


            // Recargo mayor a lo que se abona
            if (Decimal.Round(recargo ?? 0M, 2) > Decimal.Round(abonado ?? 0, 2))
                lstRdo.Add(new EstructuraValidacion
                {
                    Mensage = string.Format("La linea para el cliente '{0}' en el período '{1}': \n\t- El recargo supera lo abonado. Revise los datos ingresados."
                                            , linea.EntidadAfectada1.NombreCompleto.ToUpper()
                                            , linea.ValFecha2.Value.ToString(FormatHelper.MonthNumberYearFormat)),
                    Tipo = EnumTipoError.Advertencia
                });

            if (Decimal.Round(abonado + bonificacion - recargo ?? 0M, 2) > Decimal.Round(precioOri ?? 0, 2))
                lstRdo.Add(new EstructuraValidacion
                {
                    Mensage = string.Format("La linea para el cliente '{0}' en el período '{1}': \n\t- Lo abonado mas la bonificación y el recargo ({2}) superan el precio del Servicio ({3})."
                                            , linea.EntidadAfectada1.NombreCompleto.ToUpper()
                                            , linea.ValFecha2.Value.ToString(FormatHelper.MonthNumberYearFormat)
                                            , (abonado + bonificacion - recargo).Value.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)
                                            , precioOri.Value.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)),
                    Tipo = EnumTipoError.Advertencia
                });


            if (linea.EntityState == System.Data.EntityState.Modified && linea.FechaBaja == null)
            {
                var ini = linea.ValFecha2.Value.Inferior(DateInterval.Month);
                var fin = linea.ValFecha2.Value.Superior(DateInterval.Month);

                //var otros = ObtenerPagosRegistrados(ini, fin, linea.EntidadAfectada1.Id, linea.Concepto.Id, linea.ValLista1.Id);
                //var otro = otros.FirstOrDefault();

                //if (otro != null && otro.Id != linea.Id)
                //    lstRdo.Add(new EstructuraValidacion
                //    {
                //        Mensage = string.Format("El cliente '{0}' ya registra un cobro mensual para la cochera {1} en el período {2}."
                //                                , linea.EntidadAfectada1.NombreCompleto.ToUpper()
                //                                , linea.ValLista1.Nombre
                //                                , linea.ValFecha2.Value.ToString("MM-yyyy")),
                //        Tipo = EnumTipoError.Error

                //    });

                var contratado = ObtenerContratosMensuales(ini, fin, null, linea.EntidadAfectada1.Id, linea.Concepto.Id, linea.ValLista1.Id).Count() != 0;
                if (!contratado)
                    lstRdo.Add(new EstructuraValidacion()
                    {
                        Mensage = string.Format("El pago que intenta registrar para el cliente '{0}', cochera {1} y período {2} no corresponde a un contrato vigente con dicho cliente."
                                                , linea.EntidadAfectada1.NombreCompleto.ToUpper()
                                                , linea.ValLista1.Nombre
                                                , linea.ValFecha2.Value.ToString("MM-yyyy")),
                        Tipo = EnumTipoError.Error
                    });
                    
            }

            if(lstRdo.Count > 0)
                throw new ValidacionException("No es posible guardar los pagos. Revise lo siguiente:\n\n", lstRdo);


        }


        /// <summary>
        /// Guarda el pago especificado
        /// </summary>
        /// <param name="_pago"></param>
        public void Guardar(ProxyExpPagosMensLinea pago)
        {
            var lstRdo = new List<EstructuraValidacion>();
            ValidarSaldoLinea(pago, false, lstRdo);
            if (lstRdo.Count > 0)
                throw new ValidacionException("No es posible guardar los pagos. Revise lo siguiente:\n\n", lstRdo);

            var linea = Persistidor.Linq.Lineas<Reg_Det>().First(l => l.Id == pago.IdRegDet);

            var mapeo = new MapeoExpPagosMensuales();
            mapeo.LLenarRegistro(linea, pago, Persistidor);

            ValidarLinea(linea, false);
            Guardar(linea.Reg_encab);
        }

        public void DarDeBaja(long idLineaPago)
        {
            var linea = Persistidor.Linq.Lineas<Reg_Det>().First(l => l.Id == idLineaPago);
            ValidarBajaLinea(linea.Reg_encab, linea);

            linea.FechaBaja = DateTime.Now;
            Guardar(linea.Reg_encab);
        }

        void ValidarBajaLinea(Reg_encab transaccion, Reg_Det linea)
        {
            if (linea.FechaBaja != null)
                throw new ValidacionException("Este registro de pago ya está dado de baja. No se puede realizar la acción.");
        }

        /// <summary>
        /// Calcula y devuelve el saldo de la línea. Opcionalmente actualiza el atributo "Saldo" de la instancia proporcionada.
        /// </summary>
        /// <param name="linea"></param>
        /// <param name="actualizarLinea"></param>
        public static decimal CalcularSaldo(ProxyExpPagosMensLinea linea, bool actualizarLinea = true)
        {
            var saldo = CalcularSaldo(linea.SaldoOrig, linea.Abonado, linea.Bonificacion, linea.Recargo);

            if (actualizarLinea)
                linea.Saldo = saldo;

            return saldo;
        }

        public static decimal CalcularSaldo(decimal saldoOriginal, decimal abonado, decimal bonificacion, decimal recargo)
        {
            var loQueHayQuePagar = saldoOriginal - bonificacion;
            var loQueEstaPagando = (abonado - recargo);
            var saldo = loQueHayQuePagar - loQueEstaPagando;

            return saldo;
        }
    }
}
