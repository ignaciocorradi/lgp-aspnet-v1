using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcGrilla
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
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcGrilla));
            this.dgvGrilla = new Gizmox.WebGUI.Forms.DataGridView();
            this.lstImagenes = new Gizmox.WebGUI.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgvGrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(1, 1);
            this.dgvGrilla.Name = "dgvGrilla";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgvGrilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrilla.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-ES");
            this.dgvGrilla.Size = new System.Drawing.Size(389, 304);
            this.dgvGrilla.TabIndex = 0;
            // 
            // lstImagenes
            // 
            this.lstImagenes.Images.AddRange(new Gizmox.WebGUI.Common.Resources.ResourceHandle[] {
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("lstImagenes.Images")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("lstImagenes.Images1")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("lstImagenes.Images2")),
            new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("lstImagenes.Images3"))});
            this.lstImagenes.ImageSize = new System.Drawing.Size(16, 16);
            this.lstImagenes.Images.SetKeyName(0, "16.exit.png");
            this.lstImagenes.Images.SetKeyName(1, "16.editar.png");
            this.lstImagenes.Images.SetKeyName(2, "16.dardebaja1.png");
            this.lstImagenes.Images.SetKeyName(3, "16.eliminar.png");
            // 
            // UcGrilla
            // 
            this.Controls.Add(this.dgvGrilla);
            this.DockPadding.Bottom = 1;
            this.DockPadding.Left = 1;
            this.DockPadding.Right = 1;
            this.DockPadding.Top = 1;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(1, 1, 1, 1);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ucGrillaEntidades";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvGrilla;
        private ImageList lstImagenes;


    }
}