using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEdicionServicio
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
            this.ucEdicionServicio = new AppGest.Vista.Controles.ucEdicionServicio();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(246, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor ingrese los datos del cliente.";
            // 
            // ucEdicionServicio
            // 
            this.ucEdicionServicio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucEdicionServicio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucEdicionServicio.DockPadding.All = 3;
            this.ucEdicionServicio.Location = new System.Drawing.Point(9, 19);
            this.ucEdicionServicio.MensajeUsuario = null;
            this.ucEdicionServicio.Name = "ucEdicionServicio";
            this.ucEdicionServicio.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucEdicionServicio.Size = new System.Drawing.Size(602, 429);
            this.ucEdicionServicio.TabIndex = 0;
            this.ucEdicionServicio.Text = "ucEdicionServicio";
            // 
            // FrmEdicionServicio
            // 
            this.Controls.Add(this.ucEdicionServicio);
            this.Size = new System.Drawing.Size(630, 490);
            this.Text = "Alta de cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label label1;
        private Controles.ucEdicionServicio ucEdicionServicio;


    }
}