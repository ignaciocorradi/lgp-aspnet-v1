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
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.Negocio.Modelo.Reportes;

#endregion

namespace AppGest.Vista.Reportes
{
    public partial class FrmReporte : FrmBase
    {
        private string _rptKey = string.Empty;
        public FrmReporte()
        {
            InitializeComponent();
            aspPage.BringToFront();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            StringBuilder objStringBuilder = new StringBuilder();

            foreach (string objArgument in this.Context.Arguments)
            {
                _rptKey = this.Context.Arguments["rptKey"];
                objStringBuilder.Append(objArgument);

            }
            aspPage.Path = Helper.AspNetBaseUrl(this.Context.HttpContext) + "vista/reportes/FrmReporteAsp.aspx?rptKey=" + _rptKey;
            //this.Tag = objStringBuilder.ToString();
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


            FrmReporte f = new FrmReporte();
            f.ShowDialog();
        }    
    }
}