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
using AppGest.Negocio.Modelo;
using AppGest.Vista.Controles;
using AppGest.Datos.Persistencia;

#endregion

namespace AppGest.Vista
{
    public partial class FrmDetallePagoIngresosEgresos : FrmBase
    {
        private bool _esEdicion;
        public FrmDetallePagoIngresosEgresos()
        {
            InitializeComponent();
        }

        public FrmDetallePagoIngresosEgresos(FormBorderStyle estiloBorde, Color fondo, ProxyPagoIngresosEgresosVariosDetalle detalle, bool esEdicion, bool permiteGuardar, TipoServicio tipoServicio)
            : this()
        {
            InicializarPantalla(estiloBorde, fondo, detalle, esEdicion, permiteGuardar, tipoServicio);
        }

        private void InicializarPantalla(FormBorderStyle estiloBorde, Color fondo, ProxyPagoIngresosEgresosVariosDetalle detalle, bool esEdicion, bool permiteGuardar, TipoServicio tipoServicio)
        {
            this._esEdicion = esEdicion;
            this.FormBorderStyle = estiloBorde;
            this.ucDetallePagoEgresosVarios1.BackColor = fondo;
            this.ucDetallePagoEgresosVarios1.tbMenu.Visible = true;
            this.ucDetallePagoEgresosVarios1.tbMenu.Enabled = true;
            this.ucDetallePagoEgresosVarios1.Cancelar_Click += new Controles.Click_EventHandler(ucDetallePagoEgresosVarios1_Cancelar_Click);
            this.ucDetallePagoEgresosVarios1.Guardar_Click += new Controles.Click_EventHandler(ucDetallePagoEgresosVarios1_Guardar_Click);

            this.ucDetallePagoEgresosVarios1.CargarPago(detalle, _esEdicion, permiteGuardar, tipoServicio);
        }

        void ucDetallePagoEgresosVarios1_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;

            this.CerrarForm();
        }

        void ucDetallePagoEgresosVarios1_Cancelar_Click(object sender, EventArgs e)
        {
            // si se cancela, solo se cierra el formulario para
            if (this.ucDetallePagoEgresosVarios1.HayCambios())
            {
                //TODO: Revisar si aplica.
                MessageBox.Show("Ha realizado cambios en el pago.\n¿Desea Guardar estos cambios?.", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3, new EventHandler(Guardar_Cerrar_Cancelar));
            }
            else
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
                Guardar_Cerrar_Cancelar(this, e);
            }
        }

        private void Guardar_Cerrar_Cancelar(object sender, EventArgs e)
        {
            // Guarda los cambios
            this.DialogResult = ((Gizmox.WebGUI.Forms.Form)sender).DialogResult;
            switch (((Gizmox.WebGUI.Forms.Form)sender).DialogResult)
            {
                case DialogResult.No:
                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.ucDetallePagoEgresosVarios1_Guardar_Click(sender, e);
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
            this.ucDetallePagoEgresosVarios1.Dispose();
            this.Close();
        }
    }
}