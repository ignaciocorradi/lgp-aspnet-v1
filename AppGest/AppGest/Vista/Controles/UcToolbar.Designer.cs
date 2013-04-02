using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace AppGest.Vista.Controles
{
    partial class UcToolbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcToolbar));
            this.tbMenu = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbtnGuardar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnCancelar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnCerrar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.pnCabecera = new Gizmox.WebGUI.Forms.Panel();
            this.lblTituloBase = new AppGest.ControlBase.Label();
            this.pnCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMenu
            // 
            this.tbMenu.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Flat;
            this.tbMenu.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtnGuardar,
            this.tbtnCancelar,
            this.tbtnCerrar});
            this.tbMenu.DragHandle = true;
            this.tbMenu.DropDownArrows = true;
            this.tbMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMenu.ImageSize = new System.Drawing.Size(16, 16);
            this.tbMenu.Location = new System.Drawing.Point(0, 0);
            this.tbMenu.MenuHandle = true;
            this.tbMenu.Name = "tbMenu";
            this.tbMenu.ShowToolTips = true;
            this.tbMenu.Size = new System.Drawing.Size(596, 28);
            this.tbMenu.TabIndex = 0;
            this.tbMenu.TextAlign = Gizmox.WebGUI.Forms.ToolBarTextAlign.Right;
            // 
            // tbtnGuardar
            // 
            this.tbtnGuardar.CustomStyle = "F";
            this.tbtnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbtnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbtnGuardar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnGuardar.Image"));
            this.tbtnGuardar.Name = "tbtnGuardar";
            this.tbtnGuardar.Size = 24;
            this.tbtnGuardar.Text = "Guardar";
            this.tbtnGuardar.ToolTipText = "Guardar cambios...";
            this.tbtnGuardar.Click += new System.EventHandler(this.tbtnGuardar_Click);
            // 
            // tbtnCancelar
            // 
            this.tbtnCancelar.CustomStyle = "F";
            this.tbtnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbtnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbtnCancelar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCancelar.Image"));
            this.tbtnCancelar.Name = "tbtnCancelar";
            this.tbtnCancelar.Size = 24;
            this.tbtnCancelar.Text = "Cancelar";
            this.tbtnCancelar.ToolTipText = "Cancelar cambios...";
            this.tbtnCancelar.Click += new System.EventHandler(this.tbtnCancelar_Click);
            // 
            // tbtnCerrar
            // 
            this.tbtnCerrar.CustomStyle = "F";
            this.tbtnCerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbtnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbtnCerrar.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("tbtnCerrar.Image"));
            this.tbtnCerrar.Name = "tbtnCerrar";
            this.tbtnCerrar.Size = 24;
            this.tbtnCerrar.Text = "Cerrar";
            this.tbtnCerrar.ToolTipText = "Cancelar cambios...";
            this.tbtnCerrar.Visible = false;
            this.tbtnCerrar.Click += new System.EventHandler(this.tbtnCerrar_Click);
            // 
            // pnCabecera
            // 
            this.pnCabecera.AutoSize = true;
            this.pnCabecera.Controls.Add(this.lblTituloBase);
            this.pnCabecera.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnCabecera.DockPadding.All = 4;
            this.pnCabecera.Location = new System.Drawing.Point(3, 31);
            this.pnCabecera.Name = "pnCabecera";
            this.pnCabecera.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.pnCabecera.Size = new System.Drawing.Size(596, 39);
            this.pnCabecera.TabIndex = 1;
            // 
            // lblTituloBase
            // 
            this.lblTituloBase.AutoSize = true;
            this.lblTituloBase.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lblTituloBase.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTituloBase.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTituloBase.Location = new System.Drawing.Point(4, 4);
            this.lblTituloBase.Name = "lblTituloBase";
            this.lblTituloBase.Size = new System.Drawing.Size(67, 30);
            this.lblTituloBase.TabIndex = 0;
            this.lblTituloBase.Text = "Título";
            // 
            // UcToolbar
            // 
            this.Controls.Add(this.pnCabecera);
            this.Controls.Add(this.tbMenu);
            this.DockPadding.All = 3;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.Size = new System.Drawing.Size(602, 308);
            this.Text = "usEdicion";
            this.pnCabecera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolBar tbMenu;
        protected ToolBarButton tbtnGuardar;
        protected ToolBarButton tbtnCancelar;
        protected ToolBarButton tbtnCerrar;
        protected ControlBase.Label lblTituloBase;
        protected Panel pnCabecera;







    }
}