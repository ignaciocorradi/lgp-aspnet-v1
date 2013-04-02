using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Util;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpParamsEgresoEmpleado : ExpertoRegistro
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

        public void Guardar(ProxyExpParamsEgresoEmpleadoEncab proxyTransaccion)
        {
            var transaccion = LLenarTransaccion(proxyTransaccion);
            this.Guardar(transaccion);
            Persistidor.Confirmar();
        }
        private Reg_encab LLenarTransaccion(ProxyExpParamsEgresoEmpleadoEncab proxyTransaccion)
        {
            using (var expCpto = FabExpertos.Inst.Obtener<ExpConcepto>(this))
            {
                var carga = proxyTransaccion.Lineas;
                var mapeo = new MapeoExpParamsEgresoEmpleado();
                
                Reg_encab transaccion = null;
                if (proxyTransaccion.IdRegEncab == 0)
                    transaccion = Nuevo(HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_PARAM_EGRESO_EMPLEADO));
                else
                    transaccion = Persistidor.ObtenerTransaccionPorId<Reg_encab>(proxyTransaccion.IdRegEncab);
                
                if (carga.FirstOrDefault() != null)
                    transaccion.SetEntidadAfectada(carga.First().Empleado);

                foreach (var lineaPrx in carga)
                {
                    var linea = transaccion.Reg_Det.FirstOrDefault(x => x.Id != 0 &&  x.Id == lineaPrx.IdRegDet);
                    
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
            var periodos = transaccion.Reg_Det.OrderBy(x => x.ValFecha1);
            if (periodos.Count() == 0)
                throw new ValidacionException(string.Format("La registración debe contener al menos un registro. Revise los datos ingresados."));

            var ant = null as Reg_Det;

            foreach (var linea in periodos)
            {
                var desde = linea.ValFecha1.IsNullOrMinValue() ? "" : linea.ValFecha1.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                var hasta = linea.ValFecha2.IsNullOrMinValue() ? "" : linea.ValFecha2.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);

                if (ant != null)
                {
                    if (!ant.ValFecha2.HasValue)
                    {
                        var desdeAnt = ant.ValFecha1.IsNullOrMinValue() ? "" : ant.ValFecha1.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                        var hastaAnt = ant.ValFecha2.IsNullOrMinValue() ? "" : ant.ValFecha2.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                        throw new ValidacionException(string.Format("El periodo [{0} - {1}] no es el último periodo. Debe indicar un valor para el campo 'Hasta'.", desdeAnt, hastaAnt));
                    }
                    else if (!linea.ValFecha1.HasValue || linea.ValFecha1.Value <= ant.ValFecha2.Value)
                    {
                        var desdeAnt = ant.ValFecha1.IsNullOrMinValue() ? "" : ant.ValFecha1.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                        var hastaAnt = ant.ValFecha2.IsNullOrMinValue() ? "" : ant.ValFecha2.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                        throw new ValidacionException(string.Format("Los periodos [{0} - {1}] y [{2} - {3}] están solapados.", desdeAnt, hastaAnt, desde, hasta));
                    }
                }

                ant = linea;
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

            var desde = linea.ValFecha1.IsNullOrMinValue() ? "" : linea.ValFecha1.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
            var hasta = linea.ValFecha2.IsNullOrMinValue() ? "" : linea.ValFecha2.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);

            var ingreso = linea.EntidadAfectada1.Alta.Inferior(DateInterval.Day);
            if (linea.ValFecha1.IsNullOrMinValue() || linea.ValFecha1.Value.Inferior(DateInterval.Day) < ingreso)
            {
                var ingresoStr = linea.EntidadAfectada1.Alta.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                throw new ValidacionException(string.Format("El periodo '{0}' - '{1}' no es válido porque la fecha de ingreso del empleado ({2}) es mayor a la fecha de inicio del periodo. Revise los datos ingresados", desde, hasta, ingresoStr));
            }

            if (!linea.Precio.HasValue || linea.Precio.Value < 0)
                throw new ValidacionException(string.Format("Debe especificar un importe válido para el periodo '{0}' - '{1}'.", desde, hasta));


            if (!linea.Precio.HasValue || linea.Precio.Value < 0)
                throw new ValidacionException(string.Format("Debe especificar un importe válido para el periodo '{0}' - '{1}'.", desde, hasta));

            if (linea.ValFecha1.HasValue && linea.ValFecha2.HasValue && linea.ValFecha2 < linea.ValFecha1)
                throw new ValidacionException(string.Format("El periodo '{0}' - '{1}' no es válido. La fecha desde debe ser menor a la fecha hasta.", desde, hasta));

            //TODO: Validar que si modificó Fecha Desde/Hasta, no queden pagos fuera.
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

        public ProxyExpParamsEgresoEmpleadoEncab ObtenerEgresosXEmpleado(long idEmpleado, bool crearSiNoExiste = false)
        {
            var cptoTran = HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_PARAM_EGRESO_EMPLEADO);

            var lineas = Persistidor.Linq.Lineas<Reg_Det>()
                .Where(l => l.Reg_encab.Concepto.Id == cptoTran.Id
                            && l.Reg_encab.EntidadAfectada.Id == idEmpleado).ToList();
            
            if (lineas.Count == 0 && crearSiNoExiste)
            {
                var cptoSueldo = HelperModelo.ObtenerConceptosUsuario(this, ConceptoEgresos.EGRESOS_EMPLEADOS).Where(c => c.Abreviatura == "REMU").FirstOrDefault();
                var encab = Nuevo(cptoTran);
                var emp = Persistidor.ObtenerEntidadPorId<Empleado>(idEmpleado);
                encab.SetEntidadAfectada(emp);

                var linea = Nuevo(encab, cptoSueldo);
                linea.ValFecha1 = emp.Alta.Date;
                linea.SetEntidadAfectada1(emp);
                lineas.Add(linea);
            }

            var proxies = ProxyRegistroDet.CrearDesde<ProxyExpParamsEgresoEmpleadoLinea, ProxyExpParamsEgresoEmpleadoEncab, MapeoExpParamsEgresoEmpleado, KeyEntidadParamsEgresoEmpleado>(lineas, Persistidor);
            var encabezados = ProxyRegistroDet.ObtenerEncabezados<ProxyExpParamsEgresoEmpleadoLinea, ProxyExpParamsEgresoEmpleadoEncab, MapeoExpParamsEgresoEmpleado, KeyEntidadParamsEgresoEmpleado>(proxies.ToList(), Persistidor);

            return encabezados.FirstOrDefault();                                            
        }

        DateTime Max(DateTime f1, DateTime f2)
        {
            if (f1 >= f2)
                return f1;
            else
                return f2;
        }

        public ProxyExpParamsEgresoEmpleadoLinea NuevaLinea(ProxyExpParamsEgresoEmpleadoEncab transaccion)
        {
            var cptoSueldo = HelperModelo.ObtenerConceptosUsuario(this, ConceptoEgresos.EGRESOS_EMPLEADOS).Where(c => c.Abreviatura == "REMU").FirstOrDefault();
            var linea = Nuevo(transaccion.Encabezado, cptoSueldo);

            linea.SetEntidadAfectada1(transaccion.Empleado);

            var lineaPrx = new ProxyExpParamsEgresoEmpleadoLinea();
            var lineaAnt = transaccion.Lineas.OrderBy(x => x.Desde).LastOrDefault();
            if (lineaAnt != null)
            {
                if (lineaAnt.Hasta == DateTime.MinValue)
                    lineaAnt.Hasta = Max(DateTime.Now.Superior(DateInterval.Minute), lineaAnt.Desde).Superior(DateInterval.Day, DateInterval.Day);

                linea.ValFecha1 = lineaAnt.Hasta.Date.AddDays(1);
            }
            else
            {
                linea.ValFecha2 = transaccion.Empleado.Alta.Date;
            }

            var mapeo = new MapeoExpParamsEgresoEmpleado();
            mapeo.LLenarProxy(lineaPrx, linea, Persistidor);
            transaccion.Lineas.Add(lineaPrx);

            return lineaPrx;
        }

    }
}
