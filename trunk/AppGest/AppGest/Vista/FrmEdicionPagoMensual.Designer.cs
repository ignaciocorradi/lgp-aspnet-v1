using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionPagoMensual
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
            this.label1 = new AppGest.ControlBase.Label();
            this.ucDatosPagoMensual1 = new AppGest.Vista.Controles.UcDatosPagoMensual();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(246, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor ingrese los datos del cliente.";
            // 
            // ucDatosPagoMensual1
            // 
            this.ucDatosPagoMensual1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucDatosPagoMensual1.DockPadding.All = 3;
            this.ucDatosPagoMensual1.Location = new System.Drawing.Point(5, 5);
            this.ucDatosPagoMensual1.MensajeUsuario = "";
            this.ucDatosPagoMensual1.Name = "ucDatosPagoMensual1";
            this.ucDatosPagoMensual1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucDatosPagoMensual1.Size = new System.Drawing.Size(566, 536);
            this.ucDatosPagoMensual1.TabIndex = 0;
            this.ucDatosPagoMensual1.Text = "UcDatosPagoMensual";
            // 
            // FrmEdicionPagoMensual
            // 
            this.Controls.Add(this.ucDatosPagoMensual1);
            this.Text = "Edición de Pago Mensual";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.UcDatosPagoMensual ucDatosPagoMensual1;


    }
}