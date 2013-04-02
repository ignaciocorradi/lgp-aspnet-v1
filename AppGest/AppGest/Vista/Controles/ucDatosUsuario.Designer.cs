using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucDatosUsuario
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
            this.txtClave = new AppGest.ControlBase.TextBox();
            this.lblPass = new AppGest.ControlBase.Label();
            this.lblConfirmClave = new AppGest.ControlBase.Label();
            this.txtConfirmClave = new AppGest.ControlBase.TextBox();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNombre
            // 
            this.pnlNombre.Controls.Add(this.lblConfirmClave);
            this.pnlNombre.Controls.Add(this.txtClave);
            this.pnlNombre.Controls.Add(this.txtConfirmClave);
            this.pnlNombre.Controls.Add(this.lblPass);
            this.pnlNombre.Location = new System.Drawing.Point(9, 73);
            this.pnlNombre.Size = new System.Drawing.Size(497, 87);
            this.pnlNombre.Controls.SetChildIndex(this.lblPass, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtConfirmClave, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtClave, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblConfirmClave, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblAlias, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtNombre, 0);
            this.pnlNombre.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.pnlNombre.Controls.SetChildIndex(this.lblNombre, 0);
            // 
            // pnlFechas
            // 
            this.pnlFechas.Location = new System.Drawing.Point(9, 161);
            this.pnlFechas.Size = new System.Drawing.Size(497, 46);
            this.pnlFechas.Visible = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Location = new System.Drawing.Point(9, 0);
            this.pnlCabecera.Size = new System.Drawing.Size(497, 72);
            // 
            // imgImagen
            // 
            this.imgImagen.Location = new System.Drawing.Point(379, 4);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Datos del usuario";
            // 
            // pnlBase
            // 
            this.pnlBase.Size = new System.Drawing.Size(514, 298);
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(13, 7);
            this.lblNombre.Text = "Usuario";
            // 
            // lblFechaA
            // 
            this.lblFechaA.Location = new System.Drawing.Point(13, 5);
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Location = new System.Drawing.Point(13, 21);
            this.dtpFechaA.TabIndex = 2;
            // 
            // lblFechaB
            // 
            this.lblFechaB.Location = new System.Drawing.Point(167, 5);
            this.lblFechaB.TabIndex = 1;
            // 
            // txtFechaB
            // 
            this.txtFechaB.Location = new System.Drawing.Point(165, 21);
            // 
            // lblAlias
            // 
            this.lblAlias.Location = new System.Drawing.Point(252, 7);
            // 
            // lblObs
            // 
            this.lblObs.Location = new System.Drawing.Point(22, 251);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(22, 211);
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(252, 26);
            this.txtAbreviatura.Size = new System.Drawing.Size(231, 20);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(22, 265);
            this.txtObservacion.Size = new System.Drawing.Size(473, 20);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(22, 227);
            this.txtDesc.Size = new System.Drawing.Size(473, 20);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(13, 26);
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(514, 28);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // txtClave
            // 
            this.txtClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtClave.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtClave.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(13, 64);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.SelectTextOnGotFocus = true;
            this.txtClave.Size = new System.Drawing.Size(223, 20);
            this.txtClave.TabIndex = 5;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblPass.AutoSize = true;
            this.lblPass.EsObligatorio = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPass.Location = new System.Drawing.Point(13, 49);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(63, 13);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Contraseña *";
            // 
            // lblConfirmClave
            // 
            this.lblConfirmClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblConfirmClave.AutoSize = true;
            this.lblConfirmClave.EsObligatorio = true;
            this.lblConfirmClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmClave.Location = new System.Drawing.Point(252, 49);
            this.lblConfirmClave.Name = "lblConfirmClave";
            this.lblConfirmClave.Size = new System.Drawing.Size(106, 13);
            this.lblConfirmClave.TabIndex = 6;
            this.lblConfirmClave.Text = "Repita la contraseña *";
            // 
            // txtConfirmClave
            // 
            this.txtConfirmClave.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtConfirmClave.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtConfirmClave.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtConfirmClave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmClave.Location = new System.Drawing.Point(252, 64);
            this.txtConfirmClave.Name = "txtConfirmClave";
            this.txtConfirmClave.PasswordChar = '*';
            this.txtConfirmClave.SelectTextOnGotFocus = true;
            this.txtConfirmClave.Size = new System.Drawing.Size(231, 20);
            this.txtConfirmClave.TabIndex = 7;
            this.txtConfirmClave.UseSystemPasswordChar = true;
            // 
            // ucDatosUsuario
            // 
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(520, 332);
            this.Text = "ucDatosUsuario";
            this.Load += new System.EventHandler(this.ucDatosUsuario_Load);
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AppGest.ControlBase.Label lblPass;
        private AppGest.ControlBase.Label lblConfirmClave;
        public ControlBase.TextBox txtClave;
        public ControlBase.TextBox txtConfirmClave;


    }
}