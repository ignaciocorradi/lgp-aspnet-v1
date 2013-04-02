using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucListaServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucListaServicios));
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Location = new System.Drawing.Point(5, 5);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoAjustarAnchoColumnas = true;
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.EncabezadoFilaVisible = true;
            this.ucGrilla1.Location = new System.Drawing.Point(5, 147);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(867, 332);
            this.ucGrilla1.TabIndex = 2;
            this.ucGrilla1.Text = "ucGrillaEntidades";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Location = new System.Drawing.Point(5, 33);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(867, 76);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Concepto";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnBuscar.CustomStyle = "F";
            this.btnBuscar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBuscar.Image"));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(329, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(106, 34);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(32, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(283, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // ucListaServicios
            // 
            this.Controls.Add(this.ucGrilla1);
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 5;
            this.MensajeUsuario = "Desde aquí prodrá editar los datos de clientes existentes.";
            this.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.Size = new System.Drawing.Size(877, 484);
            this.Text = "ucEdicionCliente";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrilla1;
        private GroupBox grpFiltros;
        private Button btnBuscar;
        private AppGest.ControlBase.TextBox txtNombre;
        private ControlBase.Label label1;
        
  


    }
}