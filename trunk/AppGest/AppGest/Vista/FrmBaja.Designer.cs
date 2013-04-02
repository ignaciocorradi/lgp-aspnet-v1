using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmBaja
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
            this.lblMensaje = new AppGest.ControlBase.Label();
            this.dtpFechaBaja = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnAceptar = new AppGest.ControlBase.Button();
            this.btnCancelar = new AppGest.ControlBase.Button();
            this.lblFecha = new AppGest.ControlBase.Label();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.label1 = new AppGest.ControlBase.Label();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMensaje.Location = new System.Drawing.Point(11, 40);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(38, 15);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "Se dará de \"Baja\" al cliente Juan, Perez, con: \r\n - Cochera 457\r\n - vehículo: ADF" +
    " 565";
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaBaja.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBaja.Location = new System.Drawing.Point(103, 121);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(119, 21);
            this.dtpFechaBaja.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(69, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Si";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnCancelar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(179, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "No";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFecha.Location = new System.Drawing.Point(102, 102);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Indique la fecha de baja:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CustomStyle = "LabelSkin";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(1, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos de la baja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(116, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "¿Quiere continuar?";
            // 
            // FrmBaja
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpFechaBaja);
            this.Controls.Add(this.lblMensaje);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.None;
            this.Size = new System.Drawing.Size(338, 222);
            this.Text = "FrmBaja";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBase.Label lblMensaje;
        private DateTimePicker dtpFechaBaja;
        private ControlBase.Button btnAceptar;
        private ControlBase.Button btnCancelar;
        private ControlBase.Label lblFecha;
        protected ControlBase.Label lblTitulo;
        private ControlBase.Label label1;


    }
}