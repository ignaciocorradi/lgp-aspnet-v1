using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEdicionServicio
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
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.grpServicio = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblNombreServicio = new AppGest.ControlBase.Label();
            this.lblNombreConcepto = new AppGest.ControlBase.Label();
            this.lblFechaHasta = new AppGest.ControlBase.Label();
            this.lblFechaDesde = new AppGest.ControlBase.Label();
            this.lblPrecio = new AppGest.ControlBase.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.nudPrecio = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.btnAgregar = new Gizmox.WebGUI.Forms.Button();
            this.pnCabecera.SuspendLayout();
            this.grpServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Visible = false;
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoAjustarAnchoColumnas = true;
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.EncabezadoFilaVisible = true;
            this.ucGrilla1.Location = new System.Drawing.Point(5, 136);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(867, 343);
            this.ucGrilla1.TabIndex = 2;
            this.ucGrilla1.Text = "ucGrillaEntidades";
            // 
            // grpServicio
            // 
            this.grpServicio.Controls.Add(this.lblNombreServicio);
            this.grpServicio.Controls.Add(this.lblNombreConcepto);
            this.grpServicio.Controls.Add(this.lblFechaHasta);
            this.grpServicio.Controls.Add(this.lblFechaDesde);
            this.grpServicio.Controls.Add(this.lblPrecio);
            this.grpServicio.Controls.Add(this.dtpFechaHasta);
            this.grpServicio.Controls.Add(this.dtpFechaDesde);
            this.grpServicio.Controls.Add(this.nudPrecio);
            this.grpServicio.Controls.Add(this.btnAgregar);
            this.grpServicio.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpServicio.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpServicio.Location = new System.Drawing.Point(5, 33);
            this.grpServicio.Name = "grpServicio";
            this.grpServicio.Size = new System.Drawing.Size(867, 103);
            this.grpServicio.TabIndex = 1;
            this.grpServicio.TabStop = false;
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.AutoSize = true;
            this.lblNombreServicio.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNombreServicio.ForeColor = System.Drawing.Color.Gray;
            this.lblNombreServicio.Location = new System.Drawing.Point(14, 35);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(38, 15);
            this.lblNombreServicio.TabIndex = 14;
            this.lblNombreServicio.Text = "NOMBRE_DEL_SERVICIO";
            // 
            // lblNombreConcepto
            // 
            this.lblNombreConcepto.AutoSize = true;
            this.lblNombreConcepto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreConcepto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreConcepto.Location = new System.Drawing.Point(13, 15);
            this.lblNombreConcepto.Name = "lblNombreConcepto";
            this.lblNombreConcepto.Size = new System.Drawing.Size(38, 15);
            this.lblNombreConcepto.TabIndex = 13;
            this.lblNombreConcepto.Text = "Concepto";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaHasta.Location = new System.Drawing.Point(260, 55);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(35, 13);
            this.lblFechaHasta.TabIndex = 11;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaDesde.Location = new System.Drawing.Point(125, 55);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(35, 13);
            this.lblFechaDesde.TabIndex = 10;
            this.lblFechaDesde.Text = "Fecha Desde";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecio.Location = new System.Drawing.Point(14, 55);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(44, 13);
            this.lblPrecio.TabIndex = 0;
            this.lblPrecio.Text = "Precio";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaHasta.CustomFormat = "";
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(260, 73);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            this.dtpFechaHasta.Size = new System.Drawing.Size(115, 18);
            this.dtpFechaHasta.TabIndex = 9;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaDesde.CustomFormat = "";
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(125, 73);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            this.dtpFechaDesde.Size = new System.Drawing.Size(115, 18);
            this.dtpFechaDesde.TabIndex = 9;
            // 
            // nudPrecio
            // 
            this.nudPrecio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudPrecio.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrecio.CurrentValueChanged = false;
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(14, 73);
            this.nudPrecio.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(91, 22);
            this.nudPrecio.TabIndex = 8;
            this.nudPrecio.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregar.CustomStyle = "F";
            this.btnAgregar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(392, 61);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 34);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ucEdicionServicio
            // 
            this.Controls.Add(this.ucGrilla1);
            this.Controls.Add(this.grpServicio);
            this.DockPadding.All = 5;
            this.MensajeUsuario = "Desde aquí prodrá editar los datos de clientes existentes.";
            this.MostrarCabecera = false;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.Size = new System.Drawing.Size(877, 484);
            this.Text = "ucEdicionCliente";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.grpServicio, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpServicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrilla1;
        private GroupBox grpServicio;
        private Button btnAgregar;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private NumericUpDown nudPrecio;
        private AppGest.ControlBase.Label lblPrecio;
        private AppGest.ControlBase.Label lblFechaHasta;
        private AppGest.ControlBase.Label lblFechaDesde;
        private ControlBase.Label lblNombreServicio;
        private ControlBase.Label lblNombreConcepto;
  


    }
}