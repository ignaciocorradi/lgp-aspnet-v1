using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.ControlBase
{
    partial class ucStatusBar
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
            this.lblEstado = new AppGest.ControlBase.Label();
            this.lblInfo = new AppGest.ControlBase.Label();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblEstado.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblEstado.Location = new System.Drawing.Point(0, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 15);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Listo.";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblInfo.Location = new System.Drawing.Point(663, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(138, 35);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Usuario:";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucStatusBar
            // 
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblInfo);
            this.Size = new System.Drawing.Size(801, 35);
            this.Text = "ucStatusBar";
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblEstado;
        private Label lblInfo;



    }
}