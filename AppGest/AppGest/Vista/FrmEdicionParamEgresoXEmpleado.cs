#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio;
using AppGest.Negocio.Modelo;

using AppGest.Datos.Persistencia;

#endregion

namespace AppGest.Vista
{
    public partial class FrmEdicionParamEgresoXEmpleado : FrmBase
    {
        public ProxyExpParamsEgresoEmpleadoLinea Linea { get; private set; }
       
        public FrmEdicionParamEgresoXEmpleado():base()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(536, 374);
            UcDatosParamEgresoXEmpleado1.ComprobarCambios = false;

        }

        public FrmEdicionParamEgresoXEmpleado(FormBorderStyle formBorderStyle, Color color, ProxyExpParamsEgresoEmpleadoLinea linea)
            :this()
        {
            Linea = linea;
            this.FormBorderStyle = formBorderStyle;
            this.BackColor = color;
            this.UcDatosParamEgresoXEmpleado1.Cancelar_Click += new Controles.Click_EventHandler(ucDatosParamEgresoXEmpleado1_Cancelar_Click);
            this.UcDatosParamEgresoXEmpleado1.Guardar_Click += new Controles.Click_EventHandler(ucDatosParamEgresoXEmpleado1_Guardar_Click);
            this.UcDatosParamEgresoXEmpleado1.Modificar(linea);
        }
        void ucDatosParamEgresoXEmpleado1_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.CerrarForm();
        }

        void ucDatosParamEgresoXEmpleado1_Cancelar_Click(object sender, EventArgs e)
        {
            if (UcDatosParamEgresoXEmpleado1.HayCambios())
            {
                MessageBox.Show("Ha realizado cambios en los datos, si continua se perderán.\n¿Desea guardar los cambios?",
                    "Guardar cambios", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                    new EventHandler(Guardar_Cerrar_Cancelar));
            }
            else
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
                this.Guardar_Cerrar_Cancelar(this, new EventArgs());
            }
        }

        private void Guardar_Cerrar_Cancelar(object sender, EventArgs e)
        {
            // Guarda los cambios
            this.DialogResult = ((Gizmox.WebGUI.Forms.Form) sender).DialogResult;
            switch (((Gizmox.WebGUI.Forms.Form)sender).DialogResult)
            {
                case DialogResult.No:
                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.UcDatosParamEgresoXEmpleado1.GuardarUC();
                    break;
                case DialogResult.Cancel:
                // No hace nada
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Retry:
                default:
                    break;
            }
        }

        private void CerrarForm()
        {
            this.UcDatosParamEgresoXEmpleado1.Dispose();
            this.Close();
        }
   
    }
}