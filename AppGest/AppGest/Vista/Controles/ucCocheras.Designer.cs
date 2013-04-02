using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucCocheras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCocheras));
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNombre
            // 
            this.pnlNombre.Location = new System.Drawing.Point(5, 72);
            this.pnlNombre.Size = new System.Drawing.Size(520, 47);
            this.pnlNombre.TabIndex = 4;
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(5, 199);
            this.pnlFechas.Size = new System.Drawing.Size(520, 46);
            this.pnlFechas.TabIndex = 6;
            this.pnlFechas.Visible = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(5, 0);
            this.pnlCabecera.Size = new System.Drawing.Size(512, 72);
            this.pnlCabecera.TabIndex = 5;
            // 
            // imgImagen
            // 
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            this.imgImagen.Location = new System.Drawing.Point(429, 4);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos de la cochera";
            // 
            // pnlBase
            // 
            this.pnlBase.Size = new System.Drawing.Size(530, 254);
            // 
            // lblNombre
            // 
            this.lblNombre.EsObligatorio = false;
            this.lblNombre.Location = new System.Drawing.Point(8, 6);
            this.lblNombre.Text = "Identificacion de cochera";
            // 
            // lblFechaA
            // 
            this.lblFechaA.Location = new System.Drawing.Point(13, 5);
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Location = new System.Drawing.Point(13, 21);
            // 
            // lblFechaB
            // 
            this.lblFechaB.Location = new System.Drawing.Point(164, 5);
            // 
            // txtFechaB
            // 
            this.txtFechaB.Location = new System.Drawing.Point(162, 21);
            // 
            // lblAlias
            // 
            this.lblAlias.Location = new System.Drawing.Point(246, 7);
            this.lblAlias.Visible = false;
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(16, 162);
            this.lblObs.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(16, 123);
            this.lblDescripcion.TabIndex = 0;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(246, 22);
            this.txtAbreviatura.Size = new System.Drawing.Size(250, 20);
            this.txtAbreviatura.Visible = false;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(16, 176);
            this.txtObservacion.Size = new System.Drawing.Size(485, 20);
            this.txtObservacion.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(16, 139);
            this.txtDesc.Size = new System.Drawing.Size(485, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(11, 22);
            this.txtNombre.ReadOnly = true;
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(530, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // ucCocheras
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(536, 288);
            this.Text = "ucCocheras";
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


    }
}