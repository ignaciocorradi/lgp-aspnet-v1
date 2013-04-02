#region Using

using System;
using System.Linq;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using AppGest.Util.Atributos;
using Gizmox.WebGUI.Forms;
using System.Text;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    public partial class ucConceptos : UcToolbar
    {
        #region -- Atributos --
        TipoServicio _tipoServicio;
        string _descripcion = string.Empty;
        Concepto _concepto;
        Reg_encab _transaccion;
        Enum _valor;
        #endregion

        #region -- Constructores --
        public ucConceptos()
        {
            InitializeComponent();
        }

        public ucConceptos(TipoServicio tipoServicio) : this()
        {
            _tipoServicio = tipoServicio;
            this.InicializarPantalla();
        }
        #endregion

        #region -- Metodos --
        private void InicializarPantalla()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConceptos));
            string imagen = string.Empty;
            switch (_tipoServicio)
            {
                case TipoServicio.EgresosEmpleados :
                    _descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoEgresos.EGRESOS_EMPLEADOS);
                    _valor = ConceptoEgresos.EGRESOS_EMPLEADOS;
                    imagen = "pbImagenServicio.GastoEmpleado.Image";
                    break;
                case TipoServicio.EgresosVarios :
                    _descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoEgresos.EGRESOS_VARIOS);
                    imagen = "pbImagenServicio.GastoVario.Image";
                    _valor = ConceptoEgresos.EGRESOS_VARIOS;
                    break;
                case TipoServicio.Ingresos :
                    _descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL);
                    imagen = "pbImagenServicio.IngresoMensual.Image";
                    _valor = ConceptoIngresos.ALQUILER_MENSUAL;
                    break;
            }

            this.dtpFechaHasta.Value = this.dtpFechaDesde.Value.AddYears(1);
            this.lblNombreServicio.Text = "Nombre del concepto:";  //_descripcion;
            this.lblTipoServicio.Text = _descripcion;
            this.pbImagenServicio.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString(imagen));
        }

        /// <summary>
        /// Guarda los cambios realizados en el concepto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected override void OnGuardar_Click(EventArgs e)
        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
                    {
                        if (_concepto == null)
                        {
                            _concepto = exp.Nuevo();
                        }
                        else
                        {
                            _concepto = exp.ObtenerPorId(_concepto.Id);
                        }

                        this.CargarConcepto();

                        exp.GuardarPrecios(this.ActualizarListaDePrecio(exp, _concepto));

                        MensajeUsuario = "Se creó correctamente el " + _descripcion + ": '" + _concepto.Nombre + "'";

                        base.ClickOk(sender, e);
                    }
                }
            }
            catch (ValidacionException io)
            {
                MessageBox.Show("No es posible guardar el " + _descripcion +", complete los siguientes datos: \n\n\t " + io.MessageComplete,
                  "Guardar cambios", MessageBoxButtons.OK,
                  MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar.\n\nDetalle:\n" + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + ex.Message + "\n\n" + ex.InnerException);
            }
            
        }

        private bool Validar()
        {
            bool rdo = true;
            StringBuilder msj = new StringBuilder();

            if (String.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                msj.AppendLine("El campo Nombre es obligatorio.");
                rdo = false;
            }

            if (this.dtpFechaDesde.Checked && this.dtpFechaHasta.Checked && this.dtpFechaDesde.Value > this.dtpFechaHasta.Value)
            {
                msj.AppendLine("Fecha Desde no puede ser mayor a Fecha Hasta.");
                rdo = false;
            }

            if (!rdo)
            {
                MessageBox.Show(msj.ToString(), _descripcion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return rdo;
        }

        public void CargarConcepto()
        {
            _concepto.Nombre = this.txtNombre.Text;
            _concepto.Observaciones = this.txtObservacion.Text;
            _concepto.Descripcion = this.txtDesc.Text;
            _concepto.Abreviatura = Helper.ObtenerIniciales(_concepto.Nombre);
            _concepto.ValorEnum = _valor;
        }

        public void CargarControles(Concepto conceptoDeUsuario, TipoServicio tipoServicio)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {

                if (conceptoDeUsuario.Id > 0)
                {
                    _transaccion = exp.ObtenerEncabPrecio(conceptoDeUsuario.Id);
                }
                else
                {
                    _transaccion = exp.NuevoEncabPrecio(conceptoDeUsuario, false);
                }

                //_transaccion.Reg_Det.Last<Reg_Det>().ValFecha1 = this.dtpFechaDesde.Value;
                //_transaccion.Reg_Det.Last<Reg_Det>().ValFecha2 = this.dtpFechaHasta.Value;
                //_transaccion.Reg_Det.Last<Reg_Det>().Precio = this.nudPrecio.Value;
            }

            _concepto = _transaccion.Reg_Det.Last().Concepto;
            _tipoServicio = tipoServicio;

            this.txtNombre.Text = _concepto.Nombre;
            this.txtAbreviatura.Text = _concepto.Abreviatura;
            this.txtObservacion.Text =_concepto.Observaciones;
            this.txtDesc.Text = _concepto.Descripcion;

            this.dtpFechaDesde.Hide();
            this.dtpFechaHasta.Hide();
            this.nudPrecio.Hide();
            this.lblFechaDesde.Hide();
            this.lblFechaHasta.Hide();
            this.lblPrecio.Hide();

            this.InicializarPantalla();
        }

        private Reg_encab ActualizarListaDePrecio(ExpConcepto exp, Concepto conceptoDeUsuario)
        {
            Reg_encab encabezado;

            if (conceptoDeUsuario.Id > 0)
            {
                encabezado = exp.ObtenerEncabPrecio(conceptoDeUsuario.Id);
            }
            else
            {
                encabezado = exp.NuevoEncabPrecio(conceptoDeUsuario, true);

                encabezado.Reg_Det.Last<Reg_Det>().ValFecha1 = this.dtpFechaDesde.Checked ? (DateTime?) this.dtpFechaDesde.Value : null;
                encabezado.Reg_Det.Last<Reg_Det>().ValFecha2 = this.dtpFechaHasta.Checked ? (DateTime?)this.dtpFechaHasta.Value : null;
                encabezado.Reg_Det.Last<Reg_Det>().Precio = this.nudPrecio.Value;
            }

            return encabezado;

        }

        private void txtNombre_LostFocus(object sender, EventArgs e)
        {
            this.txtAbreviatura.Text = Helper.ObtenerIniciales(this.txtNombre.Text);
        }
        #endregion
    }
}