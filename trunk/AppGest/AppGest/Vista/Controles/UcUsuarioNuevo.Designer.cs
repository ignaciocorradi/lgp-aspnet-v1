using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcUsuarioNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcUsuarioNuevo));
            this.lblConfirmClave = new AppGest.ControlBase.Label();
            this.txtClave = new AppGest.ControlBase.TextBox();
            this.txtConfirmClave = new AppGest.ControlBase.TextBox();
            this.lblPass = new AppGest.ControlBase.Label();
            this.lblUsuario = new AppGest.ControlBase.Label();
            this.txtUsuario = new AppGest.ControlBase.TextBox();
            this.cmbTipo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTipo = new AppGest.ControlBase.Label();
            this.pnlContacto.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContacto
            // 
            this.pnlContacto.Location = new System.Drawing.Point(9, 211);
            this.pnlContacto.TabIndex = 8;
            // 
            // lblNombre2
            // 
            this.lblNombre2.Visible = false;
            // 
            // txtNombre2
            // 
            this.txtNombre2.Visible = false;
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // txtDni
            // 
            this.txtDni.Visible = false;
            // 
            // pnlNombre
            // 
            this.pnlNombre.Location = new System.Drawing.Point(9, 157);
            this.pnlNombre.Size = new System.Drawing.Size(585, 52);
            this.pnlNombre.TabIndex = 7;
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(9, 361);
            this.pnlFechas.TabIndex = 9;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(9, 0);
            // 
            // imgImagen
            // 
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos de usuario del sistema";
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.lblTipo);
            this.pnlBase.Controls.Add(this.cmbTipo);
            this.pnlBase.Controls.Add(this.txtUsuario);
            this.pnlBase.Controls.Add(this.lblUsuario);
            this.pnlBase.Controls.Add(this.lblPass);
            this.pnlBase.Controls.Add(this.txtConfirmClave);
            this.pnlBase.Controls.Add(this.txtClave);
            this.pnlBase.Controls.Add(this.lblConfirmClave);
            this.pnlBase.Size = new System.Drawing.Size(621, 496);
            this.pnlBase.Controls.SetChildIndex(this.pnlContacto, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlNombre, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlFechas, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlCabecera, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtObservacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblObs, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblConfirmClave, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtClave, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtConfirmClave, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblPass, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(this.cmbTipo, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTipo, 0);
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(30, 453);
            this.lblObs.TabIndex = 12;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(30, 469);
            this.txtObservacion.TabIndex = 13;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(30, 430);
            this.txtDesc.TabIndex = 11;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(30, 414);
            this.lblDescripcion.TabIndex = 10;
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(621, 28);
            // 
            // lblConfirmClave
            // 
            this.lblConfirmClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblConfirmClave.AutoSize = true;
            this.lblConfirmClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmClave.Location = new System.Drawing.Point(272, 116);
            this.lblConfirmClave.Name = "lblConfirmClave";
            this.lblConfirmClave.Size = new System.Drawing.Size(106, 13);
            this.lblConfirmClave.TabIndex = 5;
            this.lblConfirmClave.Text = "Repita la contraseña";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtClave.Location = new System.Drawing.Point(33, 132);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(223, 20);
            this.txtClave.TabIndex = 4;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // txtConfirmClave
            // 
            this.txtConfirmClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtConfirmClave.Location = new System.Drawing.Point(272, 132);
            this.txtConfirmClave.Name = "txtConfirmClave";
            this.txtConfirmClave.PasswordChar = '*';
            this.txtConfirmClave.Size = new System.Drawing.Size(231, 20);
            this.txtConfirmClave.TabIndex = 6;
            this.txtConfirmClave.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPass.Location = new System.Drawing.Point(33, 116);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(63, 13);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsuario.Location = new System.Drawing.Point(33, 75);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(35, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtUsuario.Location = new System.Drawing.Point(33, 93);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(223, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(272, 92);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(231, 21);
            this.cmbTipo.TabIndex = 14;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTipo.Location = new System.Drawing.Point(272, 75);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(35, 13);
            this.lblTipo.TabIndex = 15;
            this.lblTipo.Text = "Tipo";
            // 
            // UcUsuarioNuevo
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(627, 530);
            this.Text = "UcUsuarioNuevo";
            this.pnlContacto.ResumeLayout(false);
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label lblPass;
        public TextBox txtConfirmClave;
        public TextBox txtClave;
        private AppGest.ControlBase.Label lblConfirmClave;
        private AppGest.ControlBase.TextBox txtUsuario;
        private AppGest.ControlBase.Label lblUsuario;
        private AppGest.ControlBase.Label lblTipo;
        private ComboBox cmbTipo;



    }
}