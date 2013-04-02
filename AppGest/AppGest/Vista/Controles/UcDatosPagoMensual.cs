#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo;
using AppGest.Util.Atributos;
using AppGest.Negocio.Core;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class UcDatosPagoMensual : UcToolbar
    {
        public ProxyExpPagosMensLinea Pago
        {
            get { return _pago; }
        }   ProxyExpPagosMensLinea _pago;

        public UcDatosPagoMensual()
        {
            InitializeComponent();
        }

        public void Modificar(ProxyExpPagosMensLinea pago)
        {
            // TODO: Obtener la entidad para la edicion de los mensuales.
            _pago = pago;

            _pago.IniciarCambios();
            Inicializar();
            Cargar();

            SetEdiable(true);
        }

        private void SetEdiable(bool editable)
        {
            ucCliente.Enabled = false;  // los datos del cliente no serán editables
            pnlDatosPago.Enabled = editable;
        }

        private void Inicializar()
        {
        }

        public override bool HayCambios()
        {
            bool rdo = false;

            rdo =
                    _pago.Abonado != nudImporte.CurrentValue
                    || _pago.Bonificacion != nudBonificacion.CurrentValue
                    || _pago.Recargo != nudBonificacion.CurrentValue
                    || _pago.Periodo.Inferior(DateInterval.Month) != dtpPeriodoImpago.Value.Inferior(DateInterval.Month)
                    || _pago.FechaPago != dtpFechaPago.Value
                    || _pago.Comentario != txtComentario.Text;

            return rdo;

        }

        protected void Cargar()
        {
            ucCliente.LLenarControles(_pago.Cliente);
            dtpPeriodoImpago.Value = _pago.Periodo;
            dtpFechaPago.Value = _pago.FechaPago;
            nudImporte.CurrentValue = _pago.Abonado;
            nudBonificacion.CurrentValue = _pago.Bonificacion;
            nudRecargo.CurrentValue = _pago.Recargo;
            txtServicio.Text = _pago.Concepto.Nombre;
            nudPrecio.CurrentValue = _pago.PrecioOrig;
            txtComentario.Text = _pago.Comentario;

            nudImporte.ValueChanged += new EventHandler(Cambia_Saldo);
            nudBonificacion.ValueChanged += new EventHandler(Cambia_Saldo);
            nudRecargo.ValueChanged += new EventHandler(Cambia_Saldo);

            nudSaldo.CurrentValue = _pago.Saldo;
        }

        void Cambia_Saldo(object sender, EventArgs e)
        {
            nudSaldo.CurrentValue = ExpPagosMensuales.CalcularSaldo(_pago.Saldo, nudImporte.CurrentValue - _pago.Abonado, nudBonificacion.CurrentValue - _pago.Bonificacion, nudRecargo.CurrentValue - _pago.Recargo);
        }

        void LLenarProxy()
        {
            _pago.Periodo = dtpPeriodoImpago.Value;
            _pago.FechaPago = dtpFechaPago.Value;
            _pago.Abonado = nudImporte.CurrentValue;
            _pago.Recargo = nudRecargo.CurrentValue;
            _pago.Bonificacion = nudBonificacion.CurrentValue;
            _pago.Comentario = txtComentario.Text;
        }
        public void Nuevo()
        {
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {

                using (var experto = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
                {
                    LLenarProxy();
                    experto.Guardar(_pago);
                    _pago.AceptarCambios();
                    base.ClickOk(sender, e);
                }
            }
            catch (ValidacionException vex)
            {
                _pago.RechazarCambios();
                _pago.IniciarCambios();
                MessageBox.Show(vex.MessageCompleteConTitulo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Validación al guardar: " + vex.MessageCompleteConTitulo);
            }
            catch (Exception ex)
            {
                _pago.RechazarCambios();
                _pago.IniciarCambios();
                MessageBox.Show("Error al guardar.\n\nDetalle:\n" + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + ex.Message + "\n\n" + ex.InnerException);
            }
        }

        protected override void ClickCancelar(object sender, EventArgs e)
        {
            base.ClickCancelar(sender, e);
        }
    }
}