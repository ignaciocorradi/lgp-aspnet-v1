using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcDatosParamEgresoXEmpleado
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
            this.label10 = new AppGest.ControlBase.Label();
            this.label9 = new AppGest.ControlBase.Label();
            this.label8 = new AppGest.ControlBase.Label();
            this.label3 = new AppGest.ControlBase.Label();
            this.label7 = new AppGest.ControlBase.Label();
            this.txtComentario = new AppGest.ControlBase.TextBox();
            this.txtConcepto = new AppGest.ControlBase.TextBox();
            this.nudMonto = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.dtpHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.pnlDatosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(560, 28);
            this.tbMenu.TabIndex = 2;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(560, 69);
            this.pnCabecera.Visible = false;
            // 
            // pnlDatosPago
            // 
            this.pnlDatosPago.Controls.Add(this.lblEmpleado);
            this.pnlDatosPago.Controls.Add(this.label10);
            this.pnlDatosPago.Controls.Add(this.label9);
            this.pnlDatosPago.Controls.Add(this.label8);
            this.pnlDatosPago.Controls.Add(this.label3);
            this.pnlDatosPago.Controls.Add(this.label7);
            this.pnlDatosPago.Controls.Add(this.txtComentario);
            this.pnlDatosPago.Controls.Add(this.txtConcepto);
            this.pnlDatosPago.Controls.Add(this.nudMonto);
            this.pnlDatosPago.Controls.Add(this.dtpHasta);
            this.pnlDatosPago.Controls.Add(this.dtpDesde);
            this.pnlDatosPago.Controls.Add(this.lblTitulo);
            this.pnlDatosPago.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlDatosPago.Location = new System.Drawing.Point(3, 71);
            this.pnlDatosPago.Name = "pnlDatosPago";
            this.pnlDatosPago.Size = new System.Drawing.Size(560, 289);
            this.pnlDatosPago.TabIndex = 0;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmpleado.Location = new System.Drawing.Point(52, 56);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(38, 15);
            this.lblEmpleado.TabIndex = 13;
            this.lblEmpleado.Text = "Empleado: {0} - DNI: {1} - Alta: {2}";
            // 
            // label10
            // 
            this.label10.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(51, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Comentario";
            // 
            // label9
            // 
            this.label9.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(51, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Concepto";
            // 
            // label8
            // 
            this.label8.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.EsObligatorio = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(51, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sueldo *";
            // 
            // label3
            // 
            this.label3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(233, 87);
            this.label3.Name = "label7";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.EsObligatorio = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(51, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Desde *";
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtComentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(54, 239);
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
            this.txtConcepto.Location = new System.Drawing.Point(54, 198);
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
            this.nudMonto.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudMonto.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMonto.CurrentValueChanged = false;
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMonto.Location = new System.Drawing.Point(54, 147);
            this.nudMonto.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(156, 22);
            this.nudMonto.TabIndex = 6;
            this.nudMonto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.dtpHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpHasta.Checked = false;
            this.dtpHasta.CustomFormat = "";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(236, 104);
            this.dtpHasta.Name = "dtpFechaPago";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(168, 22);
            this.dtpHasta.TabIndex = 4;
            this.toolTip1.SetToolTip(this.dtpHasta, "Fecha fin del periodo\r\nPuede esta vácia, quite el tilde y no ingrese fecha.");
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.dtpDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(54, 104);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(168, 22);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CustomStyle = "LabelSkin";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(51, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos del salario";
            // 
            // UcDatosParamEgresoXEmpleado
            // 
            this.Controls.Add(this.pnlDatosPago);
            this.DockPadding.All = 3;
            this.MostrarCabecera = false;
            this.Size = new System.Drawing.Size(566, 364);
            this.Text = "UcDatosParamEgresoXEmpleado";
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
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private NumericUpDown nudMonto;
        protected internal ControlBase.Label label9;
        protected internal ControlBase.Label label8;
        protected internal ControlBase.Label label3;
        protected internal ControlBase.Label label7;
        protected internal ControlBase.Label label10;
        private ControlBase.Label lblEmpleado;
        private ToolTip toolTip1;
        protected ControlBase.TextBox txtConcepto;
        protected ControlBase.TextBox txtComentario;




    }
}