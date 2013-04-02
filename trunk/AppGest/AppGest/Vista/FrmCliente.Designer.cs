using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmCliente
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
            this.ucCliente = new AppGest.Vista.Controles.ucCliente();
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
            // ucCliente
            // 
            this.ucCliente.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucCliente.DockPadding.All = 3;
            this.ucCliente.Location = new System.Drawing.Point(-4, 5);
            this.ucCliente.MensajeUsuario = null;
            this.ucCliente.MostrarBarra = false;
            this.ucCliente.MostrarCabecera = false;
            this.ucCliente.Name = "ucCliente";
            this.ucCliente.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucCliente.Size = new System.Drawing.Size(602, 530);
            this.ucCliente.TabIndex = 0;
            this.ucCliente.Text = "ucCliente";
            // 
            // FrmCliente
            // 
            this.Controls.Add(this.ucCliente);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(604, 536);
            this.Text = "Alta de cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.ucCliente ucCliente;


    }
}