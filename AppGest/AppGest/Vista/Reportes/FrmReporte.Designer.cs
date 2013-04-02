using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Reportes
{
    partial class FrmReporte
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
            this.aspPage = new Gizmox.WebGUI.Forms.Hosts.AspPageBox();
            this.SuspendLayout();
            // 
            // aspPage
            // 
            this.aspPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.aspPage.Location = new System.Drawing.Point(0, 0);
            this.aspPage.Name = "aspPage";
            this.aspPage.Path = "~/Vista/Reportes/FrmReporteAsp.aspx";
            this.aspPage.Size = new System.Drawing.Size(419, 466);
            this.aspPage.TabIndex = 0;
            // 
            // FrmReporte
            // 
            this.Controls.Add(this.aspPage);
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "FrmReporte";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Hosts.AspPageBox aspPage;



    }
}