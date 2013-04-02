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

#endregion

namespace AppGest.Vista.Controles
{
    

    [AdministradorAttribute]
    [SupervisorAttribute]
    public partial class ucListaServicios : UcToolbar
    {
        TipoServicio _tipoServicio;

        public ucListaServicios(TipoServicio tipoServicio)
        {
            _tipoServicio = tipoServicio;
            InitializeComponent();
            this.VisualizarBotonesToolbar(false, false, true);
            this.EstablecerTitulo("Editar precio de " + this.ObtenerTitulo());
        }

        public ParametrosGrilla ConfiguracionGrilla { 
            get
            {
                if (_configuracion == null)
                    _configuracion = CrearConfiguracionGrilla();
                return _configuracion;
            } 
        }
        ParametrosGrilla _configuracion = null;

        public void Listar()
        {
            CargarDatos();
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
        }

        private void CargarDatos(string nombre = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                
                switch(_tipoServicio)
                {
                    case TipoServicio.Ingresos:
                        ucGrilla1.DataSource = exp.ListaLineasPrecioConceptos(TipoConcepto.ConceptoIngresos, exp.CptoTransaccionPrecio.Id, nombre);
                        break;
                    case TipoServicio.EgresosEmpleados:
                        ucGrilla1.DataSource = (IList)exp.ListaConceptos(nombre, ConceptoEgresos.EGRESOS_EMPLEADOS);
                        break;
                    case TipoServicio.EgresosVarios:
                        ucGrilla1.DataSource = (IList)exp.ListaConceptos(nombre, ConceptoEgresos.EGRESOS_VARIOS);
                        break;
                }
            }
        }

        private ParametrosGrilla CrearConfiguracionGrilla()
        {
            ucGrilla1.Dock = DockStyle.Fill;
            ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrilla1.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrilla1_ClickAccion);

            var columnas = new List<ParametrosColumna>();
            if(_tipoServicio == TipoServicio.Ingresos)
                CrearColumnasDatosProxy(columnas);
            else
                CrearColumnasDatos(columnas);
            CrearColumnasAccion(columnas);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }

        void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Editar":
                    if (_tipoServicio == TipoServicio.Ingresos)
                    {
                        EditarServicioProxy(this.ucGrilla1.DataSource[e.RowIndex] as ProxyCptoPrecio);
                    }
                    else
                    {
                        EditarServicio(this.ucGrilla1.DataSource[e.RowIndex] as Concepto);
                    }
                    break;
            }
        }

        private void EditarServicioProxy(ProxyCptoPrecio servicio)
        {
            if (servicio != null)
            {
                FrmEdicionServicio f = new FrmEdicionServicio(FormBorderStyle.None, Color.White, servicio.Concepto);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmEdicionServicio_FormClosed);
            }
        }
        private void EditarServicio(Concepto servicio)
        {
            if (servicio != null)
            {
                FrmEdicionServicio f = new FrmEdicionServicio(FormBorderStyle.None, Color.White, servicio);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmEdicionServicio_FormClosed);
            }
        }

        void FrmEdicionServicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.Listar();
            }
        }

        private void CrearColumnasDatosProxy(List<ParametrosColumna> columnas)
        {
            string encabezadoServicios = this.ObtenerTitulo();

            var pCol = new ParametrosColumna("Servicio", encabezadoServicios, true, 0, 300, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyCptoPrecio.PROP_DETALLELINEAVIGENTE, "Resumen último precio", true, 1, 600, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);
        }

        private void CrearColumnasDatos(List<ParametrosColumna>  columnas)
        {
            string encabezadoServicios = this.ObtenerTitulo();

            var pCol = new ParametrosColumna("nombre", encabezadoServicios, true, 0, 300, true, false, 
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);
        }

        private string ObtenerTitulo()
        {
            switch (_tipoServicio)
            {
                case TipoServicio.Ingresos:
                    return "Ingresos";
                case TipoServicio.EgresosEmpleados:
                    return "Egresos del Personal";
                case TipoServicio.EgresosVarios:
                    return "Egresos Varios";
            }
            return string.Empty;
        }

        private void CrearColumnasAccion(List<ParametrosColumna> columnas)
        {
            var pCol = new ParametrosColumnaAccion("Editar", "Acciones", "Editar", "Editar el servicio");
            pCol.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            
            if(_tipoServicio == TipoServicio.Ingresos)
                pCol.Posicion = 2;
            else
                pCol.Posicion = 1;
            pCol.Ancho = 75;
            columnas.Add(pCol);
        }

        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();
        }

        /// <summary>
        /// Emula el evento de click del botón cancelar
        /// </summary>
        internal override void CancelarUC()
        {
            this.MensajeUsuario = "Listo.";
            this.ClickCancelar(this, new EventArgs());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            this.CargarDatos(this.txtNombre.Text.Trim());
        }
  
    }
}