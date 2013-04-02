using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpPagoEgresoEmpleado
    {

        internal class MapeoExpPagoEgresoEmpleado : MapeoRegistroProxy<ProxyExpPagoEgresoEmpleadoEncab, ProxyExpPagoEgresoEmpleadoLinea, KeyEntidadPagoEgresoEmp>
        {
            internal override void LLenarRegistro(Reg_Det linea, ProxyExpPagoEgresoEmpleadoLinea proxyLinea, PersistidorPredet persistidor)
            {
                linea.SetEntidadAfectada1(ObtenerAsocEnContexto(linea, proxyLinea.Empleado, persistidor));
                linea.SetConcepto(ObtenerAsocEnContexto(linea, proxyLinea.Concepto, persistidor));
                linea.SetValLista1(ObtenerAsocEnContexto(linea, proxyLinea.Momento, persistidor));
                linea.Precio = proxyLinea.Importe;
                linea.Comentario = proxyLinea.Comentario;
                linea.ValFecha1 = (proxyLinea.Periodo.IsMinValue() ? (DateTime?) null : proxyLinea.Periodo);
                linea.FechaBaja = proxyLinea.FechaBaja;
                linea.Comentario = string.IsNullOrWhiteSpace(proxyLinea.Comentario) ? null : proxyLinea.Comentario;
                linea.Cantidad = 1;
                linea.Importe = linea.Cantidad * linea.Precio;
                linea.ValFecha2 = proxyLinea.FechaPago;

            }

            internal override void LLenarProxy(ProxyExpPagoEgresoEmpleadoLinea destino, Reg_Det origen, PersistidorPredet persistidor)
            {
                destino.Linea = origen;
                destino.Encabezado = origen.Reg_encab;
                destino.Empleado = (Empleado) origen.EntidadAfectada1;
                destino.Concepto = origen.Concepto;
                destino.Momento = (Concepto) origen.ValLista1;
                destino.Importe = origen.Precio ?? 0M;
                destino.Comentario = origen.Comentario;
                destino.Periodo = origen.ValFecha1.IsNullOrMinValue() ? DateTime.MinValue : origen.ValFecha1.Value;
                destino.FechaBaja = origen.FechaBaja;
                destino.Comentario = origen.Comentario ?? string.Empty;
                destino.FechaPago = origen.ValFecha2.IsNullOrMinValue() ? DateTime.MinValue : origen.ValFecha2.Value;
                
            }

            internal override void LLenarProxy(ProxyExpPagoEgresoEmpleadoEncab encab, Reg_encab origen, PersistidorPredet persistidor)
            {
                encab.Encabezado = origen;
                encab.FechaRegistro = origen.FechaRegistro.Value;
                encab.Empleado = (Empleado) origen.EntidadAfectada;
            }

            internal override void LLenarRegistro(Reg_encab encab, ProxyExpPagoEgresoEmpleadoEncab proxyEncab, PersistidorPredet persistidor)
            {
                encab.FechaRegistro = proxyEncab.FechaRegistro.Value;
                encab.SetEntidadAfectada(ObtenerAsocEnContexto(encab, proxyEncab.Empleado, persistidor));
            }


        }
    }

    internal class KeyEntidadPagoEgresoEmp : KeyEntidad<ProxyExpPagoEgresoEmpleadoEncab, ProxyExpPagoEgresoEmpleadoLinea>
    {
        public override string GetKeyLinea(ProxyExpPagoEgresoEmpleadoLinea prxLinea)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyLinea(Reg_Det linea)
        {
            throw new NotImplementedException();
        }
    }

}
