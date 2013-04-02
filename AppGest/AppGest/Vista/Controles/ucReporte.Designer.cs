using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReporte));
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(822, 28);
            // 
            // tbtnCancelar
            // 
            this.tbtnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCancelar.Image"));
            this.tbtnCancelar.Text = "Cerrar";
            this.tbtnCancelar.ToolTipText = "Cerrar la solapa actual";
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.htmlBox1.Expires = -1;
            this.htmlBox1.Html = "<HTML>No content.</HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(3, 31);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(822, 507);
            this.htmlBox1.TabIndex = 2;
            // 
            // ucReporte
            // 
            this.Controls.Add(this.htmlBox1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(828, 541);
            this.Text = "ucReporte";
            this.Controls.SetChildIndex(this.htmlBox1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlBox htmlBox1;

    }
}