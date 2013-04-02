using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVehiculo));
            this.lnlModelo = new AppGest.ControlBase.Label();
            this.lblMarca = new AppGest.ControlBase.Label();
            this.txtModelo = new AppGest.ControlBase.TextBox();
            this.txtMarca = new AppGest.ControlBase.TextBox();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNombre
            // 
            this.pnlNombre.Controls.Add(this.lnlModelo);
            this.pnlNombre.Controls.Add(this.txtModelo);
            this.pnlNombre.Controls.Add(this.lblMarca);
            this.pnlNombre.Controls.Add(this.txtMarca);
            this.pnlNombre.Size = new System.Drawing.Size(512, 92);
            this.pnlNombre.TabIndex = 0;
            this.pnlNombre.Controls.SetChildIndex(this.txtMarca, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblMarca, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtModelo, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lnlModelo, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblAlias, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre, 0);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(6, 245);
            this.pnlFechas.Size = new System.Drawing.Size(512, 47);
            this.pnlFechas.TabIndex = 5;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Size = new System.Drawing.Size(512, 72);
            this.pnlCabecera.TabIndex = 6;
            // 
            // imgImagen
            // 
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            this.imgImagen.Location = new System.Drawing.Point(429, 2);
            this.imgImagen.Size = new System.Drawing.Size(66, 68);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos del vehículo";
            // 
            // pnlBase
            // 
            this.pnlBase.Size = new System.Drawing.Size(525, 300);
            this.pnlBase.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.lblNombre.Location = new System.Drawing.Point(7, 7);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Dominio";
            // 
            // lblFechaA
            // 
            this.lblFechaA.Location = new System.Drawing.Point(8, 5);
            // 
            // txtFechaA
            // 
            this.dtpFechaA.Location = new System.Drawing.Point(8, 21);
            // 
            // lblFechaB
            // 
            this.lblFechaB.Location = new System.Drawing.Point(159, 5);
            // 
            // txtFechaB
            // 
            this.txtFechaB.Location = new System.Drawing.Point(157, 21);
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.txtAbreviatura.Location = new System.Drawing.Point(236, 65);
            this.txtAbreviatura.Size = new System.Drawing.Size(264, 20);
            this.txtAbreviatura.Visible = false;
            // 
            // lblAlias
            // 
            this.lblAlias.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.lblAlias.Location = new System.Drawing.Point(233, 49);
            this.lblAlias.Text = "Observaciones";
            this.lblAlias.Visible = false;
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(10, 208);
            this.lblObs.TabIndex = 3;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(10, 222);
            this.txtObservacion.Size = new System.Drawing.Size(496, 20);
            this.txtObservacion.TabIndex = 4;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(10, 185);
            this.txtDesc.Size = new System.Drawing.Size(496, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(10, 169);
            this.lblDescripcion.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.txtNombre.Location = new System.Drawing.Point(7, 26);
            this.txtNombre.TabIndex = 0;
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(525, 28);
            this.tbMenu.TabIndex = 1;
            // 
            // lnlModelo
            // 
            this.lnlModelo.AutoSize = true;
            this.lnlModelo.Location = new System.Drawing.Point(7, 49);
            this.lnlModelo.Name = "lnlModelo";
            this.lnlModelo.Size = new System.Drawing.Size(41, 13);
            this.lnlModelo.TabIndex = 4;
            this.lnlModelo.Text = "Modelo";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(233, 10);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(36, 13);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "Marca";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(7, 65);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(223, 20);
            this.txtModelo.TabIndex = 5;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(236, 26);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(264, 20);
            this.txtMarca.TabIndex = 2;
            // 
            // ucVehiculo
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(531, 334);
            this.Text = "ucAutos";
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label lnlModelo;
        private AppGest.ControlBase.TextBox txtModelo;
        private AppGest.ControlBase.Label lblMarca;
        private AppGest.ControlBase.TextBox txtMarca;


    }
}