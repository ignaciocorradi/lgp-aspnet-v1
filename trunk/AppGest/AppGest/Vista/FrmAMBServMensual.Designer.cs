using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmAMBServMensual
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
            this.ucABMServMens = new AppGest.Vista.Controles.UcABMServicioMensual();
            this.SuspendLayout();
            // 
            // ucABMServMens
            // 
            this.ucABMServMens.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucABMServMens.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucABMServMens.DockPadding.All = 3;
            this.ucABMServMens.Location = new System.Drawing.Point(0, 0);
            this.ucABMServMens.LstCocherasAsignadas = null;
            this.ucABMServMens.LstCocherasDisponibles = null;
            this.ucABMServMens.MensajeUsuario = null;
            this.ucABMServMens.Name = "ucABMServicioMensual1";
            this.ucABMServMens.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucABMServMens.Size = new System.Drawing.Size(415, 386);
            this.ucABMServMens.TabIndex = 0;
            this.ucABMServMens.Text = "UcABMServicioMensual";
            // 
            // FrmAMBServMensual
            // 
            this.Controls.Add(this.ucABMServMens);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(415, 386);
            this.Text = "FrmAMBServMensual";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.UcABMServicioMensual ucABMServMens;


    }
}