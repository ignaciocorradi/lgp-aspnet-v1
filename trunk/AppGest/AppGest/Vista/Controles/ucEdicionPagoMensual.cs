#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using System.Collections;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucEdicionPagoMensual : UcEdicionBase
    {
        public ucEdicionPagoMensual()
        {
            InitializeComponent();
            this.EstablecerTitulo("Edición de cobros de clientes mensuales");
            lblAbonado.Text = "";
            lblBonif.Text = "";
            lblRecargo.Text = "";
        }

        public void Inicializar()
        {
            ucGrilla1.DataSource = new List<ProxyExpPagosMensLinea>();

            var configuracion = UcPagosMensuales.ObtenerConfiguracionGrillaPagos(false);
            UcPagosMensuales.CrearColumnaEdicion(configuracion.ParametrosColumna, configuracion.ParametrosColumna.Count +1);

            ucGrilla1.ParametrosGrilla = configuracion;
            SuscribirAcciones();

        }

        void CargarDatos()
        {

            using (var exp = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
            {
                this.MensajeUsuario = "Buscando...";
                var datos = exp.ObtenerPagosRegistrados(
                        chkHabPeriodo.Checked ? dtpPeriodoDesde.Value.Inferior(DateInterval.Month) : (DateTime?)null
                        , chkHabPeriodo.Checked ? dtpPeriodoHasta.Value.Superior(DateInterval.Month) : (DateTime?) null
                        , chkHabFechaPago.Checked ? dtpFechaPago.Value : (DateTime?) null
                        , txtNombre.Text
                        , null
                        , txtCochera.Text
                        );

                ucGrilla1.DataSource = datos as IList;
                if (datos.Count == 0)
                    this.MensajeUsuario = "No se encontraron datos.";
                else
                    this.MensajeUsuario = (datos.Count == 1 ? "Se encontró " : "Se encontraron ")
                                            + datos.Count.ToString()
                                            + (datos.Count == 1 ? " registro." : " registros.");
            }
        }

  
        protected override void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    EditarPago(this.ucGrilla1.DataSource[e.RowIndex] as ProxyExpPagosMensLinea);
                    break;

                case "Baja":
                    ConfirmarYDarBajaPago(this.ucGrilla1.DataSource[e.RowIndex] as ProxyExpPagosMensLinea);
                    break;

            }
        }

        private void EditarPago(ProxyExpPagosMensLinea pago)
        {
            if (pago != null)
            {
                FrmEdicionPagoMensual f = new FrmEdicionPagoMensual(FormBorderStyle.None, Color.White, pago);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarClienteClose_FormClosed);
            }
        }

        private void ConfirmarYDarBajaPago(ProxyExpPagosMensLinea pago)
        {
            var msg = "Va a 'dar de baja' este registro de cobro mensual. ¿Desea continuar?";
            if (pago != null)
            {
                MessageBox.Show(msg, "Baja de registro de Cobro Mensual",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2,
                                new EventHandler(delegate(object sender, EventArgs e) { DarBaja(sender, pago); }));
            }
        }

        private void DarBaja(object sender, ProxyExpPagosMensLinea pago)
        {

            try
            {
                var rdo = ((Form)sender).DialogResult;
                if (rdo == DialogResult.Yes)
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
                        exp.DarDeBaja(pago.IdRegDet);

                    this.CargarDatos();
                }
            }
            catch (ValidacionException vex)
            {
                MessageBox.Show(vex.MessageCompleteConTitulo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar.\n\nDetalle:\n" + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + ex.Message + "\n\n" + ex.InnerException);
            }
            finally
            {
            }
        }

        void frmEditarClienteClose_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.CargarDatos();
            }
        }

        protected override void CrearColumnasDatos(List<ParametrosColumna> columnas)
        {
            var pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NroCliente, "Nro Cliente", true, 0, 70, true, false,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreCliente, "Clientes", true, 1, 170, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreVehiculos, "Vehículos asociados", true, 1, 350, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreCocheras, "Cocheras asociadas", true,2, 500, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);
        }

        protected override void CrearColumnasAccion(List<ParametrosColumna> columnas)
        {
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 4;
            pcAccion.Ancho = BotonEditar.Ancho;

            columnas.Add(pcAccion);

        }

        /// <summary>
        /// Emula el evento de click del botón Guardar
        /// </summary>
        internal override void GuardarUC()
        {
            this.tbtnGuardar_Click(this, new EventArgs());
        }
        /// <summary>
        /// Emula el evento de click del botón cancelar
        /// </summary>
        internal override void CancelarUC()
        {
            this.MensajeUsuario = "Listo.";
            this.ClickCancelar(this, new EventArgs());
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //bool? activos = null;
            //if (this.rbtnActivos.Checked)
            //{
            //    activos = true;
            //}
            //else if (this.rbtnDadosDeBaja.Checked)
            //{
            //    activos = false;
            //}

            //this.CargarDatos(this.txtNombre.Text.Trim(), this.txtApellido.Text.Trim(), activos);
        }

        void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.CargarDatos();
            this.ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            IList<ProxyExpPagosMensLinea> datos = this.ucGrilla1.DataSource as IList<ProxyExpPagosMensLinea>;

            if (datos.Count == 0)
            {
                lblAbonado.Text = "";
                lblBonif.Text = "";
                lblRecargo.Text = "";
            }
            else
            {
                decimal abonado = (from r in datos
                                   select r.Abonado).Sum();
                decimal recargo = (from r in datos
                                   select r.Recargo).Sum();
                decimal bonif = (from r in datos
                                 select r.Bonificacion).Sum();

                lblAbonado.Text = "Total Abonado: " + abonado.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
                lblBonif.Text = "Total Bonif: " + bonif.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
                lblRecargo.Text = "Total Recargo: " + recargo.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            }
        }

        private void chkHabPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroPeriodo.Enabled = chkHabPeriodo.Checked;
        }

        private void chkHabFechaPago_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroFechaPago.Enabled = chkHabFechaPago.Checked;
        }
    }
}