using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpPagosIngresosEgresos : ExpertoRegistro
    {
        /// <summary>
        /// Representa un concepto de transacción para el registro de egresos.
        /// </summary>
        public Concepto CptoTransaccionRegistroEgreso { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_EGRESOS); } }

        /// <summary>
        /// Representa un concepto de transacción para el registro de ingresos.
        /// </summary>
        public Concepto CptoTransaccionRegistroIngreso { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_INGRESOS); } }

        public List<ProxyPagoIngresosEgresosVariosDetalle>  ListarPagos(Concepto cptoListaPrecioPago,FiltrosDatos filtro, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            return this.ListarRegristrosIngresosEgresos(cptoListaPrecioPago,filtro, this.CptoTransaccionRegistroEgreso, TipoServicio.EgresosVarios, fechaDesde, fechaHasta);
        }

        public List<ProxyPagoIngresosEgresosVariosDetalle> ListarCobros(Concepto cptoListaPrecioCobro, FiltrosDatos filtro, DateTime? fechaDesde = null, 
            DateTime? fechaHasta = null, Persona cliente = null,
            DateTime? fVtoDesde = null, DateTime? fVtoHasta = null,
            DateTime? fRegDesde = null, DateTime? fRegHasta = null)
        {
            return this.ListarRegristrosIngresosEgresos(cptoListaPrecioCobro, filtro, this.CptoTransaccionRegistroIngreso
                , TipoServicio.Ingresos, fechaDesde, fechaHasta, cliente, fVtoDesde, fVtoHasta, fRegDesde, fRegHasta);
        }

        private List<ProxyPagoIngresosEgresosVariosDetalle> ListarRegristrosIngresosEgresos(Concepto cptoListaPrecio, FiltrosDatos filtro, 
            Concepto transaccionIngresoEgreso, TipoServicio tipo,
            DateTime? fechaDesde = null, DateTime? fechaHasta = null, Persona cliente = null,
            DateTime? fVtoDesde = null, DateTime? fVtoHasta = null,
            DateTime? fServDesde = null, DateTime? fServHasta = null
            )
        {
            List<ProxyPagoIngresosEgresosVariosDetalle> detalles = new List<ProxyPagoIngresosEgresosVariosDetalle>();


            long idCtoListaPrecio = cptoListaPrecio != null ? cptoListaPrecio.Id : 0;
            int clase = cptoListaPrecio != null ? cptoListaPrecio.Clase : 0;
            int valor = cptoListaPrecio != null ? cptoListaPrecio.Valor : 0;
            long idcli = cliente != null ? cliente.Id : 0;

            var reg = Persistidor.ListaRegDet<Reg_Det>(d => d.Reg_encab.Concepto.Id == transaccionIngresoEgreso.Id
                && (idCtoListaPrecio == 0 || (d.Concepto.Id == idCtoListaPrecio))
                && (fechaDesde == null || d.ValFecha1 >= fechaDesde) //FechaPago
                && (fechaHasta == null || d.ValFecha1 <= fechaHasta)

                && (fVtoDesde == null || d.ValFecha2 >= fVtoDesde) //FechaVto
                && (fVtoHasta == null || d.ValFecha2 <= fVtoHasta)

                && (fServDesde == null || d.ValFecha3 >= fServDesde) //FechaServicio
                && (fServHasta == null || d.ValFecha3 <= fServHasta)

                && (idcli == 0 || d.EntidadAfectada1.Id == idcli )).ToList();

            var encab = (from e in reg select e.Reg_encab).Distinct().ToList() ;

            var proxEnc = (from p in encab
                          select new ProxyPagoIngresosEgresosVarios(p, tipo)).ToList();

            foreach (var enc in proxEnc)
            {
                
                switch (filtro)
                {
                    case FiltrosDatos.VerSaldoMayorACero:
                        detalles.AddRange(enc.Detalles.Where(l => (l.Importe - l.Abonado) > 0
                            && (idcli == 0 || l.Cliente.Id == idcli)
                            && (idCtoListaPrecio == 0 || (l.Concepto.Id == idCtoListaPrecio))
                            && (fechaDesde == null || l.FechaPago >= fechaDesde) //FechaPago
                            && (fechaHasta == null || l.FechaPago <= fechaHasta)

                            && (fVtoDesde == null || l.FechaVencimiento >= fVtoDesde) //FechaVto
                            && (fVtoHasta == null || l.FechaVencimiento <= fVtoHasta)

                            && (fServDesde == null || l.FechaServicio >= fServDesde) //FechaServicio
                            && (fServHasta == null || l.FechaServicio <= fServHasta)
                            ));
                        break;
                    case FiltrosDatos.VerSaldoIgualACero:
                        detalles.AddRange(enc.Detalles.Where(l => (l.Importe - l.Abonado) == 0 
                            && (idcli == 0 || l.Cliente.Id == idcli)
                            && (idCtoListaPrecio == 0 || (l.Concepto.Id == idCtoListaPrecio))
                            && (fechaDesde == null || l.FechaPago >= fechaDesde) //FechaPago
                            && (fechaHasta == null || l.FechaPago <= fechaHasta)

                            && (fVtoDesde == null || l.FechaVencimiento >= fVtoDesde) //FechaVto
                            && (fVtoHasta == null || l.FechaVencimiento <= fVtoHasta)

                            && (fServDesde == null || l.FechaServicio >= fServDesde) //FechaServicio
                            && (fServHasta == null || l.FechaServicio <= fServHasta)
                            ));
                        break;
                    case FiltrosDatos.VerTodos:
                    default:
                        detalles.AddRange(enc.Detalles.Where(l=> (idcli==0 || l.Cliente.Id == idcli )
                            && (idCtoListaPrecio == 0 || (l.Concepto.Id == idCtoListaPrecio))
                            && (fechaDesde == null || l.FechaPago >= fechaDesde) //FechaPago
                            && (fechaHasta == null || l.FechaPago <= fechaHasta)

                            && (fVtoDesde == null || l.FechaVencimiento >= fVtoDesde) //FechaVto
                            && (fVtoHasta == null || l.FechaVencimiento <= fVtoHasta)

                            && (fServDesde == null || l.FechaServicio >= fServDesde) //FechaServicio
                            && (fServHasta == null || l.FechaServicio <= fServHasta)
                            ));
                        break;
                }
               
            }

            return detalles;
        }

        public Reg_encab NuevoPago(TipoServicio tipo, bool conDetalle = true)
        {

            Reg_encab transaccion = tipo == TipoServicio.EgresosVarios ? this.Nuevo(this.CptoTransaccionRegistroEgreso) : this.Nuevo(this.CptoTransaccionRegistroIngreso);

            transaccion.FechaRegistro = DateTime.Now;
            if (conDetalle)
                this.Nuevo(transaccion, new Concepto());
            return transaccion;
        }

        public decimal ObtenerImporte(long idConceptoListaPrecio, DateTime fechaPago, decimal valorActual)
        {
            decimal rdo = 0M;
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(this))
            {
                Reg_encab encab = exp.ObtenerEncabPrecio(idConceptoListaPrecio);
                if (encab != null)
                {
                    var fila = (from linea in encab.Reg_Det
                                where linea.Concepto.Id == idConceptoListaPrecio &&
                                       (linea.ValFecha1 == null || (linea.ValFecha1.HasValue && linea.ValFecha1.Value <= fechaPago))
                                       &&
                                       (linea.ValFecha2 == null || (linea.ValFecha2.HasValue && linea.ValFecha2.Value >= fechaPago))
                                select linea).FirstOrDefault();

                    rdo = (fila != null && fila.Precio.HasValue) ? fila.Precio.Value : valorActual;
                }

            }
            return rdo;
        }

        public void GuardarPago( ProxyPagoIngresosEgresosVarios proxy)
        {
            var encab = CargarPagos(proxy);

            Guardar(encab);

            Persistidor.Confirmar();
 
        }
        private Reg_encab CargarPagos(ProxyPagoIngresosEgresosVarios proxy)
        {
            Reg_encab encab = null;
            if (proxy.Encabezado.Id == 0)
            {
                encab = this.NuevoPago(proxy.Tipo, false);
                encab.FechaAlta = DateTime.Now;
                
            }
            else
            {
                encab = Persistidor.ObtenerTransaccionPorId<Reg_encab>(proxy.Encabezado.Id);
                encab.FechaModif = DateTime.Now;
            }
             
            encab.Comentario = proxy.Comentario;
            encab.FechaRegistro = proxy.FechaRegistro;

            foreach (ProxyPagoIngresosEgresosVariosDetalle proxyDetalle in proxy.Detalles)
            {
                // Buscar todas las entidades y asignarlas ahora. 
                var cpto = this.Persistidor.ObtenerEntidadPorId<Concepto>(proxyDetalle.Concepto.Id);
                Reg_Det linea;
                if (proxyDetalle.EsNuevo)
                {
                    linea = this.NuevoDetalle();
                    linea.FechaAlta = DateTime.Now;
                    
                }
                else
                {
                    linea = encab.Reg_Det.Where(r => r.Id == proxyDetalle.IdRegistro).FirstOrDefault();
                    linea.FechaModif = DateTime.Now;
                }
                
                //Realizo la actualizacion de los valores de las propiedades
                linea.Comentario = proxyDetalle.Comentario;
                linea.SetConcepto(cpto);
                linea.Cantidad = 1;
                linea.Precio = proxyDetalle.Importe;
                linea.Importe = proxyDetalle.Importe;
                linea.ValNum1 = proxyDetalle.Abonado;
                linea.ValFecha1 = proxyDetalle.FechaPago;
                linea.ValFecha3 = proxyDetalle.FechaServicio;
                linea.ValFecha2 = proxyDetalle.FechaVencimiento;

                if (proxyDetalle.Cliente != null)
                {
                    var cli = this.Persistidor.ObtenerEntidadPorId<Cliente>(proxyDetalle.Cliente.Id);
                    linea.SetEntidadAfectada1(cli);
                }
                this.AsignarRegistroDetalle(encab, linea, cpto);

            }
            return encab;
        }

        public ProxyPagoIngresosEgresosVariosDetalle NuevoDetalle(ProxyPagoIngresosEgresosVarios parent)
        {
            var linea = this.Nuevo(parent.Encabezado, null);
            return new ProxyPagoIngresosEgresosVariosDetalle(linea, parent);
        }

        Concepto cptoRelVehiculo { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoRelaciones.ASOC_CLIENTE_VEHICULO); } }

        public List<Vehiculo> ObtenerVehiculos(Cliente entidad)
        {
            //Obtiene los vehículos asociados a un cliente que no esten dados de baja.
            //var lst = (from c in Persistidor.ListaRegDet<Reg_Det>()
            //          where c.Concepto.Id == cptoRelVehiculo.Id
            //                 && c.EntidadAfectada1.Id == entidad.Id
            //                 && !cptoRelVehiculo.Baja.HasValue
            //                 && !c.ValLista1.Baja.HasValue
            //          select c.ValLista1.Id).ToList();

            var lst = (from c in Persistidor.Linq.Lineas()
            where c.Concepto.Id == cptoRelVehiculo.Id
                    && c.EntidadAfectada1.Id == entidad.Id
                    && !cptoRelVehiculo.Baja.HasValue
                    && !c.ValLista1.Baja.HasValue
            select c.ValLista1).ToList();

            var lstVeh = (from v in lst select v as Vehiculo).ToList(); 
            return lstVeh;
        }
    }
    public enum FiltrosDatos
    {
        VerSoloDadosDeBaja,
        VerSoloActivos,
        VerTodos,
        VerSaldoMayorACero,
        VerSaldoIgualACero,
        VerSaldoMenorACero
    }
}
