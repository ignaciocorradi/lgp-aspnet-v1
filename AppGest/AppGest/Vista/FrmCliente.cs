#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;


#endregion

namespace AppGest.Vista
{
    public partial class FrmCliente : FrmBase
    {
        private Cliente _entidad;  
       
        public FrmCliente()
        {
            InitializeComponent();
        }
        public FrmCliente(FormBorderStyle estiloBorde, Color fondo, Cliente cliente)
            :this()
        {

            _entidad = cliente;
            InicializarPantalla(estiloBorde, fondo);
            this.ucCliente.Cargar<Cliente>(_entidad);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estiloBorde">Indica si va a mostrar el borde del formulario al crear </param>
        /// <param name="fondo">indica el color de fondo del formulario</param>
        private void InicializarPantalla(FormBorderStyle estiloBorde, Color fondo)
        {
            this.FormBorderStyle = estiloBorde;
            this.ucCliente.BackColor = fondo;
            this.ucCliente.tbMenu.Visible = true;
            this.ucCliente.tbMenu.Enabled = true;
            this.ucCliente.LLenarControles<Cliente>(_entidad);
            this.ucCliente.Cancelar_Click += new Controles.Click_EventHandler(ucCliente_Cancelar_Click);
            this.ucCliente.Guardar_Click += new Controles.Click_EventHandler(ucCliente_Guardar_Click);
        }

        void ucCliente_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingres� el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.ucCliente.Cargar<Cliente>(_entidad);
            this.CerrarForm();
        }

        void ucCliente_Cancelar_Click(object sender, EventArgs e)
        {
            // si se cancela, solo se cierra el formulario para
            if (this.ucCliente.HayCambios())
            {
                //TODO: Revisar si aplica.
                MessageBox.Show("Ha realizado cambios en el Cliente.\n�Desea Guardar estos cambios?.", "�Guardar cambios?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3, new EventHandler(Guardar_Cerrar_Cancelar));
            }
            else
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
                Guardar_Cerrar_Cancelar(this, e);
            }
        }

        private void Guardar_Cerrar_Cancelar(object sender, EventArgs e)
        {
            // Guarda los cambios
            this.DialogResult = ((Gizmox.WebGUI.Forms.Form)sender).DialogResult;
            switch (((Gizmox.WebGUI.Forms.Form)sender).DialogResult)
            {
                case DialogResult.No:
                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.ucCliente_Guardar_Click(sender, e);
                    break;
                case DialogResult.Cancel:
                // No hace nada
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Retry:
                default:
                    break;
            }

        }

        private void CerrarForm()
        {
            this.ucCliente.Dispose();
            this.Close();
        }
   
    }
}