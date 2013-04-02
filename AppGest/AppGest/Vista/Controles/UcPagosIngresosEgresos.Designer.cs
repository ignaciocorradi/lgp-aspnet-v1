using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcPagosIngresosEgresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPagosIngresosEgresos));
            this.grpEncabezado = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblComentario = new AppGest.ControlBase.Label();
            this.txtcomentario = new AppGest.ControlBase.TextBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblValorTotal = new AppGest.ControlBase.Label();
            this.lblTotal = new AppGest.ControlBase.Label();
            this.btnAgregar = new AppGest.ControlBase.Button();
            this.lblValorFecha = new AppGest.ControlBase.Label();
            this.lblFechaRegistro = new AppGest.ControlBase.Label();
            this.ucGrillaPagosEgresosVarios = new AppGest.Vista.Controles.UcGrilla();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.grpEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(741, 28);
            this.tbMenu.TabIndex = 2;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            // 
            // grpEncabezado
            // 
            this.grpEncabezado.Controls.Add(this.lblComentario);
            this.grpEncabezado.Controls.Add(this.txtcomentario);
            this.grpEncabezado.Controls.Add(this.pictureBox1);
            this.grpEncabezado.Controls.Add(this.lblValorTotal);
            this.grpEncabezado.Controls.Add(this.lblTotal);
            this.grpEncabezado.Controls.Add(this.btnAgregar);
            this.grpEncabezado.Controls.Add(this.lblValorFecha);
            this.grpEncabezado.Controls.Add(this.lblFechaRegistro);
            this.grpEncabezado.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.grpEncabezado.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpEncabezado.Location = new System.Drawing.Point(3, 31);
            this.grpEncabezado.Name = "grpEncabezado";
            this.grpEncabezado.Size = new System.Drawing.Size(741, 91);
            this.grpEncabezado.TabIndex = 0;
            this.grpEncabezado.TabStop = false;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComentario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblComentario.Location = new System.Drawing.Point(39, 54);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(38, 15);
            this.lblComentario.TabIndex = 5;
            this.lblComentario.Text = "Comentarios:";
            this.lblComentario.Visible = false;
            // 
            // txtcomentario
            // 
            this.txtcomentario.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtcomentario.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtcomentario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomentario.Location = new System.Drawing.Point(125, 54);
            this.txtcomentario.Multiline = true;
            this.txtcomentario.Name = "txtcomentario";
            this.txtcomentario.SelectTextOnGotFocus = true;
            this.txtcomentario.Size = new System.Drawing.Size(413, 31);
            this.txtcomentario.TabIndex = 6;
            this.txtcomentario.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(675, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblValorTotal.Location = new System.Drawing.Point(413, 20);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Padding = new Gizmox.WebGUI.Forms.Padding(2);
            this.lblValorTotal.Size = new System.Drawing.Size(94, 13);
            this.lblValorTotal.TabIndex = 4;
            this.lblValorTotal.Text = "$_VALOR_TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotal.Location = new System.Drawing.Point(360, 26);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregar.CustomStyle = "F";
            this.btnAgregar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregar.Image"));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(226, 16);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(111, 31);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.toolTip1.SetToolTip(this.btnAgregar, "Agrega una linea de pago nueva");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblValorFecha
            // 
            this.lblValorFecha.AutoSize = true;
            this.lblValorFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblValorFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblValorFecha.Location = new System.Drawing.Point(122, 30);
            this.lblValorFecha.Name = "lblValorFecha";
            this.lblValorFecha.Size = new System.Drawing.Size(35, 13);
            this.lblValorFecha.TabIndex = 1;
            this.lblValorFecha.Text = "VALOR_FECHA";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaRegistro.Location = new System.Drawing.Point(14, 29);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(35, 13);
            this.lblFechaRegistro.TabIndex = 0;
            this.lblFechaRegistro.Text = "Fecha de Registro:";
            // 
            // ucGrillaPagosEgresosVarios
            // 
            this.ucGrillaPagosEgresosVarios.AutoAjustarAnchoColumnas = true;
            this.ucGrillaPagosEgresosVarios.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrillaPagosEgresosVarios.DataSource = null;
            this.ucGrillaPagosEgresosVarios.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucGrillaPagosEgresosVarios.DockPadding.All = 5;
            this.ucGrillaPagosEgresosVarios.EncabezadoFilaVisible = true;
            this.ucGrillaPagosEgresosVarios.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGrillaPagosEgresosVarios.Location = new System.Drawing.Point(3, 122);
            this.ucGrillaPagosEgresosVarios.Name = "ucGrillaPagosEgresosVarios";
            this.ucGrillaPagosEgresosVarios.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.ucGrillaPagosEgresosVarios.ParametrosGrilla = null;
            this.ucGrillaPagosEgresosVarios.Size = new System.Drawing.Size(741, 398);
            this.ucGrillaPagosEgresosVarios.TabIndex = 1;
            this.ucGrillaPagosEgresosVarios.Text = "ucGrillaPagosEgresosVarios";
            // 
            // UcPagosIngresosEgresos
            // 
            this.Controls.Add(this.ucGrillaPagosEgresosVarios);
            this.Controls.Add(this.grpEncabezado);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(747, 523);
            this.Text = "UcPagosEgresosVarios";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.grpEncabezado, 0);
            this.Controls.SetChildIndex(this.ucGrillaPagosEgresosVarios, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpEncabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpEncabezado;
        private UcGrilla ucGrillaPagosEgresosVarios;
        private ControlBase.Label lblValorFecha;
        private ControlBase.Label lblFechaRegistro;
        private ControlBase.Button btnAgregar;
        private ControlBase.Label lblValorTotal;
        private ControlBase.Label lblTotal;
        private PictureBox pictureBox1;
        private ControlBase.Label lblComentario;
        private ControlBase.TextBox txtcomentario;
        private ToolTip toolTip1;


    }
}