using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionPagoEgresoEmpleado
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
            this.UcDatosPagoEgresoEmpleado1 = new AppGest.Vista.Controles.UcDatosPagoEgresoEmpleado();
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
            // UcDatosPagoEgresoEmpleado1
            // 
            this.UcDatosPagoEgresoEmpleado1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.UcDatosPagoEgresoEmpleado1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.UcDatosPagoEgresoEmpleado1.DockPadding.All = 3;
            this.UcDatosPagoEgresoEmpleado1.Location = new System.Drawing.Point(0, 0);
            this.UcDatosPagoEgresoEmpleado1.MensajeUsuario = "";
            this.UcDatosPagoEgresoEmpleado1.Name = "ucDatosPagoEgresoEmpleado1";
            this.UcDatosPagoEgresoEmpleado1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.UcDatosPagoEgresoEmpleado1.Size = new System.Drawing.Size(524, 376);
            this.UcDatosPagoEgresoEmpleado1.TabIndex = 0;
            this.UcDatosPagoEgresoEmpleado1.Text = "UcDatosPagoEgresoEmpleado";
            // 
            // FrmEdicionPagoEgresoEmpleado
            // 
            this.Controls.Add(this.UcDatosPagoEgresoEmpleado1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(524, 376);
            this.Text = "Edición de Pago Mensual";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.UcDatosPagoEgresoEmpleado UcDatosPagoEgresoEmpleado1;


    }
}