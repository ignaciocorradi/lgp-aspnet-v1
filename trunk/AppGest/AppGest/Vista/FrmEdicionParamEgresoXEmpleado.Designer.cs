using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionParamEgresoXEmpleado
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
            this.UcDatosParamEgresoXEmpleado1 = new AppGest.Vista.Controles.UcDatosParamEgresoXEmpleado();
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
            // UcDatosParamEgresoXEmpleado1
            // 
            this.UcDatosParamEgresoXEmpleado1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.UcDatosParamEgresoXEmpleado1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.UcDatosParamEgresoXEmpleado1.DockPadding.All = 3;
            this.UcDatosParamEgresoXEmpleado1.Location = new System.Drawing.Point(0, 0);
            this.UcDatosParamEgresoXEmpleado1.MensajeUsuario = "";
            this.UcDatosParamEgresoXEmpleado1.Name = "ucDatosParamEgresoXEmpleado1";
            this.UcDatosParamEgresoXEmpleado1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.UcDatosParamEgresoXEmpleado1.Size = new System.Drawing.Size(536, 374);
            this.UcDatosParamEgresoXEmpleado1.TabIndex = 0;
            this.UcDatosParamEgresoXEmpleado1.Text = "UcDatosParamEgresoXEmpleado";
            // 
            // FrmEdicionParamEgresoXEmpleado
            // 
            this.Controls.Add(this.UcDatosParamEgresoXEmpleado1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(536, 374);
            this.Text = "Edición de Pago Mensual";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.UcDatosParamEgresoXEmpleado UcDatosParamEgresoXEmpleado1;


    }
}