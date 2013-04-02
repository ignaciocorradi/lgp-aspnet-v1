using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucPersona
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
            this.txtApellido = new AppGest.ControlBase.TextBox();
            this.lblApellido = new AppGest.ControlBase.Label();
            this.txtDomicilio = new AppGest.ControlBase.TextBox();
            this.lblDomicilio = new AppGest.ControlBase.Label();
            this.lblTelefono2 = new AppGest.ControlBase.Label();
            this.txtTel2 = new AppGest.ControlBase.TextBox();
            this.txtTel = new AppGest.ControlBase.TextBox();
            this.lblTelefono = new AppGest.ControlBase.Label();
            this.txtMovil = new AppGest.ControlBase.TextBox();
            this.lblCelular = new AppGest.ControlBase.Label();
            this.txtMail = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.lblNombre2 = new AppGest.ControlBase.Label();
            this.txtNombre2 = new AppGest.ControlBase.TextBox();
            this.pnlContacto = new Gizmox.WebGUI.Forms.Panel();
            this.lblEmail = new AppGest.ControlBase.Label();
            this.txtDni = new AppGest.ControlBase.TextBox();
            this.label1 = new AppGest.ControlBase.Label();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnCabecera.SuspendLayout();
            this.pnlContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNombre
            // 
            this.pnlNombre.Controls.Add(this.label1);
            this.pnlNombre.Controls.Add(this.txtNombre2);
            this.pnlNombre.Controls.Add(this.txtApellido);
            this.pnlNombre.Controls.Add(this.lblApellido);
            this.pnlNombre.Controls.Add(this.lblNombre2);
            this.pnlNombre.Controls.Add(this.txtDni);
            this.pnlNombre.Location = new System.Drawing.Point(3, 72);
            this.pnlNombre.Size = new System.Drawing.Size(585, 92);
            this.pnlNombre.Controls.SetChildIndex(this.txtDni, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre2, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblApellido, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtApellido, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre2, 0);
            this.pnlNombre.Controls.SetChildIndex(this.label1, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblAlias, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre, 0);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(3, 315);
            this.pnlFechas.Size = new System.Drawing.Size(585, 48);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(3, 0);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(19, 26);
            this.lblTitulo.Text = "Datos de Persona";
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlContacto);
            this.pnlBase.Size = new System.Drawing.Size(608, 367);
            this.pnlBase.Controls.SetChildIndex(this.pnlContacto, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlNombre, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlFechas, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlCabecera, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtObservacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblObs, 0);
            // 
            // lblFechaA
            // 
            this.lblFechaA.EsObligatorio = true;
            this.lblFechaA.Text = "Fecha Alta *";
            // 
            // txtFechaB
            // 
            this.txtFechaB.TextMaskFormat = Gizmox.WebGUI.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblAlias
            // 
            this.lblAlias.Location = new System.Drawing.Point(473, 7);
            this.lblAlias.TabIndex = 4;
            this.lblAlias.Text = "Iniciales";
            this.lblAlias.Visible = false;
            // 
            // lblObs
            // 
            this.lblObs.Enabled = false;
            this.lblObs.Location = new System.Drawing.Point(24, 407);
            this.lblObs.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Enabled = false;
            this.lblDescripcion.Location = new System.Drawing.Point(24, 368);
            this.lblDescripcion.Visible = false;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(476, 26);
            this.txtAbreviatura.ReadOnly = true;
            this.txtAbreviatura.Size = new System.Drawing.Size(90, 20);
            this.txtAbreviatura.TabIndex = 5;
            this.txtAbreviatura.Visible = false;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(24, 421);
            this.txtObservacion.Visible = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(24, 384);
            this.txtDesc.Visible = false;
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(608, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtApellido.Location = new System.Drawing.Point(260, 26);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.SelectTextOnGotFocus = true;
            this.txtApellido.Size = new System.Drawing.Size(210, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblApellido.AutoSize = true;
            this.lblApellido.EsObligatorio = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApellido.Location = new System.Drawing.Point(260, 7);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido *";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtDomicilio.Location = new System.Drawing.Point(21, 21);
            this.txtDomicilio.Multiline = true;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.SelectTextOnGotFocus = true;
            this.txtDomicilio.Size = new System.Drawing.Size(545, 48);
            this.txtDomicilio.TabIndex = 1;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDomicilio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDomicilio.Location = new System.Drawing.Point(21, 5);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(47, 13);
            this.lblDomicilio.TabIndex = 0;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // lblTelefono2
            // 
            this.lblTelefono2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTelefono2.AutoSize = true;
            this.lblTelefono2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTelefono2.Location = new System.Drawing.Point(260, 72);
            this.lblTelefono2.Name = "lblTelefono2";
            this.lblTelefono2.Size = new System.Drawing.Size(60, 13);
            this.lblTelefono2.TabIndex = 4;
            this.lblTelefono2.Text = "Tel. laboral";
            // 
            // txtTel2
            // 
            this.txtTel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtTel2.Location = new System.Drawing.Point(260, 88);
            this.txtTel2.MaxLength = 15;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.SelectTextOnGotFocus = true;
            this.txtTel2.Size = new System.Drawing.Size(308, 20);
            this.txtTel2.TabIndex = 5;
            this.txtTel2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTel
            // 
            this.txtTel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtTel.Location = new System.Drawing.Point(21, 88);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.SelectTextOnGotFocus = true;
            this.txtTel.Size = new System.Drawing.Size(223, 20);
            this.txtTel.TabIndex = 3;
            this.txtTel.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTelefono.Location = new System.Drawing.Point(21, 72);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtMovil
            // 
            this.txtMovil.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtMovil.Location = new System.Drawing.Point(21, 127);
            this.txtMovil.MaxLength = 15;
            this.txtMovil.Name = "txtMovil";
            this.txtMovil.SelectTextOnGotFocus = true;
            this.txtMovil.Size = new System.Drawing.Size(223, 20);
            this.txtMovil.TabIndex = 7;
            this.txtMovil.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblCelular
            // 
            this.lblCelular.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCelular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCelular.Location = new System.Drawing.Point(21, 111);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(40, 13);
            this.lblCelular.TabIndex = 6;
            this.lblCelular.Text = "Celular";
            // 
            // txtMail
            // 
            this.txtMail.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtMail.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtMail.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtMail.CustomStyle = "Masked";
            this.txtMail.Location = new System.Drawing.Point(260, 127);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(308, 20);
            this.txtMail.TabIndex = 9;
            // 
            // lblNombre2
            // 
            this.lblNombre2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblNombre2.AutoSize = true;
            this.lblNombre2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre2.Location = new System.Drawing.Point(21, 52);
            this.lblNombre2.Name = "lblNombre2";
            this.lblNombre2.Size = new System.Drawing.Size(58, 13);
            this.lblNombre2.TabIndex = 6;
            this.lblNombre2.Text = "2º Nombre";
            // 
            // txtNombre2
            // 
            this.txtNombre2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtNombre2.Location = new System.Drawing.Point(21, 68);
            this.txtNombre2.Name = "txtNombre2";
            this.txtNombre2.SelectTextOnGotFocus = true;
            this.txtNombre2.Size = new System.Drawing.Size(223, 20);
            this.txtNombre2.TabIndex = 7;
            // 
            // pnlContacto
            // 
            this.pnlContacto.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlContacto.Controls.Add(this.lblDomicilio);
            this.pnlContacto.Controls.Add(this.lblTelefono2);
            this.pnlContacto.Controls.Add(this.txtTel2);
            this.pnlContacto.Controls.Add(this.lblEmail);
            this.pnlContacto.Controls.Add(this.txtDomicilio);
            this.pnlContacto.Controls.Add(this.txtMail);
            this.pnlContacto.Controls.Add(this.txtTel);
            this.pnlContacto.Controls.Add(this.lblCelular);
            this.pnlContacto.Controls.Add(this.lblTelefono);
            this.pnlContacto.Controls.Add(this.txtMovil);
            this.pnlContacto.Location = new System.Drawing.Point(3, 164);
            this.pnlContacto.Name = "pnlContacto";
            this.pnlContacto.Size = new System.Drawing.Size(585, 150);
            this.pnlContacto.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(260, 111);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(31, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(260, 68);
            this.txtDni.MaxLength = 10;
            this.txtDni.Name = "txtDni";
            this.txtDni.SelectTextOnGotFocus = true;
            this.txtDni.Size = new System.Drawing.Size(151, 20);
            this.txtDni.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(263, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Doc. de Identidad";
            // 
            // ucPersona
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(614, 401);
            this.Text = "ucPersona";
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnCabecera.ResumeLayout(false);
            this.pnlContacto.ResumeLayout(false);
            this.ResumeLayout(false);

        }



           public Panel pnlContacto;
           public AppGest.ControlBase.Label lblApellido;
        public AppGest.ControlBase.Label lblDomicilio;
        public AppGest.ControlBase.Label lblTelefono2;
        public AppGest.ControlBase.Label lblTelefono;
        public AppGest.ControlBase.Label lblCelular;
        public MaskedTextBox txtMail;
        public AppGest.ControlBase.Label lblNombre2;
        public AppGest.ControlBase.Label lblEmail;
        #endregion
        protected AppGest.ControlBase.Label label1;
        public ControlBase.TextBox txtDomicilio;
        public ControlBase.TextBox txtTel2;
        public ControlBase.TextBox txtTel;
        public ControlBase.TextBox txtMovil;
        public ControlBase.TextBox txtNombre2;
        protected ControlBase.TextBox txtDni;
        protected ControlBase.TextBox txtApellido;






    }
}