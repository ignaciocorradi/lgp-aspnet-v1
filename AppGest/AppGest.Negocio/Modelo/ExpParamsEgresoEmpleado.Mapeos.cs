using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpParamsEgresoEmpleado
    {

        internal class MapeoExpParamsEgresoEmpleado : MapeoRegistroProxy<ProxyExpParamsEgresoEmpleadoEncab, ProxyExpParamsEgresoEmpleadoLinea, KeyEntidadParamsEgresoEmpleado>
        {
            internal override void LLenarRegistro(Reg_Det linea, ProxyExpParamsEgresoEmpleadoLinea proxyLinea, PersistidorPredet persistidor)
            {
                linea.SetEntidadAfectada1(ObtenerAsocEnContexto(linea, proxyLinea.Empleado, persistidor));
                linea.SetConcepto(ObtenerAsocEnContexto(linea, proxyLinea.Concepto, persistidor));
                linea.Precio = proxyLinea.Importe;
                linea.Comentario = proxyLinea.Comentario;
                linea.ValFecha1 = (proxyLinea.Desde.IsMinValue() ? (DateTime?) null : proxyLinea.Desde);
                linea.ValFecha2 = (proxyLinea.Hasta.IsMinValue() ? (DateTime?) null : proxyLinea.Hasta);
                linea.FechaBaja = proxyLinea.FechaBaja;
                linea.Comentario = string.IsNullOrWhiteSpace(proxyLinea.Comentario) ? null : proxyLinea.Comentario;
                linea.Cantidad = 1;
                linea.Importe = linea.Cantidad * linea.Precio;

            }

            internal override void LLenarProxy(ProxyExpParamsEgresoEmpleadoLinea destino, Reg_Det origen, PersistidorPredet persistidor)
            {
                destino.Linea = origen;
                destino.Encabezado = origen.Reg_encab;
                destino.Empleado = (Empleado) origen.EntidadAfectada1;
                destino.Concepto = origen.Concepto;
                destino.Importe = origen.Precio ?? 0M;
                destino.Comentario = origen.Comentario;
                destino.Desde = origen.ValFecha1.IsNullOrMinValue() ? DateTime.MinValue : origen.ValFecha1.Value;
                destino.Hasta = origen.ValFecha2.IsNullOrMinValue() ? DateTime.MinValue : origen.ValFecha2.Value;
                destino.FechaBaja = origen.FechaBaja;
                destino.Comentario = origen.Comentario ?? string.Empty;
                
            }

            internal override void LLenarProxy(ProxyExpParamsEgresoEmpleadoEncab encab, Reg_encab origen, PersistidorPredet persistidor)
            {
                encab.Encabezado = origen;
                encab.FechaRegistro = origen.FechaRegistro.Value;
                encab.Empleado = (Empleado) origen.EntidadAfectada;
            }

            internal override void LLenarRegistro(Reg_encab encab, ProxyExpParamsEgresoEmpleadoEncab proxyEncab, PersistidorPredet persistidor)
            {
                encab.FechaRegistro = proxyEncab.FechaRegistro.Value;
                encab.SetEntidadAfectada(ObtenerAsocEnContexto(encab, proxyEncab.Empleado, persistidor));
            }

        }
    }



    internal class KeyEntidadParamsEgresoEmpleado : KeyEntidad<ProxyExpParamsEgresoEmpleadoEncab, ProxyExpParamsEgresoEmpleadoLinea>
    {
        public override string GetKeyLinea(ProxyExpParamsEgresoEmpleadoLinea prxLinea)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyLinea(Reg_Det linea)
        {
            throw new NotImplementedException();
        }
    }

}
