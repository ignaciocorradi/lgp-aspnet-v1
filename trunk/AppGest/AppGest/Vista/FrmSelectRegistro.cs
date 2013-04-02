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
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Vista.Controles;
using AppGest.Util;

#endregion

namespace AppGest.Vista
{
    public partial class FrmSelectRegistro : FrmBase
    {
        Cliente _cliente;
        IList<ProxyFacturaLinea> _lineasAgregadas;
        public IList<ProxyPagoIngresosEgresosVariosDetalle> Seleccionados =  new List<ProxyPagoIngresosEgresosVariosDetalle>();

        public FrmSelectRegistro()
            :base()
        {
            InitializeComponent();
            this.Size = new Size(915, 434);
            this.BackColor = Color.White;
            lblResultado.Text = "Presione 'Buscar' para listar los registros.";
            ConfigurarGrilla();
        }

        public FrmSelectRegistro(IList<Concepto> conceptos, Cliente cliente, IList<ProxyFacturaLinea> lineasAgregadas)
            :this()
        {
            _cliente = cliente;
            _lineasAgregadas = lineasAgregadas;
            TituloCliente();
            CargarComboConceptos(conceptos);
 
        }
        #region Cargar Controlees --
        private void CargarComboConceptos(IList<Concepto> conceptos = null)
        {
            if(conceptos == null)
                using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
                    conceptos = exp.ListaConceptosIngresosVarios();

            Concepto todosConceptos = new Concepto() { Id = 0, Nombre = "(Todos)" };
            conceptos.Insert(0, todosConceptos);
            this.cmbEgreso.DataSource = conceptos;
            this.cmbEgreso.DisplayMember = Concepto.PROP_NOMBRE;


        }
        private void TituloCliente()
        {
            lblCliente.Text = string.Format(lblCliente.Text, _cliente.NombreCompleto);
            
        }
        #endregion

        #region Grilla
        void ConfigurarGrilla()
        {
            ucGrillaRdo.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrillaRdo.ParametrosGrilla = GetConfiguracion();
            ucGrillaRdo.DataSource = new List<ProxyPagoIngresosEgresosVariosDetalle>();
        }

        private ParametrosGrilla GetConfiguracion()
        {
            var columnas = new List<ParametrosColumna>();
            CrearColumnasDatos(columnas, 1);
            CrearColumnasAccion(columnas, 0);

            

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false);
            return configuracion;
        }
        private int CrearColumnasDatos(List<ParametrosColumna> columnas, int pos)
        {

            var pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_SERVICIO, "Fecha Serv", true, pos++, 130, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_CONCEPTO_EGRESO, "Concepto", true, pos++, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_IMPORTE, "Importe", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_ABONADO, "Pagado", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_PAGO, "Fecha Pago", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_VENCIMIENTO, "Vto.", true, pos++, 120, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_COMENTARIO, "Comentario", true, pos++, 300, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            return pos;
        }

        private void CrearColumnasAccion(List<ParametrosColumna> columnas, int pos)
        {
            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Seleccion", " ", string.Empty);
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = true;
            pcAccion.Posicion = pos;
            pcAccion.Ancho = 30;

            columnas.Add(pcAccion);
            

        }
        #endregion



        private void CargarDatos(Concepto conceptoAsociado, DateTime? fPagoDesde = null, DateTime? fPagoHasta = null
            , Persona cliente = null
            , DateTime? fVtoDesde = null, DateTime? fVtoHasta = null
            , DateTime? fRegDesde = null, DateTime? fRegHasta = null)
        {
            FiltrosDatos filtro = FiltrosDatos.VerTodos;

            if (rbSoloCancelado.Checked)
                filtro = FiltrosDatos.VerSaldoIgualACero;
            else if (rbVerImpagos.Checked)
                filtro = FiltrosDatos.VerSaldoMayorACero;


            List<ProxyPagoIngresosEgresosVariosDetalle> detalles = null;
            List<ProxyPagoIngresosEgresosVariosDetalle> detallesRdo = new List<ProxyPagoIngresosEgresosVariosDetalle>();
            using (var exp = FabExpertos.Inst.Obtener<ExpFactura>(IdSesion))
            {
                detalles = exp.ListarCobros(conceptoAsociado, filtro, fPagoDesde, fPagoHasta, cliente, fVtoDesde, fVtoHasta, fRegDesde, fRegHasta);
            }
            var idsAgrgados = (from linea in _lineasAgregadas
                               select linea.LineaIE.IdRegistro).ToList();

            if (idsAgrgados.Count == 0)
                detallesRdo.AddRange(detalles);
            else
            {
                foreach (var reg in detalles)
                {
                    if (!idsAgrgados.Contains(reg.IdRegistro))
                        detallesRdo.Add(reg);
                }
            }

            //var importe = detallesRdo.Sum(r => r.Importe);
            //var abonado = detallesRdo.Sum(r => r.Abonado);
            //var saldo = importe - abonado;

            if (detallesRdo.Count == 0)
                lblResultado.Text = "No se encontraron registros con los filtros solicitados.";
            else
                lblResultado.Text = "Se encontraron " + detallesRdo.Count.ToString() + " registro/s.";

            ucGrillaRdo.DataSource = detallesRdo;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Concepto concepto = this.cmbEgreso.SelectedItem as Concepto;
            if (concepto != null && concepto.Id == 0)
                concepto = null;

            DateTime? fPagoDesde = this.dtpPagoDesde.Checked ? this.dtpPagoDesde.Value as DateTime? : null;
            DateTime? fPagoHasta = this.dtpPagoHasta.Checked ? this.dtpPagoHasta.Value as DateTime? : null;

            DateTime? fVtoDesde = this.dtpPagoDesde.Checked ? this.dtpPagoDesde.Value as DateTime? : null;
            DateTime? fVtoHasta = this.dtpPagoHasta.Checked ? this.dtpPagoHasta.Value as DateTime? : null;

            DateTime? fRegDesde = this.dtpPagoDesde.Checked ? this.dtpPagoDesde.Value as DateTime? : null;
            DateTime? fRegHasta = this.dtpPagoHasta.Checked ? this.dtpPagoHasta.Value as DateTime? : null;

            this.CargarDatos(concepto, fPagoDesde, fPagoHasta, _cliente, fVtoDesde, fVtoHasta, fRegDesde, fRegHasta);
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var seleccion = ucGrillaRdo.Filas().Where(r => ucGrillaRdo.ObtenerControlAccion<CheckBox>(r, "Seleccion").Checked).ToList();
            foreach (var item in seleccion)
            {
                Seleccionados.Add(item.DataBoundItem as ProxyPagoIngresosEgresosVariosDetalle);
            }

            if (Seleccionados.Count > 0)
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar al menos un pago para continuar.","Selección de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Seleccionados.Clear();
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.Close();
            
        }
    }
}