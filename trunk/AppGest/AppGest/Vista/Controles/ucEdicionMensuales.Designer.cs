using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEdicionMensuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEdicionMensuales));
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnActivos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnDadosDeBaja = new Gizmox.WebGUI.Forms.RadioButton();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblMensajes = new AppGest.ControlBase.Label();
            this.txtNroCliente = new AppGest.ControlBase.TextBox();
            this.label4 = new AppGest.ControlBase.Label();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.txtCochera = new AppGest.ControlBase.TextBox();
            this.txtVehiculo = new AppGest.ControlBase.TextBox();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.DockPadding.All = 1;
            this.ucGrilla1.Location = new System.Drawing.Point(3, 128);
            this.ucGrilla1.Size = new System.Drawing.Size(957, 210);
            this.ucGrilla1.TabIndex = 1;
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(957, 28);
            this.tbMenu.TabIndex = 2;
            // 
            // tbtnCancelar
            // 
            this.tbtnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCancelar.Image"));
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.rbtnTodos);
            this.grpFiltros.Controls.Add(this.rbtnActivos);
            this.grpFiltros.Controls.Add(this.rbtnDadosDeBaja);
            this.grpFiltros.Controls.Add(this.pictureBox1);
            this.grpFiltros.Controls.Add(this.lblMensajes);
            this.grpFiltros.Controls.Add(this.txtNroCliente);
            this.grpFiltros.Controls.Add(this.label4);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.label3);
            this.grpFiltros.Controls.Add(this.label2);
            this.grpFiltros.Controls.Add(this.txtCochera);
            this.grpFiltros.Controls.Add(this.txtVehiculo);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(3, 31);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(957, 97);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnTodos.Location = new System.Drawing.Point(110, 71);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(56, 17);
            this.rbtnTodos.TabIndex = 7;
            this.rbtnTodos.Text = "Todos";
            // 
            // rbtnActivos
            // 
            this.rbtnActivos.AutoSize = true;
            this.rbtnActivos.Checked = true;
            this.rbtnActivos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnActivos.Location = new System.Drawing.Point(25, 71);
            this.rbtnActivos.Name = "rbtnActivos";
            this.rbtnActivos.Size = new System.Drawing.Size(61, 17);
            this.rbtnActivos.TabIndex = 6;
            this.rbtnActivos.Text = "Activos";
            // 
            // rbtnDadosDeBaja
            // 
            this.rbtnDadosDeBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDadosDeBaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnDadosDeBaja.Location = new System.Drawing.Point(190, 71);
            this.rbtnDadosDeBaja.Name = "rbtnDadosDeBaja";
            this.rbtnDadosDeBaja.Size = new System.Drawing.Size(111, 17);
            this.rbtnDadosDeBaja.TabIndex = 8;
            this.rbtnDadosDeBaja.Text = "Dados de baja";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(888, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.lblMensajes.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblMensajes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMensajes.Location = new System.Drawing.Point(3, 82);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 12);
            this.lblMensajes.TabIndex = 9;
            this.lblMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNroCliente.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCliente.Location = new System.Drawing.Point(427, 45);
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.SelectTextOnGotFocus = true;
            this.txtNroCliente.Size = new System.Drawing.Size(72, 20);
            this.txtNroCliente.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(424, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nro. Cliente";
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
            this.btnBuscar.Location = new System.Drawing.Point(515, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(107, 34);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(311, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cochera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(198, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dominio vehículo:";
            // 
            // txtCochera
            // 
            this.txtCochera.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtCochera.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtCochera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCochera.Location = new System.Drawing.Point(314, 45);
            this.txtCochera.Name = "txtCochera";
            this.txtCochera.SelectTextOnGotFocus = true;
            this.txtCochera.Size = new System.Drawing.Size(100, 20);
            this.txtCochera.TabIndex = 5;
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtVehiculo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtVehiculo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehiculo.Location = new System.Drawing.Point(201, 45);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.SelectTextOnGotFocus = true;
            this.txtVehiculo.Size = new System.Drawing.Size(100, 20);
            this.txtVehiculo.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(22, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // ucEdicionMensuales
            // 
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(963, 341);
            this.Text = "ucEdicionMensuales";
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

        private GroupBox grpFiltros;
        private AppGest.ControlBase.Label label3;
        private AppGest.ControlBase.Label label2;
        private AppGest.ControlBase.TextBox txtCochera;
        private AppGest.ControlBase.TextBox txtVehiculo;
        private AppGest.ControlBase.TextBox txtNombre;
        private AppGest.ControlBase.Label label1;
        private Button btnBuscar;
        private AppGest.ControlBase.TextBox txtNroCliente;
        private AppGest.ControlBase.Label label4;
        private ControlBase.Label lblMensajes;
        private PictureBox pictureBox1;
        private RadioButton rbtnTodos;
        private RadioButton rbtnActivos;
        private RadioButton rbtnDadosDeBaja;


    }
}