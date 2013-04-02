using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using AppGest.Vista.Controles;

namespace AppGest.Vista
{
    partial class FrmNuevoUsuario
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
            this.grpDatosUsuario = new Gizmox.WebGUI.Forms.GroupBox();
            this.UcUsuarioNuevo1 = new AppGest.Vista.Controles.UcUsuarioNuevo();
            this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.grpDatosUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.grpDatosUsuario.Controls.Add(this.UcUsuarioNuevo1);
            this.grpDatosUsuario.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpDatosUsuario.Location = new System.Drawing.Point(6, -13);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(612, 514);
            this.grpDatosUsuario.TabIndex = 0;
            this.grpDatosUsuario.TabStop = false;
            this.grpDatosUsuario.Text = "Ingrese los siguientes datos...";
            // 
            // UcUsuarioNuevo1
            // 
            this.UcUsuarioNuevo1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.UcUsuarioNuevo1.DockPadding.All = 3;
            this.UcUsuarioNuevo1.Location = new System.Drawing.Point(7, 16);
            this.UcUsuarioNuevo1.MensajeUsuario = null;
            this.UcUsuarioNuevo1.Name = "ucDatosUsuario1";
            this.UcUsuarioNuevo1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.UcUsuarioNuevo1.Size = new System.Drawing.Size(592, 480);
            this.UcUsuarioNuevo1.TabIndex = 0;
            this.UcUsuarioNuevo1.Text = "ucDatosUsuario";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(257, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // FrmNuevoUsuario
            // 
            this.Controls.Add(this.grpDatosUsuario);
            this.Size = new System.Drawing.Size(624, 509);
            this.Text = "FrmNuevoUsuario";
            this.grpDatosUsuario.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcUsuarioNuevo UcUsuarioNuevo1;
        private GroupBox grpDatosUsuario;
        private ComboBox comboBox1;


    }
}