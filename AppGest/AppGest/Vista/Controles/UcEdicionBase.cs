#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace AppGest.Vista.Controles
{
    public  partial class UcEdicionBase : UcToolbar
    {
        public UcEdicionBase()
        {
            InitializeComponent();
            this.VisualizarBotonesToolbar(false, false, true);
        }
        public ParametrosGrilla ConfiguracionGrilla
        {
            get
            {
                if (_configuracion == null)
                    _configuracion = CrearConfiguracionGrilla();
                return _configuracion;
            }
        } ParametrosGrilla _configuracion = null;


        public void ActualizarGrilla()
        {
            Listar();
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
        }
        protected void frmEditarClose_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.ActualizarGrilla();
            }
        }
        protected ParametrosGrilla CrearConfiguracionGrilla()
        {
            ucGrilla1.Dock = DockStyle.Fill;
            ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            SuscribirAcciones();
            

            var columnas = new List<ParametrosColumna>();
            CrearColumnasDatos(columnas);
            CrearColumnasAccion(columnas);

            var configuracion = new ParametrosGrilla(columnas, true, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }

        protected virtual void SuscribirAcciones()
        {
            ucGrilla1.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrilla1_ClickAccion);
        }

        public virtual void Listar() { throw new NotImplementedException("Implementar Listar()"); }
        protected virtual void CrearColumnasDatos(List<ParametrosColumna> columnas) { throw new NotImplementedException("Implementar CrearColumnasDatos()"); }
        protected virtual void CrearColumnasAccion(List<ParametrosColumna> columnas) { throw new NotImplementedException("Implementar CrearColumnasAccion()"); }
        protected virtual void ucGrilla1_ClickAccion(object sender, AccionEventArgs e) { throw new NotImplementedException("Implementar ucGrilla1_ClickAccion"); }

        protected void tbtnGuardar_Click(object sender, EventArgs e)
        {
            ClickOk(sender, e);
        }
        protected void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();

        }

        /// <summary>
        /// Emula el evento de click del botón Guardar
        /// </summary>
        internal override void GuardarUC()
        {
            this.tbtnGuardar_Click(this, new EventArgs());
        }
        /// <summary>
        /// Emula el evento de click del botón cancelar
        /// </summary>
        internal override void CancelarUC()
        {
            this.MensajeUsuario = "Listo.";
            this.ClickCancelar(this, new EventArgs());
        }
    
    }
}