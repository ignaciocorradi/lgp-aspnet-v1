using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEmpleado));
            this.pnlContacto.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContacto
            // 
            this.pnlContacto.Location = new System.Drawing.Point(7, 164);
            // 
            // pnlNombre
            // 
            this.pnlNombre.Location = new System.Drawing.Point(7, 72);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(7, 315);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(7, 0);
            // 
            // imgImagen
            // 
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos del empleado";
            // 
            // pnlBase
            // 
            this.pnlBase.Size = new System.Drawing.Size(598, 475);
            // 
            // lblFechaA
            // 
            this.lblFechaA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaA.Text = "Fecha de ingreso";
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Enabled = true;
            this.dtpFechaA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaA.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaA.Size = new System.Drawing.Size(143, 17);
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(28, 407);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(28, 424);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(28, 384);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(28, 368);
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(598, 28);
            // 
            // ucEmpleado
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(604, 509);
            this.Text = "ucEmpleado";
            this.pnlContacto.ResumeLayout(false);
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