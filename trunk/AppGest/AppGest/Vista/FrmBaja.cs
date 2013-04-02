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

namespace AppGest.Vista
{
    public partial class FrmBaja : FrmBase
    {
        public FrmBaja():base()
        {
            InitializeComponent();
            this.Size = new Size(338, 222);
        }
        public FrmBaja(DateTime fechabaja, bool mostrarFecha, string titulo, string mensaje, object proxy)
            : this()
        {
            this.dtpFechaBaja.Value = fechabaja;
            this.dtpFechaBaja.Visible = mostrarFecha;
            this.lblFecha.Visible = mostrarFecha;
            this.lblTitulo.Text = titulo;
            this.lblMensaje.Text = mensaje;
            this.Tag = proxy;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.FechaAccion = dtpFechaBaja.Value;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.FechaAccion = null;
            this.Close();
        }

        public DateTime? FechaAccion { get; private set; }
    }
}