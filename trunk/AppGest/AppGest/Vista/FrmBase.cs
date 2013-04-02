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
using AppGest.Negocio.Modelo;
using System.Security.Authentication;
using AppGest.Util;

#endregion

namespace AppGest.Vista
{
    public partial class FrmBase : Form
    {
        protected bool RunTime
        {
            get
            {
                return System.Web.HttpContext.Current != null;
            }
        }
        public FrmBase()
        {
            try
            {
                InitializeComponent();
            }
            catch (AuthenticationException ae)
            {
                Logger.Inst.Error("Autenticación", ae);
            }
        }

        protected Guid IdSesion
        {
            get
            {
                return (Guid) (this.Context.Session["idSesion"] ?? Guid.Empty);
            }
            set
            {
                this.Context.Session["idSesion"] = value;
            }
        }

        /// <summary>
        /// Redirecciona a otra pantalla
        /// </summary>
        public void IrA(string pantalla)
        {
            pantalla = pantalla + ".wgx";
            this.Context.Redirect(pantalla);
        }
        protected void Salir()
        {
            var idSesion = IdSesion;
            IdSesion = Guid.Empty;

            ExpSeguridad.Instancia.CerrarSesion(IdSesion);
        }

        protected virtual void MessageBoxHandler(object sender, EventArgs e)
        {

 
        }

        protected virtual void FrmBase_Load(object sender, EventArgs e)
        {

            if (this.IdSesion == Guid.Empty)
            {
                this.IrA("FrmInicio");
            }

        }
    }

}