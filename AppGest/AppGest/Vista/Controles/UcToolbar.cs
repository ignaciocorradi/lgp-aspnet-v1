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

    public partial class UcToolbar : UcBase
    {
        public bool ComprobarCambios = true;

        [DefaultValue(true)]
        public bool MostrarCabecera { get { return this.pnCabecera.Visible; } set { this.pnCabecera.Visible = value; } }
        [DefaultValue(true)]
        public bool MostrarBarra { get { return this.tbMenu.Visible; } set { this.tbMenu.Visible = value; } }

        public UcToolbar()
        {
            InitializeComponent();
            //if (RunTime)
            //    this.OcultarTitulo();
        }

        public void OcultarTitulo()
        {
            this.lblTituloBase.Text = string.Empty;
            this.lblTituloBase.Visible = false;
        }

        protected void EstablecerTitulo(string titulo)
        {
            this.lblTituloBase.Text = titulo;
            this.lblTituloBase.Visible = true;
        }

        #region  -- Susc Eventos ---

        private void tbtnGuardar_Click(object sender, EventArgs e)
        {
            PreClickOk(sender, e);
            ClickOk(sender, e);
            PosClickOk(sender, e);
        }

        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();
        }

        private void tbtnCerrar_Click(object sender, System.EventArgs e)
        {
            CancelarUC();
        }


        #endregion 

        #region -- Metodos --

        /// <summary>
        /// Muestra u oculta los botones de la toolbar segun los parametros.
        /// Por defecto si no se utiliza este método se muestran los botones Guardar y Cancelar, y se oculta el boton Cerrar
        /// </summary>
        /// <param name="guardarVisible">indica si el boton Guardar se visualiza o no</param>
        /// <param name="cancelarVisible">indica si el boton Cancelar se visualiza o no</param>
        /// <param name="cerrarVisible">indica si el boton Cerrar se visualiza o no</param>
        protected void VisualizarBotonesToolbar(bool guardarVisible, bool cancelarVisible, bool cerrarVisible)
        {
            this.tbtnGuardar.Visible = guardarVisible;
            this.tbtnCancelar.Visible = cancelarVisible;
            this.tbtnCerrar.Visible = cerrarVisible;
        }

        /// <summary>
        /// Evento click del boton Ok en la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ClickOk(object sender, EventArgs e)
        {
            OnGuardar_Click(e);
        }

        /// <summary>
        /// Acciones a realizar antes de ejecutar el Click del boton Ok de la barra de tarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PreClickOk(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Acciones a realizar despues del click del botón Ok de la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PosClickOk(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Evento click del boton Ok en la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ClickCancelar(object sender, EventArgs e)
        {
            this.MensajeUsuario = "Se canceló la acción. Los datos no se guardaron.";
            OnCancelar_Click(e);
        }

        /// <summary>
        /// Acciones a realizar antes de ejecutar el Click del boton Ok de la barra de tarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PreClickCancelar(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Acciones a realizar despues del click del botón Ok de la barra de tareas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void PosClickCancelar(object sender, EventArgs e)
        {
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
            if (ComprobarCambios)
            {
                if (HayCambios())
                {
                    MessageBox.Show("Ha realizado cambios en los datos, si continua se perderán.\n¿Desea guardar los cambios?",
                        "Guardar cambios", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                        new EventHandler(MessageHayCambiosHandler));
                }
                else
                {
                    this.ClickCancelar(this, new EventArgs());
                }
            }
            else
                this.ClickCancelar(this, new EventArgs());
        }
        
        protected virtual void MessageHayCambiosHandler(object sender, EventArgs e)
        {
            DialogResult dr = ((MessageBoxWindow)sender).DialogResult;

            switch (dr)
            {
                case DialogResult.No:
                    this.ClickCancelar(this, new EventArgs());
                    break;
                case DialogResult.Yes:
                    this.GuardarUC();
                    break;
                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Retry:
                default:
                    break;
            }
        }

        #endregion

  
    }
}