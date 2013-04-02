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
using AppGest.Vista.Controles;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using System.Collections;

#endregion

namespace AppGest.Vista
{
    public partial class FrmBusquedaCliente : FrmBase
    {
        public Cliente ClienteSeleccionado { get; set; }

        public FrmBusquedaCliente()
        {
            InitializeComponent();
        }

        public bool ExigeSeleccionCliente
        {
            get { return !this.btnLimpiar.Visible; }
            set 
            {
                this.btnLimpiar.Visible = !value;
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

        public void Listar()
        {
            CargarDatos(this.txtNombre.Text);
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
            //ucGrilla1.Grilla.CellDoubleClick += new DataGridViewCellEventHandler(Grilla_CellDoubleClick);
        }

        void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private ParametrosGrilla CrearConfiguracionGrilla()
        {
            var columnas = new List<ParametrosColumna>();
            var pCol = new ParametrosColumna(Cliente.PROP_NOMBRECOMPLETO, "Cliente", true, 0, 410, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);

            columnas.Add(pCol);

            var configuracion = new ParametrosGrilla(columnas, true, false, false, false, true, ScrollBars.Both, false);
            return configuracion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.CargarDatos(this.txtNombre.Text.Trim());
        }

        private void CargarDatos(string nombre = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
            {
                var datos = exp.ListaTodos(null, nombre, true);
                ucGrilla1.DataSource = (IList)datos.ToList();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClienteSeleccionado = null;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ucGrilla1.FilaActual != null)
            {
                ClienteSeleccionado = (Cliente)ucGrilla1.DataSource[ucGrilla1.FilaActual.Index] as Cliente;
                this.Close();
            }

        }
    }
}