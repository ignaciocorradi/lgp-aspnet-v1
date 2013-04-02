using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmSelectRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectRegistro));
            this.rbTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbSoloCancelado = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbVerImpagos = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblCliente = new AppGest.ControlBase.Label();
            this.lblFechaHasta = new AppGest.ControlBase.Label();
            this.lblFechaDesde = new AppGest.ControlBase.Label();
            this.dtpPagoHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpPagoDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cmbEgreso = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnBuscar = new AppGest.ControlBase.Button();
            this.lblEgreso = new AppGest.ControlBase.Label();
            this.label1 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.dtpVtoDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpVtoHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new AppGest.ControlBase.Label();
            this.dtpRegHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpRegDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.ucGrillaRdo = new AppGest.Vista.Controles.UcGrilla();
            this.btnSeleccionar = new AppGest.ControlBase.Button();
            this.btnCancelar = new AppGest.ControlBase.Button();
            this.lblResultado = new AppGest.ControlBase.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.SuspendLayout();
            // 
            // rbTodos
            // 
            this.rbTodos.Location = new System.Drawing.Point(244, 95);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(84, 17);
            this.rbTodos.TabIndex = 4;
            this.rbTodos.Text = "Ver todos";
            // 
            // rbSoloCancelado
            // 
            this.rbSoloCancelado.Location = new System.Drawing.Point(244, 120);
            this.rbSoloCancelado.Name = "rbSoloCancelado";
            this.rbSoloCancelado.Size = new System.Drawing.Size(141, 17);
            this.rbSoloCancelado.TabIndex = 5;
            this.rbSoloCancelado.Text = "Ver solo lo cancelado";
            // 
            // rbVerImpagos
            // 
            this.rbVerImpagos.Checked = true;
            this.rbVerImpagos.Location = new System.Drawing.Point(244, 70);
            this.rbVerImpagos.Name = "rbVerImpagos";
            this.rbVerImpagos.Size = new System.Drawing.Size(136, 17);
            this.rbVerImpagos.TabIndex = 3;
            this.rbVerImpagos.Text = "Ver solo impagos";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCliente.Location = new System.Drawing.Point(9, 21);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(35, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Seleccionar registros de ingeso de {0}";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaHasta.Location = new System.Drawing.Point(416, 113);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(37, 15);
            this.lblFechaHasta.TabIndex = 9;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaDesde.Location = new System.Drawing.Point(414, 83);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(37, 15);
            this.lblFechaDesde.TabIndex = 7;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // dtpPagoHasta
            // 
            this.dtpPagoHasta.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpPagoHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpPagoHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPagoHasta.Checked = false;
            this.dtpPagoHasta.CustomFormat = "";
            this.dtpPagoHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpPagoHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpPagoHasta.Location = new System.Drawing.Point(460, 109);
            this.dtpPagoHasta.Name = "dtpPagoHasta";
            this.dtpPagoHasta.ShowCheckBox = true;
            this.dtpPagoHasta.Size = new System.Drawing.Size(112, 22);
            this.dtpPagoHasta.TabIndex = 10;
            // 
            // dtpPagoDesde
            // 
            this.dtpPagoDesde.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpPagoDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpPagoDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPagoDesde.Checked = false;
            this.dtpPagoDesde.CustomFormat = "";
            this.dtpPagoDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpPagoDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpPagoDesde.Location = new System.Drawing.Point(460, 79);
            this.dtpPagoDesde.Name = "dtpPagoDesde";
            this.dtpPagoDesde.ShowCheckBox = true;
            this.dtpPagoDesde.Size = new System.Drawing.Size(112, 17);
            this.dtpPagoDesde.TabIndex = 8;
            // 
            // cmbEgreso
            // 
            this.cmbEgreso.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbEgreso.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEgreso.FormattingEnabled = true;
            this.cmbEgreso.Location = new System.Drawing.Point(16, 90);
            this.cmbEgreso.Name = "cmbEgreso";
            this.cmbEgreso.Size = new System.Drawing.Size(210, 21);
            this.cmbEgreso.TabIndex = 2;
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
            this.btnBuscar.Location = new System.Drawing.Point(16, 152);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 34);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEgreso
            // 
            this.lblEgreso.AutoSize = true;
            this.lblEgreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEgreso.Location = new System.Drawing.Point(13, 71);
            this.lblEgreso.Name = "lblEgreso";
            this.lblEgreso.Size = new System.Drawing.Size(35, 13);
            this.lblEgreso.TabIndex = 1;
            this.lblEgreso.Text = "Seleccionar concepto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(475, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(614, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha Vto.";
            // 
            // dtpVtoDesde
            // 
            this.dtpVtoDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpVtoDesde.Checked = false;
            this.dtpVtoDesde.CustomFormat = "";
            this.dtpVtoDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpVtoDesde.Location = new System.Drawing.Point(594, 80);
            this.dtpVtoDesde.Name = "dtpVtoDesde";
            this.dtpVtoDesde.ShowCheckBox = true;
            this.dtpVtoDesde.Size = new System.Drawing.Size(122, 21);
            this.dtpVtoDesde.TabIndex = 12;
            // 
            // dtpVtoHasta
            // 
            this.dtpVtoHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpVtoHasta.Checked = false;
            this.dtpVtoHasta.CustomFormat = "";
            this.dtpVtoHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpVtoHasta.Location = new System.Drawing.Point(594, 110);
            this.dtpVtoHasta.Name = "dtpVtoHasta";
            this.dtpVtoHasta.ShowCheckBox = true;
            this.dtpVtoHasta.Size = new System.Drawing.Size(122, 21);
            this.dtpVtoHasta.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(744, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fecha Servicio";
            // 
            // dtpRegHasta
            // 
            this.dtpRegHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpRegHasta.Checked = false;
            this.dtpRegHasta.CustomFormat = "";
            this.dtpRegHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpRegHasta.Location = new System.Drawing.Point(732, 110);
            this.dtpRegHasta.Name = "dtpRegHasta";
            this.dtpRegHasta.ShowCheckBox = true;
            this.dtpRegHasta.Size = new System.Drawing.Size(122, 21);
            this.dtpRegHasta.TabIndex = 16;
            // 
            // dtpRegDesde
            // 
            this.dtpRegDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpRegDesde.Checked = false;
            this.dtpRegDesde.CustomFormat = "";
            this.dtpRegDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpRegDesde.Location = new System.Drawing.Point(732, 80);
            this.dtpRegDesde.Name = "dtpRegDesde";
            this.dtpRegDesde.ShowCheckBox = true;
            this.dtpRegDesde.Size = new System.Drawing.Size(122, 21);
            this.dtpRegDesde.TabIndex = 15;
            // 
            // ucGrillaRdo
            // 
            this.ucGrillaRdo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.ucGrillaRdo.AutoAjustarAnchoColumnas = true;
            this.ucGrillaRdo.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaRdo.DataSource = null;
            this.ucGrillaRdo.DockPadding.All = 1;
            this.ucGrillaRdo.EncabezadoFilaVisible = false;
            this.ucGrillaRdo.Location = new System.Drawing.Point(12, 215);
            this.ucGrillaRdo.Name = "ucGrillaRdo";
            this.ucGrillaRdo.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaRdo.ParametrosGrilla = null;
            this.ucGrillaRdo.Size = new System.Drawing.Size(882, 265);
            this.ucGrillaRdo.TabIndex = 21;
            this.ucGrillaRdo.Text = "ucGrillaEntidades";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnSeleccionar.CustomStyle = "F";
            this.btnSeleccionar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeleccionar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnSeleccionar.Image"));
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(149, 152);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(115, 34);
            this.btnSeleccionar.TabIndex = 18;
            this.btnSeleccionar.Text = "Seleccionar";
            this.toolTip1.SetToolTip(this.btnSeleccionar, "Selecciona los registros tildados y regresa a la pantalla de Factura.");
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnCancelar.CustomStyle = "F";
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnCancelar.Image"));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(290, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 34);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancela la seleccion y regresa a la pantalla de Factura.");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblResultado.ForeColor = System.Drawing.Color.Blue;
            this.lblResultado.Location = new System.Drawing.Point(13, 193);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(38, 15);
            this.lblResultado.TabIndex = 20;
            this.lblResultado.Text = "Resultado";
            // 
            // FrmSelectRegistro
            // 
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.ucGrillaRdo);
            this.Controls.Add(this.dtpRegDesde);
            this.Controls.Add(this.dtpRegHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpVtoHasta);
            this.Controls.Add(this.dtpVtoDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEgreso);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbEgreso);
            this.Controls.Add(this.dtpPagoDesde);
            this.Controls.Add(this.dtpPagoHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.rbVerImpagos);
            this.Controls.Add(this.rbSoloCancelado);
            this.Controls.Add(this.rbTodos);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.None;
            this.Size = new System.Drawing.Size(904, 492);
            this.Text = "Seleccionar registros";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private RadioButton rbTodos;
        private RadioButton rbSoloCancelado;
        private RadioButton rbVerImpagos;
        private ControlBase.Label lblCliente;
        private ControlBase.Label lblFechaHasta;
        private ControlBase.Label lblFechaDesde;
        private DateTimePicker dtpPagoHasta;
        private DateTimePicker dtpPagoDesde;
        private ComboBox cmbEgreso;
        private ControlBase.Button btnBuscar;
        private ControlBase.Label lblEgreso;
        private ControlBase.Label label1;
        private ControlBase.Label label2;
        private DateTimePicker dtpVtoDesde;
        private DateTimePicker dtpVtoHasta;
        private ControlBase.Label label3;
        private DateTimePicker dtpRegHasta;
        private DateTimePicker dtpRegDesde;
        private Controles.UcGrilla ucGrillaRdo;
        private ControlBase.Button btnSeleccionar;
        private ControlBase.Button btnCancelar;
        private ControlBase.Label lblResultado;
        private ToolTip toolTip1;


    }
}