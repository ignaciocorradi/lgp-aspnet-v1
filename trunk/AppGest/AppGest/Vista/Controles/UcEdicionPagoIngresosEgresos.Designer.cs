using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcEdicionPagoIngresosEgresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcEdicionPagoIngresosEgresos));
            this.btnBuscar = new AppGest.ControlBase.Button();
            this.lblEgreso = new AppGest.ControlBase.Label();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblTotalSaldo = new AppGest.ControlBase.Label();
            this.lblTotSaldot = new AppGest.ControlBase.Label();
            this.lblTotAbonado = new AppGest.ControlBase.Label();
            this.lblTotImporte = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.label1 = new AppGest.ControlBase.Label();
            this.btnAsignFactura = new AppGest.ControlBase.Button();
            this.rbTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbSoloCancelado = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbVerImpagos = new Gizmox.WebGUI.Forms.RadioButton();
            this.cmbCliente = new AppGest.Vista.Controles.BusquedaClienteComboBox();
            this.lblCliente = new AppGest.ControlBase.Label();
            this.lblPagoEfectuado = new AppGest.ControlBase.Label();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblFechaHasta = new AppGest.ControlBase.Label();
            this.lblFechaDesde = new AppGest.ControlBase.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cmbEgreso = new Gizmox.WebGUI.Forms.ComboBox();
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(1182, 28);
            // 
            // tbtnGuardar
            // 
            this.tbtnGuardar.Visible = false;
            // 
            // tbtnCancelar
            // 
            this.tbtnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCancelar.Image"));
            this.tbtnCancelar.Text = "Cerrar";
            this.tbtnCancelar.ToolTipText = "Cerrar";
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.TabIndex = 1;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(1182, 38);
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
            this.btnBuscar.Location = new System.Drawing.Point(491, 82);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 34);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEgreso
            // 
            this.lblEgreso.AutoSize = true;
            this.lblEgreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEgreso.Location = new System.Drawing.Point(14, 33);
            this.lblEgreso.Name = "lblEgreso";
            this.lblEgreso.Size = new System.Drawing.Size(35, 13);
            this.lblEgreso.TabIndex = 0;
            this.lblEgreso.Text = "Seleccionar concepto:";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblTotalSaldo);
            this.grpFiltros.Controls.Add(this.lblTotSaldot);
            this.grpFiltros.Controls.Add(this.lblTotAbonado);
            this.grpFiltros.Controls.Add(this.lblTotImporte);
            this.grpFiltros.Controls.Add(this.label2);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Controls.Add(this.btnAsignFactura);
            this.grpFiltros.Controls.Add(this.rbTodos);
            this.grpFiltros.Controls.Add(this.rbSoloCancelado);
            this.grpFiltros.Controls.Add(this.rbVerImpagos);
            this.grpFiltros.Controls.Add(this.cmbCliente);
            this.grpFiltros.Controls.Add(this.lblCliente);
            this.grpFiltros.Controls.Add(this.lblPagoEfectuado);
            this.grpFiltros.Controls.Add(this.pictureBox1);
            this.grpFiltros.Controls.Add(this.lblFechaHasta);
            this.grpFiltros.Controls.Add(this.lblFechaDesde);
            this.grpFiltros.Controls.Add(this.dtpFechaHasta);
            this.grpFiltros.Controls.Add(this.dtpFechaDesde);
            this.grpFiltros.Controls.Add(this.cmbEgreso);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.lblEgreso);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(3, 31);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1182, 129);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Indique los filtros para buscar registros de pagos";
            // 
            // lblTotalSaldo
            // 
            this.lblTotalSaldo.AutoSize = true;
            this.lblTotalSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalSaldo.Location = new System.Drawing.Point(791, 67);
            this.lblTotalSaldo.Name = "lblTotalSaldo";
            this.lblTotalSaldo.Size = new System.Drawing.Size(38, 15);
            this.lblTotalSaldo.TabIndex = 20;
            this.lblTotalSaldo.Text = "$ 0";
            this.lblTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotSaldot
            // 
            this.lblTotSaldot.AutoSize = true;
            this.lblTotSaldot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotSaldot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotSaldot.Location = new System.Drawing.Point(721, 67);
            this.lblTotSaldot.Name = "lblTotSaldot";
            this.lblTotSaldot.Size = new System.Drawing.Size(38, 15);
            this.lblTotSaldot.TabIndex = 19;
            this.lblTotSaldot.Text = "Total Saldo:";
            // 
            // lblTotAbonado
            // 
            this.lblTotAbonado.AutoSize = true;
            this.lblTotAbonado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotAbonado.Location = new System.Drawing.Point(791, 43);
            this.lblTotAbonado.Name = "lblTotAbonado";
            this.lblTotAbonado.Size = new System.Drawing.Size(78, 15);
            this.lblTotAbonado.TabIndex = 18;
            this.lblTotAbonado.Text = "$ 0";
            this.lblTotAbonado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotImporte
            // 
            this.lblTotImporte.AutoSize = true;
            this.lblTotImporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotImporte.Location = new System.Drawing.Point(791, 19);
            this.lblTotImporte.Name = "lblTotImporte";
            this.lblTotImporte.Size = new System.Drawing.Size(78, 15);
            this.lblTotImporte.TabIndex = 17;
            this.lblTotImporte.Text = "$ 0";
            this.lblTotImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(701, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total Abonado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(708, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Total Importe:";
            // 
            // btnAsignFactura
            // 
            this.btnAsignFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAsignFactura.CustomStyle = "F";
            this.btnAsignFactura.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAsignFactura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAsignFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignFactura.Location = new System.Drawing.Point(833, 14);
            this.btnAsignFactura.Name = "btnAsignFactura";
            this.btnAsignFactura.Size = new System.Drawing.Size(96, 34);
            this.btnAsignFactura.TabIndex = 14;
            this.btnAsignFactura.Text = "Asig. Factura";
            this.toolTip1.SetToolTip(this.btnAsignFactura, "Asignar a factura");
            // 
            // rbTodos
            // 
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(367, 90);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(84, 17);
            this.rbTodos.TabIndex = 13;
            this.rbTodos.Text = "Ver todos";
            // 
            // rbSoloCancelado
            // 
            this.rbSoloCancelado.Location = new System.Drawing.Point(182, 90);
            this.rbSoloCancelado.Name = "rbSoloCancelado";
            this.rbSoloCancelado.Size = new System.Drawing.Size(141, 17);
            this.rbSoloCancelado.TabIndex = 12;
            this.rbSoloCancelado.Text = "Ver solo lo cancelado";
            // 
            // rbVerImpagos
            // 
            this.rbVerImpagos.Location = new System.Drawing.Point(17, 90);
            this.rbVerImpagos.Name = "rbVerImpagos";
            this.rbVerImpagos.Size = new System.Drawing.Size(136, 17);
            this.rbVerImpagos.TabIndex = 11;
            this.rbVerImpagos.Text = "Ver solo impagos";
            // 
            // cmbCliente
            // 
            this.cmbCliente.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbCliente.ClienteSeleccionado = null;
            this.cmbCliente.ExigeSeleccion = true;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(491, 53);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(206, 21);
            this.cmbCliente.TabIndex = 8;
            this.cmbCliente.Visible = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCliente.Location = new System.Drawing.Point(488, 33);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(35, 13);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Seleccionar Cliente";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCliente.Visible = false;
            // 
            // lblPagoEfectuado
            // 
            this.lblPagoEfectuado.AutoSize = true;
            this.lblPagoEfectuado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPagoEfectuado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPagoEfectuado.Location = new System.Drawing.Point(237, 18);
            this.lblPagoEfectuado.Name = "lblPagoEfectuado";
            this.lblPagoEfectuado.Size = new System.Drawing.Size(38, 15);
            this.lblPagoEfectuado.TabIndex = 2;
            this.lblPagoEfectuado.Text = "Pago efectuado entre:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(1116, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaHasta.Location = new System.Drawing.Point(362, 35);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(37, 15);
            this.lblFechaHasta.TabIndex = 5;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaDesde.Location = new System.Drawing.Point(237, 33);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(37, 15);
            this.lblFechaDesde.TabIndex = 3;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaHasta.CustomFormat = "";
            this.dtpFechaHasta.CustomStyle = "F";
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpFechaHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(367, 52);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            this.dtpFechaHasta.Size = new System.Drawing.Size(116, 17);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaDesde.CustomFormat = "F";
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpFechaDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(240, 52);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            this.dtpFechaDesde.Size = new System.Drawing.Size(112, 17);
            this.dtpFechaDesde.TabIndex = 4;
            // 
            // cmbEgreso
            // 
            this.cmbEgreso.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbEgreso.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEgreso.FormattingEnabled = true;
            this.cmbEgreso.Location = new System.Drawing.Point(17, 52);
            this.cmbEgreso.Name = "cmbEgreso";
            this.cmbEgreso.Size = new System.Drawing.Size(210, 21);
            this.cmbEgreso.TabIndex = 1;
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoAjustarAnchoColumnas = true;
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.EncabezadoFilaVisible = true;
            this.ucGrilla1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrilla1.Location = new System.Drawing.Point(3, 198);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(1182, 312);
            this.ucGrilla1.TabIndex = 1;
            this.ucGrilla1.Text = "ucGrillaEgresos";
            // 
            // UcEdicionPagoIngresosEgresos
            // 
            this.Controls.Add(this.ucGrilla1);
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(1188, 513);
            this.Text = "ucEdicionConceptos";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBase.Button btnBuscar;
        private AppGest.ControlBase.Label lblEgreso;
        private GroupBox grpFiltros;
        private UcGrilla ucGrilla1;
        private ComboBox cmbEgreso;
        private ControlBase.Label lblFechaHasta;
        private ControlBase.Label lblFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private PictureBox pictureBox1;
        private ControlBase.Label lblPagoEfectuado;
        private BusquedaClienteComboBox cmbCliente;
        private ControlBase.Label lblCliente;
        private RadioButton rbTodos;
        private RadioButton rbSoloCancelado;
        private RadioButton rbVerImpagos;
        private ControlBase.Label lblTotAbonado;
        private ControlBase.Label lblTotImporte;
        private ControlBase.Label label2;
        private ControlBase.Label label1;
        private ControlBase.Button btnAsignFactura;
        private ToolTip toolTip1;
        private ControlBase.Label lblTotalSaldo;
        private ControlBase.Label lblTotSaldot;


    }
}