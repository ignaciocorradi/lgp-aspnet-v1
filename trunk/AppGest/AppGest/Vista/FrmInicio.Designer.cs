using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.btnIniciar = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.txtUsuario = new AppGest.ControlBase.TextBox();
            this.txtClave = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.lblNuevoUsr = new Gizmox.WebGUI.Forms.LinkLabel();
            this.grpBase = new Gizmox.WebGUI.Forms.Panel();
            this.lblMensaje = new AppGest.ControlBase.Label();
            this.grpBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnIniciar.CustomStyle = "F";
            this.btnIniciar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnIniciar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(188, 186);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(136, 29);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar sesión";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(149, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(149, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(152, 83);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(216, 25);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.GotFocus += new System.EventHandler(this.txtUsuario_GotFocus);
            this.txtUsuario.SelectTextOnGotFocus = true;
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtClave.CustomStyle = "Masked";
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtClave.Location = new System.Drawing.Point(152, 139);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(216, 25);
            this.txtClave.TabIndex = 3;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.GotFocus += new System.EventHandler(this.txtClave_GotFocus);
            // 
            // lblNuevoUsr
            // 
            this.lblNuevoUsr.ClientMode = false;
            this.lblNuevoUsr.Font = new System.Drawing.Font("Calibri", 9.25F);
            this.lblNuevoUsr.ForeColor = System.Drawing.Color.Gold;
            this.lblNuevoUsr.LinkColor = System.Drawing.Color.DarkRed;
            this.lblNuevoUsr.Location = new System.Drawing.Point(41, 239);
            this.lblNuevoUsr.Name = "lblNuevoUsr";
            this.lblNuevoUsr.Size = new System.Drawing.Size(106, 16);
            this.lblNuevoUsr.TabIndex = 5;
            this.lblNuevoUsr.TabStop = true;
            this.lblNuevoUsr.Text = "Nuevo usuario";
            this.lblNuevoUsr.Visible = false;
            this.lblNuevoUsr.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lblNuevoUsr_LinkClicked);
            // 
            // grpBase
            // 
            this.grpBase.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.grpBase.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("grpBase.BackgroundImage"));
            this.grpBase.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.grpBase.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.grpBase.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.grpBase.Controls.Add(this.lblMensaje);
            this.grpBase.Controls.Add(this.lblNuevoUsr);
            this.grpBase.Controls.Add(this.btnIniciar);
            this.grpBase.Controls.Add(this.txtClave);
            this.grpBase.Controls.Add(this.label1);
            this.grpBase.Controls.Add(this.txtUsuario);
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Location = new System.Drawing.Point(6, 5);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(565, 280);
            this.grpBase.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(144, 166);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(38, 15);
            this.lblMensaje.TabIndex = 6;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmInicio
            // 
            this.AcceptButton = this.btnIniciar;
            this.Controls.Add(this.grpBase);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(578, 293);
            this.Text = "Inicio de sesión";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.grpBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnIniciar;
        private AppGest.ControlBase.Label label1;
        private AppGest.ControlBase.Label label2;
        private MaskedTextBox txtClave;
        private LinkLabel lblNuevoUsr;
        private Panel grpBase;
        private ControlBase.Label lblMensaje;
        private ControlBase.TextBox txtUsuario;


    }
}