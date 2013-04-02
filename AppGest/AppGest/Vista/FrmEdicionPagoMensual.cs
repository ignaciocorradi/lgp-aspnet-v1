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
using AppGest.Negocio.Core;

#endregion

namespace AppGest.Vista
{
    public partial class FrmEdicionPagoMensual : FrmBase
    {
        //private Concepto _concepto;  
       
        public FrmEdicionPagoMensual():base()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(576, 550);
            ucDatosPagoMensual1.ComprobarCambios = false;

        }

        public FrmEdicionPagoMensual(FormBorderStyle formBorderStyle, Color color, ProxyExpPagosMensLinea pago)
            :this()
        {
            this.FormBorderStyle = formBorderStyle;
            this.BackColor = color;
            this.ucDatosPagoMensual1.Cancelar_Click += new Controles.Click_EventHandler(ucDatosPagoMensual_Cancelar_Click);
            this.ucDatosPagoMensual1.Guardar_Click += new Controles.Click_EventHandler(ucDatosPagoMensual_Guardar_Click);

            CalcularSaldoActual(pago);
            this.ucDatosPagoMensual1.Modificar(pago);
        }

        private void CalcularSaldoActual(ProxyExpPagosMensLinea pago)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
            {
                var pendientes = exp.ObtenerPagosPendientes(pago.Periodo, null, pago.Cliente.Id, null);
                var pendiente = pendientes.SingleOrDefault();

                if (pendiente != null)
                {
                    pago.Saldo = pendiente.SaldoOrig;
                    pago.SaldoOrig = pendientes.Single().SaldoOrig - (pago.Abonado - pago.Recargo);
                }
                else
                {
                    pago.Saldo = 0;
                    pago.SaldoOrig = 0 - (pago.Abonado - pago.Recargo);
                }
            }
        }
        void ucDatosPagoMensual_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.CerrarForm();
        }

        void ucDatosPagoMensual_Cancelar_Click(object sender, EventArgs e)
        {
            if (ucDatosPagoMensual1.HayCambios())
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

                    if (ucDatosPagoMensual1.Pago != null)
                        ucDatosPagoMensual1.Pago.RechazarCambios();

                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.ucDatosPagoMensual1.GuardarUC();
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
            this.ucDatosPagoMensual1.Dispose();
            this.Close();
        }
   
    }
}