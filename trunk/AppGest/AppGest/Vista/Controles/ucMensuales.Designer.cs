using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucMensuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMensuales));
            this.imgImagen = new Gizmox.WebGUI.Forms.PictureBox();
            this.btnEditarCochera = new Gizmox.WebGUI.Forms.Button();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblCocherasAsoc = new AppGest.ControlBase.Label();
            this.btnAsociar = new Gizmox.WebGUI.Forms.Button();
            this.lvCocherasAsoc = new Gizmox.WebGUI.Forms.ListView();
            this.chNroCochera = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chServicio = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chServDesde = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chServHasta = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.btnBajaAuto = new Gizmox.WebGUI.Forms.Button();
            this.btnModificarAuto = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarAuto = new Gizmox.WebGUI.Forms.Button();
            this.lvVehiculos = new Gizmox.WebGUI.Forms.ListView();
            this.chDominio = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chMarca = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chModelo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.ucCliente = new AppGest.Vista.Controles.ucClienteAbrev();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.pnCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.Dock = Gizmox.WebGUI.Forms.DockStyle.None;
            this.lblTituloBase.Location = new System.Drawing.Point(12, 17);
            this.lblTituloBase.Text = "Datos del cliente, autos y asociación a cocheras";
            // 
            // pnCabecera
            // 
            this.pnCabecera.Controls.Add(this.imgImagen);
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(998, 68);
            this.pnCabecera.Controls.SetChildIndex(this.lblTituloBase, 0);
            this.pnCabecera.Controls.SetChildIndex(this.imgImagen, 0);
            // 
            // imgImagen
            // 
            this.imgImagen.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            this.imgImagen.Location = new System.Drawing.Point(877, 0);
            this.imgImagen.Name = "imgImagen";
            this.imgImagen.Size = new System.Drawing.Size(64, 64);
            this.imgImagen.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImagen.TabIndex = 1;
            this.imgImagen.TabStop = false;
            // 
            // btnEditarCochera
            // 
            this.btnEditarCochera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnEditarCochera.CustomStyle = "F";
            this.btnEditarCochera.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEditarCochera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEditarCochera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditarCochera.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnEditarCochera.Image"));
            this.btnEditarCochera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCochera.Location = new System.Drawing.Point(620, 220);
            this.btnEditarCochera.Name = "btnEditarCochera";
            this.btnEditarCochera.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnEditarCochera.Size = new System.Drawing.Size(87, 30);
            this.btnEditarCochera.TabIndex = 8;
            this.btnEditarCochera.Text = "Editar";
            this.btnEditarCochera.Click += new System.EventHandler(this.btnEditarCochera_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(510, 184);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // lblCocherasAsoc
            // 
            this.lblCocherasAsoc.AutoSize = true;
            this.lblCocherasAsoc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCocherasAsoc.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCocherasAsoc.Location = new System.Drawing.Point(546, 191);
            this.lblCocherasAsoc.Name = "lblCocherasAsoc";
            this.lblCocherasAsoc.Size = new System.Drawing.Size(145, 21);
            this.lblCocherasAsoc.TabIndex = 6;
            this.lblCocherasAsoc.Text = "Cocheras asociadas";
            // 
            // btnAsociar
            // 
            this.btnAsociar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAsociar.CustomStyle = "F";
            this.btnAsociar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAsociar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAsociar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAsociar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAsociar.Image"));
            this.btnAsociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsociar.Location = new System.Drawing.Point(510, 220);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnAsociar.Size = new System.Drawing.Size(97, 30);
            this.btnAsociar.TabIndex = 7;
            this.btnAsociar.Text = "Asociar";
            this.btnAsociar.Click += new System.EventHandler(this.btnAgregarCochera_Click);
            // 
            // lvCocherasAsoc
            // 
            this.lvCocherasAsoc.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lvCocherasAsoc.AutoGenerateColumns = true;
            this.lvCocherasAsoc.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lvCocherasAsoc.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent;
            this.lvCocherasAsoc.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.chNroCochera,
            this.chServicio,
            this.chServDesde,
            this.chServHasta});
            this.lvCocherasAsoc.DataMember = null;
            this.lvCocherasAsoc.FullRowSelect = true;
            this.lvCocherasAsoc.GridLines = true;
            this.lvCocherasAsoc.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCocherasAsoc.ItemsPerPage = 20;
            this.lvCocherasAsoc.Location = new System.Drawing.Point(510, 254);
            this.lvCocherasAsoc.MultiSelect = false;
            this.lvCocherasAsoc.Name = "lvCocherasAsoc";
            this.lvCocherasAsoc.ShowGroups = false;
            this.lvCocherasAsoc.ShowItemToolTips = false;
            this.lvCocherasAsoc.Size = new System.Drawing.Size(431, 112);
            this.lvCocherasAsoc.TabIndex = 9;
            // 
            // chNroCochera
            // 
            this.chNroCochera.Image = null;
            this.chNroCochera.Text = "Cochera";
            this.chNroCochera.Width = 57;
            // 
            // chServicio
            // 
            this.chServicio.Image = null;
            this.chServicio.Text = "Servicio";
            this.chServicio.Width = 148;
            // 
            // chServDesde
            // 
            this.chServDesde.Image = null;
            this.chServDesde.Text = "Desde";
            this.chServDesde.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Date;
            this.chServDesde.Width = 60;
            // 
            // chServHasta
            // 
            this.chServHasta.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            this.chServHasta.Image = null;
            this.chServHasta.Text = "Hasta";
            this.chServHasta.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Date;
            this.chServHasta.Width = 60;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(510, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(544, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Autos asociados";
            // 
            // btnBajaAuto
            // 
            this.btnBajaAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnBajaAuto.CustomStyle = "F";
            this.btnBajaAuto.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBajaAuto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBajaAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBajaAuto.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBajaAuto.Image"));
            this.btnBajaAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajaAuto.Location = new System.Drawing.Point(720, 48);
            this.btnBajaAuto.Name = "btnBajaAuto";
            this.btnBajaAuto.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBajaAuto.Size = new System.Drawing.Size(110, 29);
            this.btnBajaAuto.TabIndex = 4;
            this.btnBajaAuto.Text = "Dar de baja";
            this.btnBajaAuto.Click += new System.EventHandler(this.btnBajaAuto_Click);
            // 
            // btnModificarAuto
            // 
            this.btnModificarAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnModificarAuto.CustomStyle = "F";
            this.btnModificarAuto.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnModificarAuto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnModificarAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModificarAuto.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnModificarAuto.Image"));
            this.btnModificarAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarAuto.Location = new System.Drawing.Point(620, 48);
            this.btnModificarAuto.Name = "btnModificarAuto";
            this.btnModificarAuto.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnModificarAuto.Size = new System.Drawing.Size(87, 29);
            this.btnModificarAuto.TabIndex = 3;
            this.btnModificarAuto.Text = "Editar";
            this.btnModificarAuto.Click += new System.EventHandler(this.btnModificarAuto_Click);
            // 
            // btnAgregarAuto
            // 
            this.btnAgregarAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregarAuto.CustomStyle = "F";
            this.btnAgregarAuto.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarAuto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarAuto.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregarAuto.Image"));
            this.btnAgregarAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarAuto.Location = new System.Drawing.Point(510, 48);
            this.btnAgregarAuto.Name = "btnAgregarAuto";
            this.btnAgregarAuto.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnAgregarAuto.Size = new System.Drawing.Size(97, 29);
            this.btnAgregarAuto.TabIndex = 2;
            this.btnAgregarAuto.Text = "Agregar";
            this.btnAgregarAuto.Click += new System.EventHandler(this.btnAgregarAuto_Click);
            // 
            // lvVehiculos
            // 
            this.lvVehiculos.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lvVehiculos.AutoGenerateColumns = true;
            this.lvVehiculos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lvVehiculos.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.chDominio,
            this.chMarca,
            this.chModelo});
            this.lvVehiculos.DataMember = null;
            this.lvVehiculos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvVehiculos.FullRowSelect = true;
            this.lvVehiculos.GridLines = true;
            this.lvVehiculos.ItemsPerPage = 20;
            this.lvVehiculos.Location = new System.Drawing.Point(510, 81);
            this.lvVehiculos.Name = "lvAutos";
            this.lvVehiculos.ShowItemToolTips = false;
            this.lvVehiculos.Size = new System.Drawing.Size(435, 97);
            this.lvVehiculos.TabIndex = 5;
            this.lvVehiculos.SelectedIndexChanged += new System.EventHandler(this.lvVehiculos_SelectedIndexChanged);
            // 
            // chDominio
            // 
            this.chDominio.Image = null;
            this.chDominio.Text = "Dominio";
            this.chDominio.Width = 105;
            // 
            // chMarca
            // 
            this.chMarca.Image = null;
            this.chMarca.Text = "Marca";
            this.chMarca.Width = 143;
            // 
            // chModelo
            // 
            this.chModelo.Image = null;
            this.chModelo.Text = "Modelo";
            this.chModelo.Width = 182;
            // 
            // ucCliente
            // 
            this.ucCliente.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.ucCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucCliente.DockPadding.All = 3;
            this.ucCliente.KeySolapa = null;
            this.ucCliente.Location = new System.Drawing.Point(3, 4);
            this.ucCliente.MensajeUsuario = null;
            this.ucCliente.MostrarBarra = false;
            this.ucCliente.MostrarCabecera = false;
            this.ucCliente.Name = "ucCliente";
            this.ucCliente.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucCliente.Size = new System.Drawing.Size(485, 411);
            this.ucCliente.TabIndex = 0;
            this.ucCliente.Text = "ucClienteAbrev";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 427);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.ucCliente);
            this.panel2.Controls.Add(this.btnEditarCochera);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblCocherasAsoc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lvCocherasAsoc);
            this.panel2.Controls.Add(this.lvVehiculos);
            this.panel2.Controls.Add(this.btnAsociar);
            this.panel2.Controls.Add(this.btnAgregarAuto);
            this.panel2.Controls.Add(this.btnBajaAuto);
            this.panel2.Controls.Add(this.btnModificarAuto);
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 417);
            this.panel2.TabIndex = 0;
            // 
            // ucMensuales
            // 
            this.Controls.Add(this.panel1);
            this.DockPadding.All = 3;
            this.Location = new System.Drawing.Point(0, -1);
            this.Size = new System.Drawing.Size(1004, 529);
            this.Text = "ucMensuales";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.pnCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox imgImagen;
        private ucClienteAbrev ucCliente;
        private Button btnAsociar;
        private ListView lvCocherasAsoc;
        public AppGest.ControlBase.Label lblCocherasAsoc;
        private ColumnHeader chNroCochera;
        private ListView lvVehiculos;
        private ColumnHeader chDominio;
        private ColumnHeader chMarca;
        private ColumnHeader chModelo;
        private Button btnAgregarAuto;
        private Button btnModificarAuto;
        private Button btnBajaAuto;
        private Panel panel1;
        public AppGest.ControlBase.Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ColumnHeader chServicio;
        private ColumnHeader chServHasta;
        private ColumnHeader chServDesde;
        private Button btnEditarCochera;
        private Panel panel2;



    }
}