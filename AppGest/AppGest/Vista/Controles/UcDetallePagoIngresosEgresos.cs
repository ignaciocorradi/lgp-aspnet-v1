#region Using

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Util.Atributos;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using System.Collections;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [Administrador]
    [Supervisor]
    [Operador]
    public partial class UcDetallePagoIngresosEgresos :  UcToolbar
    {
        #region Atributos
        TipoServicio _tipoServicio;
        ProxyPagoIngresosEgresosVariosDetalle _detalle;
        private bool _esEdicion;
        #endregion
        #region Ctor
        public UcDetallePagoIngresosEgresos()
        {
            InitializeComponent();
            this.lblComentario.AutoSize = false;
        }
        #endregion

        #region Metodos
        public void CargarPago(ProxyPagoIngresosEgresosVariosDetalle detalle, bool esEdicion, bool permiteGuardar, TipoServicio tipoServicio)
        {
            this._esEdicion = esEdicion;
            _tipoServicio = tipoServicio;
            this.InicializarSegunTipoServicio();

            this._detalle = detalle;
            base.tbtnGuardar.Visible = permiteGuardar;
            this.btnAceptar.Visible = !permiteGuardar;
            this.CargarComboEgresosVarios();
            
            if (_esEdicion)
            {
                this.CargarCamposPantalla();
            }
            else
            {
                this.CargarImporte();
            }
            // cambie el evento para que no busque en la BD por cada cambio en el combo. 
            this.cmbEgresos.Leave += new System.EventHandler(this.cmbEgresos_Leave);
            this.cmbCliente.Cliente_Selected += new Selected_EventHandler(cmbCliente_Cliente_Selected);
            
        }

        void cmbCliente_Cliente_Selected(object sender, EventArgs e, Cliente c)
        {
            CargarVehiculo(c); 
        }

       

        private void InicializarSegunTipoServicio()
        {
            string titulo = string.Empty;

            switch (_tipoServicio)
            {
                case TipoServicio.Ingresos:
                    this.lblFechaPago.Text = "Fecha de cobro";
                    this.lblSeleccionarEgreso.Text = "Seleccionar servicio";
                    titulo = "Registro de cobros de ingresos";
                    lblFechaServ.Text = "Fecha servicio";
                    this.CargarComboClientes();
                    break;
                case TipoServicio.EgresosEmpleados:
                    this.lblFechaPago.Text = "Fecha de pago";
                    this.lblSeleccionarEgreso.Text = "Seleccionar Egreso";
                    titulo = "Registro de Pago de personal";
                    break;
                case TipoServicio.EgresosVarios:
                    lblFechaServ.Text = "Fecha";
                    this.lblFechaPago.Text = "Fecha de pago";
                    this.lblSeleccionarEgreso.Text = "Seleccionar servicio";
                    titulo = "Registro de pago de egresos";
                    break;
            }

            this.EstablecerTitulo(titulo);

            this.ReposicionarControles();
        }

        private void ReposicionarControles()
        {
            if (_tipoServicio != TipoServicio.Ingresos)
            {
                this.btnAceptar.Top -= 30;
                this.lblComentario.Top = this.lblFechaVencimiento.Top;
                this.txtComentario.Top = this.dtpFechaVencimiento.Top;
                this.lblFechaVencimiento.Top = this.lblIndicarImporte.Top;
                this.dtpFechaVencimiento.Top = this.nudImporte.Top;
                this.lblIndicarImporte.Top = this.lblCliente.Top;
                this.nudImporte.Top = this.cmbCliente.Top;
            }
            else
            {
                this.lblCliente.Visible = true;
                this.cmbCliente.Visible = true;
                this.Height += 30;
            }
        }

        private void CargarComboClientes()
        {
            this.cmbCliente.ExigeSeleccion = true;
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
            {
                IList<Cliente> clientes = exp.ListaTodos(null, null, null, true);

                Cliente sinCliente = new Cliente() { Id = 0 };
                clientes.Insert(0, sinCliente);
                this.cmbCliente.DataSource = clientes;
                this.cmbCliente.DisplayMember = Persona.PROP_NOMBRECOMPLETO;
            }
        }

        private void CargarComboEgresosVarios()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                switch (_tipoServicio)
                {
                    case TipoServicio.Ingresos:
                        this.cmbEgresos.DataSource = (IList)exp.ListaConceptosIngresosVarios();
                        break;
                    case TipoServicio.EgresosVarios:
                        this.cmbEgresos.DataSource = (IList)exp.ListaConceptos(null, ConceptoEgresos.EGRESOS_VARIOS);
                        break;
                }
                
                this.cmbEgresos.DisplayMember = Concepto.PROP_NOMBRE;
            }
        }

        private void CargarCamposPantalla()
        {
            this.txtComentario.Text = _detalle.Comentario;
            this.cmbEgresos.Text = _detalle.Concepto.Nombre;
            this.nudImporte.Value = _detalle.Importe;
            this.nudAbonado.Value = _detalle.Abonado;
            this.dtpFechaServicio.Value = _detalle.FechaServicio.Value;



            if (_detalle.FechaPago.HasValue)
            {
                this.dtpFechaPago.Checked = true;
                this.dtpFechaPago.Value = _detalle.FechaPago.Value;
            }
            else
                this.dtpFechaPago.Checked = false;
                
            

            if(_detalle.FechaVencimiento.HasValue)
            {
                this.dtpFechaVencimiento.Checked = true;
                this.dtpFechaVencimiento.Value = _detalle.FechaVencimiento.Value;
            }

            if (_tipoServicio == TipoServicio.Ingresos)
            {
                this.cmbCliente.Text = _detalle.Cliente != null ? _detalle.Cliente.NombreCompleto : this.cmbCliente.Items.OfType<Persona>().FirstOrDefault(p => p.Id == 0).NombreCompleto;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.CargarValoresProxy();
            base.ClickOk(sender,e);
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            
            try
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
                {
                    this.CargarValoresProxy();
                    _detalle.ActualizarLinea(_detalle);
                    exp.GuardarPago(_detalle.Parent);
                }

                MensajeUsuario = "Se guardó correctamente la linea de pago.";
                base.ClickOk(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la linea de pagos. Verifique los datos.\n\nDetalle error: " + ex.Message, "Error el guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar pagos.\nError:" + ex.Message, ex.InnerException);
            }

        }

        private void CargarValoresProxy()
        {
            _detalle.Comentario = this.txtComentario.Text;
            _detalle.Concepto = (Concepto) this.cmbEgresos.SelectedItem;
            _detalle.Importe = this.nudImporte.Value;
            _detalle.Abonado = this.nudAbonado.Value;
            _detalle.FechaPago = this.dtpFechaPago.Checked ? this.dtpFechaPago.Value as DateTime? : null;
            _detalle.FechaServicio = this.dtpFechaServicio.Value;
            _detalle.FechaVencimiento = this.dtpFechaVencimiento.Checked ? this.dtpFechaVencimiento.Value as DateTime? : null;

            if (_tipoServicio == TipoServicio.Ingresos)
            {
                _detalle.Cliente = (Persona)this.cmbCliente.SelectedItem;
            }
        }

        private void cmbEgresos_Leave(object sender, EventArgs e)
        {
            if(!_esEdicion)
                this.CargarImporte();
        }

        private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
        {
            if(!_esEdicion)
                this.CargarImporte();
        }
        void CargarVehiculo(Cliente entidad)
        {
            if (entidad != null)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
                {
                    var vs = (from v in exp.ObtenerVehiculos(entidad) select v.Nombre + " " + v.Marca +"\n").ToList();
                    var cadenaVs = string.Join("", vs);
                    this.txtComentario.Text = cadenaVs;

                }
            }
        }
        private void CargarImporte()
        {
            Concepto conceptoActualizado = (Concepto) this.cmbEgresos.SelectedItem;

            using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
            {

                this.nudImporte.Value = conceptoActualizado != null ? exp.ObtenerImporte(conceptoActualizado.Id, this.dtpFechaPago.Value, this.nudImporte.Value) : 0;
            }
        }

        #endregion

    }
}