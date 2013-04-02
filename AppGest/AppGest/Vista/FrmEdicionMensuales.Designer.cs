using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionMensuales
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
            this.ucMensuales1 = new AppGest.Vista.Controles.ucMensuales();
            this.SuspendLayout();
            // 
            // ucMensuales1
            // 
            this.ucMensuales1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucMensuales1.DockPadding.All = 3;
            this.ucMensuales1.Location = new System.Drawing.Point(6, 4);
            this.ucMensuales1.MensajeUsuario = "";
            this.ucMensuales1.MostrarCabecera = false;
            this.ucMensuales1.Name = "ucMensuales1";
            this.ucMensuales1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucMensuales1.Size = new System.Drawing.Size(1005, 503);
            this.ucMensuales1.TabIndex = 0;
            this.ucMensuales1.Text = "ucMensuales";
            // 
            // FrmEdicionMensuales
            // 
            this.Controls.Add(this.ucMensuales1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(1020, 517);
            this.Text = "FrmEdicionMensuales";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucMensuales ucMensuales1;




    }
}