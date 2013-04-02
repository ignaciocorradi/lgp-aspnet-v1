using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcDatosPagoMensual
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
            this.ucCliente = new AppGest.Vista.Controles.ucClienteAbrev();
            this.pnlDatosPago = new Gizmox.WebGUI.Forms.Panel();
            this.label8 = new AppGest.ControlBase.Label();
            this.label7 = new AppGest.ControlBase.Label();
            this.nudPrecio = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label6 = new AppGest.ControlBase.Label();
            this.txtComentario = new AppGest.ControlBase.TextBox();
            this.txtServicio = new AppGest.ControlBase.TextBox();
            this.label5 = new AppGest.ControlBase.Label();
            this.nudBonificacion = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.nudRecargo = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.nudImporte = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label4 = new AppGest.ControlBase.Label();
            this.label3 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpPeriodoImpago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label1 = new AppGest.ControlBase.Label();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.label9 = new AppGest.ControlBase.Label();
            this.nudSaldo = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.pnCabecera.SuspendLayout();
            this.pnlDatosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(527, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Visible = false;
            // 
            // ucCliente
            // 
            this.ucCliente.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucCliente.DockPadding.All = 3;
            this.ucCliente.KeySolapa = null;
            this.ucCliente.Location = new System.Drawing.Point(11, 288);
            this.ucCliente.MensajeUsuario = "";
            this.ucCliente.MostrarBarra = false;
            this.ucCliente.MostrarCabecera = false;
            this.ucCliente.Name = "ucCliente";
            this.ucCliente.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucCliente.Size = new System.Drawing.Size(510, 212);
            this.ucCliente.TabIndex = 3;
            this.ucCliente.Text = "ucClienteAbrev";
            this.ucCliente.VerdatoVehiculo = false;
            // 
            // pnlDatosPago
            // 
            this.pnlDatosPago.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlDatosPago.Controls.Add(this.nudSaldo);
            this.pnlDatosPago.Controls.Add(this.label9);
            this.pnlDatosPago.Controls.Add(this.label8);
            this.pnlDatosPago.Controls.Add(this.label7);
            this.pnlDatosPago.Controls.Add(this.nudPrecio);
            this.pnlDatosPago.Controls.Add(this.label6);
            this.pnlDatosPago.Controls.Add(this.txtComentario);
            this.pnlDatosPago.Controls.Add(this.txtServicio);
            this.pnlDatosPago.Controls.Add(this.label5);
            this.pnlDatosPago.Controls.Add(this.nudBonificacion);
            this.pnlDatosPago.Controls.Add(this.nudRecargo);
            this.pnlDatosPago.Controls.Add(this.nudImporte);
            this.pnlDatosPago.Controls.Add(this.label4);
            this.pnlDatosPago.Controls.Add(this.label3);
            this.pnlDatosPago.Controls.Add(this.label2);
            this.pnlDatosPago.Controls.Add(this.dtpFechaPago);
            this.pnlDatosPago.Controls.Add(this.dtpPeriodoImpago);
            this.pnlDatosPago.Controls.Add(this.label1);
            this.pnlDatosPago.Controls.Add(this.lblTitulo);
            this.pnlDatosPago.Location = new System.Drawing.Point(11, 31);
            this.pnlDatosPago.Name = "pnlDatosPago";
            this.pnlDatosPago.Size = new System.Drawing.Size(510, 255);
            this.pnlDatosPago.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(25, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Recargo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(295, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Precio Servicio";
            // 
            // nudPrecio
            // 
            this.nudPrecio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudPrecio.BackColor = System.Drawing.Color.LightGray;
            this.nudPrecio.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.LightGray);
            this.nudPrecio.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.nudPrecio.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrecio.CurrentValueChanged = false;
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Location = new System.Drawing.Point(298, 172);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.ReadOnly = true;
            this.nudPrecio.Size = new System.Drawing.Size(155, 20);
            this.nudPrecio.TabIndex = 14;
            this.nudPrecio.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudPrecio, "Precio del servicio");
            this.nudPrecio.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.CustomStyle = "LabelSkin";
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(28, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtComentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(28, 213);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.SelectTextOnGotFocus = true;
            this.txtComentario.Size = new System.Drawing.Size(425, 39);
            this.txtComentario.TabIndex = 16;
            // 
            // txtServicio
            // 
            this.txtServicio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtServicio.BackColor = System.Drawing.Color.LightGray;
            this.txtServicio.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtServicio.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtServicio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicio.Location = new System.Drawing.Point(28, 172);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.ReadOnly = true;
            this.txtServicio.SelectTextOnGotFocus = true;
            this.txtServicio.Size = new System.Drawing.Size(228, 20);
            this.txtServicio.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtServicio, "Servicio contratado por el cliente");
            // 
            // label5
            // 
            this.label5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.CustomStyle = "LabelSkin";
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(28, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Servicio";
            // 
            // nudBonificacion
            // 
            this.nudBonificacion.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudBonificacion.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudBonificacion.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBonificacion.CurrentValueChanged = false;
            this.nudBonificacion.DecimalPlaces = 2;
            this.nudBonificacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBonificacion.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBonificacion.Location = new System.Drawing.Point(298, 125);
            this.nudBonificacion.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudBonificacion.Name = "nudBonificacion";
            this.nudBonificacion.Size = new System.Drawing.Size(155, 22);
            this.nudBonificacion.TabIndex = 10;
            this.nudBonificacion.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudBonificacion, "Bonificación al cliente");
            this.nudBonificacion.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // nudRecargo
            // 
            this.nudRecargo.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudRecargo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudRecargo.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRecargo.CurrentValueChanged = false;
            this.nudRecargo.DecimalPlaces = 2;
            this.nudRecargo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRecargo.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRecargo.Location = new System.Drawing.Point(28, 125);
            this.nudRecargo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudRecargo.Name = "nudRecargo";
            this.nudRecargo.Size = new System.Drawing.Size(125, 22);
            this.nudRecargo.TabIndex = 8;
            this.nudRecargo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudRecargo, "Recargo cobrado al cliente");
            this.nudRecargo.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // nudImporte
            // 
            this.nudImporte.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudImporte.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudImporte.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImporte.CurrentValueChanged = false;
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporte.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudImporte.Location = new System.Drawing.Point(298, 78);
            this.nudImporte.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(155, 22);
            this.nudImporte.TabIndex = 6;
            this.nudImporte.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudImporte, "Importe abonado por el cliente");
            this.nudImporte.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            this.nudImporte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.CustomStyle = "LabelSkin";
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(295, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Abonado";
            // 
            // label3
            // 
            this.label3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.CustomStyle = "LabelSkin";
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(295, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bonificación";
            // 
            // label2
            // 
            this.label2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.CustomStyle = "LabelSkin";
            this.label2.EsObligatorio = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(159, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de Pago *";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPago.Location = new System.Drawing.Point(162, 78);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(125, 22);
            this.dtpFechaPago.TabIndex = 4;
            this.toolTip1.SetToolTip(this.dtpFechaPago, "Fecha de pago");
            // 
            // dtpPeriodoImpago
            // 
            this.dtpPeriodoImpago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpPeriodoImpago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPeriodoImpago.CustomFormat = "MM-yyyy";
            this.dtpPeriodoImpago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodoImpago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoImpago.Location = new System.Drawing.Point(28, 78);
            this.dtpPeriodoImpago.Name = "dtpPeriodoImpago";
            this.dtpPeriodoImpago.Size = new System.Drawing.Size(125, 22);
            this.dtpPeriodoImpago.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dtpPeriodoImpago, "Periodo de pago");
            // 
            // label1
            // 
            this.label1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.CustomStyle = "LabelSkin";
            this.label1.EsObligatorio = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(28, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periodo Pago *";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CustomStyle = "LabelSkin";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(26, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos del Pago";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(159, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Saldo";
            // 
            // nudSaldo
            // 
            this.nudSaldo.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudSaldo.BackColor = System.Drawing.Color.LightGray;
            this.nudSaldo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.LightGray);
            this.nudSaldo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudSaldo.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSaldo.CurrentValueChanged = false;
            this.nudSaldo.DecimalPlaces = 2;
            this.nudSaldo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSaldo.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSaldo.Location = new System.Drawing.Point(162, 125);
            this.nudSaldo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudSaldo.Name = "nudSaldo";
            this.nudSaldo.ReadOnly = true;
            this.nudSaldo.Size = new System.Drawing.Size(125, 22);
            this.nudSaldo.TabIndex = 8;
            this.nudSaldo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudSaldo, "Recargo cobrado al cliente");
            this.nudSaldo.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // UcDatosPagoMensual
            // 
            this.Controls.Add(this.pnlDatosPago);
            this.Controls.Add(this.ucCliente);
            this.DockPadding.All = 3;
            this.MostrarCabecera = false;
            this.Size = new System.Drawing.Size(533, 513);
            this.Text = "UcDatosPagoMensual";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.ucCliente, 0);
            this.Controls.SetChildIndex(this.pnlDatosPago, 0);
            this.pnCabecera.ResumeLayout(false);
            this.pnlDatosPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucClienteAbrev ucCliente;
        private Panel pnlDatosPago;
        private AppGest.ControlBase.Label label1;
        protected AppGest.ControlBase.Label lblTitulo;
        private DateTimePicker dtpPeriodoImpago;
        private AppGest.ControlBase.Label label2;
        private DateTimePicker dtpFechaPago;
        private NumericUpDown nudBonificacion;
        private NumericUpDown nudRecargo;
        private NumericUpDown nudImporte;
        private AppGest.ControlBase.Label label4;
        private AppGest.ControlBase.Label label3;
        private AppGest.ControlBase.Label label5;
        private AppGest.ControlBase.Label label6;
        private ControlBase.Label label7;
        private NumericUpDown nudPrecio;
        private ControlBase.Label label8;
        private ToolTip toolTip1;
        protected ControlBase.TextBox txtServicio;
        protected ControlBase.TextBox txtComentario;
        private NumericUpDown nudSaldo;
        private ControlBase.Label label9;




    }
}