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
    [OperadorAttribute]
    public partial class ucEdicionCliente : UcToolbar
    {
        #region -- Constructores --
        
        public ucEdicionCliente()
        {
            InitializeComponent();

            this.VisualizarBotonesToolbar(false, false, true);
            this.EstablecerTitulo("Editar cliente");
        }
        #endregion

        public ParametrosGrilla ConfiguracionGrilla { 
            get
            {
                if (_configuracion == null)
                    _configuracion = CrearConfiguracionGrilla();
                return _configuracion;
            } 
        }
        ParametrosGrilla _configuracion = null;

        #region -- Metodos --
        public void Listar()
        {
            CargarDatos(-1);
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
        }

        private void CargarDatos(int? nroCliente = null, string nombre = null, string apellido = null, bool? activos = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
            {
                this.MensajeUsuario = "Buscando...";
                var datos = exp.ListaTodos(nroCliente, nombre, apellido, activos);
                ucGrilla1.DataSource = (IList)datos.ToList();
                if (datos.Count == 0)
                    this.MensajeUsuario = "No se encontraron datos.";
                else
                    this.MensajeUsuario = (datos.Count == 1 ? "Se encontró " : "Se encontraron ")
                                            + datos.Count.ToString()
                                            + (datos.Count == 1 ? " registro." : " registros.");
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
        private void BajaEntidad(Cliente cliente)
        {
            string msg = "";
            if (cliente.Baja.HasValue)
            {
                // Si esta dado de baja, se puede volver a activar.
                msg = "Va a 'Activar' el cliente '{0}'. ¿Desea continuar?";
            }
            else
            {
                // Si no esta dado de baja, lo bajonea.
                msg = "Va a 'dar de baja' el cliente '{0}'. ¿Desea continuar?";
            }
            msg = string.Format(msg, cliente.NombreCompleto);

            MessageBox.Show(msg, "Baja / Activar cliente",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2,
                            new EventHandler(delegate(object sender, EventArgs e) { ActivarBaja(sender, cliente); }));


        }
        private void ActivarBaja(object sender, Cliente cliente)
        {
            Cliente clienteEnEdicion = cliente;
            var rdo = ((Form)sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
                {
                    Cliente c = exp.ObtenerPorId(clienteEnEdicion.Id);

                    if (c.Baja.HasValue)
                    {
                        c.Baja = null;
                    }
                    else
                    {
                        c.Baja = DateTime.Now;
                    }
                    exp.Guardar(c);
                }
                this.CargarDatos();
            }

        }
        private void EditarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                FrmCliente f = new FrmCliente(FormBorderStyle.None, Color.White, cliente);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarClienteClose_FormClosed);
            }
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
        private void CrearColumnasDatos(List<ParametrosColumna> columnas)
        {
            var pCol = new ParametrosColumna(Cliente.PROP_NROCLIENTE, "Nro Cliente", true, 0, 80, true, false,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_NOMBRECOMPLETO, "Cliente", true, 1, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_DOMICILIOCOMPLETO, "Domicilio", true, 2, 350, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_TELEFONO, "Teléfono", true, 3, 100, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_CELULAR, "Celular", true, 4, 100, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_ALTA, "Fecha Ingreso", true, 5, 110, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Cliente.PROP_ACTIVO, "Activo", true, 6, 50, true, false,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);
        }

        private void CrearColumnasAccion(List<ParametrosColumna> columnas)
        {

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Baja", "Baja / Activar", "Dar de baja el registro actual", TipoControlAccion.BotonBaja));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 7;
            pcAccion.Ancho = BotonBaja.Ancho + BotonEditar.Ancho;

            columnas.Add(pcAccion);



        }

        #endregion

        #region -- Eventos --
        
        void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {
             
            switch (e.Accion)
            {
                case "Editar":
                    EditarCliente(this.ucGrilla1.DataSource[e.RowIndex] as Cliente);
                    break;

                case "Baja":
                    BajaEntidad(this.ucGrilla1.DataSource[e.RowIndex] as Cliente);
                    break;
                
            }
        }
        
        void frmEditarClienteClose_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.btnBuscar_Click(this, new EventArgs());
            }
        }
            
        private void tbtnGuardar_Click(object sender, EventArgs e)
        {
            ClickOk(sender, e);
        }
        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            bool? activos = null;
            if(this.rbtnActivos.Checked)
            {
                activos = true;
            }
            else if (this.rbtnDadosDeBaja.Checked)
            {
                activos = false;
            }

            int? nro =  this.txtNroCliente.Text == string.Empty ? (int?)null : Convert.ToInt32(this.txtNroCliente.Text);
            
            this.CargarDatos(nro, this.txtNombre.Text.Trim(), this.txtApellido.Text.Trim(), activos);
        }
        #endregion

    }
}