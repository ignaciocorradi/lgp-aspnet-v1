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
    public partial class UcPagosMensuales : UcToolbar
    {
        #region Atributos
        
        private List<ProxyExpPagosMensLinea> _pagosSeleccionados = new List<ProxyExpPagosMensLinea>();
        string _patronTitulo;

        #endregion
        #region Propiedades
        
        #endregion
        #region Ctor
        public UcPagosMensuales()
        {
            InitializeComponent();
            this.VisualizarBotonesToolbar(false, false, true);
            this.EstablecerTitulo("Registros de cobro mensual");
            _patronTitulo = this.lblTitulo.Text;
            InicializarFiltros();
            InicializarGrillaClientes();
            InicializarGrillaPagos();


        }
        #endregion
        #region Metodos
        private void InicializarFiltros()
        {
            txtNombreFiltro.Text = string.Empty;
            dtpPeriodoImpago.Value = DateTime.Now;
        }

        private void InicializarGrillaClientes()
        {
            var configuracion = ObtenerConfiguracionGrillaClientes();
            ucGrillaClientes.ParametrosGrilla = configuracion;
            ucGrillaClientes.DataSource = new List<ProxyExpPagosMensLinea>();
            //ucGrillaPagos.Grilla.RowHeadersVisible = false;

            ucGrillaClientes.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrillaClientes_ClickAccion);
        }

        void ucGrillaClientes_ClickAccion(object sender, AccionEventArgs e)
        {
            _pagosSeleccionados.Add((ProxyExpPagosMensLinea)ucGrillaClientes.DataSource[e.RowIndex]);
        }

        private void BuscarClientes()
        {
            var cliente = txtNombreFiltro.Text.Trim();
            DateTime perImpago = dtpPeriodoImpago.Value;

            using (var experto = FabExpertos.Inst.Obtener<ExpPagosMensuales>(this.IdSesion))
            {
                ucGrillaClientes.DataSource = experto.ObtenerPagosPendientes(perImpago, cliente).OrderBy(x => x.NombreCompleto).ToList();
                lblRdoCliente.Text = ucGrillaClientes.DataSource.Count.ToString() + " clientes encontrados.";
            }


        }

        private void InicializarGrillaPagos()
        {
            ConfigurarGrillaPagos(this.ucGrillaPagos);
            ucGrillaPagos.DataSource = new List<ProxyExpPagosMensLinea>();
            ucGrillaPagos.Grilla.CellEndEdit += new DataGridViewCellEventHandler(GrillaPagos_CellEndEdit);
        }

        void GrillaPagos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                var columna = ucGrillaPagos.Grilla.Columns[e.ColumnIndex];
                if (ColumnaAfectaSaldo(columna))
                {
                    var row = ucGrillaPagos.Grilla.Rows[e.RowIndex];
                    ActualizarSaldo(row, columna);
                }
            }
        }

        private void ActualizarSaldo(DataGridViewRow row, DataGridViewColumn columna)
        {
            var linea = row.DataBoundItem as ProxyExpPagosMensLinea;
            if (row != null)
            {
                ExpPagosMensuales.CalcularSaldo(linea, true);
                row.Cells[columna.Index].Update();
            }

        }

        private bool ColumnaAfectaSaldo(DataGridViewColumn columna)
        {
            return columna != null
                            && (columna.Name == "Abonado"
                            ||  columna.Name == "Recargo"
                            ||  columna.Name == "Bonificacion");
        }

        internal static void ConfigurarGrillaPagos(UcGrilla grilla)
        {
            var configuracion = ObtenerConfiguracionGrillaPagos(true);
            grilla.ParametrosGrilla = configuracion;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // ucGrillaPagos.Grilla.Columns["FechaPago"].CellTemplate = new CalendarCell();
        }
        private static ParametrosGrilla ObtenerConfiguracionGrillaClientes()
        {
            List<ParametrosColumna> columnas = new List<ParametrosColumna>();

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Seleccion", " ", string.Empty);
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = true;
            pcAccion.Posicion = 1;
            pcAccion.Ancho = 30;

            columnas.Add(pcAccion);


            ParametrosColumna pColumna = null;

            pColumna = new ParametrosColumna("ClienteYVehiculos", "Cliente [vehículo]", true, 2, 200, false, false
                , DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("NroCochera", "Cochera", true, 3, 60, false, false
                , DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);
            columnas.Add(pColumna);


            var configuracion = new ParametrosGrilla(columnas, false, false, false, false, true, ScrollBars.Both, false);
            return configuracion;
        }


        internal static ParametrosGrilla ObtenerConfiguracionGrillaPagos(bool check)
        {
            var colorInhab = Color.FromArgb(241, 241, 241);

            List<ParametrosColumna> columnas = new List<ParametrosColumna>();
            var pos = 1;
            var columnaEditable = EnumEditable.Editable;
            if (check)
            {
                pos = CrearColumnaSeleccion(columnas, pos, colorInhab);
            }
            else
            {
                columnaEditable = EnumEditable.NoEditable;
            }
            ParametrosColumna pColumna = null;

            pColumna = new ParametrosColumna("NombreCompleto", "Apellido y Nombre", true, pos++, 190, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);
            pColumna.Estilo.BackColor = check ? colorInhab : pColumna.Estilo.BackColor;

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("NroCochera", "Coch.", true, pos++, 60, true, false, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, false);

            pColumna.Estilo.BackColor = check ? colorInhab : pColumna.Estilo.BackColor;

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("AltaCliente", "F. Ingreso", true, pos++, 80, true, false, DataGridViewContentAlignment.MiddleCenter,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormat, null, false);

            pColumna.Estilo.BackColor = check ? colorInhab : pColumna.Estilo.BackColor;

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("PeriodoStr", "Periodo", true, pos++, 70, true, false, DataGridViewContentAlignment.MiddleCenter,
                DataGridViewContentAlignment.MiddleCenter, null, null, false);

            pColumna.Estilo.BackColor = check ? colorInhab : pColumna.Estilo.BackColor;
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("PrecioOrig", "Precio", true, pos++, 75, true, false, DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Abonado", "Abonado", true, pos++, 75, true, false, DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false, columnaEditable);
            if (check)
                pColumna.HeaderBackColor = Color.LightSeaGreen;
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Bonificacion", "Bonif.", true, pos++, 75, true, false, DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false, columnaEditable);
            if (check)
                pColumna.HeaderBackColor = Color.LightSeaGreen;
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Recargo", "Recargo", true, pos++, 75, true, false, DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false, columnaEditable);
            if (check)
                pColumna.HeaderBackColor = Color.LightSeaGreen;
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("FechaPago", "Fecha Cobro", true, pos++, 95, true, false, DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, false, columnaEditable);
            if (check)
                pColumna.HeaderBackColor = Color.LightSeaGreen;
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Saldo", "Saldo", true, pos++, 75, true, false, DataGridViewContentAlignment.MiddleRight,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);
            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Comentario", "Comentario", true, pos++, 190, true, false, DataGridViewContentAlignment.MiddleLeft,
                DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, false, columnaEditable);
            if (check)
                pColumna.HeaderBackColor = Color.LightSeaGreen;
            columnas.Add(pColumna);

            var configuracion = new ParametrosGrilla(columnas, !check, true, false, true, true, ScrollBars.Both, false, columnaEditable, EnumEditable.NoEditable, null);
            return configuracion;
        }

        internal static int CrearColumnaSeleccion(List<ParametrosColumna> columnas, int pos, Color? colorInhab = null)
        {
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Seleccion", " ", string.Empty);

            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            if (colorInhab.HasValue)
                pcAccion.Estilo.BackColor = colorInhab.Value;
            pcAccion.Redimensionable = true;
            pcAccion.Posicion = pos++;
            pcAccion.Ancho = 30;


            columnas.Add(pcAccion);
            return pos;
        }

        internal static int CrearColumnaEdicion(List<ParametrosColumna> columnas, int pos)
        {

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Baja", "Baja", "Dar de baja el cliente.", TipoControlAccion.BotonBaja));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = pos++;
            pcAccion.Ancho = BotonEditar.Ancho + BotonBaja.Ancho;

            columnas.Add(pcAccion);
            return pos;


        }

        private void btnAgregarClientesSel_Click(object sender, EventArgs e)
        {
            try
            {
                // filas seleccionadas
                var seleccion = ucGrillaClientes.Filas().Where(r => ucGrillaClientes.ObtenerControlAccion<CheckBox>(r, "Seleccion").Checked).ToList();
                AgregarLineasPago(seleccion);
                DefinirEstadoComboPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al asignar el cliente.\nRefresque la búsqueda e intente nuevamente.\n\nDatos del error: "+ ex.Message
                    , "Error al asignar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Ha ocurrido un error al asignar el cliente.\n" + ex.Message, ex.InnerException);
            }

        }

        private void DefinirEstadoComboPeriodo()
        {
            this.dtpPeriodoImpago.Enabled = ucGrillaPagos.Grilla.Rows.Count == 0;
            if (dtpPeriodoImpago.Enabled)
            {
                dtpPeriodoImpago.BackColor = Color.White;
                lblTitulo.Visible = false;

            }
            else
            {
                dtpPeriodoImpago.BackColor = Color.LightGray;
                lblTitulo.Visible = true;
                DateTime f = dtpPeriodoImpago.Value;
                lblTitulo.Text = string.Format(_patronTitulo, f.ToString("MMMM").ToUpper() + " de " + f.Year.ToString());
            }
        }

        private void btnAgregarTodosCli_Click(object sender, EventArgs e)
        {
            try
            {
                // filas seleccionadas
                var seleccion = ucGrillaClientes.Filas();
                AgregarLineasPago(seleccion);
                DefinirEstadoComboPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al asignar todos los clientes.\nRefresque la búsqueda e intente nuevamente.\n\nDatos del error: "+ ex.Message
                    , "Error al asignar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Ha ocurrido un error al asignar todos los clientes.\n" + ex.Message, ex.InnerException);
            }
        }


        private void btnQuitarPagosSel_Click(object sender, EventArgs e)
        {
            try
            {
                // filas seleccionadas
                var seleccion = ucGrillaPagos.Filas().Where(r => ucGrillaClientes.ObtenerControlAccion<CheckBox>(r, "Seleccion").Checked).ToList();
                QuitarLineasPago(seleccion);
                DefinirEstadoComboPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al quitar el cliente.\nPresione F5 e intente nuevamente.\n\nDatos del error: " + ex.Message
                    , "Error al quitar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Ha ocurrido un error al quitar el cliente.\n" + ex.Message, ex.InnerException);
            }
        }

        private void btnQuitarTodosPagos_Click(object sender, EventArgs e)
        {
            try
            {
                // filas seleccionadas
                var seleccion = ucGrillaPagos.Filas().ToList();
                QuitarLineasPago(seleccion);
                DefinirEstadoComboPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al quitar todos los clientes.\nPresione F5 intente nuevamente.\n\nDatos del error: " + ex.Message
                    , "Error al quitar todos los Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Ha ocurrido un error al quitar todos los clientes.\n" + ex.Message, ex.InnerException);
            }
        }


        private void QuitarLineasPago(List<DataGridViewRow> seleccion)
        {
            foreach (var rowSeleccionado in seleccion)
            {
                var datosRow = (ProxyExpPagosMensLinea)rowSeleccionado.DataBoundItem;
                ucGrillaPagos.RemoveRow(rowSeleccionado.DataBoundItem);

                if (((IList<ProxyExpPagosMensLinea>)ucGrillaClientes.DataSource).FirstOrDefault(d => d.IdRegDet == datosRow.IdRegDet) == null)
                    ucGrillaClientes.AddRow(datosRow);
            }


        }

        private void AgregarLineasPago(IList<DataGridViewRow> seleccion)
        {
            foreach (var rowSeleccionado in seleccion)
            {
                AgregarLineaPago(rowSeleccionado);
            }
        }

        static string KeyLineaPagos(ProxyExpPagosMensLinea linea)
        {
            var keyLinea = linea.Cliente.Id.ToString() + "|" + linea.Periodo.ToString("MM-yyyy");
            return keyLinea;
        }
        private void AgregarLineaPago(DataGridViewRow rowSeleccionado)
        {
            var lineaSel = (ProxyExpPagosMensLinea)rowSeleccionado.DataBoundItem;
            var enGrillaPagos = (IList<ProxyExpPagosMensLinea>) ucGrillaPagos.DataSource;
            var keyLineaSel = KeyLineaPagos(lineaSel);

            if (!enGrillaPagos.Any(d => KeyLineaPagos(d) == keyLineaSel))
                ucGrillaPagos.AddRow(lineaSel);

            ucGrillaClientes.Grilla.Rows.Remove(rowSeleccionado);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                btnPagar.Enabled = false;

                var pagos = (IList<ProxyExpPagosMensLinea>)ucGrillaPagos.DataSource;
                if (pagos.Count > 0)
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
                    {
                        exp.Guardar(txtComentarioRegistro.Text, pagos);
                    }

                    MessageBox.Show(this.Form, "Los datos se registraron correctamente.", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                    this.MensajeUsuario = "Los datos se registraron correctamente.";
                    LimpiarGrillaPagos();
                    DefinirEstadoComboPeriodo();
                }
                else
                {
                    MessageBox.Show(this.Form, "Debe agregar al menos un registro para guardar los datos.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error, true);
                }
            }
            catch (ValidacionException vex)
            {
                

                MessageBox.Show(vex.MessageCompleteConTitulo, "Validación de registros de cobros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + vex.MessageCompleteConTitulo + "\n\n" + vex.InnerException);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar.\n\nDetalle:\n" + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + ex.Message + "\n\n" + ex.InnerException);
            }
            finally
            {
                btnPagar.Enabled = true;
            }
        }

        private void LimpiarGrillaPagos()
        {
            var pagos = (IList<ProxyExpPagosMensLinea>)ucGrillaPagos.DataSource;
            pagos.Clear();

            ucGrillaPagos.DataSource = null;
            ucGrillaPagos.DataSource = pagos as IList;
        }

        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar_Click(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void btnAplicarFechaCobro_Click(object sender, EventArgs e)
        {
            var pagos = (IList<ProxyExpPagosMensLinea>)ucGrillaPagos.DataSource;

            foreach (var fila in pagos)
            {
                fila.FechaPago = dtpFechaPago.Value;
            }
            ucGrillaPagos.Update();
        }

        void NuevoMensual()
        {
            if (this.Parent != null && this.Parent.Parent != null && this.Parent.Parent.Parent != null)
            {
                FrmPrincipal f = this.Parent.Parent.Parent as FrmPrincipal;
                f.NuevoMensual();
            }

        }

        private void btnNuevoMensual_Click(object sender, EventArgs e)
        {
            NuevoMensual();
        }
        #endregion

       

       

    }
}