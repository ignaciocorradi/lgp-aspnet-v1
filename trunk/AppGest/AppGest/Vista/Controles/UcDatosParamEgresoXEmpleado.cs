#region Using

using System;
using System.Collections.Generic;
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
    public partial class UcDatosParamEgresoXEmpleado : UcToolbar
    {
        ProxyExpParamsEgresoEmpleadoLinea _linea;

        public UcDatosParamEgresoXEmpleado()
        {
            InitializeComponent();
        }

        public void Modificar(ProxyExpParamsEgresoEmpleadoLinea linea)
        {
            // TODO: Obtener la entidad para la edicion de los mensuales.
            _linea = linea;
            Inicializar();
            Cargar();

            SetEdiable(true);
        }

        private void SetEdiable(bool editable)
        {
            
            pnlDatosPago.Enabled = editable;


            // se habilitan los campos editables
            if (pnlDatosPago.Enabled)
            {
                using(var exp = FabExpertos.Inst.Obtener<ExpPagoEgresoEmpleado>(this.IdSesion))
                {
                    var listaPagos = exp.ObtenerPagosEfectuadosAEmpleado(_linea.Empleado.Id, _linea.Desde, _linea.Hasta);
                    nudMonto.Enabled = editable && listaPagos.Count == 0;
                }
            }
        }

        private void Inicializar()
        {
            this.nudMonto.TextAlign = HorizontalAlignment.Right;
        }

        public override bool HayCambios()
        {
            bool rdo = false;

            rdo =
                    _linea.Importe != nudMonto.CurrentValue
                    || _linea.Desde != dtpDesde.Value
                    || _linea.Hasta != dtpHasta.Value
                    || _linea.Comentario != txtComentario.Text;

            return rdo;

        }

        protected void Cargar()
        {
            
            lblEmpleado.Text = string.Format(lblEmpleado.Text, _linea.Empleado.NombreCompleto, _linea.Empleado.Dni, _linea.Empleado.Alta.ToString(FormatHelper.ShortDateFormat));

            dtpDesde.Value = _linea.Desde.IsMinValue() ? dtpDesde.MinDate : _linea.Desde;
            dtpHasta.Value = _linea.Hasta.IsMinValue() ? dtpHasta.MinDate : _linea.Hasta;
            nudMonto.CurrentValue = _linea.Importe;
            txtConcepto.Text = _linea.Concepto.Nombre;
            txtComentario.Text = _linea.Comentario;
        }

        void LLenarProxy()
        {
            _linea.Desde = dtpDesde.MinDate.Equals(dtpDesde.Value) ? DateTime.MinValue : dtpDesde.Value;
            _linea.Hasta = dtpHasta.MinDate.Equals(dtpHasta.Value) ? DateTime.MinValue : dtpHasta.Value;
            _linea.Importe = nudMonto.CurrentValue;
            _linea.Concepto.Nombre = txtConcepto.Text;
            _linea.Comentario = txtComentario.Text;
        }

        public void Nuevo()
        {
        }
        protected override void ClickOk(object sender, EventArgs e)
        {
            LLenarProxy();
            base.ClickOk(sender, e);
        }

        protected override void ClickCancelar(object sender, EventArgs e)
        {
            base.ClickCancelar(sender, e);
        }
    }
}