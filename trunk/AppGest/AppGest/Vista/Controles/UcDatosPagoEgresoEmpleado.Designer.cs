using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcDatosPagoEgresoEmpleado
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
            this.pnlDatosPago = new Gizmox.WebGUI.Forms.Panel();
            this.lblEmpleado = new AppGest.ControlBase.Label();
            this.lblFechaPago = new AppGest.ControlBase.Label();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboMomento = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblComent = new AppGest.ControlBase.Label();
            this.lblConcepto = new AppGest.ControlBase.Label();
            this.lblImporte = new AppGest.ControlBase.Label();
            this.lblMotivo = new AppGest.ControlBase.Label();
            this.lblPeriodo = new AppGest.ControlBase.Label();
            this.txtComentario = new AppGest.ControlBase.TextBox();
            this.txtConcepto = new AppGest.ControlBase.TextBox();
            this.nudMonto = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.dtpPeriodo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.pnlDatosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(585, 28);
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.TabIndex = 1;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(585, 68);
            this.pnCabecera.Visible = false;
            // 
            // pnlDatosPago
            // 
            this.pnlDatosPago.Controls.Add(this.lblEmpleado);
            this.pnlDatosPago.Controls.Add(this.lblFechaPago);
            this.pnlDatosPago.Controls.Add(this.dtpFechaPago);
            this.pnlDatosPago.Controls.Add(this.cboMomento);
            this.pnlDatosPago.Controls.Add(this.lblComent);
            this.pnlDatosPago.Controls.Add(this.lblConcepto);
            this.pnlDatosPago.Controls.Add(this.lblImporte);
            this.pnlDatosPago.Controls.Add(this.lblMotivo);
            this.pnlDatosPago.Controls.Add(this.lblPeriodo);
            this.pnlDatosPago.Controls.Add(this.txtComentario);
            this.pnlDatosPago.Controls.Add(this.txtConcepto);
            this.pnlDatosPago.Controls.Add(this.nudMonto);
            this.pnlDatosPago.Controls.Add(this.dtpPeriodo);
            this.pnlDatosPago.Controls.Add(this.lblTitulo);
            this.pnlDatosPago.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDatosPago.Location = new System.Drawing.Point(3, 72);
            this.pnlDatosPago.Name = "pnlDatosPago";
            this.pnlDatosPago.Size = new System.Drawing.Size(585, 301);
            this.pnlDatosPago.TabIndex = 0;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmpleado.Location = new System.Drawing.Point(63, 53);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(38, 15);
            this.lblEmpleado.TabIndex = 13;
            this.lblEmpleado.Text = "Empleado: {0} - DNI: {1} - Alta: {2}";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.EsObligatorio = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaPago.Location = new System.Drawing.Point(63, 91);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(38, 15);
            this.lblFechaPago.TabIndex = 1;
            this.lblFechaPago.Text = "Fecha de pago *";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.dtpFechaPago.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaPago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "";
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(66, 108);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(180, 22);
            this.dtpFechaPago.TabIndex = 2;
            // 
            // cboMomento
            // 
            this.cboMomento.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cboMomento.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cboMomento.FormattingEnabled = true;
            this.cboMomento.Location = new System.Drawing.Point(66, 154);
            this.cboMomento.Name = "cboMomento";
            this.cboMomento.Size = new System.Drawing.Size(180, 21);
            this.cboMomento.TabIndex = 6;
            // 
            // lblComent
            // 
            this.lblComent.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblComent.AutoSize = true;
            this.lblComent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblComent.Location = new System.Drawing.Point(63, 225);
            this.lblComent.Name = "lblComent";
            this.lblComent.Size = new System.Drawing.Size(73, 15);
            this.lblComent.TabIndex = 11;
            this.lblComent.Text = "Comentario";
            // 
            // lblConcepto
            // 
            this.lblConcepto.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConcepto.Location = new System.Drawing.Point(63, 184);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(73, 15);
            this.lblConcepto.TabIndex = 9;
            this.lblConcepto.Text = "Concepto";
            // 
            // lblImporte
            // 
            this.lblImporte.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblImporte.AutoSize = true;
            this.lblImporte.EsObligatorio = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImporte.Location = new System.Drawing.Point(263, 91);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(73, 15);
            this.lblImporte.TabIndex = 3;
            this.lblImporte.Text = "Importe a pagar *";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.EsObligatorio = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMotivo.Location = new System.Drawing.Point(63, 138);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(73, 15);
            this.lblMotivo.TabIndex = 5;
            this.lblMotivo.Text = "Motivo de pago *";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.EsObligatorio = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPeriodo.Location = new System.Drawing.Point(263, 138);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(73, 15);
            this.lblPeriodo.TabIndex = 7;
            this.lblPeriodo.Text = "Periodo *";
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtComentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(66, 243);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.SelectTextOnGotFocus = true;
            this.txtComentario.Size = new System.Drawing.Size(430, 39);
            this.txtComentario.TabIndex = 12;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtConcepto.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtConcepto.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.Location = new System.Drawing.Point(66, 202);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ReadOnly = true;
            this.txtConcepto.SelectTextOnGotFocus = true;
            this.txtConcepto.Size = new System.Drawing.Size(430, 20);
            this.txtConcepto.TabIndex = 10;
            // 
            // nudMonto
            // 
            this.nudMonto.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.nudMonto.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudMonto.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.nudMonto.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudMonto.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMonto.CurrentValueChanged = false;
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMonto.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMonto.Location = new System.Drawing.Point(266, 108);
            this.nudMonto.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(156, 22);
            this.nudMonto.TabIndex = 4;
            this.nudMonto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.dtpPeriodo.BackColor = System.Drawing.Color.LightGray;
            this.dtpPeriodo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpPeriodo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpPeriodo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPeriodo.CustomFormat = "MMM - yyyy";
            this.dtpPeriodo.Enabled = false;
            this.dtpPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(266, 155);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(156, 22);
            this.dtpPeriodo.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CustomStyle = "LabelSkin";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(61, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos del Pago";
            // 
            // UcDatosPagoEgresoEmpleado
            // 
            this.Controls.Add(this.pnlDatosPago);
            this.DockPadding.All = 3;
            this.MostrarCabecera = false;
            this.Size = new System.Drawing.Size(591, 376);
            this.Text = "UcDatosPagoEgresoEmpleado";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.pnlDatosPago, 0);
            this.pnCabecera.ResumeLayout(false);
            this.pnlDatosPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlDatosPago;
        protected AppGest.ControlBase.Label lblTitulo;
        private DateTimePicker dtpPeriodo;
        private NumericUpDown nudMonto;
        protected internal ControlBase.Label lblConcepto;
        protected internal ControlBase.Label lblImporte;
        protected internal ControlBase.Label lblMotivo;
        protected internal ControlBase.Label lblPeriodo;
        protected internal ControlBase.Label lblComent;
        private ComboBox cboMomento;
        private ControlBase.Label lblFechaPago;
        private DateTimePicker dtpFechaPago;
        private ControlBase.Label lblEmpleado;
        protected ControlBase.TextBox txtConcepto;
        protected ControlBase.TextBox txtComentario;




    }
}