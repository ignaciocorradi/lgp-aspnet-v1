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
using System.Collections;
using System.Linq;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class UcCargaPagoEgresoEmpleado : UcToolbar
    {
        private List<ProxyExpPagoEgresoEmpleadoLinea> _pagosPeriodoActual = new List<ProxyExpPagoEgresoEmpleadoLinea>();
        private ProxyExpPagoEgresoEmpleadoEncab _encab;
        public UcCargaPagoEgresoEmpleado()
        {
            InitializeComponent();
            VisualizarBotonesToolbar(true, true, false);
            EstablecerTitulo("Pago de Remuneraciones");
            InicializarFiltros();
            ConfigurarGrilla();
            ActualizarUI(false, true);
            SuscribirAcciones();
        }

        private void InicializarFiltros()
        {
            cboEmpleado.Text = string.Empty;
            cboEmpleado.ValueMember = Empleado.PROP_ID;
            cboEmpleado.DisplayMember = Empleado.PROP_NOMBRECOMPLETO;

            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
                cboEmpleado.DataSource = exp.EmpleadosALiquidar();

        }

        protected virtual void SuscribirAcciones()
        {
            ucGrillaDetLiq.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrillaDet_ClickAccion);
            ucGrillaResLiq.Grilla.CellFormatting += new DataGridViewCellFormattingEventHandler(UcGrillaResLiq_CellFormatting);
            ucGrillaDetLiq.Grilla.CellFormatting += new DataGridViewCellFormattingEventHandler(UcGrillaDetLiq_CellFormatting);
        }

        void UcGrillaDetLiq_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = ucGrillaDetLiq.Grilla.Rows[e.RowIndex];
                if (row.Cells["MomentoNombre"].Value != null && !row.Cells["MomentoNombre"].Value.ToString().ToUpper().Contains("ANTICIPO"))
                    e.CellStyle.BackColor = Color.SkyBlue;
            }
        }

        void UcGrillaResLiq_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = ucGrillaResLiq.Grilla.Columns[e.ColumnIndex];
                if (column.Name == "Saldo")
                {
                    e.CellStyle.ForeColor = GetForeColorBySaldo((decimal)(e.Value ?? 0M));
                }
            }
        }

        void GrillaRes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetallesPago();
        }

        private void ActualizarDetallesPago()
        {

            var itemResumen = GetItemResumenSeleccionado();
            if (itemResumen != null)
            {

                var periodoStr = itemResumen.Periodo.ToString(FormatHelper.MonthNameYearFormat);
                periodoStr = periodoStr[0].ToString().ToUpper() + periodoStr.Substring(1);

                lblTituloDetalle.Text = lblTituloDetalle.Tag.ToString() + ": " + periodoStr;
                lblRemu.Text = itemResumen.Sueldo.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
                lblTotalAbonado.Text = itemResumen.Abonado.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);

                lblSaldo.Text = itemResumen.Saldo.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
                lblSaldo.ForeColor = GetForeColorBySaldo(itemResumen.Saldo);


                FiltrarPagosPeriodo(itemResumen.Periodo);
                btnAgregar.Visible = itemResumen.Saldo > 0M;
            }
            else
            {
                lblTituloDetalle.Text = lblTituloDetalle.Tag.ToString() + ": -";
                lblRemu.Text = "-";
                lblTotalAbonado.Text = "-";
                lblSaldo.Text = "-";

                FiltrarPagosPeriodo(null);
                btnAgregar.Visible = false;
            }

        }
        Color GetForeColorBySaldo(decimal saldo)
        {
            if (saldo == 0)
                return Color.Black;
            if (saldo < 0)
                return Color.Blue;
            else
                return Color.Red;

        }
        ItemResumen GetItemResumenSeleccionado()
        {
            var row = ucGrillaResLiq.Grilla.SelectedRows.Count == 0 ? (DataGridViewRow)null : ucGrillaResLiq.Grilla.SelectedRows[0];

            if (row != null)
            {
                var itemResumen = (ItemResumen) row.DataBoundItem;
                return itemResumen;
            }
            else
                return null;

        }
        private void FiltrarPagosPeriodo(DateTime? periodo)
        {
            _pagosPeriodoActual.Clear();
            if (periodo != null)
                _pagosPeriodoActual.AddRange(_encab.Lineas.Where(x => x.FechaBaja == null && x.Periodo.Inferior(DateInterval.Month) == periodo.Value.Inferior(DateInterval.Month)).OrderBy(l=> l.FechaPago));

            ucGrillaDetLiq.DataSource = _pagosPeriodoActual;
        }


        protected void ucGrillaDet_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    using(var exp = FabExpertos.Inst.Obtener<ExpPagoEgresoEmpleado>(IdSesion))
                        EditarPago(exp, this.ucGrillaDetLiq.DataSource[e.RowIndex] as ProxyExpPagoEgresoEmpleadoLinea);
                    break;
                case "Eliminar":
                    EliminarPago(this.ucGrillaDetLiq.DataSource[e.RowIndex] as ProxyExpPagoEgresoEmpleadoLinea);
                    break;
            }
        }

        private void EliminarPago(ProxyExpPagoEgresoEmpleadoLinea linea)
        {
            if (linea != null)
                {
                    MessageBox.Show("Se eliminará la línea.\n¿Desea realizar la acción?",
                    "Guardar cambios", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                    new EventHandler(delegate(object sender, EventArgs e) { ActivarBaja(sender, linea); }));
            }
        }

        private void ActivarBaja(object sender, ProxyExpPagoEgresoEmpleadoLinea linea)
        {
            var rdo = ((Form) sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                if (linea.IdRegDet != 0)
                    linea.FechaBaja = DateTime.Now;
                else
                    _encab.Lineas.Remove(linea);

                ActualizarGrilla(false);
            }

        }

        private void ActualizarGrilla(bool inicial)
        {
            ActualizarGrillaResumen(inicial);
            ActualizarDetallesPago();
        }

        private void EditarPago(ExpPagoEgresoEmpleado experto, ProxyExpPagoEgresoEmpleadoLinea pago)
        {
            if (pago != null)
            {
                pago.IniciarCambios();
                FrmEdicionPagoEgresoEmpleado f = new FrmEdicionPagoEgresoEmpleado(experto, FormBorderStyle.None, Color.White, pago, GetItemResumenSeleccionado());
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarPagoEgresoEmpleado_FormClosed);
            }
        }

        void frmEditarPagoEgresoEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            var f = sender as FrmEdicionPagoEgresoEmpleado;
            var linea = f.Linea;
            if (f.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                linea.AceptarCambios();

                f.ItemResumen.Abonado = f.Linea.Importe;
                f.ItemResumen.Saldo = f.TotalSaldoSinImporte - - f.Linea.Importe;
            }
            else
                linea.RechazarCambios();

            ActualizarGrilla(false);
        }

        void ActualizarGrillaResumen(bool inicial)
        {

            var rowIndex = ucGrillaResLiq.FilaActual != null ? ucGrillaResLiq.FilaActual.Index : -1;

            using (var expParam = FabExpertos.Inst.Obtener<ExpParamsEgresoEmpleado>(IdSesion))
            {
                if (inicial)
                    ucGrillaResLiq.DataSource = ItemResumen.Calcular(_encab, expParam, 5) as IList;
                else
                {
                    var resumen = (List<ItemResumen>) ucGrillaResLiq.DataSource;
                    ItemResumen.Calcular(resumen, _encab, expParam);

                    ucGrillaResLiq.DataSource = resumen;
                }
            }

            ucGrillaResLiq.SeleccionarFila(rowIndex);
        }

        private void CargarSeleccion()
        {
            var empleadoId = cboEmpleado.SelectedValue;
            if (empleadoId != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagoEgresoEmpleado>(IdSesion))
                    _encab = exp.ObtenerEgresosXEmpleado(Convert.ToInt64(empleadoId), true);

                ActualizarUI(true, true);
            }

        }

        private void ActualizarUI(bool habilitar, bool inicial)
        {
            this.ucGrillaResLiq.Grilla.RowHeadersVisible = true; 

            this.btnAgregar.Enabled = habilitar;
            this.btnAgregar.Visible = habilitar;
            this.grpTotales.Visible = habilitar;
            this.ucGrillaResLiq.Enabled = habilitar;
            this.ucGrillaDetLiq.Enabled = habilitar;
            
            if(habilitar) 
                ActualizarGrilla(inicial);

            this.btnBuscar.Enabled = !habilitar;
            this.btnBuscar.Visible = !habilitar;
            this.cboEmpleado.Enabled = !habilitar;
            
        }

        void ConfigurarGrilla()
        {

            var configuracion = ObtenerConfiguracionGrillaResumen();
            ucGrillaResLiq.ParametrosGrilla = configuracion;

            ucGrillaResLiq.Grilla.RowHeadersWidth = 20;
            ucGrillaResLiq.DataSource = new List<ItemResumen>();

            configuracion = ObtenerConfiguracionGrillaDetalle();
            ucGrillaDetLiq.ParametrosGrilla = configuracion;
            ucGrillaDetLiq.DataSource = _pagosPeriodoActual;
            ucGrillaDetLiq.Grilla.RowHeadersWidth = 20;
        }

        private ParametrosGrilla ObtenerConfiguracionGrillaDetalle()
        {
            List<ParametrosColumna> columnas = new List<ParametrosColumna>();
            var pos = 0;

            ParametrosColumna pColumna = null;

            pColumna = new ParametrosColumna("ConceptoNombre", "Concepto", true, pos++, 150, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("MomentoNombre", "Tipo", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("FechaPago", "Fec. Pago", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Importe", "Importe", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pos = CrearColumnaEdicionDetalle(columnas, pos);

            pColumna = new ParametrosColumna("Comentario", "Comentario", true, 4, 140, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, "MM-yyyy", null, false);
            columnas.Add(pColumna);


            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Vertical, false, EnumEditable.NoEditable, EnumEditable.NoEditable, null);
            return configuracion;

        }

        private int CrearColumnaEdicionDetalle(List<ParametrosColumna> columnas, int pos)
        {
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Eliminar", "Eliminar", "Elimina el registro actual", TipoControlAccion.BotonEliminar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = pos++;
            pcAccion.Ancho = BotonEditar.Ancho + BotonEliminar.Ancho;

            columnas.Add(pcAccion);
            return pos;
        }

        ParametrosGrilla ObtenerConfiguracionGrillaResumen()
        {
            List<ParametrosColumna> columnas = new List<ParametrosColumna>();
            var pos = 0;

            ParametrosColumna pColumna = null;

            pColumna = new ParametrosColumna("Periodo", "Periodo", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, FormatHelper.MonthShortNameYearFormat, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Sueldo", "Sueldo", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Abonado", "Abonado", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Saldo", "Saldo", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.None, false, EnumEditable.NoEditable, EnumEditable.NoEditable, null);
            return configuracion;
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagoEgresoEmpleado>(IdSesion))
                {
                    exp.Guardar(_encab);
                }

                MessageBox.Show(this.Form, "Los datos se registraron correctamente.", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                this.MensajeUsuario = "Los datos se registraron correctamente.";
                
                base.ClickOk(sender, e);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarSeleccion();

            ActualizarDetallesPago();
            ucGrillaResLiq.Grilla.SelectionChanged += new EventHandler(GrillaRes_SelectionChanged);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_encab != null)
            {
                var itemResumen = GetItemResumenSeleccionado();
                var periodo = itemResumen.Periodo;
                ProxyExpPagoEgresoEmpleadoLinea linea;

                using (var exp = FabExpertos.Inst.Obtener<ExpPagoEgresoEmpleado>(IdSesion))
                {
                    linea = exp.NuevaLinea(_encab, periodo);

                    ActualizarDetallesPago();
                    EditarPago(exp, linea);
                }

            }
        }
    }
}