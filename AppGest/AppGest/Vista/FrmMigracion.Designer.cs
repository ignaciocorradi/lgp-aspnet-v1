using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista
{
    partial class FrmMigracion
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.dgClientes = new Gizmox.WebGUI.Forms.DataGridView();
            this.btnCargarDatos = new Gizmox.WebGUI.Forms.Button();
            this.dgPagos = new Gizmox.WebGUI.Forms.DataGridView();
            this.btnImportarClientes = new AppGest.ControlBase.Button();
            this.label5 = new AppGest.ControlBase.Label();
            this.label6 = new AppGest.ControlBase.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgClientes
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgClientes.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.dgClientes.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgClientes.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Location = new System.Drawing.Point(24, 69);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            this.dgClientes.Size = new System.Drawing.Size(593, 362);
            this.dgClientes.TabIndex = 0;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.CustomStyle = "F";
            this.btnCargarDatos.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCargarDatos.Location = new System.Drawing.Point(24, 9);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(126, 31);
            this.btnCargarDatos.TabIndex = 1;
            this.btnCargarDatos.Text = "Cargar datos";
            this.btnCargarDatos.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgPagos
            // 
            this.dgPagos.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dgPagos.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgPagos.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPagos.Location = new System.Drawing.Point(635, 69);
            this.dgPagos.Name = "dgPagos";
            this.dgPagos.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            this.dgPagos.Size = new System.Drawing.Size(344, 362);
            this.dgPagos.TabIndex = 2;
            // 
            // btnImportarClientes
            // 
            this.btnImportarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnImportarClientes.CustomStyle = "F";
            this.btnImportarClientes.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnImportarClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImportarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarClientes.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.F4;
            this.btnImportarClientes.Location = new System.Drawing.Point(161, 9);
            this.btnImportarClientes.Name = "btnImportarClientes";
            this.btnImportarClientes.Size = new System.Drawing.Size(146, 31);
            this.btnImportarClientes.TabIndex = 4;
            this.btnImportarClientes.Text = "Importar clientes [F4]";
            this.btnImportarClientes.Click += new System.EventHandler(this.btnImportarClientes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(632, 48);
            this.label5.Name = "label2";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pagos a importar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(21, 48);
            this.label6.Name = "label1";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Clientes a importar";
            // 
            // FrmMigracion
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnImportarClientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgPagos);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.dgClientes);
            this.Size = new System.Drawing.Size(1003, 456);
            this.Text = "FrmMigracion";
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private DataGridView dgClientes;
        private Button btnCargarDatos;
        private DataGridView dgPagos;
        private ControlBase.Label label5;
        private ControlBase.Label label6;
        private ControlBase.Button btnImportarClientes;


    }
}