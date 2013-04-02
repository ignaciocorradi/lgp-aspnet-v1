using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmAutoAbrev
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
            this.ucAutosAbrev1 = new AppGest.Vista.Controles.ucVehiculoAbrev();
            this.txtInfo = new AppGest.ControlBase.TextBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new AppGest.ControlBase.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucAutosAbrev1
            // 
            this.ucAutosAbrev1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucAutosAbrev1.DockPadding.All = 3;
            this.ucAutosAbrev1.Location = new System.Drawing.Point(12, 7);
            this.ucAutosAbrev1.MensajeUsuario = null;
            this.ucAutosAbrev1.MostrarBarra = false;
            this.ucAutosAbrev1.MostrarCabecera = false;
            this.ucAutosAbrev1.Name = "ucAutosAbrev1";
            this.ucAutosAbrev1.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.ucAutosAbrev1.Size = new System.Drawing.Size(544, 237);
            this.ucAutosAbrev1.TabIndex = 0;
            this.ucAutosAbrev1.Text = "ucAutosAbrev";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.txtInfo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(17, 263);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(495, 68);
            this.txtInfo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.ucAutosAbrev1);
            this.panel1.Location = new System.Drawing.Point(4, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 346);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Información del vehículo";
            // 
            // FrmAutoAbrev
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(578, 373);
            this.Text = "Gestión de vehículos";
            this.WindowState = Gizmox.WebGUI.Forms.FormWindowState.Normal;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucVehiculoAbrev ucAutosAbrev1;
        private AppGest.ControlBase.TextBox txtInfo;
        private Panel panel1;
        private AppGest.ControlBase.Label label1;



    }
}