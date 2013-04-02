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
using AppGest.Util.Atributos;
using AppGest.Negocio.Modelo;
using AppGest.Util;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using System.Collections;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucAMBFactura : UcToolbar
    {
        public List<ProxyFacturaLinea> _lineas = new List<ProxyFacturaLinea>();
       
        public List<ProxyPagoIngresosEgresosVariosDetalle> _lineasIE = new List<ProxyPagoIngresosEgresosVariosDetalle>();

        #region -- Propiedades --
        ProxyFacturaEncab Encabezado { get; set; }

        #endregion

        #region -- Ctor--
        public ucAMBFactura()
        {
            InitializeComponent();
            ConfigurarGrilla();
            LlenarCombo();
            Nuevo();
        }
        #endregion

        #region Metodos

        void LlenarCombo()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                var tiposcomp = exp.ObtenerTiposComprobantes();

                cmbTipoFac.ValueMember = ProxyTipoFactura.CONST_ENUMVALUE;
                cmbTipoFac.DisplayMember = ProxyTipoFactura.CONST_DESCRIPCION;
                cmbTipoFac.DataSource = tiposcomp;
            }
        }
        void Nuevo()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpFactura>(IdSesion))
            {
                Encabezado = new ProxyFacturaEncab(exp.Nuevo());
                Encabezado.FechaRegistro = dtpFecha.Value;
            }
        }
        void LimpiarControles()
        {
            this.dtpFecha.Value = DateTime.Now;
            this.cmbClientes.Clear();
            this.cmbTipoFac.SelectedValue = null;
            this.txtNroFactura.Clear();
            this.txtComentario.Clear();
            
        }
        void CargarEnitidad()
        {
            Encabezado.FechaRegistro = this.dtpFecha.Value;
            Encabezado.Cliente = this.cmbClientes.ClienteSeleccionado;
            Encabezado.TipoComprobante = (TipoFactura)cmbTipoFac.SelectedValue;
            Encabezado.NroFactura = this.txtNroFactura.Text;
            Encabezado.Comentario =  this.txtComentario.Text;
            

        }


        #region -- Grilla --
        void ConfigurarGrilla()
        {
            ucGrillaLineas.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            ucGrillaLineas.ClickAccion += new UcGrilla.ClickAccionEventHandler(ucGrillaLineas_ClickAccion);
            ucGrillaLineas.Grilla.CellEndEdit+=new DataGridViewCellEventHandler(Grilla_CellEndEdit);
            ucGrillaLineas.ParametrosGrilla = GetConfiguracion();
            ucGrillaLineas.DataSource = new List<ProxyPagoIngresosEgresosVariosDetalle>();
        }

        private ParametrosGrilla GetConfiguracion()
        {
            var columnas = new List<ParametrosColumna>();
            var pos = CrearColumnasDatos(columnas,0);
            CrearColumnasAccion(columnas, pos);

            var configuracion = new ParametrosGrilla(columnas, false, true, true, true, true, ScrollBars.Both, false, EnumEditable.Editable);
            return configuracion;
        }
        private int CrearColumnasDatos(List<ParametrosColumna> columnas, int pos)
        {
            
            var pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_SERVICIO, "Fecha Serv", true, pos++, 100, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true, EnumEditable.NoEditable);
            columnas.Add(pCol);


            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_CONCEPTO_EGRESO, "Concepto", true, pos++, 250, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true, EnumEditable.NoEditable);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_IMPORTE, "Importe", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true, EnumEditable.NoEditable);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_ABONADO, "Pagado", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ARCurrencyFormatCurrentCulture, null, true, EnumEditable.Editable);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_PAGO, "Fecha Pago", true, pos++, 150, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true, EnumEditable.Editable);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_FECHA_VENCIMIENTO, "Vto.", true, pos++, 120, true, false,
                DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, FormatHelper.ShortDateFormatCurrentCulture, null, true, EnumEditable.NoEditable);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(ProxyPagoIngresosEgresosVariosDetalle.PROP_COMENTARIO, "Comentario", true, pos++, 300, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true, EnumEditable.Editable);
            columnas.Add(pCol);

            return pos;
        }

        private void CrearColumnasAccion(List<ParametrosColumna> columnas, int pos)
        {

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Quitar", "Quitar", "Quitar el registro actual", TipoControlAccion.BotonEliminar));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = pos;
            pcAccion.Ancho = BotonEliminar.Ancho;

            columnas.Add(pcAccion);

        }
        void ucGrillaLineas_ClickAccion(object sender, AccionEventArgs e)
        {
            switch (e.Accion)
            {
                case "Quitar":
                    Quitar(this.ucGrillaLineas.DataSource[e.RowIndex] as ProxyFacturaLinea);
                    break;

            }
        }

        private void Quitar(ProxyFacturaLinea linea)
        {
            if (linea != null)
            {
                MessageBox.Show("Se eliminará la línea.\n¿Desea realizar la acción?",
                "Guardar cambios", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                new EventHandler(delegate(object sender, EventArgs e) { QuitarLinea(sender, linea); }));
            }
        }
        private void QuitarLinea(object sender, ProxyFacturaLinea linea)
        {
            var rdo = ((Form)sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                Encabezado.QuitarLinea(linea);
                _lineas.Remove(linea);

                ucGrillaLineas.DataSource = (IList)_lineas;
                ActualizarTotales();
            }

        }

        #endregion

        void Grilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarTotales();
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                Validar();
                using (var exp = FabExpertos.Inst.Obtener<ExpFactura>(IdSesion))
                {
                    // Actualizar proxies con datos UI
                    CargarEnitidad();
                    // Persistir
                    exp.Guardar(Encabezado);
                    this.MensajeUsuario = string.Format("Se guardó la factura '{0}' con éxito.", this.txtNroFactura.Text);

                    MessageBox.Show(this.MensajeUsuario, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                base.ClickOk(sender, e);
            }
            catch (ValidacionException vex)
            {
                MessageBox.Show(vex.MessageCompleteConTitulo, "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.MensajeUsuario = "Error. No se guardó la factura.";
                Logger.Inst.Error(ex.Message, ex);
                MessageBox.Show("No se pudo guardar la factura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Validar()
        {
            List<EstructuraValidacion> errores = new List<EstructuraValidacion>();
            
            if (this.txtNroFactura.Text == string.Empty)
            {
                errores.Add(new EstructuraValidacion()
                { Mensage = "- Debe completar el nro de factura.\n",
                    Tipo = EnumTipoError.Error
                });  
            }
            if (this.cmbClientes.ClienteSeleccionado == null)
            {
                errores.Add(new EstructuraValidacion()
                {
                    Mensage = "- Debe seleccionar un cliente.\n",
                    Tipo = EnumTipoError.Error
                });
            }
            if (this._lineas.Count == 0)
            {
                errores.Add(new EstructuraValidacion()
                {
                    Mensage = "- Debe agregar al menos una línea.\n",
                    Tipo = EnumTipoError.Error
                });
            }
            if(errores.Count>0)
                throw new ValidacionException("No se puede completar la acción.\n", errores);
        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            Cliente c = cmbClientes.ClienteSeleccionado;
            if (c != null)
            {
                FrmSelectRegistro f = new FrmSelectRegistro(null, cmbClientes.ClienteSeleccionado, _lineas);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para agregar un registro.", "Agregar línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
        
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectRegistro f = sender as FrmSelectRegistro;
            if (f.DialogResult == DialogResult.OK)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpFactura>(IdSesion))
                {
                    //TODO: Convertir los proxys a facturas.
                    foreach (var item in f.Seleccionados)
                    {
                        Reg_Det d = exp.Nuevo(Encabezado.RegEncab ,item.Concepto);
                        _lineas.Add(new ProxyFacturaLinea(d, Encabezado, item));
                    }
                }
                if(_lineas.Count > 0)
                    ucGrillaLineas.DataSource = (IList)_lineas;
                ActualizarTotales();
            }
        }

        private void ActualizarTotales()
        {
            
            var importe = _lineas.Sum(r => r.Importe);
            var abonado = _lineas.Sum(r => r.Abonado);
            var saldo = importe - abonado;
            lblTotImporte.Text = importe == 0 ? "$ 0" : importe.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            lblTotAbonado.Text = abonado == 0 ? "$ 0" : abonado.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
            lblTotalSaldo.Text = saldo == 0 ? "$ 0" : saldo.ToString(FormatHelper.ARCurrencyFormatCurrentCulture);
        }
       

        private void btnFechaPago_Click(object sender, EventArgs e)
        {
            foreach (var item in _lineas)
            {
                item.FechaPago = dtpFechaPago.Value;
            }
            ucGrillaLineas.Update();
        }
        #endregion


    } 
}