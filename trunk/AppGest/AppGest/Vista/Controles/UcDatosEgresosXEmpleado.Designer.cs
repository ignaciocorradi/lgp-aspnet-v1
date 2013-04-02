using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcDatosEgresosXEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDatosEgresosXEmpleado));
            this.ucGrilla = new AppGest.Vista.Controles.UcGrilla();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.cboEmpleado = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnBuscar = new AppGest.ControlBase.Button();
            this.lblEmpleado = new AppGest.ControlBase.Label();
            this.pnlFill = new Gizmox.WebGUI.Forms.Panel();
            this.btnAgregar = new AppGest.ControlBase.Button();
            this.label2 = new AppGest.ControlBase.Label();
            this.tlt = new Gizmox.WebGUI.Forms.ToolTip();
            this.pnCabecera.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Size = new System.Drawing.Size(642, 28);
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTituloBase.Dock = Gizmox.WebGUI.Forms.DockStyle.None;
            this.lblTituloBase.Location = new System.Drawing.Point(15, 4);
            // 
            // pnCabecera
            // 
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Size = new System.Drawing.Size(642, 38);
            // 
            // ucGrilla
            // 
            this.ucGrilla.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.ucGrilla.AutoAjustarAnchoColumnas = true;
            this.ucGrilla.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucGrilla.DataSource = null;
            this.ucGrilla.DockPadding.All = 1;
            this.ucGrilla.Enabled = false;
            this.ucGrilla.EncabezadoFilaVisible = true;
            this.ucGrilla.Location = new System.Drawing.Point(12, 124);
            this.ucGrilla.Name = "ucGrilla";
            this.ucGrilla.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.ucGrilla.ParametrosGrilla = null;
            this.ucGrilla.Size = new System.Drawing.Size(592, 293);
            this.ucGrilla.TabIndex = 2;
            this.ucGrilla.Text = "ucGrillaEntidades";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.cboEmpleado);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.lblEmpleado);
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(14, 7);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(590, 75);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Buscar empleado";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(64, 43);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(260, 21);
            this.cboEmpleado.TabIndex = 2;
            this.tlt.SetToolTip(this.cboEmpleado, "Seleccione empleado a configurar");
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnBuscar.CustomStyle = "F";
            this.btnBuscar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBuscar.Image"));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(347, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnBuscar.Size = new System.Drawing.Size(138, 40);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Cargar Valores";
            this.tlt.SetToolTip(this.btnBuscar, "Carga los valores actuales para el empleado seleccionado");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.EsObligatorio = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmpleado.Location = new System.Drawing.Point(61, 24);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(35, 13);
            this.lblEmpleado.TabIndex = 0;
            this.lblEmpleado.Text = "Seleccionar empleado: *";
            // 
            // pnlFill
            // 
            this.pnlFill.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)));
            this.pnlFill.AutoScroll = true;
            this.pnlFill.Controls.Add(this.btnAgregar);
            this.pnlFill.Controls.Add(this.label2);
            this.pnlFill.Controls.Add(this.ucGrilla);
            this.pnlFill.Controls.Add(this.grpFiltros);
            this.pnlFill.Location = new System.Drawing.Point(13, 74);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(618, 424);
            this.pnlFill.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnAgregar.CustomStyle = "F";
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregar.Image"));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(498, 87);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.btnAgregar.Size = new System.Drawing.Size(106, 31);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.tlt.SetToolTip(this.btnAgregar, "Carga los valores actuales para el empleado seleccionado");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(10, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asignaciones de remuneración aplicadas:";
            // 
            // UcDatosEgresosXEmpleado
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.pnlFill);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(648, 504);
            this.Text = "UcDatosEgresosXEmpleado";
            this.Controls.SetChildIndex(this.tbMenu, 0);
            this.Controls.SetChildIndex(this.pnCabecera, 0);
            this.Controls.SetChildIndex(this.pnlFill, 0);
            this.pnCabecera.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrilla ucGrilla;
        private GroupBox grpFiltros;
        private AppGest.ControlBase.Label lblEmpleado;
        private Panel pnlFill;
        private ControlBase.Button btnBuscar;
        private ToolTip tlt;
        private AppGest.ControlBase.Label label2;
        private ComboBox cboEmpleado;
        private ControlBase.Button btnAgregar;


    }
}