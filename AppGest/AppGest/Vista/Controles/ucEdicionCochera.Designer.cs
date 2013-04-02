using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEdicionCochera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEdicionCochera));
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.rbtnTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnActivos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnDadosDeBaja = new Gizmox.WebGUI.Forms.RadioButton();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.lblNombre = new AppGest.ControlBase.Label();
            this.lblApellido = new AppGest.ControlBase.Label();
            this.txtDescripcion = new AppGest.ControlBase.TextBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.Location = new System.Drawing.Point(5, 114);
            this.ucGrilla1.Size = new System.Drawing.Size(921, 365);
            this.ucGrilla1.TabIndex = 1;
            // 
            // tbMenu
            // 
            this.tbMenu.Location = new System.Drawing.Point(5, 5);
            this.tbMenu.Size = new System.Drawing.Size(921, 28);
            this.tbMenu.TabIndex = 2;
            // 
            // tbtnCancelar
            // 
            this.tbtnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCancelar.Image"));
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.pictureBox1);
            this.grpFiltros.Controls.Add(this.rbtnTodos);
            this.grpFiltros.Controls.Add(this.rbtnActivos);
            this.grpFiltros.Controls.Add(this.rbtnDadosDeBaja);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Controls.Add(this.lblNombre);
            this.grpFiltros.Controls.Add(this.lblApellido);
            this.grpFiltros.Controls.Add(this.txtDescripcion);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(5, 33);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(921, 81);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(854, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.Checked = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnTodos.Location = new System.Drawing.Point(443, 35);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(60, 27);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.Text = "Todos";
            // 
            // rbtnActivos
            // 
            this.rbtnActivos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnActivos.Location = new System.Drawing.Point(323, 35);
            this.rbtnActivos.Name = "rbtnActivos";
            this.rbtnActivos.Size = new System.Drawing.Size(98, 27);
            this.rbtnActivos.TabIndex = 5;
            this.rbtnActivos.Text = "Solo activos";
            // 
            // rbtnDadosDeBaja
            // 
            this.rbtnDadosDeBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDadosDeBaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnDadosDeBaja.Location = new System.Drawing.Point(521, 35);
            this.rbtnDadosDeBaja.Name = "rbtnDadosDeBaja";
            this.rbtnDadosDeBaja.Size = new System.Drawing.Size(146, 27);
            this.rbtnDadosDeBaja.TabIndex = 6;
            this.rbtnDadosDeBaja.Text = "Solo dados de baja";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(77, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(15, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Cochera";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApellido.Location = new System.Drawing.Point(112, 20);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(35, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(112, 38);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 3;
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
            this.btnBuscar.Location = new System.Drawing.Point(686, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 34);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ucEdicionCochera
            // 
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 5;
            this.MensajeUsuario = "Desde aquí prodrá editar los datos de cocheras existentes.";
            this.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.Size = new System.Drawing.Size(931, 484);
            this.Text = "ucEdicionCliente";
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.grpFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private GroupBox grpFiltros;
        private AppGest.ControlBase.TextBox txtNombre;
        private AppGest.ControlBase.Label lblNombre;
        private AppGest.ControlBase.Label lblApellido;
        private AppGest.ControlBase.TextBox txtDescripcion;
        private Button btnBuscar;
        private RadioButton rbtnTodos;
        private RadioButton rbtnActivos;
        private RadioButton rbtnDadosDeBaja;
        private PictureBox pictureBox1;
 
  


    }
}