using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Util;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpPagoEgresoEmpleado : ExpertoRegistro
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

        public void Guardar(ProxyExpPagoEgresoEmpleadoEncab proxyTransaccion)
        {
            var transaccion = LLenarTransaccion(proxyTransaccion);
            this.Guardar(transaccion);
            Persistidor.Confirmar();
        }
        private Reg_encab LLenarTransaccion(ProxyExpPagoEgresoEmpleadoEncab proxyTransaccion)
        {
            using (var expCpto = FabExpertos.Inst.Obtener<ExpConcepto>(this))
            {
                var carga = proxyTransaccion.Lineas;
                var mapeo = new MapeoExpPagoEgresoEmpleado();
                
                Reg_encab transaccion = null;
                if (proxyTransaccion.IdRegEncab == 0)
                    transaccion = Nuevo(HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_PAGO_EGRESO_EMPLEADO));
                else
                    transaccion = Persistidor.ObtenerTransaccionPorId<Reg_encab>(proxyTransaccion.IdRegEncab);
                
                if (carga.FirstOrDefault() != null)
                    transaccion.SetEntidadAfectada(carga.First().Empleado);

                foreach (var lineaPrx in carga)
                {
                    var linea = transaccion.Reg_Det.FirstOrDefault(x => x.Id != 0 && x.Id == lineaPrx.IdRegDet);
                    
                    if (linea == null)
                        linea = Nuevo(transaccion, lineaPrx.Concepto);

                    mapeo.LLenarRegistro(linea, lineaPrx, Persistidor);
                }

                return transaccion;
            }

        }

        protected override void ValidarModificar(Reg_encab transaccion)
        {
            base.ValidarModificar(transaccion);
            Validar(transaccion);
        }
        protected override void ValidarNuevo(Reg_encab transaccion)
        {
            base.ValidarNuevo(transaccion);
            Validar(transaccion);
        }

        protected void Validar(Reg_encab transaccion)
        {
            // que la transacción tenga un empleado afectado (nunca debería dar este error).
            if (transaccion.EntidadAfectada == null)
                throw new ValidacionException(string.Format("Debe especificar un empleado. Comuníquese con el adminsitrador del sistema."));


            // que haya al menos un pago a guardar
            var pagos = transaccion.Reg_Det.OrderBy(x => x.ValFecha2);
            if (pagos.Count() == 0)
                throw new ValidacionException(string.Format("La registración debe contener al menos un registro. Revise los datos ingresados."));

            var periodos = pagos.GroupBy(x => x.ValFecha1.Value.Inferior(DateInterval.Month)).OrderBy(g => g.Key);
            var aTermino = HelperModelo.ObtenerConceptoSistema(this, ConceptoCualitativo.A_TERMINO);
            var empleado = transaccion.EntidadAfectada;

            // que el periodo de pago nunca sea menor al periodo de ingreso del empleado
            var periodoMinEmpleado = empleado.Alta.Inferior(DateInterval.Month);
            var periodoAnteriorIngreso = periodos.FirstOrDefault(per => per.Key < periodoMinEmpleado);
            if (periodoAnteriorIngreso != null)
            {
                var strPerNoValido = periodoAnteriorIngreso.Key.ToString("MMM - yyyy");
                // periodo a validar
                var strPerIngresoEmpl = periodoMinEmpleado.ToString("MMM - yyyy");
                throw new ValidacionException(string.Format("El periodo '{0}' no se puede registrar porque es anterior a al mes de ingreso del empleado ({1}).", strPerNoValido, strPerIngresoEmpl));
            }


            foreach (var periodo in periodos)
            {
                var periodoSinBajas = periodo.Where(p => p.FechaBaja == null);

                if (periodoSinBajas.Count() != 0)   // Si hay algún pago validamos
                {
                    // periodo a validar
                    var strPeriodo = periodo.Key.ToString("MMM - yyyy");

                    // que todos los pagos tengan fecha de pago.
                    if (periodoSinBajas.Any(pago => !pago.ValFecha2.HasValue))
                        throw new ValidacionException(string.Format("Uno o mas pagos del periodo '{0}' no tienen fecha de pago. Revise los datos ingresados.", strPeriodo));

                    // que todos los pagos tengan un Tipo (anticipo/a término/etc).
                    var sinTipoPago = periodoSinBajas.FirstOrDefault(pago => pago.ValLista1 == null);
                    if (sinTipoPago != null)
                    {
                        var strFechaPago = sinTipoPago.ValFecha2.Value.ToString("dd/MM/yyyy");
                        throw new ValidacionException(string.Format("No se permiten pagos sin especificación de tipo. Revise el pago efectuado en el periodo {0}, fecha de pago '{1}'.", strPeriodo));
                    }

                    // que todos los importes sean correctos
                    var conImporteNoValido = periodoSinBajas.FirstOrDefault(linea => linea.Importe <= 0);
                    if (conImporteNoValido != null)
                    {
                        var strFechaPago = conImporteNoValido.ValFecha2.Value.ToString("dd/MM/yyyy");
                        throw new ValidacionException(string.Format("No se permiten pagos con importes en cero o negativos. Revise los pagos realizados en el periodo '{0}', fecha de pago '{1}'.", strPeriodo, strFechaPago));
                    }

                    // que la fecha de pago no sea inferior a la fecha de ingreso del empleado.
                    var pagoAntesIngreso = periodoSinBajas.FirstOrDefault(pagoAnt => pagoAnt.ValFecha2 < empleado.Alta);
                    if (pagoAntesIngreso != null)
                    {
                        var strFechaPago = pagoAntesIngreso.ValFecha2.Value.ToString("dd/MM/yyyy");
                        var strIngresoEmpl = empleado.Alta.ToString("dd/MM/yyyy");

                        throw new ValidacionException(string.Format("El periodo '{0}' registra un pago con fecha anterior al ingreso del empleado ('{1}'). Revise el pago con fecha  '{2}'.", strPeriodo, strIngresoEmpl, strFechaPago));
                    }

                    // que solo haya un pago "A Término".
                    var cantAtermino = periodoSinBajas.Count(linea => linea.ValLista1.Id == aTermino.Id);
                    if (cantAtermino > 1)
                    {
                        throw new ValidacionException(string.Format("Solo se permite un único pago '{0}' para el periodo '{1}'. Revise los datos ingresados.", aTermino.Nombre, strPeriodo));
                    }
                    else if (cantAtermino == 1)
                    {
                        // Si hay un pago a término, debe ser el de última fecha de pago
                        var ultimoPago = periodoSinBajas.OrderBy(pago => pago.ValFecha2).Last();
                        if (ultimoPago.ValLista1.Id != aTermino.Id)
                        {
                            throw new ValidacionException(string.Format("Solo el último pago puede ser de tipo '{0}'. Revise los datos ingresados para el periodo '{1}'.", aTermino.Nombre, strPeriodo));
                        }

                    }

                }
            }
        }

        protected override void ValidarLineaEliminada(Reg_Det lineaBD)
        {
            // TODO: implementar.
            throw new ValidacionException(string.Format("No se permite la eliminación de líneas."));
        }

        protected override void ValidarLinea(Reg_Det linea, bool transaccionNueva)
        {
            base.ValidarLinea(linea, transaccionNueva);
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
                throw new ValidacionException("Este registro ya está dado de baja. No se puede realizar la acción.");
        }
        public ProxyExpPagoEgresoEmpleadoEncab ObtenerEgresosXEmpleado(long idEmpleado, bool crearSiNoExiste = false)
        {
            var cptoTran = HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_PAGO_EGRESO_EMPLEADO);

            var lineas = Persistidor.Linq.Lineas<Reg_Det>()
                .Where(l => l.Reg_encab.Concepto.Id == cptoTran.Id
                            && l.Reg_encab.EntidadAfectada.Id == idEmpleado).ToList();

            if (lineas.Count == 0 && crearSiNoExiste)
            {
                var cptoSueldo = HelperModelo.ObtenerConceptosUsuario(this, ConceptoEgresos.EGRESOS_EMPLEADOS).Where(c => c.Abreviatura == "REMU").FirstOrDefault();
                var encab = Nuevo(cptoTran);
                encab.SetEntidadAfectada(Persistidor.ObtenerEntidadPorId<Empleado>(idEmpleado));

                var mapeo = new MapeoExpPagoEgresoEmpleado();
                var proxyEncab = new ProxyExpPagoEgresoEmpleadoEncab();
                mapeo.LLenarProxy(proxyEncab, encab, Persistidor);

                //var linea = NuevaLinea(proxyEncab, encab.EntidadAfectada.Alta.Inferior(DateInterval.Month));
                return proxyEncab;

            }
            else if (lineas.Count != 0)
            {
                var proxies = ProxyRegistroDet.CrearDesde<ProxyExpPagoEgresoEmpleadoLinea, ProxyExpPagoEgresoEmpleadoEncab, MapeoExpPagoEgresoEmpleado, KeyEntidadPagoEgresoEmp>(lineas, Persistidor);
                var encabezados = ProxyRegistroDet.ObtenerEncabezados<ProxyExpPagoEgresoEmpleadoLinea, ProxyExpPagoEgresoEmpleadoEncab, MapeoExpPagoEgresoEmpleado, KeyEntidadPagoEgresoEmp>(proxies.ToList(), Persistidor);

                return encabezados.FirstOrDefault();
            }
            else
                return null;
        }

        DateTime Max(DateTime f1, DateTime f2)
        {
            if (f1 >= f2)
                return f1;
            else
                return f2;
        }

        public ProxyExpPagoEgresoEmpleadoLinea NuevaLinea(ProxyExpPagoEgresoEmpleadoEncab transaccion, DateTime periodo)
        {
            var cptoSueldo = HelperModelo.ObtenerConceptosUsuario(this, ConceptoEgresos.EGRESOS_EMPLEADOS).Where(c => c.Abreviatura == "REMU").FirstOrDefault();
            var linea = Nuevo(transaccion.Encabezado, cptoSueldo);

            linea.SetEntidadAfectada1(transaccion.Empleado);
            linea.ValFecha1 = periodo.Inferior(DateInterval.Month);
            linea.ValFecha2 = DateTime.Now;
            linea.SetValLista1(HelperModelo.ObtenerConceptoSistema(this, ConceptoCualitativo.ANTICIPO));

            var lineaPrx = new ProxyExpPagoEgresoEmpleadoLinea();
            var mapeo = new MapeoExpPagoEgresoEmpleado();

            mapeo.LLenarProxy(lineaPrx, linea, Persistidor);
            transaccion.Lineas.Add(lineaPrx);

            return lineaPrx;
        }
        public IList<ProxyExpPagoEgresoEmpleadoLinea> ObtenerPagosEfectuadosAEmpleado(long idEmpleado, DateTime? desde, DateTime? hasta)
        {
            var encabPagos = ObtenerEgresosXEmpleado(idEmpleado, false);
            if (encabPagos != null)
            {
                return encabPagos.Lineas.Where(l => (desde.IsNullOrMinValue() || l.Periodo >= desde.Value) && (hasta.IsNullOrMinValue() || l.Periodo <= hasta.Value)).ToList();
            }
            else
                return new List<ProxyExpPagoEgresoEmpleadoLinea>();
        }
    }
}
