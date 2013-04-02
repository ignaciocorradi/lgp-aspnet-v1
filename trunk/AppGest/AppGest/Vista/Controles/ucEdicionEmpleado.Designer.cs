using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucEdicionEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEdicionEmpleado));
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.rbtnDadosDeBaja = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnActivos = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.txtApellido = new AppGest.ControlBase.TextBox();
            this.lblApellido = new AppGest.ControlBase.Label();
            this.lblNombre = new AppGest.ControlBase.Label();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Location = new System.Drawing.Point(5, 5);
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucGrilla1.Location = new System.Drawing.Point(5, 114);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(969, 365);
            this.ucGrilla1.TabIndex = 2;
            this.ucGrilla1.Text = "ucGrillaEntidades";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.pictureBox1);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.rbtnDadosDeBaja);
            this.grpFiltros.Controls.Add(this.rbtnActivos);
            this.grpFiltros.Controls.Add(this.rbtnTodos);
            this.grpFiltros.Controls.Add(this.txtApellido);
            this.grpFiltros.Controls.Add(this.lblApellido);
            this.grpFiltros.Controls.Add(this.lblNombre);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(5, 33);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(969, 81);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(902, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
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
            this.btnBuscar.Location = new System.Drawing.Point(727, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(107, 34);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rbtnDadosDeBaja
            // 
            this.rbtnDadosDeBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDadosDeBaja.Location = new System.Drawing.Point(605, 38);
            this.rbtnDadosDeBaja.Name = "rbtnDadosDeBaja";
            this.rbtnDadosDeBaja.Size = new System.Drawing.Size(110, 17);
            this.rbtnDadosDeBaja.TabIndex = 6;
            this.rbtnDadosDeBaja.Text = "Dados de baja";
            // 
            // rbtnActivos
            // 
            this.rbtnActivos.AutoSize = true;
            this.rbtnActivos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnActivos.Location = new System.Drawing.Point(452, 38);
            this.rbtnActivos.Name = "rbtnActivos";
            this.rbtnActivos.Size = new System.Drawing.Size(61, 17);
            this.rbtnActivos.TabIndex = 5;
            this.rbtnActivos.Text = "Activos";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Checked = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.Location = new System.Drawing.Point(531, 38);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(56, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.Text = "Todos";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(238, 36);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApellido.Location = new System.Drawing.Point(238, 17);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(35, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(14, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(14, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // ucEdicionEmpleado
            // 
            this.Controls.Add(this.ucGrilla1);
            this.Controls.Add(this.grpFiltros);
            this.DockPadding.All = 5;
            this.MensajeUsuario = "Desde aquí prodrá editar los datos de empleados existentes.";
            this.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.Size = new System.Drawing.Size(979, 484);
            this.Text = "ucEdicionEmpleado";
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.grpFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrilla1;
        private GroupBox grpFiltros;
        private Button btnBuscar;
        private RadioButton rbtnDadosDeBaja;
        private RadioButton rbtnActivos;
        private RadioButton rbtnTodos;
        private AppGest.ControlBase.TextBox txtApellido;
        private AppGest.ControlBase.Label lblApellido;
        private AppGest.ControlBase.Label lblNombre;
        private AppGest.ControlBase.TextBox txtNombre;
        private PictureBox pictureBox1;
  


    }
}