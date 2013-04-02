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
using AppGest.Negocio.Modelo;
using System.Collections;

using AppGest.Util;
using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    public partial class ucEdicionServicio : UcToolbar
    {
        private Concepto _concepto;
        private Reg_encab _transaccion;
        private Reg_Det _detalleEnEdicion;
        private int? _idFilaEnModificacion;
        private ResourceHandle _imgAgregar;
        private ResourceHandle _imgModificar; 

        public ucEdicionServicio()
        {
            InitializeComponent();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEdicionServicio));
            _imgAgregar = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregar.Agregar.Image"));
            _imgModificar = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnAgregar.Modificar.Image"));
            this.btnAgregar.Image = _imgAgregar;
            dtpFechaHasta.Value = dtpFechaDesde.Value.AddYears(1);
        }


        #region -- Metodos --
        public void Cargar(Concepto concepto)
        {
            _concepto = concepto;
            TipoConcepto tipoConcepto = Concepto.ClaseEnumeracion(concepto.Clase);

            switch (tipoConcepto)
            {
                case TipoConcepto.ConceptoEgresos:
                    this.InicializarEgresos();
                    break;
                case TipoConcepto.ConceptoIngresos:
                    this.lblNombreConcepto.Text = "Concepto de Ingreso";// DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL);
                    break;
            }
            lblNombreServicio.Text = _concepto.Nombre;

            this.Listar();
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
            this.ucGrilla1.Grilla.ClearSelection();
        }
        
        private void InicializarEgresos()  
        {
            ConceptoEgresos conceptoEgreso = (ConceptoEgresos)_concepto.ValorEnum;
            switch (conceptoEgreso)
            {
                case ConceptoEgresos.EGRESOS_EMPLEADOS:
                    this.lblNombreConcepto.Text = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoEgresos.EGRESOS_EMPLEADOS);
                    break;
                case ConceptoEgresos.EGRESOS_VARIOS:
                    this.lblNombreConcepto.Text = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoEgresos.EGRESOS_VARIOS);
                    break;
            }
        }

        public ParametrosGrilla ConfiguracionGrilla
        { 
            get
            {
                if (_configuracion == null)
                    _configuracion = CrearConfiguracionGrilla();
                return _configuracion;
            } 
        }
        ParametrosGrilla _configuracion = null;

        private void Listar()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                _transaccion = exp.ObtenerEncabPrecio(_concepto.Id);
                if(_transaccion == null)
                    _transaccion = exp.NuevoEncabPrecio(_concepto,false);

                ucGrilla1.DataSource = _transaccion.Reg_Det.ToList<Reg_Det>();
                this.LimpiarCampos();
            }           
        }

        private void AgregarDetalle(Reg_Det detalle)
        {
            IList detalles = ucGrilla1.DataSource;
            detalles.Add(detalle);
            ucGrilla1.DataSource = detalles;
            this.LimpiarCampos();
        }
        

        private void LimpiarCampos()
        {
            this.nudPrecio.Value = 0;
            this.dtpFechaDesde.Value = DateTime.Now.Date;
            this.dtpFechaHasta.Value = this.dtpFechaDesde.Value.AddYears(1);
        }

        private ParametrosGrilla CrearConfiguracionGrilla()
        {
            ucGrilla1.Dock = DockStyle.Fill;
            ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrilla1.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrilla1_ClickAccion);

            var columnas = new List<ParametrosColumna>();
            CrearColumnasDatos(columnas);

            var configuracion = new ParametrosGrilla(columnas, false, false, false, false, true, ScrollBars.Both, false);
            return configuracion;
        }

        private void ModificarDetalle()
        {
            _detalleEnEdicion = this.ucGrilla1.DataSource[_idFilaEnModificacion.Value] as Reg_Det;
            this.btnAgregar.Text = "Modificar";
            this.btnAgregar.Image = _imgModificar;
            this.ucGrilla1.Grilla.Rows[_idFilaEnModificacion.Value].CambiarFondo(Color.DarkGray);
            this.nudPrecio.Value = _detalleEnEdicion.Precio.HasValue? _detalleEnEdicion.Precio.Value:0M;

            if (_detalleEnEdicion.ValFecha1.HasValue)
            {
                this.dtpFechaDesde.Value = _detalleEnEdicion.ValFecha1.Value;
                this.dtpFechaDesde.Checked = true;
            }
            else
            {
                this.dtpFechaDesde.Value = DateTime.Now;
                this.dtpFechaDesde.Checked = false;
            }

            if (_detalleEnEdicion.ValFecha2.HasValue)
            {
                this.dtpFechaHasta.Value = _detalleEnEdicion.ValFecha2.Value;
                this.dtpFechaHasta.Checked = true;
            }
            else
            {
                this.dtpFechaHasta.Value = DateTime.Now.AddYears(1);
                this.dtpFechaHasta.Checked = false;
            }
        }

        private void CrearColumnasDatos(List<ParametrosColumna>  columnas)
        {
            var pCol = new ParametrosColumna(Reg_Det.PROP_PRECIO, "Precio", true, 0, 150, false, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Reg_Det.PROP_VALFECHA1, "Fecha Desde", true, 1, 150, false, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Reg_Det.PROP_VALFECHA2, "Fecha Hasta", true, 2, 150, false, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);


             ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Modificar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 3;
            pcAccion.Ancho = BotonEditar.Ancho;

            columnas.Add(pcAccion);


        }

        private void CargarNuevoDetalle(Reg_encab encabezadoDB)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                foreach (var detalle in _transaccion.Reg_Det.Where(d => d.Id == 0))
                {
                    Reg_Det detalleDB = exp.NuevoPrecio(_concepto, encabezadoDB);
                    detalleDB.Precio = detalle.Precio;
                    detalleDB.ValFecha1 = detalle.ValFecha1;
                    detalleDB.ValFecha2 = detalle.ValFecha2;
                    detalleDB.FechaModif = null;
                }
            }
        }

        private void ActualizarDetallesExistentes(Reg_encab encabezadoDB)
        {
            foreach (var detalle in _transaccion.Reg_Det.Where(d => d.Id != 0 && d.EntityState.Equals(EntityState.Modified)))
            {
                Reg_Det detalleDB = encabezadoDB.Reg_Det.First<Reg_Det>(d => d.Id == detalle.Id);
                detalleDB.Precio = detalle.Precio;
                detalleDB.ValFecha1 = detalle.ValFecha1;
                detalleDB.ValFecha2 = detalle.ValFecha2;
                detalleDB.FechaModif = DateTime.Now;
            }
        }

        private void ActualizarDetalle(Reg_Det detalle)
        {
            detalle.Precio = this.nudPrecio.Value;
            detalle.ValFecha1 = this.dtpFechaDesde.Checked ? (DateTime?)this.dtpFechaDesde.Value : null;
            detalle.ValFecha2 = this.dtpFechaHasta.Checked ? (DateTime?)this.dtpFechaHasta.Value : null;
        }

        private bool Validar()
        {
            bool rdo = true;
            StringBuilder msj = new StringBuilder();

            if (this.dtpFechaDesde.Checked && this.dtpFechaHasta.Checked && this.dtpFechaDesde.Value.Date > this.dtpFechaHasta.Value.Date)
            {
                msj.AppendLine("Fecha Desde no puede ser mayor a Fecha Hasta.");
                rdo = false;
            }

            DateTime? fechaDesde = this.dtpFechaDesde.Checked ? (DateTime?)this.dtpFechaDesde.Value : null;
            DateTime? fechaHasta = this.dtpFechaHasta.Checked ? (DateTime?)this.dtpFechaHasta.Value : null;
            if (this.ValidarRangoFechas(fechaDesde, fechaHasta))
            {
                msj.AppendLine("Fecha Desde y/o Fecha Hasta se encuentran entre algun rango de fechas ya registradas.");
                rdo = false;
            }

            if (!rdo)
            {
                MessageBox.Show(msj.ToString(), "Edición de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return rdo;
        }

        ///// <summary>
        ///// Verifica si alguna de las fechas pasadas como parametro se encuentre en alguno de los rangos 
        ///// de fechas de detalles existentes.
        ///// </summary>
        ///// <param name="fechaDesde">Fecha Desde a validar</param>
        ///// <param name="fechaHasta">Fecha Hasta a validar</param>
        ///// <returns>Verdadero si alguna de las fechas se enceuntra entre algun rango existente, falso en otro caso</returns>
        private bool ValidarRangoFechas(DateTime? fechaDesde, DateTime? fechaHasta)
        {
            //Tomo por defecto que fecha desde es menor o igual que fecha hasta 
            foreach (Reg_Det det in _transaccion.Reg_Det.Where<Reg_Det>(d => !d.Equals(_detalleEnEdicion)))
            {
                if ((!fechaDesde.HasValue && !fechaHasta.HasValue)
                    ||(!det.ValFecha1.HasValue && !det.ValFecha2.HasValue)
                    || (!det.ValFecha1.HasValue && !fechaDesde.HasValue)
                    || (!det.ValFecha2.HasValue && !fechaHasta.HasValue)
                    || (!det.ValFecha1.HasValue && det.ValFecha2.HasValue && fechaDesde.Value.Date <= det.ValFecha2.Value.Date)
                    || (!det.ValFecha2.HasValue && det.ValFecha1.HasValue && fechaHasta.Value.Date >= det.ValFecha1.Value.Date)
                    || (det.ValFecha1.HasValue && det.ValFecha2.HasValue && fechaDesde.HasValue && !fechaHasta.HasValue && fechaDesde.Value.Date <= det.ValFecha2.Value.Date)
                    || (det.ValFecha1.HasValue && det.ValFecha2.HasValue && fechaHasta.HasValue && !fechaDesde.HasValue && fechaHasta.Value.Date >= det.ValFecha1.Value.Date)
                    || (fechaDesde.HasValue && det.ValFecha1.HasValue && det.ValFecha2.HasValue && fechaDesde.Value.Date.Between(det.ValFecha1.Value.Date, det.ValFecha2.Value.Date))
                    || (fechaHasta.HasValue && det.ValFecha1.HasValue && det.ValFecha2.HasValue && fechaHasta.Value.Date.Between(det.ValFecha1.Value.Date, det.ValFecha2.Value.Date)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PrimerDetalleEnEdicion
        {
            get
            {
                return _detalleEnEdicion != null && _transaccion.Reg_Det.Count == 1 && _transaccion.Reg_Det.All<Reg_Det>(d => d.Equals(_detalleEnEdicion));
            }
        }

        #endregion

        #region -- eventos --
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
                using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
                {

                    Reg_encab encabezadoDB = _transaccion;
                    if (encabezadoDB.Id != 0)
                        encabezadoDB = exp.ObtenerEncabPrecio(_concepto.Id);
                    else
                        encabezadoDB = exp.NuevoEncabPrecio(_concepto, false);

                    CargarNuevoDetalle(encabezadoDB);
                    ActualizarDetallesExistentes(encabezadoDB);

                    exp.GuardarPrecios(encabezadoDB);

                    MensajeUsuario = "Se guardó correctamente el " + this.lblNombreServicio.Text + ": '" + _concepto.Nombre + "'";

                    base.ClickOk(sender, e);
                }
            }
            catch (InvalidOperationException io)
            {
                MessageBox.Show("No es posible guardar el " + this.lblNombreServicio.Text + ", complete los siguientes datos: \n\n\t " + io.Message,
                  "Guardar cambios", MessageBoxButtons.OK,
                  MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el " + this.lblNombreServicio.Text + ".", ex);
            }

        }
        void btnAgregar_Click(object sender, System.EventArgs e)
        {
            if (this.Validar())
            {
                Reg_Det detalle;
                if (_idFilaEnModificacion.HasValue)
                {
                    this.btnAgregar.Text = "Agregar";
                    this.btnAgregar.Image = _imgAgregar;

                    this.ucGrilla1.Grilla.Rows[_idFilaEnModificacion.Value].CambiarFondo(Color.White);
                    detalle = _detalleEnEdicion;
                    this.ActualizarDetalle(detalle);

                    _detalleEnEdicion = null;
                    _idFilaEnModificacion = null;
                }
                else
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(this.IdSesion))
                    {
                        detalle = exp.NuevoPrecio(_concepto, _transaccion);
                        this.ActualizarDetalle(detalle);
                        this.AgregarDetalle(detalle);
                    }
                }

                this.ucGrilla1.Grilla.ClearSelection();
            }
        }

        void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Modificar":
                    if (_idFilaEnModificacion.HasValue)
                    {
                        this.ucGrilla1.Grilla.Rows[_idFilaEnModificacion.Value].CambiarFondo(Color.White);
                    }
                    _idFilaEnModificacion = e.RowIndex;
                    ModificarDetalle();
                    this.ucGrilla1.Grilla.ClearSelection();
                    break;
            }
        }
        #endregion
    }
}