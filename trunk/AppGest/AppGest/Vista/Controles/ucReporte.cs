#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Util.Atributos;
using AppGest.Vista.Reportes;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo.Reportes;
using Gizmox.WebGUI.Forms.Hosts;

#endregion

namespace AppGest.Vista.Controles
{
    [Administrador]
    [Supervisor]
    [Operador]
    public partial class ucReporte : UcToolbar
    {
        private string _rptKey = string.Empty;
        public ucReporte()
        {
            InitializeComponent();
        }
        public ucReporte(string rptKey):this()
        {
            this.tbtnGuardar.Visible = false;
            _rptKey = rptKey;
        }

        protected override void OnLoad(EventArgs e)
        {
            htmlBox1.Url = Helper.AspNetBaseUrl(this.Context.HttpContext) + "vista/reportes/FrmReporteAsp.aspx?rptKey=" + _rptKey;
        }
    }
}