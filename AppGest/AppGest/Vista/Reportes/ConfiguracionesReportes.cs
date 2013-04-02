using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo.Reportes;
using AppGest.Negocio.Modelo.Reportes.Configuracion;

namespace AppGest.Vista.Reportes
{
    public static class ConfiguracionesReportes
    {
        private static Hashtable _configuracionesReportes = new Hashtable();
        private static Hashtable _parametrosGlobalesReportes = new Hashtable();

        /// <summary>
        /// Devuelve la Configuracion del Reporte cuya clave se pasa como parámetro
        /// </summary>
        /// <param name="rptKey">Clave única que identifica al reporte</param>
        /// <returns>RptItemSettings solicitada si la clave existe, sino null</returns>
        public static RptItemSettings ObtenerConfiguracionReporte(Guid idSesion, string rptKey)
        {
            return _configuracionesReportes.ContainsKey(rptKey) ? (RptItemSettings)_configuracionesReportes[rptKey] : ConfiguracionesReportes.CargarConfiguracionReporte(idSesion, rptKey);
        }

        /// <summary>
        /// Devuelve la Configuracion del Reporte cuya clave se pasa como parámetro 
        /// </summary>
        /// <param name="idSesion">IdSesion del usuario</param>
        /// <param name="rptKey">Clave única que identifica al reporte</param>
        /// <returns>RptItemSettings solicitada si la clave existe, sino null</returns>
        public static RptItemSettings CargarConfiguracionReporte(Guid idSesion, string rptKey)
        {
            RptItemSettings itemRpt = null;

            if (_configuracionesReportes.ContainsKey(rptKey))
            {
                return (RptItemSettings)_configuracionesReportes[rptKey];
            }
            else
            {
                using (var experto = FabExpertos.Inst.Obtener<ExpReportes>(idSesion))
                {
                    itemRpt = experto.ItemReporte(rptKey);
                    itemRpt.UrlServidor = experto.UrlServidorReportes();

                    _configuracionesReportes.Add(rptKey, itemRpt);
                }
            }

            return itemRpt;
        }

        /// <summary>
        /// Devuelve el Parámetro Global de Roporte cuya clave se pasa como parámetro
        /// </summary>
        /// <param name="key">Clave única que identifica al parámetro de reportes</param>
        /// <returns>cadena con el valor del parámetro si la clave existe, sino null</returns>
        public static string ObtenerParametroGlobalReporte(Guid idSesion, string key)
        {
            string globalKey = idSesion.ToString() + "_" + key;
            return _parametrosGlobalesReportes.ContainsKey(globalKey) ? (string)_parametrosGlobalesReportes[globalKey] : null;
        }

        /// <summary>
        /// Carga el valor del Parámetro Global de Roporte con la clave que se pasa como parámetro
        /// </summary>
        /// <param name="idSesion">IdSesion del usuario</param>
        /// <param name="key">Clave única que identifica al parámetro de reportes</param>
        /// <param name="valor">valor del parámetro de reportes</param>
        public static void CargarParametroGlobalReporte(Guid idSesion, string key, string valor)
        {
            string globalKey = idSesion.ToString() + "_" + key;
            if(_parametrosGlobalesReportes.ContainsKey(globalKey))
            {
                _parametrosGlobalesReportes.Remove(globalKey);
            }
            _parametrosGlobalesReportes.Add(globalKey, valor);
        }

        public static string ObtenerURLServer(Guid idSesion)
        {
            using (var experto = FabExpertos.Inst.Obtener<ExpReportes>(idSesion))
            {
                   return experto.UrlServidorReportes();
            }

        }
    }
}