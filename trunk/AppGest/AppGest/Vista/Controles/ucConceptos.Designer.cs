using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class ucConceptos
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
            this.pnlCabecera = new Gizmox.WebGUI.Forms.Panel();
            this.pbImagenServicio = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblTipoServicio = new AppGest.ControlBase.Label();
            this.pnlDatosServicio = new Gizmox.WebGUI.Forms.Panel();
            this.lblDescripcion = new AppGest.ControlBase.Label();
            this.txtDesc = new AppGest.ControlBase.TextBox();
            this.txtObservacion = new AppGest.ControlBase.TextBox();
            this.lblObs = new AppGest.ControlBase.Label();
            this.lblAlias = new AppGest.ControlBase.Label();
            this.txtAbreviatura = new AppGest.ControlBase.TextBox();
            this.nudPrecio = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.lblPrecio = new AppGest.ControlBase.Label();
            this.label4 = new AppGest.ControlBase.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFechaHasta = new AppGest.ControlBase.Label();
            this.label3 = new AppGest.ControlBase.Label();
            this.lblFechaDesde = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtNombre = new AppGest.ControlBase.TextBox();
            this.lblNombreServicio = new AppGest.ControlBase.Label();
            this.pnlServicios = new Gizmox.WebGUI.Forms.Panel();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenServicio)).BeginInit();
            this.pnlDatosServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.lblPrecio.SuspendLayout();
            this.lblFechaHasta.SuspendLayout();
            this.lblFechaDesde.SuspendLayout();
            this.pnlServicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Visible = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.pbImagenServicio);
            this.pnlCabecera.Controls.Add(this.lblTipoServicio);
            this.pnlCabecera.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(579, 72);
            this.pnlCabecera.TabIndex = 0;
            // 
            // pbImagenServicio
            // 
            this.pbImagenServicio.Location = new System.Drawing.Point(512, 5);
            this.pbImagenServicio.Name = "pbImagenServicio";
            this.pbImagenServicio.Size = new System.Drawing.Size(64, 64);
            this.pbImagenServicio.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenServicio.TabIndex = 1;
            this.pbImagenServicio.TabStop = false;
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTipoServicio.AutoSize = true;
            this.lblTipoServicio.CustomStyle = "LabelSkin";
            this.lblTipoServicio.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTipoServicio.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTipoServicio.Location = new System.Drawing.Point(19, 26);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(35, 13);
            this.lblTipoServicio.TabIndex = 0;
            this.lblTipoServicio.Text = "TipoServicio";
            // 
            // pnlDatosServicio
            // 
            this.pnlDatosServicio.Controls.Add(this.lblDescripcion);
            this.pnlDatosServicio.Controls.Add(this.txtDesc);
            this.pnlDatosServicio.Controls.Add(this.txtObservacion);
            this.pnlDatosServicio.Controls.Add(this.lblObs);
            this.pnlDatosServicio.Controls.Add(this.lblAlias);
            this.pnlDatosServicio.Controls.Add(this.txtAbreviatura);
            this.pnlDatosServicio.Controls.Add(this.nudPrecio);
            this.pnlDatosServicio.Controls.Add(this.lblPrecio);
            this.pnlDatosServicio.Controls.Add(this.dtpFechaHasta);
            this.pnlDatosServicio.Controls.Add(this.lblFechaHasta);
            this.pnlDatosServicio.Controls.Add(this.lblFechaDesde);
            this.pnlDatosServicio.Controls.Add(this.dtpFechaDesde);
            this.pnlDatosServicio.Controls.Add(this.txtNombre);
            this.pnlDatosServicio.Controls.Add(this.lblNombreServicio);
            this.pnlDatosServicio.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDatosServicio.Location = new System.Drawing.Point(0, 72);
            this.pnlDatosServicio.Name = "pnlDatosServicio";
            this.pnlDatosServicio.Size = new System.Drawing.Size(579, 223);
            this.pnlDatosServicio.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.CustomStyle = "LabelSkin";
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescripcion.Location = new System.Drawing.Point(73, 61);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(35, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtDesc.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtDesc.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(73, 80);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.SelectTextOnGotFocus = true;
            this.txtDesc.Size = new System.Drawing.Size(410, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtObservacion.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtObservacion.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(73, 121);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.SelectTextOnGotFocus = true;
            this.txtObservacion.Size = new System.Drawing.Size(410, 20);
            this.txtObservacion.TabIndex = 7;
            // 
            // lblObs
            // 
            this.lblObs.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblObs.AutoSize = true;
            this.lblObs.CustomStyle = "LabelSkin";
            this.lblObs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblObs.Location = new System.Drawing.Point(73, 104);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(35, 13);
            this.lblObs.TabIndex = 6;
            this.lblObs.Text = "Observaciones";
            // 
            // lblAlias
            // 
            this.lblAlias.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblAlias.AutoSize = true;
            this.lblAlias.CustomStyle = "LabelSkin";
            this.lblAlias.EsObligatorio = true;
            this.lblAlias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAlias.Location = new System.Drawing.Point(282, 21);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 2;
            this.lblAlias.Text = "Abreviatura *";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtAbreviatura.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtAbreviatura.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtAbreviatura.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviatura.Location = new System.Drawing.Point(285, 37);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.SelectTextOnGotFocus = true;
            this.txtAbreviatura.Size = new System.Drawing.Size(198, 20);
            this.txtAbreviatura.TabIndex = 3;
            // 
            // nudPrecio
            // 
            this.nudPrecio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.nudPrecio.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.nudPrecio.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.nudPrecio.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrecio.CurrentValueChanged = false;
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(388, 167);
            this.nudPrecio.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(95, 22);
            this.nudPrecio.TabIndex = 13;
            this.nudPrecio.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.nudPrecio, "Indica el precio del concepto. ");
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Controls.Add(this.label4);
            this.lblPrecio.CustomStyle = "LabelSkin";
            this.lblPrecio.EsObligatorio = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecio.Location = new System.Drawing.Point(385, 151);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(44, 13);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio *";
            // 
            // label4
            // 
            this.label4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.CustomStyle = "LabelSkin";
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(-15, -12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.dtpFechaHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaHasta.CustomFormat = "";
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(228, 167);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            this.dtpFechaHasta.Size = new System.Drawing.Size(115, 17);
            this.dtpFechaHasta.TabIndex = 11;
            this.toolTip1.SetToolTip(this.dtpFechaHasta, "Seleccione una fecha fin para el perido. \r\nEsta fecha puede estar vacía, para ell" +
        "o quite el tilde y no ingrese fecha. ");
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Controls.Add(this.label3);
            this.lblFechaHasta.CustomStyle = "LabelSkin";
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaHasta.Location = new System.Drawing.Point(225, 151);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(44, 13);
            this.lblFechaHasta.TabIndex = 10;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // label3
            // 
            this.label3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.CustomStyle = "LabelSkin";
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(-15, -12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha Desde";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Controls.Add(this.label2);
            this.lblFechaDesde.CustomStyle = "LabelSkin";
            this.lblFechaDesde.EsObligatorio = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaDesde.Location = new System.Drawing.Point(73, 148);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 8;
            this.lblFechaDesde.Text = "Fecha Desde *";
            // 
            // label2
            // 
            this.label2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.CustomStyle = "LabelSkin";
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(-15, -12);
            this.label2.Name = "lblFechaDesde";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.dtpFechaDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpFechaDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFechaDesde.CustomFormat = "";
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(73, 167);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            this.dtpFechaDesde.Size = new System.Drawing.Size(115, 22);
            this.dtpFechaDesde.TabIndex = 9;
            this.toolTip1.SetToolTip(this.dtpFechaDesde, "Seleccione una fecha inicio para el periodo.\r\nEsta fecha puede estar vacía, para " +
        "ello quite el tilde y no ingrese fecha. ");
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.SlateGray);
            this.txtNombre.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(73, 37);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.SelectTextOnGotFocus = true;
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.LostFocus += new System.EventHandler(this.txtNombre_LostFocus);
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblNombreServicio.AutoSize = true;
            this.lblNombreServicio.CustomStyle = "LabelSkin";
            this.lblNombreServicio.EsObligatorio = true;
            this.lblNombreServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreServicio.Location = new System.Drawing.Point(73, 18);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(35, 13);
            this.lblNombreServicio.TabIndex = 0;
            this.lblNombreServicio.Text = "Nombre *";
            // 
            // pnlServicios
            // 
            this.pnlServicios.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.pnlServicios.Controls.Add(this.pnlDatosServicio);
            this.pnlServicios.Controls.Add(this.pnlCabecera);
            this.pnlServicios.Location = new System.Drawing.Point(3, 31);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.Size = new System.Drawing.Size(579, 295);
            this.pnlServicios.TabIndex = 2;
            // 
            // ucConceptos
            // 
            this.Controls.Add(this.pnlServicios);
            this.DockPadding.All = 3;
            this.MostrarCabecera = false;
            this.Size = new System.Drawing.Size(585, 345);
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.pnlServicios, 0);
            this.pnCabecera.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenServicio)).EndInit();
            this.pnlDatosServicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.lblPrecio.ResumeLayout(false);
            this.lblFechaHasta.ResumeLayout(false);
            this.lblFechaDesde.ResumeLayout(false);
            this.pnlServicios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlCabecera;
        private AppGest.ControlBase.Label lblTipoServicio;
        private PictureBox pbImagenServicio;
        private Panel pnlDatosServicio;
        private AppGest.ControlBase.TextBox txtNombre;
        private AppGest.ControlBase.Label lblNombreServicio;
        private AppGest.ControlBase.Label lblFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private AppGest.ControlBase.Label lblFechaHasta;
        private AppGest.ControlBase.Label label3;
        private AppGest.ControlBase.Label label2;
        private DateTimePicker dtpFechaHasta;
        private AppGest.ControlBase.Label lblPrecio;
        private AppGest.ControlBase.Label label4;
        private NumericUpDown nudPrecio;
        private Panel pnlServicios;
        protected AppGest.ControlBase.Label lblAlias;
        protected AppGest.ControlBase.Label lblDescripcion;
        protected AppGest.ControlBase.Label lblObs;
        protected ControlBase.TextBox txtAbreviatura;
        protected ControlBase.TextBox txtDesc;
        protected ControlBase.TextBox txtObservacion;
        private ToolTip toolTip1;


    }
}