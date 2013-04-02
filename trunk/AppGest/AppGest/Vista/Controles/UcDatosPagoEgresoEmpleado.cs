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
using AppGest.Datos.Persistencia;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class UcDatosPagoEgresoEmpleado : UcToolbar
    {
        ProxyExpPagoEgresoEmpleadoLinea _linea;
        ItemResumen _itemRes;
        public UcDatosPagoEgresoEmpleado()
        {
            InitializeComponent();
          
        }

        public void Modificar(ExpPagoEgresoEmpleado experto, ProxyExpPagoEgresoEmpleadoLinea linea, ItemResumen item)
        {
            // TODO: Obtener la entidad para la edicion de los mensuales.
            _itemRes = item;
            _linea = linea;
            Inicializar(experto);
            Cargar(experto);

            SetEdiable(experto, true);
        }

        private void SetEdiable(ExpPagoEgresoEmpleado experto, bool editable)
        {
            
            pnlDatosPago.Enabled = editable;


            // se habilitan los campos editables
            if (pnlDatosPago.Enabled)
            {
                // TODO: Rever [MF]
                //var listaPagos = experto.ObtenerPagosEfectuadosAEmpleado(_linea.Empleado.Id, _linea.Periodo.Inferior(DateInterval.Month), _linea.Periodo.Superior(DateInterval.Month));
                //nudMonto.Enabled = listaPagos.Count == 0;
            }
        }

        private void Inicializar(ExpPagoEgresoEmpleado experto)
        {
            var momentos = new List<Concepto>();

            momentos.Add(HelperModelo.ObtenerConceptoSistema(experto, ConceptoCualitativo.ANTICIPO));
            momentos.Add(HelperModelo.ObtenerConceptoSistema(experto, ConceptoCualitativo.A_TERMINO));

            this.cboMomento.DisplayMember = "Nombre";
            this.cboMomento.ValueMember = "Id";
            this.cboMomento.DataSource = momentos;

            this.cboMomento.SelectedItem = momentos[0];
        }

        public override bool HayCambios()
        {
            return _linea.TieneCambios;
        }

        protected void Cargar(ExpPagoEgresoEmpleado experto)
        {
            
            lblEmpleado.Text = string.Format(lblEmpleado.Text, _linea.Empleado.NombreCompleto, _linea.Empleado.Dni, _linea.Empleado.Alta.ToString(FormatHelper.ShortDateFormat));

            dtpPeriodo.Value = _linea.Periodo.IsMinValue() ? dtpPeriodo.MinDate : _linea.Periodo;
            dtpFechaPago.Value = _linea.FechaPago.IsMinValue() ? DateTime.MinValue : _linea.FechaPago;

            if(_linea.Momento !=null ) cboMomento.SelectedValue = _linea.Momento.Id;
            nudMonto.CurrentValue = _linea.Importe == 0 ? _itemRes.Saldo : _linea.Importe; // ;
            txtConcepto.Text = _linea.Concepto.Nombre;
            txtComentario.Text = _linea.Comentario;
        }

        void LLenarProxy()
        {
            _linea.Periodo = dtpPeriodo.MinDate.Equals(dtpPeriodo.Value) ? DateTime.MinValue : dtpPeriodo.Value;
            _linea.FechaPago = dtpFechaPago.Value;
            _linea.Momento = cboMomento.SelectedItem as Concepto;
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