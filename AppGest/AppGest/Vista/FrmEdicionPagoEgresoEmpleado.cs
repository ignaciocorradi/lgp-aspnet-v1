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
using AppGest.Vista.Controles;

#endregion

namespace AppGest.Vista
{
    public partial class FrmEdicionPagoEgresoEmpleado : FrmBase
    {
        public ProxyExpPagoEgresoEmpleadoLinea Linea { get; private set; }
        public ItemResumen ItemResumen { get; private set; }
        public decimal TotalSaldoSinImporte { get; private set; }

        public FrmEdicionPagoEgresoEmpleado():base()
        {
            InitializeComponent();
            this.Size = new Size(524, 376);
            UcDatosPagoEgresoEmpleado1.ComprobarCambios = false;

        }

        public FrmEdicionPagoEgresoEmpleado(ExpPagoEgresoEmpleado experto, FormBorderStyle formBorderStyle, Color color, ProxyExpPagoEgresoEmpleadoLinea linea, ItemResumen itemResumen)
            :this()
        {
            Linea = linea;
            ItemResumen = itemResumen;
            TotalSaldoSinImporte = itemResumen.Sueldo + itemResumen.Abonado;

            this.FormBorderStyle = formBorderStyle;
            this.BackColor = color;
            this.UcDatosPagoEgresoEmpleado1.Cancelar_Click += new Controles.Click_EventHandler(ucDatosPagoEgresoEmpleado1_Cancelar_Click);
            this.UcDatosPagoEgresoEmpleado1.Guardar_Click += new Controles.Click_EventHandler(ucDatosPagoEgresoEmpleado1_Guardar_Click);
            this.UcDatosPagoEgresoEmpleado1.Modificar(experto, linea, itemResumen);
        }
        void ucDatosPagoEgresoEmpleado1_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.CerrarForm();
        }

        void ucDatosPagoEgresoEmpleado1_Cancelar_Click(object sender, EventArgs e)
        {
            if (UcDatosPagoEgresoEmpleado1.HayCambios())
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
                    this.UcDatosPagoEgresoEmpleado1.GuardarUC();
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
            this.UcDatosPagoEgresoEmpleado1.Dispose();
            this.Close();
        }
   
    }
}