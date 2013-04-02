using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcABMServicioMensual
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
            this.cmbServMensuales = new Gizmox.WebGUI.Forms.ComboBox();
            this.chNroCocheraDisp = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chDescCocheraDisp = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lvCocherasDisponibles = new Gizmox.WebGUI.Forms.ListView();
            this.dtpDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new AppGest.ControlBase.Label();
            this.lblNombreCochera = new AppGest.ControlBase.Label();
            this.lblCocherasDisp = new AppGest.ControlBase.Label();
            this.label5 = new AppGest.ControlBase.Label();
            this.label2 = new AppGest.ControlBase.Label();
            this.label1 = new AppGest.ControlBase.Label();
            this.lblTitulo = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(422, 28);
            // 
            // tbtnGuardar
            // 
            this.tbtnGuardar.Text = "Aceptar";
            this.tbtnGuardar.ToolTipText = "Aceptar cambios...";
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(422, 38);
            // 
            // cmbServMensuales
            // 
            this.cmbServMensuales.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.cmbServMensuales.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbServMensuales.FormattingEnabled = true;
            this.cmbServMensuales.Location = new System.Drawing.Point(17, 101);
            this.cmbServMensuales.Name = "cmbServMensuales";
            this.cmbServMensuales.Size = new System.Drawing.Size(375, 21);
            this.cmbServMensuales.TabIndex = 1;
            // 
            // chNroCocheraDisp
            // 
            this.chNroCocheraDisp.Image = null;
            this.chNroCocheraDisp.Text = "Nro. Cochera";
            this.chNroCocheraDisp.Width = 99;
            // 
            // chDescCocheraDisp
            // 
            this.chDescCocheraDisp.Image = null;
            this.chDescCocheraDisp.Text = "Descripción";
            this.chDescCocheraDisp.Width = 237;
            // 
            // lvCocherasDisponibles
            // 
            this.lvCocherasDisponibles.AutoGenerateColumns = true;
            this.lvCocherasDisponibles.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.lvCocherasDisponibles.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lvCocherasDisponibles.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent;
            this.lvCocherasDisponibles.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.chNroCocheraDisp,
            this.chDescCocheraDisp});
            this.lvCocherasDisponibles.DataMember = null;
            this.lvCocherasDisponibles.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lvCocherasDisponibles.FullRowSelect = true;
            this.lvCocherasDisponibles.GridLines = true;
            this.lvCocherasDisponibles.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCocherasDisponibles.ItemsPerPage = 10;
            this.lvCocherasDisponibles.Location = new System.Drawing.Point(17, 232);
            this.lvCocherasDisponibles.MultiSelect = false;
            this.lvCocherasDisponibles.Name = "lvCocherasDisponibles";
            this.lvCocherasDisponibles.ShowGroups = false;
            this.lvCocherasDisponibles.ShowItemToolTips = false;
            this.lvCocherasDisponibles.Size = new System.Drawing.Size(375, 113);
            this.lvCocherasDisponibles.TabIndex = 7;
            this.lvCocherasDisponibles.SelectedIndexChanged += new System.EventHandler(this.lvCocherasDisponibles_SelectedIndexChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.dtpDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpDesde.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(23, 149);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.dtpHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dtpHasta.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpHasta.Checked = false;
            this.dtpHasta.CustomFormat = "";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(165, 149);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(109, 25);
            this.dtpHasta.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(18, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cochera asignada:";
            // 
            // lblNombreCochera
            // 
            this.lblNombreCochera.AutoSize = true;
            this.lblNombreCochera.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreCochera.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNombreCochera.Location = new System.Drawing.Point(141, 180);
            this.lblNombreCochera.Name = "lblNombreCochera";
            this.lblNombreCochera.Size = new System.Drawing.Size(35, 13);
            this.lblNombreCochera.TabIndex = 9;
            this.lblNombreCochera.Text = "(Ninguna)";
            // 
            // lblCocherasDisp
            // 
            this.lblCocherasDisp.AutoSize = true;
            this.lblCocherasDisp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCocherasDisp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCocherasDisp.Location = new System.Drawing.Point(26, 350);
            this.lblCocherasDisp.Name = "lblCocherasDisp";
            this.lblCocherasDisp.Size = new System.Drawing.Size(38, 15);
            this.lblCocherasDisp.TabIndex = 11;
            this.lblCocherasDisp.Text = "Cocheras disponibles: {0}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.EsObligatorio = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(14, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Servicio contratado: *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.EsObligatorio = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(19, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Desde: *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(162, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hasta:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.EsObligatorio = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(17, 208);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 15);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Seleccionar cocheras disponibles *";
            // 
            // UcABMServicioMensual
            // 
            this.Controls.Add(this.lblNombreCochera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCocherasDisp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lvCocherasDisponibles);
            this.Controls.Add(this.cmbServMensuales);
            this.Controls.Add(this.lblTitulo);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(428, 373);
            this.Text = "UcABMServicioMensual";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.cmbServMensuales, 0);
            this.Controls.SetChildIndex(this.lvCocherasDisponibles, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblCocherasDisp, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblNombreCochera, 0);
            this.pnCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbServMensuales;
        private ColumnHeader chNroCocheraDisp;
        private ColumnHeader chDescCocheraDisp;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        public ListView lvCocherasDisponibles;
        private AppGest.ControlBase.Label label4;
        private AppGest.ControlBase.Label lblNombreCochera;
        private ControlBase.Label lblCocherasDisp;
        private ControlBase.Label label5;
        private ControlBase.Label label2;
        private ControlBase.Label label1;
        private ControlBase.Label lblTitulo;


    }
}