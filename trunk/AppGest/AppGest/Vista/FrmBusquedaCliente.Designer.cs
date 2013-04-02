using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmBusquedaCliente
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
            this.grbFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnAceptar = new AppGest.ControlBase.Button();
            this.btnLimpiar = new AppGest.ControlBase.Button();
            this.lblNombre = new AppGest.ControlBase.Label();
            this.btnBuscar = new AppGest.ControlBase.Button();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.grbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.btnAceptar);
            this.grbFiltros.Controls.Add(this.btnLimpiar);
            this.grbFiltros.Controls.Add(this.lblNombre);
            this.grbFiltros.Controls.Add(this.btnBuscar);
            this.grbFiltros.Controls.Add(this.txtNombre);
            this.grbFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grbFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grbFiltros.Location = new System.Drawing.Point(0, 0);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(478, 57);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(318, 31);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(72, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.toolTip1.SetToolTip(this.btnAceptar, "Presione Aceptar para seleccionar el cliente.");
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnLimpiar.CustomStyle = "F";
            this.btnLimpiar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnLimpiar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(398, 31);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(72, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Ninguno";
            this.toolTip1.SetToolTip(this.btnLimpiar, "Presione Ninguno para quitar la seleccion actual.");
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(9, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre o Apellido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnBuscar.CustomStyle = "F";
            this.btnBuscar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnBuscar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(238, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(9, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(223, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoAjustarAnchoColumnas = true;
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.EncabezadoFilaVisible = false;
            this.ucGrilla1.Location = new System.Drawing.Point(0, 57);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(478, 164);
            this.ucGrilla1.TabIndex = 1;
            this.ucGrilla1.Text = "ucGrillaEntidades";
            // 
            // FrmBusquedaCliente
            // 
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.ucGrilla1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(478, 221);
            this.Text = "FrmBusquedaCliente";
            this.grbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grbFiltros;
        private AppGest.ControlBase.Label lblNombre;
        private AppGest.ControlBase.Button btnBuscar;
        private AppGest.ControlBase.TextBox txtNombre;
        private Controles.UcGrilla ucGrilla1;
        private ControlBase.Button btnLimpiar;
        private ControlBase.Button btnAceptar;
        private ToolTip toolTip1;


    }
}