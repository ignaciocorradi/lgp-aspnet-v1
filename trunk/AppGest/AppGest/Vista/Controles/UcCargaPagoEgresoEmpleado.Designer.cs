using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcCargaPagoEgresoEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCargaPagoEgresoEmpleado));
            this.ucGrillaResLiq = new AppGest.Vista.Controles.UcGrilla();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.cboEmpleado = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnBuscar = new AppGest.ControlBase.Button();
            this.lblEmpleado = new AppGest.ControlBase.Label();
            this.pnlFill = new Gizmox.WebGUI.Forms.Panel();
            this.grpTotales = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblRemu = new AppGest.ControlBase.Label();
            this.lblSaldo = new AppGest.ControlBase.Label();
            this.label3 = new AppGest.ControlBase.Label();
            this.lblTotalAbonado = new AppGest.ControlBase.Label();
            this.label4 = new AppGest.ControlBase.Label();
            this.label5 = new AppGest.ControlBase.Label();
            this.ucGrillaDetLiq = new AppGest.Vista.Controles.UcGrilla();
            this.lblTituloDetalle = new AppGest.ControlBase.Label();
            this.btnAgregar = new AppGest.ControlBase.Button();
            this.label2 = new AppGest.ControlBase.Label();
            this.tlt = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.grpTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(1145, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(1145, 68);
            // 
            // ucGrillaResLiq
            // 
            this.ucGrillaResLiq.AutoAjustarAnchoColumnas = true;
            this.ucGrillaResLiq.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaResLiq.BackColor = System.Drawing.Color.LightGray;
            this.ucGrillaResLiq.DataSource = null;
            this.ucGrillaResLiq.DockPadding.All = 1;
            this.ucGrillaResLiq.EncabezadoFilaVisible = true;
            this.ucGrillaResLiq.Location = new System.Drawing.Point(12, 160);
            this.ucGrillaResLiq.Name = "ucResLiq";
            this.ucGrillaResLiq.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaResLiq.ParametrosGrilla = null;
            this.ucGrillaResLiq.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.None;
            this.ucGrillaResLiq.Size = new System.Drawing.Size(364, 212);
            this.ucGrillaResLiq.TabIndex = 2;
            this.ucGrillaResLiq.Text = "ucGrillaEntidades";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.cboEmpleado);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.lblEmpleado);
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(12, 7);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(364, 115);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "  Buscar Empleado   ";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(27, 49);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(297, 21);
            this.cboEmpleado.TabIndex = 2;
            this.tlt.SetToolTip(this.cboEmpleado, "Seleccione empleado a recuperar");
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnBuscar.CustomStyle = "F";
            this.btnBuscar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBuscar.Image"));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(27, 76);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(150, 33);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Cargar liquidación";
            this.tlt.SetToolTip(this.btnBuscar, "Carga todos los pagos realizados al empleado,  para el periodo especificado");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.EsObligatorio = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmpleado.Location = new System.Drawing.Point(24, 28);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(35, 13);
            this.lblEmpleado.TabIndex = 0;
            this.lblEmpleado.Text = "&Seleccionar empleado: *";
            // 
            // pnlFill
            // 
            this.pnlFill.AutoScroll = true;
            this.pnlFill.Controls.Add(this.grpTotales);
            this.pnlFill.Controls.Add(this.ucGrillaDetLiq);
            this.pnlFill.Controls.Add(this.lblTituloDetalle);
            this.pnlFill.Controls.Add(this.btnAgregar);
            this.pnlFill.Controls.Add(this.label2);
            this.pnlFill.Controls.Add(this.ucGrillaResLiq);
            this.pnlFill.Controls.Add(this.grpFiltros);
            this.pnlFill.Location = new System.Drawing.Point(3, 71);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1140, 382);
            this.pnlFill.TabIndex = 0;
            // 
            // grpTotales
            // 
            this.grpTotales.Controls.Add(this.lblRemu);
            this.grpTotales.Controls.Add(this.lblSaldo);
            this.grpTotales.Controls.Add(this.label3);
            this.grpTotales.Controls.Add(this.lblTotalAbonado);
            this.grpTotales.Controls.Add(this.label4);
            this.grpTotales.Controls.Add(this.label5);
            this.grpTotales.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpTotales.Location = new System.Drawing.Point(400, 298);
            this.grpTotales.Name = "grpTotales";
            this.grpTotales.Size = new System.Drawing.Size(222, 74);
            this.grpTotales.TabIndex = 13;
            this.grpTotales.TabStop = false;
            // 
            // lblRemu
            // 
            this.lblRemu.AutoSize = true;
            this.lblRemu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRemu.Location = new System.Drawing.Point(111, 12);
            this.lblRemu.Name = "lblRemu";
            this.lblRemu.Size = new System.Drawing.Size(62, 15);
            this.lblRemu.TabIndex = 10;
            this.lblRemu.Text = "$ 2500,00";
            this.lblRemu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.ForeColor = System.Drawing.Color.Red;
            this.lblSaldo.Location = new System.Drawing.Point(111, 52);
            this.lblSaldo.Name = "label6";
            this.lblSaldo.Size = new System.Drawing.Size(55, 15);
            this.lblSaldo.TabIndex = 12;
            this.lblSaldo.Text = "$ 514,77";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Remuneración:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAbonado
            // 
            this.lblTotalAbonado.AutoSize = true;
            this.lblTotalAbonado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalAbonado.Location = new System.Drawing.Point(111, 32);
            this.lblTotalAbonado.Name = "lblTotalAbonado";
            this.lblTotalAbonado.Size = new System.Drawing.Size(62, 15);
            this.lblTotalAbonado.TabIndex = 11;
            this.lblTotalAbonado.Text = "$ 1985,23";
            this.lblTotalAbonado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(10, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total abonado:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Saldo periodo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucGrillaDetLiq
            // 
            this.ucGrillaDetLiq.AutoAjustarAnchoColumnas = true;
            this.ucGrillaDetLiq.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaDetLiq.BackColor = System.Drawing.Color.LightGray;
            this.ucGrillaDetLiq.DataSource = null;
            this.ucGrillaDetLiq.DockPadding.All = 1;
            this.ucGrillaDetLiq.EncabezadoFilaVisible = true;
            this.ucGrillaDetLiq.Location = new System.Drawing.Point(401, 34);
            this.ucGrillaDetLiq.Name = "ucDetLiq";
            this.ucGrillaDetLiq.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaDetLiq.ParametrosGrilla = null;
            this.ucGrillaDetLiq.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.ucGrillaDetLiq.Size = new System.Drawing.Size(716, 259);
            this.ucGrillaDetLiq.TabIndex = 6;
            this.ucGrillaDetLiq.Text = "ucGrillaEntidades";
            // 
            // lblTituloDetalle
            // 
            this.lblTituloDetalle.AutoSize = true;
            this.lblTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloDetalle.ForeColor = System.Drawing.Color.Blue;
            this.lblTituloDetalle.Location = new System.Drawing.Point(397, 8);
            this.lblTituloDetalle.Name = "label1";
            this.lblTituloDetalle.Size = new System.Drawing.Size(38, 15);
            this.lblTituloDetalle.TabIndex = 5;
            this.lblTituloDetalle.Tag = "Detalle de liquidación";
            this.lblTituloDetalle.Text = "Detalle de liquidación";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregar.CustomStyle = "F";
            this.btnAgregar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregar.Image"));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(1011, 298);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnAgregar.Size = new System.Drawing.Size(106, 32);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.tlt.SetToolTip(this.btnAgregar, "Agregar nuevo pago al periodo actual");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(10, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resumen de liquidaciones";
            // 
            // UcCargaPagoEgresoEmpleado
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.pnlFill);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(1151, 462);
            this.Text = "UcCargaPagoEgresoEmpleado";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.pnlFill, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.grpTotales.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrillaResLiq;
        private GroupBox grpFiltros;
        private ControlBase.Label lblEmpleado;
        private Panel pnlFill;
        private ControlBase.Button btnBuscar;
        private ToolTip tlt;
        private ControlBase.Label label2;
        private ComboBox cboEmpleado;
        private ControlBase.Button btnAgregar;
        private ControlBase.Label lblTituloDetalle;
        private ControlBase.Label label5;
        private ControlBase.Label label4;
        private ControlBase.Label label3;
        private UcGrilla ucGrillaDetLiq;
        private ControlBase.Label lblSaldo;
        private ControlBase.Label lblTotalAbonado;
        private ControlBase.Label lblRemu;
        private GroupBox grpTotales;


    }
}