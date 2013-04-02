using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucDatosEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDatosEntidad));
            this.lblNombre = new AppGest.ControlBase.Label();
            this.lblFechaA = new AppGest.ControlBase.Label();
            this.dtpFechaA = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFechaB = new AppGest.ControlBase.Label();
            this.txtFechaB = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.txtAbreviatura = new AppGest.ControlBase.TextBox();
            this.lblAlias = new AppGest.ControlBase.Label();
            this.pnlNombre = new Gizmox.WebGUI.Forms.Panel();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.pnlFechas = new Gizmox.WebGUI.Forms.Panel();
            this.pnlCabecera = new Gizmox.WebGUI.Forms.Panel();
            this.imgImagen = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.pnlBase = new Gizmox.WebGUI.Forms.Panel();
            this.lblObs = new AppGest.ControlBase.Label();
            this.txtObservacion = new AppGest.ControlBase.TextBox();
            this.txtDesc = new AppGest.ControlBase.TextBox();
            this.lblDescripcion = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(611, 28);
            this.tbMenu.TabIndex = 1;
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(611, 38);
            this.pnCabecera.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblNombre.AutoSize = true;
            this.lblNombre.CustomStyle = "LabelSkin";
            this.lblNombre.EsObligatorio = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(20, 7);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            // 
            // lblFechaA
            // 
            this.lblFechaA.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFechaA.AutoSize = true;
            this.lblFechaA.CustomStyle = "LabelSkin";
            this.lblFechaA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaA.Location = new System.Drawing.Point(20, 5);
            this.lblFechaA.Name = "lblFechaA";
            this.lblFechaA.Size = new System.Drawing.Size(58, 13);
            this.lblFechaA.TabIndex = 0;
            this.lblFechaA.Text = "Fecha Alta";
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.dtpFechaA.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.dtpFechaA.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaA.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaA.CustomFormat = "";
            this.dtpFechaA.CustomStyle = "Masked";
            this.dtpFechaA.Enabled = false;
            this.dtpFechaA.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaA.Location = new System.Drawing.Point(20, 21);
            this.dtpFechaA.Name = "dtpFechaA";
            this.dtpFechaA.Size = new System.Drawing.Size(143, 22);
            this.dtpFechaA.TabIndex = 1;
            // 
            // lblFechaB
            // 
            this.lblFechaB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFechaB.AutoSize = true;
            this.lblFechaB.CustomStyle = "LabelSkin";
            this.lblFechaB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaB.Location = new System.Drawing.Point(172, 5);
            this.lblFechaB.Name = "lblFechaB";
            this.lblFechaB.Size = new System.Drawing.Size(60, 13);
            this.lblFechaB.TabIndex = 2;
            this.lblFechaB.Text = "Fecha Baja";
            // 
            // txtFechaB
            // 
            this.txtFechaB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtFechaB.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.txtFechaB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtFechaB.CustomStyle = "Masked";
            this.txtFechaB.Location = new System.Drawing.Point(170, 21);
            this.txtFechaB.Mask = "00/00/0000";
            this.txtFechaB.Name = "txtFechaB";
            this.txtFechaB.ReadOnly = true;
            this.txtFechaB.Size = new System.Drawing.Size(134, 22);
            this.txtFechaB.TabIndex = 3;
            this.txtFechaB.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtAbreviatura.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtAbreviatura.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtAbreviatura.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviatura.Location = new System.Drawing.Point(260, 26);
            this.txtAbreviatura.Name = "txtAlias";
            this.txtAbreviatura.SelectTextOnGotFocus = true;
            this.txtAbreviatura.Size = new System.Drawing.Size(308, 22);
            this.txtAbreviatura.TabIndex = 3;
            // 
            // lblAlias
            // 
            this.lblAlias.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblAlias.AutoSize = true;
            this.lblAlias.CustomStyle = "LabelSkin";
            this.lblAlias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAlias.Location = new System.Drawing.Point(260, 7);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 2;
            this.lblAlias.Text = "Abreviatura";
            // 
            // pnlNombre
            // 
            this.pnlNombre.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlNombre.Controls.Add(this.txtNombre);
            this.pnlNombre.Controls.Add(this.lblNombre);
            this.pnlNombre.Controls.Add(this.txtAbreviatura);
            this.pnlNombre.Controls.Add(this.lblAlias);
            this.pnlNombre.Location = new System.Drawing.Point(13, 71);
            this.pnlNombre.Name = "pnlNombre";
            this.pnlNombre.Size = new System.Drawing.Size(585, 52);
            this.pnlNombre.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(21, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(223, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // pnlFechas
            // 
            this.pnlFechas.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlFechas.Controls.Add(this.txtFechaB);
            this.pnlFechas.Controls.Add(this.lblFechaA);
            this.pnlFechas.Controls.Add(this.dtpFechaA);
            this.pnlFechas.Controls.Add(this.lblFechaB);
            this.pnlFechas.Location = new System.Drawing.Point(13, 125);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(585, 47);
            this.pnlFechas.TabIndex = 2;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlCabecera.Controls.Add(this.imgImagen);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Location = new System.Drawing.Point(13, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(585, 72);
            this.pnlCabecera.TabIndex = 0;
            // 
            // imgImagen
            // 
            this.imgImagen.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.imgImagen.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("imgImagen.Image"));
            this.imgImagen.Location = new System.Drawing.Point(502, 5);
            this.imgImagen.Name = "imgImagen";
            this.imgImagen.Size = new System.Drawing.Size(64, 64);
            this.imgImagen.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImagen.TabIndex = 1;
            this.imgImagen.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.CustomStyle = "LabelSkin";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(21, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos de entidad";
            // 
            // pnlBase
            // 
            this.pnlBase.AutoScroll = true;
            this.pnlBase.Controls.Add(this.pnlCabecera);
            this.pnlBase.Controls.Add(this.lblObs);
            this.pnlBase.Controls.Add(this.txtObservacion);
            this.pnlBase.Controls.Add(this.txtDesc);
            this.pnlBase.Controls.Add(this.lblDescripcion);
            this.pnlBase.Controls.Add(this.pnlFechas);
            this.pnlBase.Controls.Add(this.pnlNombre);
            this.pnlBase.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(3, 31);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(611, 269);
            this.pnlBase.TabIndex = 0;
            // 
            // lblObs
            // 
            this.lblObs.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblObs.AutoSize = true;
            this.lblObs.CustomStyle = "LabelSkin";
            this.lblObs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblObs.Location = new System.Drawing.Point(31, 220);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(35, 13);
            this.lblObs.TabIndex = 5;
            this.lblObs.Text = "Observaciones";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtObservacion.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtObservacion.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(31, 239);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.SelectTextOnGotFocus = true;
            this.txtObservacion.Size = new System.Drawing.Size(547, 22);
            this.txtObservacion.TabIndex = 6;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtDesc.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtDesc.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(31, 195);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.SelectTextOnGotFocus = true;
            this.txtDesc.Size = new System.Drawing.Size(547, 22);
            this.txtDesc.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.CustomStyle = "LabelSkin";
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescripcion.Location = new System.Drawing.Point(31, 179);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(35, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción";
            // 
            // ucDatosEntidad
            // 
            this.Controls.Add(this.pnlBase);
            this.DockPadding.All = 3;
            this.MostrarCabecera = false;
            this.Size = new System.Drawing.Size(617, 341);
            this.Text = "usDatosEntidad";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.pnCabecera.ResumeLayout(false);
            this.pnlNombre.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImagen)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Panel pnlNombre;
        protected Panel pnlFechas;
        protected Panel pnlCabecera;
        protected PictureBox imgImagen;
        protected AppGest.ControlBase.Label lblTitulo;
        protected Panel pnlBase;
        protected AppGest.ControlBase.Label lblNombre;
        protected AppGest.ControlBase.Label lblFechaA;
        protected DateTimePicker dtpFechaA;
        protected AppGest.ControlBase.Label lblFechaB;
        protected MaskedTextBox txtFechaB;
        protected AppGest.ControlBase.Label lblAlias;
        protected AppGest.ControlBase.Label lblObs;
        protected AppGest.ControlBase.Label lblDescripcion;
        protected ControlBase.TextBox txtAbreviatura;
        protected ControlBase.TextBox txtObservacion;
        protected ControlBase.TextBox txtDesc;
        public ControlBase.TextBox txtNombre;







    }
}