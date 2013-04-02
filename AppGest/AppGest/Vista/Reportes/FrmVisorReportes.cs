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

#endregion

namespace AppGest.Vista.Reportes
{
    public partial class FrmVisorReportes : FrmBase
    {
        private string _rptKey = string.Empty;
        public FrmVisorReportes()
        {
            InitializeComponent();
        }

   

        private void FrmVisorReportes_Load(object sender, EventArgs e)
        {
            
            _rptKey = this.Context.Arguments["rptKey"];
            this.Text = (this.Context.Arguments["Titulo"] == null || this.Context.Arguments["Titulo"].Length ==0)   ? "Informes" : this.Context.Arguments["Titulo"];
            this.Context.Arguments.Remove("rptKey");
            this.Context.Arguments.Remove("Titulo");

            htmlBox1.Url= Helper.AspNetBaseUrl(this.Context.HttpContext) + "vista/reportes/FrmReporteAsp.aspx?rptKey=" + _rptKey;
           
        }

    }
}