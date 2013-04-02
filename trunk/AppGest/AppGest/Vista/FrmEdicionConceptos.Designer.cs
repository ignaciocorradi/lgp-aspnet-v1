using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionConceptos
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
            this.ucConceptos1 = new AppGest.Vista.Controles.ucConceptos();
            this.SuspendLayout();
            // 
            // ucConceptos1
            // 
            this.ucConceptos1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucConceptos1.DockPadding.All = 3;
            this.ucConceptos1.Location = new System.Drawing.Point(9, 9);
            this.ucConceptos1.MensajeUsuario = null;
            this.ucConceptos1.Name = "ucConceptos1";
            this.ucConceptos1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucConceptos1.Size = new System.Drawing.Size(594, 305);
            this.ucConceptos1.TabIndex = 0;
            this.ucConceptos1.Text = "usEdicion";
            // 
            // FrmEdicionConceptos
            // 
            this.Controls.Add(this.ucConceptos1);
            this.Size = new System.Drawing.Size(615, 328);
            this.Text = "FrmEdicionConceptos";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucConceptos ucConceptos1;



    }
}