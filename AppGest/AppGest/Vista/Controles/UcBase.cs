#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Negocio.Modelo;
using System.Security.Authentication;
using AppGest.Util;
using System.ComponentModel.Design;

#endregion

namespace AppGest.Vista.Controles
{
    public delegate void Click_EventHandler(object sender, EventArgs e);
    public delegate void Message_EventHandler(object sender, EventArgs e);

    
    public partial class UcBase : UserControl
    {
        System.ComponentModel.ComponentResourceManager _resources = new System.ComponentModel.ComponentResourceManager(typeof(UcBase));

        protected string IMG_BOTONEDITAR = "botonEditar";
        protected string IMG_BOTONBAJA = "botonBaja";

        public UcBase()
        {
            if (RunTime)
            {
                //Por ahora solo se verifica si los uc's son distintos a los del formulario de nuevo usuario,
                //si se desea ocultar este formulario agregar algun valor en el web.config
                if (!this.GetType().Equals(typeof(UcUsuarioNuevo)) && !this.GetType().Equals(typeof(ucDatosUsuario)))
                {
                    Helper.TienePermiso(IdSesion, this.GetType(), _resources);
                }
            }
            InitializeComponent();
        }


        protected bool RunTime
        {
            get
            {
                return System.Web.HttpContext.Current != null;
            }
        }

        #region -- Declaracion de eventos --
        public event Click_EventHandler Guardar_Click;
        public event Click_EventHandler Cancelar_Click;
        public event Message_EventHandler MensageUsuario_Change;
        #endregion

        #region -- Propiedades --
        public string MensajeUsuario
        {
            get { return _msjUsuario; }
            set
            {
                if (value != _msjUsuario)
                {
                    _msjUsuario = value;
                    OnMensageUsuario_Change(new EventArgs());
                }
            }
        }string _msjUsuario = string.Empty;
        protected Guid IdSesion
        {
            get
            {
                return (Guid)(this.Context.Session["idSesion"] ?? Guid.Empty);
            }
        }
        public string KeySolapa { get; set; }
        #endregion

        protected virtual void OnGuardar_Click(EventArgs e)
        {
            if (Guardar_Click != null)
                Guardar_Click(this, e);

        }
        protected virtual void OnCancelar_Click(EventArgs e)
        {
            if (Cancelar_Click != null)
                Cancelar_Click(this, e);

        }
        protected virtual void OnMensageUsuario_Change(EventArgs e)
        {
            if (MensageUsuario_Change != null)
                MensageUsuario_Change(this, e);
        }
        
        #region -- Metodos --
        public new virtual void Dispose()
        {
            
            this.Guardar_Click = null;
            this.Cancelar_Click = null;
            this.MensageUsuario_Change = null;

            base.Dispose();
        }
        public virtual bool HayCambios()
        {
            return false;
        }
        internal virtual void GuardarUC()
        {
            throw new NotImplementedException();
        }
        internal virtual void CancelarUC()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}