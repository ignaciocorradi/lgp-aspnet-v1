using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEdicionPagoMensual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEdicionPagoMensual));
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.pnlFiltroFechaPago = new Gizmox.WebGUI.Forms.Panel();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.chkHabFechaPago = new Gizmox.WebGUI.Forms.CheckBox();
            this.pnlFiltroPeriodo = new Gizmox.WebGUI.Forms.Panel();
            this.lblPeriodoHasta = new AppGest.ControlBase.Label();
            this.lblPeriodoDesde = new AppGest.ControlBase.Label();
            this.dtpPeriodoHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpPeriodoDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.chkHabPeriodo = new Gizmox.WebGUI.Forms.CheckBox();
            this.label3 = new AppGest.ControlBase.Label();
            this.txtCochera = new AppGest.ControlBase.TextBox();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.lblAbonado = new AppGest.ControlBase.Label();
            this.lblBonif = new AppGest.ControlBase.Label();
            this.lblRecargo = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.pnlFiltroFechaPago.SuspendLayout();
            this.pnlFiltroPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.Location = new System.Drawing.Point(3, 212);
            this.ucGrilla1.Size = new System.Drawing.Size(882, 214);
            this.ucGrilla1.TabIndex = 1;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblRecargo);
            this.grpFiltros.Controls.Add(this.lblBonif);
            this.grpFiltros.Controls.Add(this.lblAbonado);
            this.grpFiltros.Controls.Add(this.pnlFiltroFechaPago);
            this.grpFiltros.Controls.Add(this.chkHabFechaPago);
            this.grpFiltros.Controls.Add(this.pnlFiltroPeriodo);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.chkHabPeriodo);
            this.grpFiltros.Controls.Add(this.label3);
            this.grpFiltros.Controls.Add(this.txtCochera);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(3, 31);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(882, 142);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Indicar filtros para buscar registros:";
            // 
            // pnlFiltroFechaPago
            // 
            this.pnlFiltroFechaPago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlFiltroFechaPago.Controls.Add(this.dtpFechaPago);
            this.pnlFiltroFechaPago.Enabled = false;
            this.pnlFiltroFechaPago.Location = new System.Drawing.Point(384, 37);
            this.pnlFiltroFechaPago.Name = "pnlFiltroFechaPago";
            this.pnlFiltroFechaPago.Size = new System.Drawing.Size(171, 48);
            this.pnlFiltroFechaPago.TabIndex = 3;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaPago.CustomStyle = "text-align: center;";
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPago.Location = new System.Drawing.Point(7, 15);
            this.dtpFechaPago.Name = "dateTimePicker1";
            this.dtpFechaPago.Size = new System.Drawing.Size(151, 21);
            this.dtpFechaPago.TabIndex = 0;
            // 
            // chkHabFechaPago
            // 
            this.chkHabFechaPago.AutoSize = true;
            this.chkHabFechaPago.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHabFechaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabFechaPago.Location = new System.Drawing.Point(384, 20);
            this.chkHabFechaPago.Name = "chkHabFechaPago";
            this.chkHabFechaPago.Size = new System.Drawing.Size(157, 17);
            this.chkHabFechaPago.TabIndex = 2;
            this.chkHabFechaPago.Text = "Filtrar por fecha de cobro:";
            this.chkHabFechaPago.CheckedChanged += new System.EventHandler(this.chkHabFechaPago_CheckedChanged);
            // 
            // pnlFiltroPeriodo
            // 
            this.pnlFiltroPeriodo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlFiltroPeriodo.Controls.Add(this.lblPeriodoHasta);
            this.pnlFiltroPeriodo.Controls.Add(this.lblPeriodoDesde);
            this.pnlFiltroPeriodo.Controls.Add(this.dtpPeriodoHasta);
            this.pnlFiltroPeriodo.Controls.Add(this.dtpPeriodoDesde);
            this.pnlFiltroPeriodo.Enabled = false;
            this.pnlFiltroPeriodo.Location = new System.Drawing.Point(27, 37);
            this.pnlFiltroPeriodo.Name = "pnlFiltroPeriodo";
            this.pnlFiltroPeriodo.Size = new System.Drawing.Size(332, 48);
            this.pnlFiltroPeriodo.TabIndex = 1;
            // 
            // lblPeriodoHasta
            // 
            this.lblPeriodoHasta.AutoSize = true;
            this.lblPeriodoHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodoHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPeriodoHasta.Location = new System.Drawing.Point(168, 5);
            this.lblPeriodoHasta.Name = "lblPeriodoHasta";
            this.lblPeriodoHasta.Size = new System.Drawing.Size(39, 13);
            this.lblPeriodoHasta.TabIndex = 2;
            this.lblPeriodoHasta.Text = "Hasta:";
            // 
            // lblPeriodoDesde
            // 
            this.lblPeriodoDesde.AutoSize = true;
            this.lblPeriodoDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodoDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPeriodoDesde.Location = new System.Drawing.Point(4, 5);
            this.lblPeriodoDesde.Name = "lblPeriodoDesde";
            this.lblPeriodoDesde.Size = new System.Drawing.Size(41, 13);
            this.lblPeriodoDesde.TabIndex = 0;
            this.lblPeriodoDesde.Text = "Desde:";
            // 
            // dtpPeriodoHasta
            // 
            this.dtpPeriodoHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPeriodoHasta.CustomFormat = "MM-yyyy";
            this.dtpPeriodoHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoHasta.Location = new System.Drawing.Point(169, 21);
            this.dtpPeriodoHasta.Name = "dtpPeriodoHasta";
            this.dtpPeriodoHasta.Size = new System.Drawing.Size(151, 21);
            this.dtpPeriodoHasta.TabIndex = 3;
            // 
            // dtpPeriodoDesde
            // 
            this.dtpPeriodoDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPeriodoDesde.CustomFormat = "MM-yyyy";
            this.dtpPeriodoDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoDesde.Location = new System.Drawing.Point(5, 21);
            this.dtpPeriodoDesde.Name = "dtpPeriodoDesde";
            this.dtpPeriodoDesde.Size = new System.Drawing.Size(151, 21);
            this.dtpPeriodoDesde.TabIndex = 1;
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
            this.btnBuscar.Location = new System.Drawing.Point(572, 91);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(122, 38);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // chkHabPeriodo
            // 
            this.chkHabPeriodo.AutoSize = true;
            this.chkHabPeriodo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHabPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabPeriodo.Location = new System.Drawing.Point(27, 20);
            this.chkHabPeriodo.Name = "chkHabPeriodo";
            this.chkHabPeriodo.Size = new System.Drawing.Size(128, 17);
            this.chkHabPeriodo.TabIndex = 0;
            this.chkHabPeriodo.Text = "Filtrar por Periodos:";
            this.chkHabPeriodo.CheckedChanged += new System.EventHandler(this.chkHabPeriodo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(27, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cochera";
            // 
            // txtCochera
            // 
            this.txtCochera.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtCochera.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtCochera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCochera.Location = new System.Drawing.Point(27, 109);
            this.txtCochera.Name = "txtCochera";
            this.txtCochera.SelectTextOnGotFocus = true;
            this.txtCochera.Size = new System.Drawing.Size(95, 20);
            this.txtCochera.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(128, 109);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(125, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cliente";
            // 
            // lblAbonado
            // 
            this.lblAbonado.AutoSize = true;
            this.lblAbonado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAbonado.Location = new System.Drawing.Point(723, 22);
            this.lblAbonado.Name = "lblAbonado";
            this.lblAbonado.Size = new System.Drawing.Size(38, 15);
            this.lblAbonado.TabIndex = 9;
            this.lblAbonado.Text = "Total Abonado: {0}";
            // 
            // lblBonif
            // 
            this.lblBonif.AutoSize = true;
            this.lblBonif.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBonif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBonif.Location = new System.Drawing.Point(723, 43);
            this.lblBonif.Name = "lblBonif";
            this.lblBonif.Size = new System.Drawing.Size(38, 15);
            this.lblBonif.TabIndex = 10;
            this.lblBonif.Text = "Total Bonif.: {0}";
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRecargo.Location = new System.Drawing.Point(723, 65);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(38, 15);
            this.lblRecargo.TabIndex = 11;
            this.lblRecargo.Text = "Total Recargo: {0}";
            // 
            // ucEdicionPagoMensual
            // 
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(888, 429);
            this.Text = "ucEdicionPagoMensual";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.pnlFiltroFechaPago.ResumeLayout(false);
            this.pnlFiltroPeriodo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpFiltros;
        private AppGest.ControlBase.Label label3;
        private AppGest.ControlBase.TextBox txtCochera;
        private AppGest.ControlBase.TextBox txtNombre;
        private AppGest.ControlBase.Label label1;
        private Button btnBuscar;
        private DateTimePicker dtpFechaPago;
        private DateTimePicker dtpPeriodoDesde;
        private AppGest.ControlBase.Label lblPeriodoDesde;
        private CheckBox chkHabPeriodo;
        private Panel pnlFiltroPeriodo;
        private AppGest.ControlBase.Label lblPeriodoHasta;
        private DateTimePicker dtpPeriodoHasta;
        private Panel pnlFiltroFechaPago;
        private CheckBox chkHabFechaPago;
        private ControlBase.Label lblRecargo;
        private ControlBase.Label lblBonif;
        private ControlBase.Label lblAbonado;


    }
}