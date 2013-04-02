using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmCochera
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
            this.ucCochera = new AppGest.Vista.Controles.ucCocheras();
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
            // ucCochera
            // 
            this.ucCochera.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucCochera.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucCochera.DockPadding.All = 3;
            this.ucCochera.Location = new System.Drawing.Point(7, 9);
            this.ucCochera.MensajeUsuario = null;
            this.ucCochera.MostrarBarra = false;
            this.ucCochera.MostrarCabecera = false;
            this.ucCochera.Name = "ucCliente";
            this.ucCochera.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucCochera.Size = new System.Drawing.Size(558, 279);
            this.ucCochera.TabIndex = 0;
            this.ucCochera.Text = "ucCliente";
            // 
            // FrmCochera
            // 
            this.Controls.Add(this.ucCochera);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(572, 317);
            this.Text = "Alta de cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.ucCocheras ucCochera;


    }
}