#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.Negocio.Modelo.Reportes;
using AppGest.Negocio.Core;

#endregion

namespace AppGest.Vista.Reportes
{
    public partial class FrmReporte2  : FrmBase
    {
        public FrmReporte2()
        {
            InitializeComponent();
            aspPage.BringToFront();
        }

        public static void Ejecutar(FrmBase desde, Guid idSesion, string rptNombre)
        {
            string urlServidor = null;
            RptItemSettings itemRpt = null;

            using (var experto = FabExpertos.Inst.Obtener<ExpReportes>(idSesion))
            {
                urlServidor = experto.UrlServidorReportes();
                itemRpt = experto.ItemReporte(rptNombre);

                ParamSesion.Set<string>(desde.Context, ParamSesion.RPT_SERV, urlServidor);
                ParamSesion.Set<string>(desde.Context, ParamSesion.RPT_RUTA, itemRpt.Reporte);
                ParamSesion.Set<string>(desde.Context, ParamSesion.RPT_NOMBRE, itemRpt.Nombre);
            }


            //FrmReporte f = new FrmReporte();
            //f.ShowDialog();

            desde.Context.Redirect("FrmReporte.wgx");
        }
   }
}