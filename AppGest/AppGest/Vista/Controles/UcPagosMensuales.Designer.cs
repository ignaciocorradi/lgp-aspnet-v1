using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcPagosMensuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPagosMensuales));
            this.ucGrillaClientes = new AppGest.Vista.Controles.UcGrilla();
            this.ucGrillaPagos = new AppGest.Vista.Controles.UcGrilla();
            this.btnAgregarClientesSel = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarTodosClientes = new Gizmox.WebGUI.Forms.Button();
            this.btnQuitarPagosSel = new Gizmox.WebGUI.Forms.Button();
            this.btnQuitarTodosPagos = new Gizmox.WebGUI.Forms.Button();
            this.grpFiltroClientes = new Gizmox.WebGUI.Forms.GroupBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.dtpPeriodoImpago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblNombre = new AppGest.ControlBase.Label();
            this.txtNombreFiltro = new AppGest.ControlBase.TextBox();
            this.btnNuevoMensual = new AppGest.ControlBase.Button();
            this.grpEncabPago = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtComentarioRegistro = new AppGest.ControlBase.TextBox();
            this.label4 = new AppGest.ControlBase.Label();
            this.btnPagar = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAplicarFechaCobro = new AppGest.ControlBase.Button();
            this.label5 = new AppGest.ControlBase.Label();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblRdoCliente = new AppGest.ControlBase.Label();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.label3 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.tlt = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.grpFiltroClientes.SuspendLayout();
            this.grpEncabPago.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // ucGrillaClientes
            // 
            this.ucGrillaClientes.AutoAjustarAnchoColumnas = true;
            this.ucGrillaClientes.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaClientes.DataSource = null;
            this.ucGrillaClientes.DockPadding.All = 1;
            this.ucGrillaClientes.EncabezadoFilaVisible = true;
            this.ucGrillaClientes.Location = new System.Drawing.Point(7, 130);
            this.ucGrillaClientes.Name = "ucGrillaClientes";
            this.ucGrillaClientes.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaClientes.ParametrosGrilla = null;
            this.ucGrillaClientes.Size = new System.Drawing.Size(366, 222);
            this.ucGrillaClientes.TabIndex = 3;
            this.ucGrillaClientes.Text = "ucGrillaEntidades";
            // 
            // ucGrillaPagos
            // 
            this.ucGrillaPagos.AutoAjustarAnchoColumnas = true;
            this.ucGrillaPagos.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaPagos.DataSource = null;
            this.ucGrillaPagos.DockPadding.All = 1;
            this.ucGrillaPagos.EncabezadoFilaVisible = true;
            this.ucGrillaPagos.Location = new System.Drawing.Point(428, 130);
            this.ucGrillaPagos.Name = "ucGrillaPagos";
            this.ucGrillaPagos.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrillaPagos.ParametrosGrilla = null;
            this.ucGrillaPagos.Size = new System.Drawing.Size(902, 223);
            this.ucGrillaPagos.TabIndex = 9;
            this.ucGrillaPagos.Text = "ucGrillaEntidades";
            // 
            // btnAgregarClientesSel
            // 
            this.btnAgregarClientesSel.CustomStyle = "F";
            this.btnAgregarClientesSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarClientesSel.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregarClientesSel.Image"));
            this.btnAgregarClientesSel.Location = new System.Drawing.Point(377, 129);
            this.btnAgregarClientesSel.Name = "btnAgregarClientesSel";
            this.btnAgregarClientesSel.Size = new System.Drawing.Size(48, 43);
            this.btnAgregarClientesSel.TabIndex = 4;
            this.tlt.SetToolTip(this.btnAgregarClientesSel, "Agregar solo los clientes seleccionados");
            this.btnAgregarClientesSel.Click += new System.EventHandler(this.btnAgregarClientesSel_Click);
            // 
            // btnAgregarTodosClientes
            // 
            this.btnAgregarTodosClientes.CustomStyle = "F";
            this.btnAgregarTodosClientes.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarTodosClientes.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregarTodosClientes.Image"));
            this.btnAgregarTodosClientes.Location = new System.Drawing.Point(377, 176);
            this.btnAgregarTodosClientes.Name = "btnAgregarTodosClientes";
            this.btnAgregarTodosClientes.Size = new System.Drawing.Size(48, 43);
            this.btnAgregarTodosClientes.TabIndex = 5;
            this.tlt.SetToolTip(this.btnAgregarTodosClientes, "Agregar TODOS los clientes. No importa si están tildados o no. \r\n");
            this.btnAgregarTodosClientes.Click += new System.EventHandler(this.btnAgregarTodosCli_Click);
            // 
            // btnQuitarPagosSel
            // 
            this.btnQuitarPagosSel.CustomStyle = "F";
            this.btnQuitarPagosSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnQuitarPagosSel.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnQuitarPagosSel.Image"));
            this.btnQuitarPagosSel.Location = new System.Drawing.Point(377, 262);
            this.btnQuitarPagosSel.Name = "btnQuitarPagosSel";
            this.btnQuitarPagosSel.Size = new System.Drawing.Size(48, 43);
            this.btnQuitarPagosSel.TabIndex = 6;
            this.tlt.SetToolTip(this.btnQuitarPagosSel, "Quita las líneas \"Seleccionadas\" de registros a cobrar.");
            this.btnQuitarPagosSel.Click += new System.EventHandler(this.btnQuitarPagosSel_Click);
            // 
            // btnQuitarTodosPagos
            // 
            this.btnQuitarTodosPagos.CustomStyle = "F";
            this.btnQuitarTodosPagos.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnQuitarTodosPagos.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnQuitarTodosPagos.Image"));
            this.btnQuitarTodosPagos.Location = new System.Drawing.Point(377, 309);
            this.btnQuitarTodosPagos.Name = "btnQuitarTodosPagos";
            this.btnQuitarTodosPagos.Size = new System.Drawing.Size(48, 43);
            this.btnQuitarTodosPagos.TabIndex = 7;
            this.tlt.SetToolTip(this.btnQuitarTodosPagos, "Quita TODAS las líneas de registros a cobrar. No importa si está seleccionadas. ");
            this.btnQuitarTodosPagos.Click += new System.EventHandler(this.btnQuitarTodosPagos_Click);
            // 
            // grpFiltroClientes
            // 
            this.grpFiltroClientes.Controls.Add(this.label1);
            this.grpFiltroClientes.Controls.Add(this.btnBuscar);
            this.grpFiltroClientes.Controls.Add(this.dtpPeriodoImpago);
            this.grpFiltroClientes.Controls.Add(this.lblNombre);
            this.grpFiltroClientes.Controls.Add(this.txtNombreFiltro);
            this.grpFiltroClientes.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltroClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltroClientes.Location = new System.Drawing.Point(7, 7);
            this.grpFiltroClientes.Name = "grpFiltroClientes";
            this.grpFiltroClientes.Size = new System.Drawing.Size(324, 89);
            this.grpFiltroClientes.TabIndex = 0;
            this.grpFiltroClientes.TabStop = false;
            this.grpFiltroClientes.Text = "(1) - Filtrar clientes a cobrar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Periodo Impago:";
            this.tlt.SetToolTip(this.label1, "Este valor es obligatorio");
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
            this.btnBuscar.Location = new System.Drawing.Point(209, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(100, 32);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar...";
            this.tlt.SetToolTip(this.btnBuscar, "Busca clientes con servicios impagos en el periodo indicado");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpPeriodoImpago
            // 
            this.dtpPeriodoImpago.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpPeriodoImpago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpPeriodoImpago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpPeriodoImpago.CustomFormat = "MM-yyyy";
            this.dtpPeriodoImpago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodoImpago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpPeriodoImpago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoImpago.Location = new System.Drawing.Point(112, 52);
            this.dtpPeriodoImpago.Name = "dtpPeriodoImpago";
            this.dtpPeriodoImpago.Size = new System.Drawing.Size(89, 18);
            this.dtpPeriodoImpago.TabIndex = 3;
            this.tlt.SetToolTip(this.dtpPeriodoImpago, "Seleccionar el periodo impago a cobrar.\r\nEste dato es OBLIGATORIO.");
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(8, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre de cliente:";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombreFiltro.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombreFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreFiltro.Location = new System.Drawing.Point(116, 20);
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.SelectTextOnGotFocus = true;
            this.txtNombreFiltro.Size = new System.Drawing.Size(192, 20);
            this.txtNombreFiltro.TabIndex = 1;
            this.tlt.SetToolTip(this.txtNombreFiltro, "Filtro por nombre del cliente.\r\nPuede escribir el nombre o apellido. \r\nAdemás pue" +
        "de estar completo o parte del nombre");
            // 
            // btnNuevoMensual
            // 
            this.btnNuevoMensual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnNuevoMensual.CustomStyle = "F";
            this.btnNuevoMensual.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnNuevoMensual.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoMensual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevoMensual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoMensual.Location = new System.Drawing.Point(340, 73);
            this.btnNuevoMensual.Name = "btnNuevoMensual";
            this.btnNuevoMensual.Size = new System.Drawing.Size(59, 23);
            this.btnNuevoMensual.TabIndex = 5;
            this.btnNuevoMensual.Text = "Nuevo";
            this.tlt.SetToolTip(this.btnNuevoMensual, "Muestra la pantalla para crear un Nuevo Cliente mensual.");
            this.btnNuevoMensual.Click += new System.EventHandler(this.btnNuevoMensual_Click);
            // 
            // grpEncabPago
            // 
            this.grpEncabPago.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.grpEncabPago.Controls.Add(this.txtComentarioRegistro);
            this.grpEncabPago.Controls.Add(this.label4);
            this.grpEncabPago.Controls.Add(this.btnPagar);
            this.grpEncabPago.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpEncabPago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEncabPago.Location = new System.Drawing.Point(428, 7);
            this.grpEncabPago.Name = "grpEncabPago";
            this.grpEncabPago.Size = new System.Drawing.Size(892, 70);
            this.grpEncabPago.TabIndex = 14;
            this.grpEncabPago.TabStop = false;
            this.grpEncabPago.Text = "(4) - Indicar fecha de pago e importe pagado";
            // 
            // txtComentarioRegistro
            // 
            this.txtComentarioRegistro.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtComentarioRegistro.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtComentarioRegistro.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtComentarioRegistro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarioRegistro.Location = new System.Drawing.Point(146, 33);
            this.txtComentarioRegistro.Multiline = true;
            this.txtComentarioRegistro.Name = "txtComentarioRegistro";
            this.txtComentarioRegistro.SelectTextOnGotFocus = true;
            this.txtComentarioRegistro.Size = new System.Drawing.Size(731, 29);
            this.txtComentarioRegistro.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(144, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Comentarios:";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnPagar.CustomStyle = "F";
            this.btnPagar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPagar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnPagar.Image"));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(13, 29);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnPagar.Size = new System.Drawing.Size(126, 36);
            this.btnPagar.TabIndex = 0;
            this.btnPagar.Text = "&Confirmar Cobro";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlt.SetToolTip(this.btnPagar, "Guarda los datos de cobro");
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnNuevoMensual);
            this.panel1.Controls.Add(this.btnAplicarFechaCobro);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpFechaPago);
            this.panel1.Controls.Add(this.lblRdoCliente);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ucGrillaPagos);
            this.panel1.Controls.Add(this.grpEncabPago);
            this.panel1.Controls.Add(this.ucGrillaClientes);
            this.panel1.Controls.Add(this.grpFiltroClientes);
            this.panel1.Controls.Add(this.btnAgregarClientesSel);
            this.panel1.Controls.Add(this.btnQuitarTodosPagos);
            this.panel1.Controls.Add(this.btnAgregarTodosClientes);
            this.panel1.Controls.Add(this.btnQuitarPagosSel);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 367);
            this.panel1.TabIndex = 2;
            // 
            // btnAplicarFechaCobro
            // 
            this.btnAplicarFechaCobro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAplicarFechaCobro.CustomStyle = "F";
            this.btnAplicarFechaCobro.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAplicarFechaCobro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFechaCobro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAplicarFechaCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarFechaCobro.Location = new System.Drawing.Point(1093, 94);
            this.btnAplicarFechaCobro.Name = "btnAplicarFechaCobro";
            this.btnAplicarFechaCobro.Size = new System.Drawing.Size(102, 31);
            this.btnAplicarFechaCobro.TabIndex = 13;
            this.btnAplicarFechaCobro.Text = "Aplicar fecha";
            this.btnAplicarFechaCobro.Click += new System.EventHandler(this.btnAplicarFechaCobro_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(980, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fecha de cobro:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.dtpFechaPago.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaPago.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaPago.CustomFormat = "";
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPago.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(980, 104);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(100, 17);
            this.dtpFechaPago.TabIndex = 12;
            // 
            // lblRdoCliente
            // 
            this.lblRdoCliente.AutoSize = true;
            this.lblRdoCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRdoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRdoCliente.Location = new System.Drawing.Point(10, 96);
            this.lblRdoCliente.Name = "lblRdoCliente";
            this.lblRdoCliente.Size = new System.Drawing.Size(38, 15);
            this.lblRdoCliente.TabIndex = 1;
            this.lblRdoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.lblTitulo.Location = new System.Drawing.Point(636, 79);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 15);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Periodo a cobrar: {0}";
            this.lblTitulo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(425, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "(3) - Clientes a cobrar: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(5, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(2) - Clientes con servicios Impagos:";
            // 
            // UcPagosMensuales
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(1285, 441);
            this.Text = "UcPagosMensuales";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltroClientes.ResumeLayout(false);
            this.grpEncabPago.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrillaClientes;
        private UcGrilla ucGrillaPagos;
        private Button btnAgregarClientesSel;
        private Button btnAgregarTodosClientes;
        private Button btnQuitarPagosSel;
        private Button btnQuitarTodosPagos;
        private GroupBox grpFiltroClientes;
        private GroupBox grpEncabPago;
        private Button btnPagar;
        private DateTimePicker dtpPeriodoImpago;
        private AppGest.ControlBase.Label lblNombre;
        private AppGest.ControlBase.TextBox txtNombreFiltro;
        private Panel panel1;
        private Button btnBuscar;
        private ToolTip tlt;
        private AppGest.ControlBase.Label label1;
        private AppGest.ControlBase.Label label3;
        private AppGest.ControlBase.Label label2;
        private AppGest.ControlBase.TextBox txtComentarioRegistro;
        private AppGest.ControlBase.Label label4;
        private ControlBase.Label lblTitulo;
        private ControlBase.Label lblRdoCliente;
        private DateTimePicker dtpFechaPago;
        private ControlBase.Button btnAplicarFechaCobro;
        private ControlBase.Label label5;
        private ControlBase.Button btnNuevoMensual;


    }
}