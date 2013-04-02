using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmEmpleado
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucEmpleado1 = new AppGest.Vista.Controles.ucEmpleado();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucEmpleado1
            // 
            this.ucEmpleado1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucEmpleado1.DockPadding.All = 3;
            this.ucEmpleado1.Location = new System.Drawing.Point(10, 17);
            this.ucEmpleado1.MensajeUsuario = null;
            this.ucEmpleado1.Name = "ucEmpleado1";
            this.ucEmpleado1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucEmpleado1.Size = new System.Drawing.Size(613, 402);
            this.ucEmpleado1.TabIndex = 0;
            this.ucEmpleado1.Text = "ucEmpleado";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.ucEmpleado1);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 422);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // FrmEmpleado
            // 
            this.Controls.Add(this.groupBox1);
            this.Size = new System.Drawing.Size(651, 439);
            this.Text = "FrmEmpleado";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucEmpleado ucEmpleado1;
        private GroupBox groupBox1;


    }
}