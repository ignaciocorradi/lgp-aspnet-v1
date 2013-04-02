using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    public partial class ExpMensuales
    {

        internal class MapeoMensuales : MapeoRegistroProxy<ProxyExpPagosMensEncab, ProxyExpPagosMensLinea, KeyEntidadMensuales>
        {
            public void LLenarLinea(Reg_encab transaccion, Reg_Det linea, Cliente cliente, Vehiculo vehiculo)
            {
                linea.SetEntidadAfectada1(cliente); 
                linea.FechaAlta = DateTime.Now;
                linea.SetValLista1(vehiculo); 
            }
            public void LLenarLinea(Reg_encab transaccion, Reg_Det linea, Cliente cliente, Proxy_LineaAsocCocheraMensual lineaAsocCochera)
            {
                linea.SetEntidadAfectada1(cliente);
                linea.FechaAlta = DateTime.Now;
                linea.SetValLista1(lineaAsocCochera.Cochera); 
                linea.SetValLista2(lineaAsocCochera.CptoIngresoMensual);
                linea.ValFecha1 = lineaAsocCochera.Desde.HasValue ? lineaAsocCochera.Desde : (DateTime?)null;
                linea.ValFecha2 = lineaAsocCochera.Hasta.HasValue ? lineaAsocCochera.Hasta :  (DateTime?)null;
            
                
            }

            internal override void LLenarRegistro(Reg_Det destino, ProxyExpPagosMensLinea origen, PersistidorPredet persistidor)
            {
            }

            internal override void LLenarProxy(ProxyExpPagosMensLinea destino, Reg_Det origen, PersistidorPredet persistidor)
            {
            }
            internal override void LLenarProxy(ProxyExpPagosMensEncab destino, Reg_encab origen, PersistidorPredet persistidor)
            {
                throw new NotImplementedException();
            }
            internal override void LLenarRegistro(Reg_encab destino, ProxyExpPagosMensEncab origen, PersistidorPredet persistidor)
            {
                throw new NotImplementedException();
            }
            internal void LLenarEncabezado(Reg_encab transaccion, Cliente cliente, Usuario usu, Empresa emp)
            {
                transaccion.SetEntidadAfectada(cliente);
                transaccion.SetUsuario(usu);
                transaccion.SetEntidadEmpresa(emp);
                transaccion.FechaAlta = DateTime.Now;
                transaccion.FechaModif = DateTime.Now;
                transaccion.FechaRegistro = DateTime.Now;

            }

            /// <summary>
            /// Se utiliza para el llenado de la transaccion en una modificación
            /// </summary>
            /// <param name="transaccion"></param>
            /// <param name="cliente"></param>
            internal void LLenarEncabezado(Reg_encab transaccion, Cliente cliente)
            {
                Cliente c = transaccion.EntidadAfectada as Cliente;
                c.CopiarDesde(cliente);
                transaccion.FechaModif = DateTime.Now;
               
            }

        }
    }

    internal class KeyEntidadMensuales: KeyEntidad<ProxyExpPagosMensEncab, ProxyExpPagosMensLinea>
    {
        public override string GetKeyLinea(ProxyExpPagosMensLinea prxLinea)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyLinea(Reg_Det linea)
        {
            throw new NotImplementedException();
        }
    }

}
