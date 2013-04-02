using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmDetallePagoIngresosEgresos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDetallePagoEgresosVarios1 = new AppGest.Vista.Controles.UcDetallePagoIngresosEgresos();
            this.SuspendLayout();
            // 
            // ucDetallePagoEgresosVarios1
            // 
            this.ucDetallePagoEgresosVarios1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucDetallePagoEgresosVarios1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucDetallePagoEgresosVarios1.DockPadding.All = 3;
            this.ucDetallePagoEgresosVarios1.Location = new System.Drawing.Point(9, 24);
            this.ucDetallePagoEgresosVarios1.MensajeUsuario = "";
            this.ucDetallePagoEgresosVarios1.Name = "ucDetallePagoEgresosVarios1";
            this.ucDetallePagoEgresosVarios1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucDetallePagoEgresosVarios1.Size = new System.Drawing.Size(390, 372);
            this.ucDetallePagoEgresosVarios1.TabIndex = 0;
            this.ucDetallePagoEgresosVarios1.Text = "UcDetallePagoEgresosVarios";
            // 
            // FrmDetallePagoEgresosVarios
            // 
            this.Controls.Add(this.ucDetallePagoEgresosVarios1);
            this.Size = new System.Drawing.Size(411, 421);
            this.Text = "FrmDetallePagoEgresosVarios";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.UcDetallePagoIngresosEgresos ucDetallePagoEgresosVarios1;


    }
}