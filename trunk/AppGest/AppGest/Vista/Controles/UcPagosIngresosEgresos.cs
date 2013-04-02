#region Using

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [Administrador]
    [Supervisor]
    [Operador]
    public partial class UcPagosIngresosEgresos : UcToolbar
    {
        private TipoServicio _tipoServicio;
        private string _encabezadoFechaPago;
        private ProxyPagoIngresosEgresosVarios _proxyPagoIngresosEgresosVarios;
        private ProxyPagoIngresosEgresosVariosDetalle _proxyPagoIngresosEgresosVariosDetalleEnEdicion;

        public UcPagosIngresosEgresos()
        {
            InitializeComponent();
        }

        public UcPagosIngresosEgresos(TipoServicio tipoServicio) : this()
        {
            _tipoServicio = tipoServicio;

            this.EstablecerTitulo(this.ObtenerTitulo());

            if (_proxyPagoIngresosEgresosVarios == null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
                {

                    Reg_encab transaccion = exp.NuevoPago( _tipoServicio, false);
                    _proxyPagoIngresosEgresosVarios = new ProxyPagoIngresosEgresosVarios(transaccion, _tipoServicio);
                }
            }

            lblValorFecha.Text = _proxyPagoIngresosEgresosVarios.FechaRegistro.ToString(FormatHelper.ShortDateFormatCurrentCulture);
            lblValorTotal.Text = _proxyPagoIngresosEgresosVarios.Total.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);

            ucGrillaPagosEgresosVarios.DataSource = _proxyPagoIngresosEgresosVarios.Detalles;
            ucGrillaPagosEgresosVarios.ParametrosGrilla = ConfiguracionGrilla;
        }

        private string ObtenerTitulo()
        {
            switch (_tipoServicio)
            {
                case TipoServicio.Ingresos:
                    _encabezadoFechaPago = "Fecha de Cobro";
                    return "Registro de ingresos de fondos";
                case TipoServicio.EgresosEmpleados:
                    _encabezadoFechaPago = "Fecha de Pago";
                    return "Pago al personal";
                case TipoServicio.EgresosVarios:
                    _encabezadoFechaPago = "Fecha de Pago";
                    return "Registro de egresos de fondos";
            }
            return string.Empty;
        }

        ParametrosGrilla _configuracion = null;
        public ParametrosGrilla ConfiguracionGrilla
        {
            get
            {
                if (_configuracion == null)
                    _configuracion = CrearConfiguracionGrilla();
                return _configuracion;
            }
        }

        private ParametrosGrilla CrearConfiguracionGrilla()
        {
            ucGrillaPagosEgresosVarios.Dock = DockStyle.Fill;
            ucGrillaPagosEgresosVarios.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrillaPagosEgresosVarios.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrillaPagosEgresosVarios_ClickAccion);

            var columnas = new List<ParametrosColumna>();
            CrearColumnasDatos(columnas);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }

        private void CrearColumnasDatos(List<ParametrosColumna> columnas)
        {
            int pos = 0;
            var pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_SERVICIO, "Fecha", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_PAGO, _encabezadoFechaPago, true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            if (_tipoServicio == TipoServicio.Ingresos)
            {
                pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_NOMBRE_CLIENTE, "Cliente", true, pos++, 250, true, false,
                    DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
                columnas.Add(pCol);
            }

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_CONCEPTO_EGRESO, "Concepto", true, pos++, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_IMPORTE, "Importe", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_ABONADO, "Pagado", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_VENCIMIENTO, "Fecha de Vto.", true, pos++, 100, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_COMENTARIO, "Comentario", true, pos++, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Modificar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Quitar", "Elimnar", "Dar de baja el registro actual", TipoControlAccion.BotonEliminar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = pos++;
            pcAccion.Ancho = BotonEliminar.Ancho + BotonEditar.Ancho;

            columnas.Add(pcAccion);

        }

        void ucGrillaPagosEgresosVarios_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Modificar":
                    _proxyPagoIngresosEgresosVariosDetalleEnEdicion = this.ucGrillaPagosEgresosVarios.DataSource[e.RowIndex] as ProxyPagoIngresosEgresosVariosDetalle;
                    this.CargarDetallePagoEgresosVarios(true);
                    break;
                case "Quitar":
                    _proxyPagoIngresosEgresosVarios.Detalles.Remove(this.ucGrillaPagosEgresosVarios.DataSource[e.RowIndex] as ProxyPagoIngresosEgresosVariosDetalle);
                    ucGrillaPagosEgresosVarios.DataSource = _proxyPagoIngresosEgresosVarios.Detalles;
                    this.ActualizarTotal();
                    break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
            {
                _proxyPagoIngresosEgresosVariosDetalleEnEdicion = exp.NuevoDetalle(_proxyPagoIngresosEgresosVarios);
            }
            this.CargarDetallePagoEgresosVarios(false);
        }

        private void CargarDetallePagoEgresosVarios(bool esEdicion)
        {
            var f = new FrmDetallePagoIngresosEgresos(FormBorderStyle.None, Color.White, _proxyPagoIngresosEgresosVariosDetalleEnEdicion, esEdicion, false, _tipoServicio);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch(((Form)sender).DialogResult)
            {
                case Gizmox.WebGUI.Forms.DialogResult.Yes :
                    if (!_proxyPagoIngresosEgresosVarios.Detalles.Contains(_proxyPagoIngresosEgresosVariosDetalleEnEdicion))
                    {
                        _proxyPagoIngresosEgresosVarios.Detalles.Add(_proxyPagoIngresosEgresosVariosDetalleEnEdicion);
                    }
                    ucGrillaPagosEgresosVarios.DataSource = _proxyPagoIngresosEgresosVarios.Detalles;

                    var tot = (from p in _proxyPagoIngresosEgresosVarios.Detalles
                              select p.Importe).Sum();

                    lblValorTotal.Text = tot.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
                    this.ActualizarTotal();
                    break;
                case Gizmox.WebGUI.Forms.DialogResult.No :
                    _proxyPagoIngresosEgresosVariosDetalleEnEdicion = null;
                    break;
            }
        }

        /// <summary>
        /// Guarda los pagos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ClickOk(object sender, EventArgs e)
        {
            if (_proxyPagoIngresosEgresosVarios.Detalles.Count == 0)
            {
                MessageBox.Show("No ha cargado pagos por guardar.", "Guardar cambios", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.ClickOk(sender, e);
                return;
            }

            try
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
                {
                    _proxyPagoIngresosEgresosVarios.Comentario = this.txtcomentario.Text;
                    exp.GuardarPago(_proxyPagoIngresosEgresosVarios);

                    if (_proxyPagoIngresosEgresosVarios.Detalles.Count == 1)
                    {
                        MensajeUsuario = "Se guardó correctamente el pago.";
                    }
                    else
                    {
                        MensajeUsuario = "Se guardaron correctamente los pagos.";
                    }

                    base.ClickOk(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro. Verifique los datos.\n\nDetalle error: " + ex.Message, "Error el guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar pagos.\nError:" + ex.Message, ex.InnerException);
            }

        }

        private void ActualizarTotal()
        {
            this.lblValorTotal.Text = _proxyPagoIngresosEgresosVarios.Total.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
        }


    }
}