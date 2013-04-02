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
using AppGest.Negocio.Core;
using System.Collections;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    public partial class ucEdicionConceptos : UcToolbar
    {
        #region -- Atributos --
        TipoServicio _tipoServicio;
        #endregion

        #region -- Consutrctores --
        public ucEdicionConceptos()
        {
            InitializeComponent();        
        }
        public ucEdicionConceptos(TipoServicio tipoServicio) : this()
        {
            _tipoServicio = tipoServicio;
            this.EstablecerTitulo("Editar " + this.ObtenerTitulo());
        }
        #endregion

        #region -- Propiedades --
        
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
        #endregion

        
        #region -- Metodos --
        public void Listar()
        {
            CargarDatos();
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
        }

        private void CargarDatos(string nombre = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                switch (_tipoServicio)
                {
                    case TipoServicio.Ingresos:
                        ucGrilla1.DataSource = (IList)exp.ListaConceptos(nombre, ConceptoIngresos.ALQUILER_MENSUAL);
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
            CrearColumnasDatos(columnas);
            CrearColumnasAccion(columnas);

            var configuracion = new ParametrosGrilla(columnas, true, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }
        private void EditarConcepto(Concepto concepto)
        {
            if (concepto != null)
            {
                FrmEdicionConceptos f = new FrmEdicionConceptos(FormBorderStyle.None, Color.White, concepto, _tipoServicio);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmEdicionConceptos_FormClosed);
            }
        }
        private void CrearColumnasDatos(List<ParametrosColumna> columnas)
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
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 1;
            pcAccion.Ancho = BotonEditar.Ancho;

            columnas.Add(pcAccion);

        }
        /// <summary>
        /// Emula el evento de click del botón cancelar
        /// </summary>
        internal override void CancelarUC()
        {
            this.MensajeUsuario = "Listo.";
            this.ClickCancelar(this, new EventArgs());
        }

        #endregion

        #region -- Eventos --
        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.CargarDatos(this.txtNombre.Text.Trim());
        }
        void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Editar":
                    EditarConcepto(this.ucGrilla1.DataSource[e.RowIndex] as Concepto);
                    break;
            }
        }



        void FrmEdicionConceptos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.btnBuscar_Click(this, new EventArgs());
            }
        }
        #endregion


    }
}