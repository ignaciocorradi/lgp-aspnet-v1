using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpPagosMensuales
    {

        internal class MapeoExpPagosMensuales : MapeoRegistroProxy<ProxyExpPagosMensEncab, ProxyExpPagosMensLinea, KeyEntidadPagoMensual>
        {
            internal override void LLenarRegistro(Reg_Det linea, ProxyExpPagosMensLinea proxyLinea, PersistidorPredet persistidor)
            {
                linea.SetEntidadAfectada1(ObtenerAsocEnContexto(linea,  proxyLinea.Cliente, persistidor));
                linea.SetValLista1(ObtenerAsocEnContexto(linea,  proxyLinea.Cochera, persistidor));
                linea.SetConcepto(ObtenerAsocEnContexto(linea, proxyLinea.Concepto, persistidor));
                linea.ValFecha1 = proxyLinea.FechaPago;
                linea.ValFecha2 = proxyLinea.Periodo;
                linea.Precio = proxyLinea.Abonado;
                linea.ValNum2 = proxyLinea.PrecioOrig;
                linea.ValNum1 = proxyLinea.Bonificacion;
                linea.ValNum3 = proxyLinea.Recargo;
                linea.ValText1 = string.IsNullOrWhiteSpace(proxyLinea.Comentario) ? null: proxyLinea.Comentario;
                linea.Cantidad = 1;
                linea.Importe = linea.Cantidad * linea.Precio;

            }

            internal override void LLenarProxy(ProxyExpPagosMensLinea destino, Reg_Det origen, PersistidorPredet persistidor)
            {
                destino.Linea = origen;
                destino.Encabezado = origen.Reg_encab;
                destino.Cliente = (Cliente) origen.EntidadAfectada1;
                destino.Cochera = (Cochera) origen.ValLista1;
                destino.Concepto = origen.Concepto;
                destino.FechaPago = origen.ValFecha1 ?? DateTime.Now;
                destino.Periodo = origen.ValFecha2.Value;
                destino.Abonado = origen.Precio ?? 0M;
                destino.PrecioOrig = origen.ValNum2 ?? destino.Abonado;
                destino.Bonificacion = origen.ValNum1.Value;
                destino.Recargo = origen.ValNum3.HasValue ? origen.ValNum3.Value : 0M;
                destino.Comentario = origen.ValText1 ?? string.Empty;
                
            }

            internal override void LLenarProxy(ProxyExpPagosMensEncab encab, Reg_encab origen, PersistidorPredet persistidor)
            {
                encab.Encabezado = origen;
                encab.FechaRegistro = origen.FechaRegistro;

            }

            internal override void LLenarRegistro(Reg_encab encab, ProxyExpPagosMensEncab proxyEncab, PersistidorPredet persistidor)
            {
                encab.FechaRegistro = proxyEncab.FechaRegistro;
            }


        }
    }


    internal class KeyEntidadPagoMensual : KeyEntidad<ProxyExpPagosMensEncab, ProxyExpPagosMensLinea>
    {
        public override string GetKeyLinea(ProxyExpPagosMensLinea prxLinea)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyLinea(Reg_Det linea)
        {
            var key = Convert.ToString(linea.ValFecha2.Value.Year * 100 + linea.ValFecha2.Value.Month)                      // periodo
                                                + "|" + Convert.ToString(linea.Concepto.Id)                                     // servicio
                                                + "|" + Convert.ToString(linea.EntidadAfectada1.Id)                             // cliente
                                                + "|" + Convert.ToString(linea.ValLista1.Id)                                    // cochera        
                                                ;
        
            return key;
        }

    }

}
