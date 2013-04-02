using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucVehiculoAbrev
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
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNombre
            // 
            this.pnlNombre.Location = new System.Drawing.Point(3, 41);
            this.pnlNombre.Size = new System.Drawing.Size(549, 89);
            this.pnlNombre.TabIndex = 0;
            this.pnlNombre.Controls.SetChildIndex(this.lblAlias, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre, 0);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Enabled = false;
            this.pnlFechas.Location = new System.Drawing.Point(3, 311);
            this.pnlFechas.Size = new System.Drawing.Size(549, 53);
            this.pnlFechas.TabIndex = 6;
            this.pnlFechas.Visible = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(3, 3);
            this.pnlCabecera.Size = new System.Drawing.Size(549, 38);
            this.pnlCabecera.TabIndex = 3;
            // 
            // imgImagen
            // 
            this.imgImagen.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.imgImagen.Location = new System.Drawing.Point(21, 4);
            this.imgImagen.Size = new System.Drawing.Size(31, 31);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTitulo.Location = new System.Drawing.Point(52, 8);
            // 
            // pnlBase
            // 
            this.pnlBase.AutoScroll = false;
            this.pnlBase.Size = new System.Drawing.Size(554, 135);
            this.pnlBase.TabIndex = 0;
            this.pnlBase.Click += new System.EventHandler(this.pnlBase_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.TabIndex = 1;
            // 
            // txtFechaA
            // 
            this.dtpFechaA.TabIndex = 2;
            // 
            // lblFechaB
            // 
            this.lblFechaB.TabIndex = 1;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(506, 26);
            this.txtAbreviatura.Size = new System.Drawing.Size(20, 20);
            this.txtAbreviatura.TabIndex = 3;
            // 
            // lblAlias
            // 
            this.lblAlias.Location = new System.Drawing.Point(448, 7);
            this.lblAlias.TabIndex = 2;
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(10, 135);
            this.lblObs.TabIndex = 1;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(10, 149);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Size = new System.Drawing.Size(496, 47);
            this.txtObservacion.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(13, 236);
            this.txtDesc.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Enabled = false;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 220);
            this.lblDescripcion.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.TabIndex = 0;
            // 
            // tbMenu
            // 
            this.tbMenu.Enabled = false;
            this.tbMenu.Location = new System.Drawing.Point(3, 364);
            this.tbMenu.Size = new System.Drawing.Size(554, 28);
            this.tbMenu.TabIndex = 1;
            this.tbMenu.Visible = false;
            // 
            // ucVehiculoAbrev
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(560, 169);
            this.Text = "ucAutosAbrev";
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


    }
}