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
using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class UcABMServicioMensual : UcToolbar
    {
        private Proxy_LineaAsocCocheraMensual _linea;
        public Proxy_LineaAsocCocheraMensual LineaAsociada
        {
            get { return LlenarLinea(); }
        }
        public List<Proxy_LineaAsocCocheraMensual> LstCocherasAsignadas {get;set;}
        public List<Cochera> LstCocherasDisponibles { get; set; }

        #region -- Constructores --
        public UcABMServicioMensual()
        {
            InitializeComponent();
            this.EstablecerTitulo("Asignar Servicio y cochera");
            this.cmbServMensuales.Focus();

        }
        #endregion

        #region -- Metodos--
        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                ValidarDatos();
                if (!LstCocherasAsignadas.Contains(this.LineaAsociada))
                    LstCocherasAsignadas.Add(this.LineaAsociada);
                base.ClickOk(sender, e);
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void ValidarDatos()
        {
            if (this.LineaAsociada.Cochera == null)
                throw new InvalidOperationException("Debe seleccionar una cohchera para continuar.");

            if (this.LineaAsociada.CptoIngresoMensual == null)
                throw new InvalidOperationException("Debe seleccionar unservicio para continuar.");

            ValidarCochera();
        }
        private void ValidarCochera()
        {
            string rdo = "";
            foreach (var cocheraAsignada in LstCocherasAsignadas)
            {
                bool mismaCochera = cocheraAsignada.Cochera.Id == LineaAsociada.Cochera.Id;

                if (!cocheraAsignada.Equals(LineaAsociada) && mismaCochera)
                {
                    // si las fechas hastas son infinitas esta mal
                    if (!cocheraAsignada.Hasta.HasValue && !LineaAsociada.Hasta.HasValue)
                        rdo = "Existe mas de una cochera con mismo concepto y con fechas hasta sin establecer o periodo infinito.";
                    else if (cocheraAsignada.Hasta.HasValue && LineaAsociada.Hasta.HasValue)
                    {
                        if (DateTimeExtension.DateDiff(DateInterval.Day, LineaAsociada.Desde.Value, cocheraAsignada.Hasta.Value) >= 0
                            || DateTimeExtension.DateDiff(DateInterval.Day, LineaAsociada.Hasta.Value, cocheraAsignada.Desde.Value) <= 0)
                            rdo = "La cochera " + LineaAsociada.Cochera.NroCochera + " con periodo : " + LineaAsociada.Desde.Value.ToShortDateString() + " a " + LineaAsociada.Hasta.Value.ToShortDateString()
                                + "\nestá solpada con\nLa cochera " + cocheraAsignada.Cochera.NroCochera + " con periodo : " + cocheraAsignada.Desde.Value.ToShortDateString() + " a " + cocheraAsignada.Hasta.Value.ToShortDateString()
                                + "\nRevise las fechas asignadas para poder continuar.";
                    }
                    else
                    {

                        if (!cocheraAsignada.Hasta.HasValue
                            && (DateTimeExtension.DateDiff(DateInterval.Day, LineaAsociada.Hasta.Value, cocheraAsignada.Desde.Value) <= 0))
                            rdo = "La cochera " + LineaAsociada.Cochera.NroCochera + " con periodo : " + LineaAsociada.Desde.Value.ToShortDateString() + " a " + LineaAsociada.Hasta.Value.ToShortDateString()
                                + "\n está solapada con la cochera " + cocheraAsignada.Cochera.NroCochera
                                + "\nRevise las fechas asignadas para poder continuar.";

                        if (!LineaAsociada.Hasta.HasValue
                            && (DateTimeExtension.DateDiff(DateInterval.Day, LineaAsociada.Desde.Value, cocheraAsignada.Hasta.Value) >= 0))
                            rdo = "La cochera " + LineaAsociada.Cochera.NroCochera + " con periodo : " + LineaAsociada.Desde.Value.ToShortDateString() + " a " + LineaAsociada.Hasta.Value.ToShortDateString()
                                + "\n está solapada con la cochera " + cocheraAsignada.Cochera.NroCochera
                                + "\nRevise las fechas asignadas para poder continuar.";

                    }
                }
                if (rdo.Length > 0)
                    throw new InvalidOperationException(rdo);

            }

        }

        public override bool HayCambios()
        {

            Cochera coSeleccionada = lvCocherasDisponibles.SelectedItem != null ? ((LVItemCochera)lvCocherasDisponibles.SelectedItem).Item : null;
            ProxyServicioMensual cptoIngSelecccionado = cmbServMensuales.SelectedItem as ProxyServicioMensual;

            var cambios = base.HayCambios();
            return cambios ||
                (
                    _linea.Desde != this.dtpDesde.Value
                || _linea.Hasta != this.dtpHasta.Value
                || (_linea.Cochera == null ? true : !_linea.Cochera.Equals(coSeleccionada))
                || (_linea.CptoIngresoMensual == null ? true : !_linea.CptoIngresoMensual.Equals(cptoIngSelecccionado))
                );

            
        }
        public void LlenarControles(Proxy_LineaAsocCocheraMensual linea, List<Cochera> cocherasDisponibles, List<Proxy_LineaAsocCocheraMensual> cocherasAsignadas)

        {
            _linea = linea;
            LstCocherasDisponibles = cocherasDisponibles;
            LstCocherasAsignadas = cocherasAsignadas;
            CargarCocheras();
            var serv = ObtenerServicios();
            this.cmbServMensuales.DataSource = serv;
            this.cmbServMensuales.DisplayMember = ProxyServicioMensual.PROP_NOMBRE_PRECIO;

            if (_linea.CptoIngresoMensual != null && serv.Count > 0)
            {
                var pselected = (from s in serv
                                where s.Servicio.Id == _linea.CptoIngresoMensual.Id
                                select s).FirstOrDefault();

                cmbServMensuales.SelectedItem = pselected;
            }               
            

            lblNombreCochera.Text = _linea.Cochera == null ? "(Ninguna)" : _linea.Cochera.NroCochera + " (" + _linea.Cochera.Descripcion + ")";
            this.dtpDesde.Value = !_linea.Desde.HasValue ? DateTime.Now : _linea.Desde.Value;
            this.dtpHasta.Checked = _linea.Hasta.HasValue && !_linea.Hasta.Value.Equals(DateTime.MinValue);
            if (this.dtpHasta.Checked)
                this.dtpHasta.Value = !_linea.Hasta.HasValue || _linea.Hasta.Value.Equals(DateTime.MinValue) ? dtpHasta.MinDate : _linea.Hasta.Value;

        }
        private void CargarCocheras()
        {
            foreach (Cochera c in LstCocherasDisponibles)
                this.lvCocherasDisponibles.Items.Add(new LVItemCochera(c));

            this.lblCocherasDisp.Text = "Cocheras disponibles: " + LstCocherasDisponibles.Count.ToString(); 
        }


        private IList<ProxyServicioMensual> ObtenerServicios()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                return exp.ObtenerServiciosAlquilerMensual(DateTime.Now );
            }
            
        }
        public void HabilitarMenu(bool barraVisible, bool HabilitarOk, bool HabilitarCancel)
        {
            this.tbMenu.Visible = true;
            this.tbtnGuardar.Visible = HabilitarOk;
            this.tbtnGuardar.Enabled = HabilitarOk;
            this.tbtnCancelar.Visible = HabilitarCancel;
            this.tbtnCancelar.Enabled = HabilitarCancel;

        }
        private Proxy_LineaAsocCocheraMensual LlenarLinea()
        {
            if (lvCocherasDisponibles.SelectedItem != null)
                _linea.Cochera = ((LVItemCochera)lvCocherasDisponibles.SelectedItem).Item;

            if (cmbServMensuales.SelectedItem != null)
                _linea.CptoIngresoMensual = ((ProxyServicioMensual)cmbServMensuales.SelectedItem).Servicio;

            _linea.Desde = dtpDesde.Value;
            _linea.Hasta = dtpHasta.Checked ? dtpHasta.Value : (DateTime?)null;

            return _linea;
        }
        #endregion

        #region -- Eventos --
        private void lvCocherasDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LVItemCochera itemCochera = (LVItemCochera)lvCocherasDisponibles.SelectedItem;
            lblNombreCochera.Text = itemCochera.Item.NroCochera + " (" + itemCochera.Item.Descripcion+")" ;
        }
        #endregion
    }
}