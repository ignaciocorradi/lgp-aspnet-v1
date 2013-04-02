using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcDetallePagoIngresosEgresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDetallePagoIngresosEgresos));
            this.lblFechaPago = new AppGest.ControlBase.Label();
            this.lblSeleccionarEgreso = new AppGest.ControlBase.Label();
            this.lblIndicarImporte = new AppGest.ControlBase.Label();
            this.lblFechaVencimiento = new AppGest.ControlBase.Label();
            this.lblComentario = new AppGest.ControlBase.Label();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaVencimiento = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cmbEgresos = new Gizmox.WebGUI.Forms.ComboBox();
            this.nudImporte = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.txtComentario = new AppGest.ControlBase.TextBox();
            this.btnAceptar = new AppGest.ControlBase.Button();
            this.cmbCliente = new AppGest.Vista.Controles.BusquedaClienteComboBox();
            this.lblCliente = new AppGest.ControlBase.Label();
            this.nudAbonado = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label1 = new AppGest.ControlBase.Label();
            this.lblFechaServ = new AppGest.ControlBase.Label();
            this.dtpFechaServicio = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.pnCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbonado)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(355, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(355, 68);
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.EsObligatorio = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaPago.Location = new System.Drawing.Point(30, 117);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(35, 13);
            this.lblFechaPago.TabIndex = 4;
            this.lblFechaPago.Text = "Fecha de pago *";
            this.lblFechaPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSeleccionarEgreso
            // 
            this.lblSeleccionarEgreso.AutoSize = true;
            this.lblSeleccionarEgreso.EsObligatorio = true;
            this.lblSeleccionarEgreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeleccionarEgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSeleccionarEgreso.Location = new System.Drawing.Point(9, 143);
            this.lblSeleccionarEgreso.Name = "lblSeleccionarEgreso";
            this.lblSeleccionarEgreso.Size = new System.Drawing.Size(35, 13);
            this.lblSeleccionarEgreso.TabIndex = 6;
            this.lblSeleccionarEgreso.Text = "Seleccionar Egreso *";
            this.lblSeleccionarEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIndicarImporte
            // 
            this.lblIndicarImporte.AutoSize = true;
            this.lblIndicarImporte.EsObligatorio = true;
            this.lblIndicarImporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIndicarImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIndicarImporte.Location = new System.Drawing.Point(72, 195);
            this.lblIndicarImporte.Name = "lblIndicarImporte";
            this.lblIndicarImporte.Size = new System.Drawing.Size(35, 13);
            this.lblIndicarImporte.TabIndex = 10;
            this.lblIndicarImporte.Text = "Precio *";
            this.lblIndicarImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaVencimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaVencimiento.Location = new System.Drawing.Point(42, 247);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(35, 13);
            this.lblFechaVencimiento.TabIndex = 14;
            this.lblFechaVencimiento.Text = "Fecha de Vto";
            this.lblFechaVencimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComentario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblComentario.Location = new System.Drawing.Point(9, 273);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(81, 32);
            this.lblComentario.TabIndex = 16;
            this.lblComentario.Text = "Comentario / Observación";
            this.lblComentario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "";
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(130, 113);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.ShowCheckBox = true;
            this.dtpFechaPago.Size = new System.Drawing.Size(206, 21);
            this.dtpFechaPago.TabIndex = 5;
            this.dtpFechaPago.ValueChanged += new System.EventHandler(this.dtpFechaPago_ValueChanged);
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaVencimiento.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaVencimiento.Checked = false;
            this.dtpFechaVencimiento.CustomFormat = "";
            this.dtpFechaVencimiento.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(130, 250);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.ShowCheckBox = true;
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(206, 21);
            this.dtpFechaVencimiento.TabIndex = 15;
            // 
            // cmbEgresos
            // 
            this.cmbEgresos.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbEgresos.FormattingEnabled = true;
            this.cmbEgresos.Location = new System.Drawing.Point(130, 140);
            this.cmbEgresos.Name = "cmbEgresos";
            this.cmbEgresos.Size = new System.Drawing.Size(206, 21);
            this.cmbEgresos.TabIndex = 7;
            // 
            // nudImporte
            // 
            this.nudImporte.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudImporte.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.nudImporte.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudImporte.CurrentValueChanged = false;
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporte.Location = new System.Drawing.Point(130, 194);
            this.nudImporte.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            131072});
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(206, 22);
            this.nudImporte.TabIndex = 11;
            this.nudImporte.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            // 
            // txtComentario
            // 
            this.txtComentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(130, 277);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.SelectTextOnGotFocus = true;
            this.txtComentario.Size = new System.Drawing.Size(206, 40);
            this.txtComentario.TabIndex = 17;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(120, 343);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 29);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbCliente.ClienteSeleccionado = null;
            this.cmbCliente.ExigeSeleccion = true;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(130, 167);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(206, 21);
            this.cmbCliente.TabIndex = 9;
            this.cmbCliente.Visible = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.EsObligatorio = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCliente.Location = new System.Drawing.Point(7, 169);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(35, 13);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "Seleccionar Cliente *";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCliente.Visible = false;
            // 
            // nudAbonado
            // 
            this.nudAbonado.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudAbonado.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.nudAbonado.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAbonado.CurrentValueChanged = false;
            this.nudAbonado.DecimalPlaces = 2;
            this.nudAbonado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.nudAbonado.Location = new System.Drawing.Point(130, 222);
            this.nudAbonado.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            131072});
            this.nudAbonado.Name = "nudAbonado";
            this.nudAbonado.Size = new System.Drawing.Size(206, 22);
            this.nudAbonado.TabIndex = 13;
            this.nudAbonado.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.EsObligatorio = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(59, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Abonado *";
            // 
            // lblFechaServ
            // 
            this.lblFechaServ.AutoSize = true;
            this.lblFechaServ.EsObligatorio = true;
            this.lblFechaServ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaServ.Location = new System.Drawing.Point(30, 88);
            this.lblFechaServ.Name = "lblFechaServ";
            this.lblFechaServ.Size = new System.Drawing.Size(38, 15);
            this.lblFechaServ.TabIndex = 2;
            this.lblFechaServ.Text = "Fecha Servicio *";
            // 
            // dtpFechaServicio
            // 
            this.dtpFechaServicio.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaServicio.CustomFormat = "";
            this.dtpFechaServicio.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaServicio.Location = new System.Drawing.Point(130, 86);
            this.dtpFechaServicio.Name = "dtpFechaServicio";
            this.dtpFechaServicio.Size = new System.Drawing.Size(206, 21);
            this.dtpFechaServicio.TabIndex = 3;
            // 
            // UcDetallePagoIngresosEgresos
            // 
            this.Controls.Add(this.dtpFechaServicio);
            this.Controls.Add(this.lblFechaServ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAbonado);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.nudImporte);
            this.Controls.Add(this.cmbEgresos);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.lblIndicarImporte);
            this.Controls.Add(this.lblSeleccionarEgreso);
            this.Controls.Add(this.lblFechaPago);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(361, 395);
            this.Text = "UcDetallePagoEgresosVarios";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.lblFechaPago, 0);
            this.Controls.SetChildIndex(this.lblSeleccionarEgreso, 0);
            this.Controls.SetChildIndex(this.lblIndicarImporte, 0);
            this.Controls.SetChildIndex(this.lblFechaVencimiento, 0);
            this.Controls.SetChildIndex(this.lblComentario, 0);
            this.Controls.SetChildIndex(this.dtpFechaPago, 0);
            this.Controls.SetChildIndex(this.dtpFechaVencimiento, 0);
            this.Controls.SetChildIndex(this.cmbEgresos, 0);
            this.Controls.SetChildIndex(this.nudImporte, 0);
            this.Controls.SetChildIndex(this.txtComentario, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.cmbCliente, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.nudAbonado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblFechaServ, 0);
            this.Controls.SetChildIndex(this.dtpFechaServicio, 0);
            this.pnCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbonado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBase.Label lblFechaPago;
        private ControlBase.Label lblSeleccionarEgreso;
        private ControlBase.Label lblIndicarImporte;
        private ControlBase.Label lblFechaVencimiento;
        private ControlBase.Label lblComentario;
        private DateTimePicker dtpFechaPago;
        private DateTimePicker dtpFechaVencimiento;
        private ComboBox cmbEgresos;
        private NumericUpDown nudImporte;
        private AppGest.ControlBase.TextBox txtComentario;
        private ControlBase.Button btnAceptar;
        private BusquedaClienteComboBox cmbCliente;
        private ControlBase.Label lblCliente;
        private NumericUpDown nudAbonado;
        private ControlBase.Label label1;
        private ControlBase.Label lblFechaServ;
        private DateTimePicker dtpFechaServicio;


    }
}