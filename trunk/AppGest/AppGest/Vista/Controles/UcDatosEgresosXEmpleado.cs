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
    public partial class UcDatosEgresosXEmpleado : UcToolbar
    {
        private List<ProxyExpPagosMensLinea> _pagosSeleccionados = new List<ProxyExpPagosMensLinea>();
        private ProxyExpParamsEgresoEmpleadoEncab _encab;
        public UcDatosEgresosXEmpleado()
        {
            InitializeComponent();

            VisualizarBotonesToolbar(true, true, false);
            EstablecerTitulo("Asignación de Remuneraciones");
            ActualizarControlesUI(false);
            InicializarFiltros();
            InicializarGrilla();
            SuscribirAcciones();
        }

        private void InicializarFiltros()
        {
            cboEmpleado.Text = string.Empty;
            cboEmpleado.ValueMember = Empleado.PROP_ID;
            cboEmpleado.DisplayMember = Empleado.PROP_NOMBRECOMPLETO;

            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
                cboEmpleado.DataSource = exp.ListaTodos();

        }

        protected virtual void SuscribirAcciones()
        {
            ucGrilla.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrilla_ClickAccion);
        }


        protected void ucGrilla_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    EditarPago(this.ucGrilla.DataSource[e.RowIndex] as ProxyExpParamsEgresoEmpleadoLinea);
                    break;
                case "Eliminar":
                    EliminarPago(this.ucGrilla.DataSource[e.RowIndex] as ProxyExpParamsEgresoEmpleadoLinea);
                    break;
            }
        }


        private void EliminarPago(ProxyExpParamsEgresoEmpleadoLinea linea)
        {
            if (linea != null)
                {
                    MessageBox.Show("Se eliminará la línea.\n¿Desea realizar la acción?",
                    "Guardar cambios", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                    new EventHandler(delegate(object sender, EventArgs e) { ActivarBaja(sender, linea); }));
            }
        }

        private void ActivarBaja(object sender, ProxyExpParamsEgresoEmpleadoLinea linea)
        {
            var rdo = ((Form) sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                if (linea.IdRegDet != 0)
                    linea.FechaBaja = DateTime.Now;
                else
                    _encab.Lineas.Remove(linea);

                ActualizarGrilla();
            }

        }

        private void EditarPago(ProxyExpParamsEgresoEmpleadoLinea param)
        {
            if (param != null)
            {
                param.IniciarCambios();
                FrmEdicionParamEgresoXEmpleado f = new FrmEdicionParamEgresoXEmpleado(FormBorderStyle.None, Color.White, param);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarParamEgresoXEmpleado_FormClosed);
            }
        }

        void frmEditarParamEgresoXEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            var f = sender as FrmEdicionParamEgresoXEmpleado;
            var linea = f.Linea;
            if (f.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                linea.AceptarCambios();
            else
                linea.RechazarCambios();

            ActualizarGrilla();
        }

        void ActualizarGrilla()
        {
            ucGrilla.DataSource = _encab.Lineas.Where(y => y.FechaBaja == null).OrderBy(x => x.Desde).ToList() as IList;
        }

        private void CargarSeleccion()
        {
            var empleadoId = cboEmpleado.SelectedValue;
            if (empleadoId != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpParamsEgresoEmpleado>(IdSesion))
                {
                    _encab = exp.ObtenerEgresosXEmpleado(Convert.ToInt64(empleadoId), true);
                }
                ActualizarControlesUI(true);
            }
            else
                ActualizarControlesUI(false);

        }

        private void ActualizarControlesUI(bool habilitar)
        {
            this.ucGrilla.Enabled = habilitar;
            this.btnAgregar.Enabled = habilitar;
            this.btnAgregar.Visible = habilitar;
            if (habilitar) ActualizarGrilla();
            this.cboEmpleado.Enabled = !habilitar;
            this.btnBuscar.Enabled = !habilitar;
            this.btnBuscar.Visible = !habilitar;
            
        }

        private void InicializarGrilla()
        {

            ConfigurarGrilla();
            ucGrilla.DataSource = new List<ProxyExpParamsEgresoEmpleadoLinea>();

        }

        void ConfigurarGrilla()
        {

            var configuracion = ObtenerConfiguracionGrilla(false);
            ucGrilla.EncabezadoFilaVisible = true;
            ucGrilla.ParametrosGrilla = configuracion;

        }

        ParametrosGrilla ObtenerConfiguracionGrilla(bool check)
        {
            var colorInhab = Color.FromArgb(241,241,241);

            List<ParametrosColumna> columnas = new List<ParametrosColumna>();
            var pos = 1;

            ParametrosColumna pColumna = null;

            pColumna = new ParametrosColumna("ConceptoNombre", "Concepto", true, pos++, 140, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Importe", "Importe", true, pos++, 90, true, false, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, false);

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Desde", "Desde", true, pos++, 90, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);
 

            columnas.Add(pColumna);

            pColumna = new ParametrosColumna("Hasta", "Hasta", true, pos++, 90, true, false, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, false);


            columnas.Add(pColumna);

            pos = CrearColumnaEdicion(columnas, pos, colorInhab);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false, EnumEditable.NoEditable, EnumEditable.NoEditable, null);
            return configuracion;
        }

        private int CrearColumnaEdicion(List<ParametrosColumna> columnas, int pos, Color? colorInhab)
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

  
        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {   
                using (var exp = FabExpertos.Inst.Obtener<ExpParamsEgresoEmpleado>(IdSesion))
                {
                    exp.Guardar(_encab);
                }

                MessageBox.Show(this.Form, "Los datos se registraron correctamente.", "Datos Guard b  ados", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
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
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_encab != null)
            {
                ProxyExpParamsEgresoEmpleadoLinea linea = null;
                using (var exp = FabExpertos.Inst.Obtener<ExpParamsEgresoEmpleado>(IdSesion))
                {
                    linea = exp.NuevaLinea(_encab);
                }

                ActualizarGrilla();
                EditarPago(linea);
            }
        }
    }
}