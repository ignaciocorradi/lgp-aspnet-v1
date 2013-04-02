using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucAMBFactura
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
            this.label1 = new AppGest.ControlBase.Label();
            this.dtpFecha = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cmbClientes = new AppGest.Vista.Controles.BusquedaClienteComboBox();
            this.label2 = new AppGest.ControlBase.Label();
            this.txtComentario = new AppGest.ControlBase.TextBox();
            this.label3 = new AppGest.ControlBase.Label();
            this.btnAgregarLinea = new AppGest.ControlBase.Button();
            this.ucGrillaLineas = new AppGest.Vista.Controles.UcGrilla();
            this.lblTotalSaldo = new AppGest.ControlBase.Label();
            this.lblTotSaldot = new AppGest.ControlBase.Label();
            this.lblTotAbonado = new AppGest.ControlBase.Label();
            this.lblTotImporte = new AppGest.ControlBase.Label();
            this.label5 = new AppGest.ControlBase.Label();
            this.label6 = new AppGest.ControlBase.Label();
            this.label7 = new AppGest.ControlBase.Label();
            this.txtNroFactura = new AppGest.ControlBase.TextBox();
            this.Tipo = new AppGest.ControlBase.Label();
            this.cmbTipoFac = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new AppGest.ControlBase.Label();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnFechaPago = new AppGest.ControlBase.Button();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(1054, 28);
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.Size = new System.Drawing.Size(92, 30);
            this.lblTituloBase.Text = "Facturas";
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(1054, 38);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(59, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFecha.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(105, 74);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(111, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // cmbClientes
            // 
            this.cmbClientes.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.cmbClientes.ClienteSeleccionado = null;
            this.cmbClientes.ExigeSeleccion = true;
            this.cmbClientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(300, 75);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(242, 23);
            this.cmbClientes.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(248, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente";
            // 
            // txtComentario
            // 
            this.txtComentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(105, 141);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.SelectTextOnGotFocus = true;
            this.txtComentario.Size = new System.Drawing.Size(437, 23);
            this.txtComentario.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(25, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cometarios";
            // 
            // btnAgregarLinea
            // 
            this.btnAgregarLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregarLinea.CustomStyle = "F";
            this.btnAgregarLinea.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarLinea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarLinea.Location = new System.Drawing.Point(26, 179);
            this.btnAgregarLinea.Name = "btnAgregarLinea";
            this.btnAgregarLinea.Size = new System.Drawing.Size(111, 31);
            this.btnAgregarLinea.TabIndex = 14;
            this.btnAgregarLinea.Text = "Agregar";
            this.btnAgregarLinea.Click += new System.EventHandler(this.btnAgregarLinea_Click);
            // 
            // ucGrillaLineas
            // 
            this.ucGrillaLineas.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.ucGrillaLineas.AutoAjustarAnchoColumnas = true;
            this.ucGrillaLineas.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaLineas.DataSource = null;
            this.ucGrillaLineas.DockPadding.All = 1;
            this.ucGrillaLineas.EncabezadoFilaVisible = true;
            this.ucGrillaLineas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ucGrillaLineas.Location = new System.Drawing.Point(19, 221);
            this.ucGrillaLineas.Name = "ucGrillaLineas";
            this.ucGrillaLineas.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaLineas.ParametrosGrilla = null;
            this.ucGrillaLineas.Size = new System.Drawing.Size(1025, 250);
            this.ucGrillaLineas.TabIndex = 15;
            this.ucGrillaLineas.Text = "Lineas de factura";
            // 
            // lblTotalSaldo
            // 
            this.lblTotalSaldo.AutoSize = true;
            this.lblTotalSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalSaldo.Location = new System.Drawing.Point(669, 124);
            this.lblTotalSaldo.Name = "lblTotalSaldo";
            this.lblTotalSaldo.Size = new System.Drawing.Size(38, 15);
            this.lblTotalSaldo.TabIndex = 21;
            this.lblTotalSaldo.Text = "$ 0";
            this.lblTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotSaldot
            // 
            this.lblTotSaldot.AutoSize = true;
            this.lblTotSaldot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotSaldot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotSaldot.Location = new System.Drawing.Point(599, 124);
            this.lblTotSaldot.Name = "lblTotSaldot";
            this.lblTotSaldot.Size = new System.Drawing.Size(38, 15);
            this.lblTotSaldot.TabIndex = 20;
            this.lblTotSaldot.Text = "Total Saldo:";
            // 
            // lblTotAbonado
            // 
            this.lblTotAbonado.AutoSize = true;
            this.lblTotAbonado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotAbonado.Location = new System.Drawing.Point(669, 100);
            this.lblTotAbonado.Name = "lblTotAbonado";
            this.lblTotAbonado.Size = new System.Drawing.Size(78, 15);
            this.lblTotAbonado.TabIndex = 19;
            this.lblTotAbonado.Text = "$ 0";
            this.lblTotAbonado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotImporte
            // 
            this.lblTotImporte.AutoSize = true;
            this.lblTotImporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotImporte.Location = new System.Drawing.Point(669, 76);
            this.lblTotImporte.Name = "lblTotImporte";
            this.lblTotImporte.Size = new System.Drawing.Size(78, 15);
            this.lblTotImporte.TabIndex = 17;
            this.lblTotImporte.Text = "$ 0";
            this.lblTotImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(579, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total Abonado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(586, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Importe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(22, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nro Factura";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNroFactura.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNroFactura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.Location = new System.Drawing.Point(105, 105);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.SelectTextOnGotFocus = true;
            this.txtNroFactura.Size = new System.Drawing.Size(121, 23);
            this.txtNroFactura.TabIndex = 7;
            // 
            // Tipo
            // 
            this.Tipo.AutoSize = true;
            this.Tipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Tipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Tipo.Location = new System.Drawing.Point(260, 107);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(38, 15);
            this.Tipo.TabIndex = 8;
            this.Tipo.Text = "Tipo";
            // 
            // cmbTipoFac
            // 
            this.cmbTipoFac.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFac.FormattingEnabled = true;
            this.cmbTipoFac.Location = new System.Drawing.Point(300, 106);
            this.cmbTipoFac.Name = "cmbTipoFac";
            this.cmbTipoFac.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoFac.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(624, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Aplicar fecha pago";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "";
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(627, 185);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaPago.TabIndex = 23;
            // 
            // btnFechaPago
            // 
            this.btnFechaPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnFechaPago.CustomStyle = "F";
            this.btnFechaPago.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFechaPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechaPago.Location = new System.Drawing.Point(733, 182);
            this.btnFechaPago.Name = "btnFechaPago";
            this.btnFechaPago.Size = new System.Drawing.Size(72, 28);
            this.btnFechaPago.TabIndex = 25;
            this.btnFechaPago.Text = "Aplicar";
            this.btnFechaPago.Click += new System.EventHandler(this.btnFechaPago_Click);
            // 
            // ucAMBFactura
            // 
            this.Controls.Add(this.btnFechaPago);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoFac);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.txtNroFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotImporte);
            this.Controls.Add(this.lblTotAbonado);
            this.Controls.Add(this.lblTotSaldot);
            this.Controls.Add(this.lblTotalSaldo);
            this.Controls.Add(this.ucGrillaLineas);
            this.Controls.Add(this.btnAgregarLinea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(1060, 488);
            this.Text = "ucAMBFactura";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.cmbClientes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtComentario, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnAgregarLinea, 0);
            this.Controls.SetChildIndex(this.ucGrillaLineas, 0);
            this.Controls.SetChildIndex(this.lblTotalSaldo, 0);
            this.Controls.SetChildIndex(this.lblTotSaldot, 0);
            this.Controls.SetChildIndex(this.lblTotAbonado, 0);
            this.Controls.SetChildIndex(this.lblTotImporte, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNroFactura, 0);
            this.Controls.SetChildIndex(this.Tipo, 0);
            this.Controls.SetChildIndex(this.cmbTipoFac, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtpFechaPago, 0);
            this.Controls.SetChildIndex(this.btnFechaPago, 0);
            this.pnCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBase.Label label1;
        private DateTimePicker dtpFecha;
        private BusquedaClienteComboBox cmbClientes;
        private ControlBase.Label label2;
        private ControlBase.TextBox txtComentario;
        private ControlBase.Label label3;
        private ControlBase.Button btnAgregarLinea;
        private UcGrilla ucGrillaLineas;
        private ControlBase.Label lblTotalSaldo;
        private ControlBase.Label lblTotSaldot;
        private ControlBase.Label lblTotAbonado;
        private ControlBase.Label lblTotImporte;
        private ControlBase.Label label5;
        private ControlBase.Label label6;
        private ControlBase.Label label7;
        private ControlBase.TextBox txtNroFactura;
        private ControlBase.Label Tipo;
        private ComboBox cmbTipoFac;
        private ControlBase.Label label4;
        private DateTimePicker dtpFechaPago;
        private ControlBase.Button btnFechaPago;


    }
}