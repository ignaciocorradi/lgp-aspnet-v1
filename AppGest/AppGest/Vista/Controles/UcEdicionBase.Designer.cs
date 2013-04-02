using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcEdicionBase
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
            this.ucGrilla1 = new AppGest.Vista.Controles.UcGrilla();
            this.SuspendLayout();
            // 
            // ucGrilla1
            // 
            this.ucGrilla1.AutoScroll = true;
            this.ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla1.DataSource = null;
            this.ucGrilla1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.ucGrilla1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrilla1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucGrilla1.Location = new System.Drawing.Point(3, 55);
            this.ucGrilla1.Name = "ucGrilla1";
            this.ucGrilla1.ParametrosGrilla = null;
            this.ucGrilla1.Size = new System.Drawing.Size(596, 250);
            this.ucGrilla1.TabIndex = 0;
            this.ucGrilla1.Text = "ucGrillaEntidades";
            // 
            // UcEdicionBase
            // 
            this.Controls.Add(this.ucGrilla1);
            this.DockPadding.All = 3;
            this.Text = "UcEdicionBase";
            this.Controls.SetChildIndex(this.ucGrilla1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UcGrilla ucGrilla1;



    }
}