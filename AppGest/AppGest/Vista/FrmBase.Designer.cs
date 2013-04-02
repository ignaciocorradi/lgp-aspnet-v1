using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.SuspendLayout();
            // 
            // FrmBase
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.Icon"));
            this.Size = new System.Drawing.Size(805, 492);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBase";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion


    }
}