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

#endregion

namespace AppGest.Vista.Controles
{
    public delegate void Selected_EventHandler(object sender, EventArgs e, Cliente c);

    public partial class BusquedaClienteComboBox : ComboBox
    {
        #region -- Declaracion de eventos --
        public event Selected_EventHandler Cliente_Selected;
        #endregion
        protected virtual void OnCliente_Selected(EventArgs e, Cliente c)
        {
            if (Cliente_Selected != null)
                Cliente_Selected(this, e, c);

        }

        private FrmBusquedaCliente _frmBusquedaCliente;
        public Cliente ClienteSeleccionado { get{return _clienteSeleccionado;} 
            set 
            {
                if (value != _clienteSeleccionado)
                {
                    _clienteSeleccionado = value;
                    OnCliente_Selected(new EventArgs(), _clienteSeleccionado);
                }
            } 
        }Cliente _clienteSeleccionado = null;
        public bool ExigeSeleccion
        {
            get
            { return _frmBusquedaCliente.ExigeSeleccionCliente; }
            set
            { _frmBusquedaCliente.ExigeSeleccionCliente = value; }
        }

        public BusquedaClienteComboBox()
        {
            _frmBusquedaCliente = new FrmBusquedaCliente();
            this.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDown;
            _frmBusquedaCliente.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(frmBusquedaCliente_FormClosing);
        }

        void frmBusquedaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClienteSeleccionado = _frmBusquedaCliente.ClienteSeleccionado;
            this.Text = ClienteSeleccionado != null ? ClienteSeleccionado.NombreCompleto : string.Empty;
        }

        protected override bool IsCustomDropDown
        {
            get
            {
                return true;
            }
        }

        protected override global::Gizmox.WebGUI.Forms.Form GetCustomDropDown()
        {
            _frmBusquedaCliente.DialogResult = Gizmox.WebGUI.Forms.DialogResult.None;
            _frmBusquedaCliente.Width = Math.Max(this.Width, _frmBusquedaCliente.Width);
            _frmBusquedaCliente.Listar();
            return _frmBusquedaCliente;
        }

        internal void Clear()
        {
            this._clienteSeleccionado = null;
            this.SelectedValue = null;
        }
    }
}