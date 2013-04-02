namespace AppGest.Vista
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.rbpParametros = new Gizmox.WebGUI.Forms.RibbonBarPage();
            this.rbgCliente = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiNuevoCliente = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiModifCliente = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiModifAutos = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbgCocheras = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiNuevaCochera = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiEditarCocheras = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbgEmpleados = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiNuevoEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiEditarEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbgCptoIngreso = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiNuevoCptoIngreso = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiEditarCptoIngreso = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiListaIngresos = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbgCptoGastoVarios = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiAltaGastoVarios = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiEditarGastoVarios = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiListaGastosVarios = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbgCptoGastoEmp = new Gizmox.WebGUI.Forms.RibbonBarGroup();
            this.rbiAltaGastoEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiEditarGastoEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiListaGastosEmpleados = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiTest1 = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.ucStatusBar1 = new AppGest.ControlBase.ucStatusBar();
            this.rbiParamEgresoEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            this.rbiPagoEgresoEmpleado = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbpParametros
            // 
            // 
            // rbgCliente
            // 
            // 
            // rbiNuevoCliente
            // 
            this.rbiNuevoCliente.ClientAction = null;
            this.rbiNuevoCliente.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiNuevoCliente.Image"));
            this.rbiNuevoCliente.Tag = "rbiNuevoCliente";
            this.rbiNuevoCliente.Text = "Alta cliente";
            // 
            // rbiModifCliente
            // 
            this.rbiModifCliente.ClientAction = null;
            this.rbiModifCliente.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiModifCliente.Image"));
            this.rbiModifCliente.Tag = "rbiModifCliente";
            this.rbiModifCliente.Text = "Editar cliente";
            // 
            // rbiModifAutos
            // 
            this.rbiModifAutos.ClientAction = null;
            this.rbiModifAutos.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiModifAutos.Image"));
            this.rbiModifAutos.Tag = "rbiModifAutos";
            this.rbiModifAutos.Text = "Editar vehículos";
            this.rbgCliente.Items.Add(this.rbiNuevoCliente);
            this.rbgCliente.Items.Add(this.rbiModifCliente);
            this.rbgCliente.Items.Add(this.rbiModifAutos);
            this.rbgCliente.Text = "Clientes";
            // 
            // rbgCocheras
            // 
            // 
            // rbiNuevaCochera
            // 
            this.rbiNuevaCochera.ClientAction = null;
            this.rbiNuevaCochera.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiNuevaCochera.Image"));
            this.rbiNuevaCochera.Tag = "rbiNuevaCochera";
            this.rbiNuevaCochera.Text = "Alta";
            // 
            // rbiEditarCocheras
            // 
            this.rbiEditarCocheras.ClientAction = null;
            this.rbiEditarCocheras.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiEditarCocheras.Image"));
            this.rbiEditarCocheras.Tag = "rbiEditarCocheras";
            this.rbiEditarCocheras.Text = "Editar";
            this.rbgCocheras.Items.Add(this.rbiNuevaCochera);
            this.rbgCocheras.Items.Add(this.rbiEditarCocheras);
            this.rbgCocheras.Text = "Cocheras";
            // 
            // rbgEmpleados
            // 
            // 
            // rbiNuevoEmpleado
            // 
            this.rbiNuevoEmpleado.ClientAction = null;
            this.rbiNuevoEmpleado.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiNuevoEmpleado.Image"));
            this.rbiNuevoEmpleado.Tag = "rbiNuevoEmpleado";
            this.rbiNuevoEmpleado.Text = "Alta";
            // 
            // rbiEditarEmpleado
            // 
            this.rbiEditarEmpleado.ClientAction = null;
            this.rbiEditarEmpleado.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiEditarEmpleado.Image"));
            this.rbiEditarEmpleado.Tag = "rbiEditarEmpleado";
            this.rbiEditarEmpleado.Text = "Editar";
            this.rbgEmpleados.Items.Add(this.rbiNuevoEmpleado);
            this.rbgEmpleados.Items.Add(this.rbiEditarEmpleado);
            this.rbgEmpleados.Text = "Empleados";
            // 
            // rbgCptoIngreso
            // 
            // 
            // rbiNuevoCptoIngreso
            // 
            this.rbiNuevoCptoIngreso.ClientAction = null;
            this.rbiNuevoCptoIngreso.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiNuevoCptoIngreso.Image"));
            this.rbiNuevoCptoIngreso.Tag = "rbiNuevoCptoIngreso";
            this.rbiNuevoCptoIngreso.Text = "Alta";
            // 
            // rbiEditarCptoIngreso
            // 
            this.rbiEditarCptoIngreso.ClientAction = null;
            this.rbiEditarCptoIngreso.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiEditarCptoIngreso.Image"));
            this.rbiEditarCptoIngreso.Tag = "rbiModifCptoIngreso";
            this.rbiEditarCptoIngreso.Text = "Editar";
            // 
            // rbiListaIngresos
            // 
            this.rbiListaIngresos.ClientAction = null;
            this.rbiListaIngresos.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiListaIngresos.Image"));
            this.rbiListaIngresos.Tag = "rbiListaIngresos";
            this.rbiListaIngresos.Text = "Editar precios";
            this.rbgCptoIngreso.Items.Add(this.rbiNuevoCptoIngreso);
            this.rbgCptoIngreso.Items.Add(this.rbiEditarCptoIngreso);
            this.rbgCptoIngreso.Items.Add(this.rbiListaIngresos);
            this.rbgCptoIngreso.Text = "Conceptos de Ingreso";
            // 
            // rbgCptoGastoVarios
            // 
            // 
            // rbiAltaGastoVarios
            // 
            this.rbiAltaGastoVarios.ClientAction = null;
            this.rbiAltaGastoVarios.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiAltaGastoVarios.Image"));
            this.rbiAltaGastoVarios.Tag = "rbiNuevoCptoGastoVario";
            this.rbiAltaGastoVarios.Text = "Alta";
            // 
            // rbiEditarGastoVarios
            // 
            this.rbiEditarGastoVarios.ClientAction = null;
            this.rbiEditarGastoVarios.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiEditarGastoVarios.Image"));
            this.rbiEditarGastoVarios.Tag = "rbiModifCptoGastoVario";
            this.rbiEditarGastoVarios.Text = "Editar";
            // 
            // rbiListaGastosVarios
            // 
            this.rbiListaGastosVarios.ClientAction = null;
            this.rbiListaGastosVarios.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiListaGastosVarios.Image"));
            this.rbiListaGastosVarios.Tag = "rbiListaGastos";
            this.rbiListaGastosVarios.Text = "Editar precios";
            this.rbgCptoGastoVarios.Items.Add(this.rbiAltaGastoVarios);
            this.rbgCptoGastoVarios.Items.Add(this.rbiEditarGastoVarios);
            this.rbgCptoGastoVarios.Items.Add(this.rbiListaGastosVarios);
            this.rbgCptoGastoVarios.Text = "Conceptos de Egresos varios";
            // 
            // rbgCptoGastoEmp
            // 

            // 
            // rbiAltaGastoEmpleado
            // 
            this.rbiAltaGastoEmpleado.ClientAction = null;
            this.rbiAltaGastoEmpleado.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiAltaGastoEmpleado.Image"));
            this.rbiAltaGastoEmpleado.Tag = "rbiNuevoCptoGastoEmpleado";
            this.rbiAltaGastoEmpleado.Text = "Alta";
            // 
            // rbiEditarGastoEmpleado
            // 
            this.rbiEditarGastoEmpleado.ClientAction = null;
            this.rbiEditarGastoEmpleado.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiEditarGastoEmpleado.Image"));
            this.rbiEditarGastoEmpleado.Tag = "rbiModifCptoGastoEmpleado";
            this.rbiEditarGastoEmpleado.Text = "Editar";
            // 
            // rbiListaGastosEmpleados
            // 
            this.rbiListaGastosEmpleados.ClientAction = null;
            this.rbiListaGastosEmpleados.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("rbiListaGastosEmpleados.Image"));
            this.rbiListaGastosEmpleados.Tag = "rbiListaGastosEmpleados";
            this.rbiListaGastosEmpleados.Text = "Editar precios";
            this.rbgCptoGastoEmp.Items.Add(this.rbiAltaGastoEmpleado);
            this.rbgCptoGastoEmp.Items.Add(this.rbiEditarGastoEmpleado);
            this.rbgCptoGastoEmp.Items.Add(this.rbiListaGastosEmpleados);
            this.rbgCptoGastoEmp.Text = "Conceptos de Liquidación del Personal";
            this.rbpParametros.Groups.Add(this.rbgCliente);
            this.rbpParametros.Groups.Add(this.rbgCocheras);
            this.rbpParametros.Groups.Add(this.rbgEmpleados);
            this.rbpParametros.Groups.Add(this.rbgCptoIngreso);
            this.rbpParametros.Groups.Add(this.rbgCptoGastoVarios);
            this.rbpParametros.Groups.Add(this.rbgCptoGastoEmp);
            this.rbpParametros.Text = "Parámetros";
            this.rbpParametros.Visible = true;
            // 
            // rbiTest1
            // 
            this.rbiTest1.ClientAction = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabControl1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.tabControl1.CustomStyle = "F";
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(876, 454);
            this.tabControl1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(834, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Cerrar sesión");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucStatusBar1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(3, 448);
            this.ucStatusBar1.MensajeEstado = "Listo.";
            this.ucStatusBar1.MensajeInfo = "Usuario:";
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(876, 30);
            this.ucStatusBar1.TabIndex = 9;
            this.ucStatusBar1.Text = "ucStatusBar";
            // 
            // rbiParamEgresoEmpleado
            // 
            this.rbiParamEgresoEmpleado.ClientAction = null;
            this.rbiParamEgresoEmpleado.Tag = "rbiParamEgresoEmpleado";
            this.rbiParamEgresoEmpleado.Text = "Egresos Por Empleado";
            // 
            // rbiPagoEgresoEmpleado
            // 
            this.rbiPagoEgresoEmpleado.ClientAction = null;
            this.rbiPagoEgresoEmpleado.Tag = "rbiPagoEgresoEmpleado";
            this.rbiPagoEgresoEmpleado.Text = "Pago de Egresos por Empleado";
            // 
            // FrmPrincipal
            // 
            this.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ucStatusBar1);
            this.Controls.Add(this.pictureBox1);
            this.DockPadding.All = 3;
            this.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.Icon"));
            this.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.Size = new System.Drawing.Size(882, 490);
            this.Text = "Sistema de Gestión de LGP";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tabControl1;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiTest1;
        private Gizmox.WebGUI.Forms.RibbonBarPage rbpParametros;
        private Gizmox.WebGUI.Forms.PictureBox pictureBox1;
        private Gizmox.WebGUI.Forms.ToolTip toolTip1;
        private ControlBase.ucStatusBar ucStatusBar1;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgCliente;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiNuevoCliente;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiModifCliente;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiModifAutos;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgCocheras;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiNuevaCochera;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiEditarCocheras;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgEmpleados;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiNuevoEmpleado;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiEditarEmpleado;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgCptoIngreso;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiNuevoCptoIngreso;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiEditarCptoIngreso;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiListaIngresos;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgCptoGastoVarios;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiAltaGastoVarios;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiEditarGastoVarios;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiListaGastosVarios;
        private Gizmox.WebGUI.Forms.RibbonBarGroup rbgCptoGastoEmp;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiAltaGastoEmpleado;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiEditarGastoEmpleado;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiListaGastosEmpleados;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiParamEgresoEmpleado;
        private Gizmox.WebGUI.Forms.RibbonBarButtonItem rbiPagoEgresoEmpleado;
    }
}