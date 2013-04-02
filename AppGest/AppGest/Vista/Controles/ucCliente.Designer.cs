using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucCliente
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
            this.label2 = new AppGest.ControlBase.Label();
            this.txtNroCliente = new AppGest.ControlBase.TextBox();
            this.label3 = new AppGest.ControlBase.Label();
            this.txtCUIT = new AppGest.ControlBase.TextBox();
            this.label4 = new AppGest.ControlBase.Label();
            this.label6 = new AppGest.ControlBase.Label();
            this.label7 = new AppGest.ControlBase.Label();
            this.txtRazonSocial = new AppGest.ControlBase.TextBox();
            this.txtDomicilioFiscal = new AppGest.ControlBase.TextBox();
            this.pnlEmpresa = new Gizmox.WebGUI.Forms.Panel();
            this.txtDomVe = new AppGest.ControlBase.TextBox();
            this.lblDatoVe = new AppGest.ControlBase.Label();
            this.pnlContacto.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnCabecera.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContacto
            // 
            this.pnlContacto.Controls.Add(this.lblDatoVe);
            this.pnlContacto.Controls.Add(this.txtDomVe);
            this.pnlContacto.Location = new System.Drawing.Point(7, 122);
            this.pnlContacto.Controls.SetChildIndex(this.txtMovil, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblTelefono, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblCelular, 0);
            this.pnlContacto.Controls.SetChildIndex(this.txtTel, 0);
            this.pnlContacto.Controls.SetChildIndex(this.txtMail, 0);
            this.pnlContacto.Controls.SetChildIndex(this.txtDomicilio, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblEmail, 0);
            this.pnlContacto.Controls.SetChildIndex(this.txtTel2, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblTelefono2, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblDomicilio, 0);
            this.pnlContacto.Controls.SetChildIndex(this.txtDomVe, 0);
            this.pnlContacto.Controls.SetChildIndex(this.lblDatoVe, 0);
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.Location = new System.Drawing.Point(257, 2);
            // 
            // lblTelefono2
            // 
            this.lblTelefono2.TabIndex = 3;
            // 
            // lblTelefono
            // 
            this.lblTelefono.TabIndex = 1;
            // 
            // lblCelular
            // 
            this.lblCelular.TabIndex = 5;
            // 
            // txtMail
            // 
            this.txtMail.TabIndex = 8;
            // 
            // lblNombre2
            // 
            this.lblNombre2.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(260, 52);
            this.label1.TabIndex = 7;
            this.label1.Visible = false;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(257, 18);
            this.txtDomicilio.Size = new System.Drawing.Size(311, 48);
            this.txtDomicilio.TabIndex = 0;
            // 
            // txtTel2
            // 
            this.txtTel2.TabIndex = 4;
            // 
            // txtTel
            // 
            this.txtTel.TabIndex = 2;
            // 
            // txtMovil
            // 
            this.txtMovil.TabIndex = 6;
            // 
            // txtNombre2
            // 
            this.txtNombre2.TabIndex = 6;
            this.txtNombre2.Visible = false;
            // 
            // txtDni
            // 
            this.txtDni.TabIndex = 8;
            this.txtDni.Visible = false;
            // 
            // pnlNombre
            // 
            this.pnlNombre.Controls.Add(this.txtNroCliente);
            this.pnlNombre.Controls.Add(this.label2);
            this.pnlNombre.Location = new System.Drawing.Point(7, 72);
            this.pnlNombre.Size = new System.Drawing.Size(585, 49);
            this.pnlNombre.Controls.SetChildIndex(this.label2, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNroCliente, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblAlias, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtDni, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre2, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblApellido, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtApellido, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre2, 0);
            this.pnlNombre.Controls.SetChildIndex(this.label1, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre, 0);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(7, 275);
            this.pnlFechas.TabIndex = 3;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(7, 0);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos del cliente";
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlEmpresa);
            this.pnlBase.Size = new System.Drawing.Size(598, 565);
            this.pnlBase.Controls.SetChildIndex(this.pnlEmpresa, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlContacto, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlNombre, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlFechas, 0);
            this.pnlBase.Controls.SetChildIndex(this.pnlCabecera, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtObservacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblObs, 0);
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Enabled = true;
            // 
            // lblAlias
            // 
            this.lblAlias.Location = new System.Drawing.Point(414, 49);
            this.lblAlias.TabIndex = 10;
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(26, 517);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(26, 478);
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(417, 68);
            this.txtAbreviatura.Size = new System.Drawing.Size(19, 20);
            this.txtAbreviatura.TabIndex = 11;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(26, 533);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(26, 494);
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(598, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(476, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nro Cliente";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNroCliente.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCliente.Location = new System.Drawing.Point(479, 26);
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.SelectTextOnGotFocus = true;
            this.txtNroCliente.Size = new System.Drawing.Size(56, 20);
            this.txtNroCliente.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(13, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Datos de Empresa";
            // 
            // txtCUIT
            // 
            this.txtCUIT.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtCUIT.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtCUIT.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCUIT.Location = new System.Drawing.Point(261, 48);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.SelectTextOnGotFocus = true;
            this.txtCUIT.Size = new System.Drawing.Size(148, 20);
            this.txtCUIT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(259, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "CUIT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(19, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Domicilio Fiscal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(18, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtRazonSocial.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(21, 48);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.SelectTextOnGotFocus = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(221, 20);
            this.txtRazonSocial.TabIndex = 2;
            // 
            // txtDomicilioFiscal
            // 
            this.txtDomicilioFiscal.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtDomicilioFiscal.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtDomicilioFiscal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilioFiscal.Location = new System.Drawing.Point(22, 92);
            this.txtDomicilioFiscal.Multiline = true;
            this.txtDomicilioFiscal.Name = "txtDomicilioFiscal";
            this.txtDomicilioFiscal.SelectTextOnGotFocus = true;
            this.txtDomicilioFiscal.Size = new System.Drawing.Size(542, 46);
            this.txtDomicilioFiscal.TabIndex = 6;
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlEmpresa.Controls.Add(this.label3);
            this.pnlEmpresa.Controls.Add(this.label4);
            this.pnlEmpresa.Controls.Add(this.txtCUIT);
            this.pnlEmpresa.Controls.Add(this.label6);
            this.pnlEmpresa.Controls.Add(this.label7);
            this.pnlEmpresa.Controls.Add(this.txtRazonSocial);
            this.pnlEmpresa.Controls.Add(this.txtDomicilioFiscal);
            this.pnlEmpresa.Location = new System.Drawing.Point(7, 325);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Size = new System.Drawing.Size(585, 146);
            this.pnlEmpresa.TabIndex = 4;
            // 
            // txtDomVe
            // 
            this.txtDomVe.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtDomVe.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtDomVe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomVe.Location = new System.Drawing.Point(19, 18);
            this.txtDomVe.Name = "txtDomVe";
            this.txtDomVe.SelectTextOnGotFocus = true;
            this.txtDomVe.Size = new System.Drawing.Size(223, 20);
            this.txtDomVe.TabIndex = 9;
            // 
            // lblDatoVe
            // 
            this.lblDatoVe.AutoSize = true;
            this.lblDatoVe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDatoVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDatoVe.Location = new System.Drawing.Point(18, 2);
            this.lblDatoVe.Name = "lblDatoVe";
            this.lblDatoVe.Size = new System.Drawing.Size(38, 15);
            this.lblDatoVe.TabIndex = 0;
            this.lblDatoVe.Text = "Dominio vehículo";
            // 
            // ucCliente
            // 
            this.DockPadding.All = 3;
            this.Location = new System.Drawing.Point(0, -95);
            this.Size = new System.Drawing.Size(604, 599);
            this.Text = "ucCliente";
            this.pnlContacto.ResumeLayout(false);
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnCabecera.ResumeLayout(false);
            this.pnlEmpresa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected internal AppGest.ControlBase.Label label2;
        protected internal ControlBase.Label label3;
        protected internal ControlBase.TextBox txtDomicilioFiscal;
        protected internal ControlBase.TextBox txtRazonSocial;
        protected internal ControlBase.Label label7;
        protected internal ControlBase.Label label6;
        protected internal ControlBase.TextBox txtCUIT;
        protected internal ControlBase.Label label4;
        protected internal Panel pnlEmpresa;
        protected internal ControlBase.TextBox txtNroCliente;
        protected ControlBase.Label lblDatoVe;
        protected ControlBase.TextBox txtDomVe;




    }
}