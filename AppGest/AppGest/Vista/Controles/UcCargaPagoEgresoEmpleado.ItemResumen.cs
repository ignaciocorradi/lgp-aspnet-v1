#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo;
using System.Collections;
using System.Linq;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{

    public class ItemResumen
    {
        public DateTime Periodo { get; set;}
        public decimal Sueldo { get; set;}
        public decimal Abonado { get; set;}
        public decimal Saldo { get; set;}


        public static void Calcular(List<ItemResumen> resumen, ProxyExpPagoEgresoEmpleadoEncab transaccion, ExpParamsEgresoEmpleado expParamPagos)
        {
            // parámetros de sueldo del empleado ...
            var contratado = expParamPagos.ObtenerEgresosXEmpleado(transaccion.Empleado.Id);
            if (contratado == null)
                return;

            // sueldos pactados...
            var sueldoContr = contratado.Lineas.OrderByDescending(linea => linea.Desde);

            // pagos realizados al empleado ....
            var pagos = transaccion.Lineas.Where(linea => linea.FechaBaja == null).GroupBy(linea => linea.Periodo.Inferior(DateInterval.Month))
                                    .OrderByDescending(ord => ord.Key)
                                    .Select(grupo => new { Periodo = grupo.Key, Abonado = grupo.Sum(l => l.Importe) });

            foreach (var item in resumen)
            {
                var periodo = item.Periodo; // periodo a calcular...

                // Obtengo el sueldo contratado para el empleado, en el periodo de la iteración...
                var sld = sueldoContr.FirstOrDefault(s => (s.Desde.IsMinValue() || s.Desde.Inferior(DateInterval.Month) <= periodo) && (s.Hasta.IsMinValue() || s.Hasta.Inferior(DateInterval.Month) >= periodo));
                
                // si hay sueldo contratado, habrá una línea de resumen.
                if (sld != null)
                {
                    // Busco el pago realizado
                    var pago = pagos.FirstOrDefault(p => p.Periodo.Inferior(DateInterval.Month) == periodo.Inferior(DateInterval.Month));
                    var abonado = pago != null ? pago.Abonado : 0M;

                    item.Sueldo = sld.Importe;
                    item.Abonado = abonado;
                    item.Saldo = sld.Importe - abonado;
                }

            }

        }

        public static IList<ItemResumen> Calcular(ProxyExpPagoEgresoEmpleadoEncab transaccion, ExpParamsEgresoEmpleado expParamPagos, int cantPeriodosPagos)
        {
            var resumen = CrearPeriodosResumen(transaccion);
            Calcular(resumen, transaccion, expParamPagos);

            var resuldato = FiltrarPeriodos(resumen, cantPeriodosPagos);
            return resuldato;
        }

        static List<ItemResumen> CrearPeriodosResumen(ProxyExpPagoEgresoEmpleadoEncab transaccion)
        {
            var resumen = new List<ItemResumen>();


            // periodos de sueldo del empleado, a la fecha....
            var minPeriodo = transaccion.Empleado.Alta.Inferior(DateInterval.Month);
            var maxPeriodo = DateTime.Now.Date.Inferior(DateInterval.Month);


            // para cada periodo, ordenados descendentemente ....
            for (var periodo = maxPeriodo; periodo >= minPeriodo; periodo = periodo.AddMonths(-1))
            {
                var item = new ItemResumen();
                item.Periodo = periodo;

                resumen.Add(item);
            }

            return resumen;
        }

        private static List<ItemResumen> FiltrarPeriodos(List<ItemResumen> resumen, int cantPeriodosPagos)
        {
            var resuldato = new List<ItemResumen>();
            int completos = 0;  // periodos pagados comletamente

            foreach (var item in resumen)
            {
                if (item.Saldo != 0 || (++completos) <= cantPeriodosPagos)
                    resuldato.Add(item);
            }
            return resuldato;
        }
    }
}