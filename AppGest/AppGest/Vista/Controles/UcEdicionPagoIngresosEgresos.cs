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
using AppGest.Negocio.Core;
using System.Collections;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [Administrador]
    [Supervisor]
    public partial class UcEdicionPagoIngresosEgresos : UcToolbar
    {
        private TipoServicio _tipoServicio;
        private string _encabezadoFechaPago;

        #region -- Constructores --
        public UcEdicionPagoIngresosEgresos()
        {
            InitializeComponent();
        }

        public UcEdicionPagoIngresosEgresos(TipoServicio tipoServicio) : this()
        {
            _tipoServicio = tipoServicio;
            this.cmbCliente.ExigeSeleccion = false;
            this.EstablecerTitulo(this.ObtenerTitulo());
            this.dtpFechaDesde.Checked = false;
            this.dtpFechaHasta.Checked = false;
        }
        #endregion

        #region -- Propiedades --
        
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
        #endregion

        
        #region -- Metodos --
        private void CargarCombo()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                IList<Concepto> conceptos = null;
                switch (_tipoServicio)
                {
                    case TipoServicio.Ingresos:
                        conceptos = exp.ListaConceptosIngresosVarios();
                        CargarComboClientes();
                        break;
                    case TipoServicio.EgresosVarios:
                        conceptos = exp.ListaConceptos(null, ConceptoEgresos.EGRESOS_VARIOS);
                        break;
                }
                
                Concepto todosConceptos = new Concepto(){ Id = 0, Nombre = "(Todos)"};
                conceptos.Insert(0, todosConceptos);
                this.cmbEgreso.DataSource = conceptos;
                this.cmbEgreso.DisplayMember = Concepto.PROP_NOMBRE;
            }
           
        }
        private void CargarComboClientes()
        {
            this.cmbCliente.Visible = true;
            this.lblCliente.Visible = true;
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
            {
                IList<Cliente> clientes = exp.ListaTodos(null, null, null, true);

                Cliente sinCliente = new Cliente() { Id = 0 };
                clientes.Insert(0, sinCliente);
                this.cmbCliente.DataSource = clientes;
                this.cmbCliente.DisplayMember = Persona.PROP_NOMBRECOMPLETO;
            }
        }

        private string ObtenerTitulo()
        {
            switch (_tipoServicio)
            {
                case TipoServicio.Ingresos:
                    _encabezadoFechaPago = "Fecha de Cobro";
                    this.lblPagoEfectuado.Text = "Cobro efectuado entre:";
                    return "Editar registros de ingreso de fondos";
                case TipoServicio.EgresosEmpleados:
                    _encabezadoFechaPago = "Fecha de Pago";
                    this.lblPagoEfectuado.Text = "Pago efectuado entre:";
                    return "Editar pago de personal";
                case TipoServicio.EgresosVarios:
                    _encabezadoFechaPago = "Fecha de Pago";
                    this.lblPagoEfectuado.Text = "Pago efectuado entre:";
                    return "Editar pago de egreso";
            }
            return string.Empty;
        }

        public void Inicializar()
        {
            ucGrilla1.DataSource = new List<ProxyPagoIngresosEgresosVariosDetalle>();
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
            this.CargarCombo();
        }

        private void CargarDatos(Concepto conceptoAsociado, DateTime? fechaDesde = null, DateTime? fechaHasta = null, Persona cliente = null)
        {
            FiltrosDatos filtro = FiltrosDatos.VerTodos;

            if (rbSoloCancelado.Checked)
                filtro = FiltrosDatos.VerSaldoIgualACero;
            else if (rbVerImpagos.Checked)
                filtro = FiltrosDatos.VerSaldoMayorACero;
              

            List<ProxyPagoIngresosEgresosVariosDetalle> detalles = null;
            using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(IdSesion))
            {
                switch (_tipoServicio)
                {
                    case TipoServicio.Ingresos:
                        detalles = exp.ListarCobros(conceptoAsociado, filtro, fechaDesde, fechaHasta, cliente);
                        break;
                    case TipoServicio.EgresosVarios:
                        detalles = exp.ListarPagos(conceptoAsociado, filtro, fechaDesde, fechaHasta);
                        break;
                }
            }
            var importe = detalles.Sum(r => r.Importe);
            var abonado = detalles.Sum(r => r.Abonado);
            var saldo = importe - abonado;

            lblTotImporte.Text = importe ==0 ? "$ 0": importe.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            lblTotAbonado.Text = abonado == 0 ? "$ 0" : abonado.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            lblTotalSaldo.Text = saldo == 0 ? "$ 0" : saldo.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            ucGrilla1.DataSource = detalles;

        }

        private ParametrosGrilla CrearConfiguracionGrilla()
        {
            //ucGrilla1.Dock = DockStyle.Fill;
            ucGrilla1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrilla1.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrilla1_ClickAccion);

            var columnas = new List<ParametrosColumna>();
            var pos = CrearColumnasDatos(columnas);
            CrearColumnasAccion(columnas, pos);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }

        private void EditarPago(ProxyPagoIngresosEgresosVariosDetalle pago)
        {
            var f = new FrmDetallePagoIngresosEgresos(FormBorderStyle.None, Color.White, pago, true, true, _tipoServicio);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        private int CrearColumnasDatos(List<ParametrosColumna> columnas)
        {
            int pos = 0;
            var pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_SERVICIO, "Fecha", true, pos++, 100, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);
            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_PAGO, _encabezadoFechaPago, true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            if (_tipoServicio == TipoServicio.Ingresos)
            {
                pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_NOMBRE_CLIENTE, "Cliente", true, pos++, 250, true, false,
                    DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
                columnas.Add(pCol);
            }

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_CONCEPTO_EGRESO, "Concepto", true, pos++, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_IMPORTE, "Importe", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_ABONADO, "Pagado", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_VENCIMIENTO, "Fecha de Vto.", true, pos++, 100, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_COMENTARIO, "Comentario", true, pos++, 300, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            return pos;
        }

        private void CrearColumnasAccion(List<ParametrosColumna> columnas, int pos)
        {
            
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = pos;
            pcAccion.Ancho = BotonEditar.Ancho ;

            columnas.Add(pcAccion);

        }
        /// <summary>
        /// Emula el evento de click del botón cancelar
        /// </summary>
        internal override void CancelarUC()
        {
            this.MensajeUsuario = "Listo.";
            this.ClickCancelar(this, new EventArgs());
        }

        #endregion

        #region -- Eventos --
        private void tbtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarUC();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Concepto concepto = this.cmbEgreso.SelectedItem as Concepto;
            if(concepto != null && concepto.Id == 0)
            {
                concepto =  null;
            }

            Persona cli = null;             
            if (_tipoServicio == TipoServicio.Ingresos)
            {
                cli = (Persona)this.cmbCliente.SelectedItem;
            }
            
            DateTime? fechaDesde = this.dtpFechaDesde.Checked ? this.dtpFechaDesde.Value as DateTime? : null;
            DateTime? fechaHasta = this.dtpFechaHasta.Checked ? this.dtpFechaHasta.Value as DateTime? : null;



            this.CargarDatos(concepto, fechaDesde, fechaHasta, cli);
        }

        void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Editar":
                    EditarPago(this.ucGrilla1.DataSource[e.RowIndex] as ProxyPagoIngresosEgresosVariosDetalle);
                    break;
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.btnBuscar_Click(this, new EventArgs());
            }
        }
        #endregion


    }
}