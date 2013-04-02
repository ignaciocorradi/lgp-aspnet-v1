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
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Modelo;
using AppGest.Vista.Reportes;
using AppGest.Negocio.Core;
using AppGest.Util;

#endregion

namespace AppGest.Vista
{
    public partial class FrmInicio : FrmBase
    {
        public FrmInicio()
        {
            InitializeComponent();
            this.txtClave.BorderColor = new BorderColor(Color.SlateGray);
            
        }

        private void lblNuevoUsr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.IrA("FrmNuevoUsuario");

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                IdSesion = ExpSeguridad.Instancia.IniciarSesion(txtUsuario.Text, txtClave.Text);

                #region Cargar Parametro Global de Reportes

                
                Usuario usuario = null;
                using (var exp = IoC.Singleton.Experto<ExpUsuarios>(IdSesion))
                {
                    usuario = exp.ObtenerUsuario(IdSesion);
                }
                ConfiguracionesReportes.CargarParametroGlobalReporte(IdSesion, "IdUsuario", usuario.Id.ToString());
                #endregion Cargar Parametro Global de Reportes

                this.IrA("FrmPrincipal");
            }
            catch (InvalidOperationException ex)
            {
                lblMensaje.Text = "Usuario o clave incorrecta. Intente nuevamente.";
                Logger.Inst.Error(lblMensaje.Text + "\n" + ex.Message, ex.InnerException);                     
                //MessageBox.Show(this, "Los datos ingresados no son correctos.\n\nReviselos e intente nuevamente."
                //    , "Datos incorrectos"
                //    , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            if (IdSesion != Guid.Empty)
            {
                IrA("FrmPrincipal");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void LimpiarControles()
        {
            this.lblMensaje.Text = "";
        }
        private void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void txtClave_GotFocus(object sender, EventArgs e)
        {
            LimpiarControles();
            this.txtClave.SelectAll();
        }

    }
}