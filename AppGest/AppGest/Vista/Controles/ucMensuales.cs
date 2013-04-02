#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion
using AppGest.Negocio.Modelo;
using AppGest.Negocio;
using System.Collections;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Util;

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucMensuales : UcToolbar
    {
        #region -- Atributos --
        ExpMensuales _expM = new ExpMensuales();
        Proxy_Mensuales _mensual;
        List<Cochera> _lstCocheraDisp;
        List<Proxy_LineaAsocCocheraMensual> _lstCocheraAsignadas;
        List<Vehiculo> _lstVehiculosAsignados;
        #endregion

        public ucMensuales()
        {
            InitializeComponent();
            this.MostrarCabecera = false;
            this.MostrarBarra = true;

            this.Select(true, false);
            this.ucCliente.Select();
            this.ucCliente.VerdatoVehiculo = false;
        }

        #region -- Metodos --
        private void Inicializar()
        {
            _lstCocheraDisp = new List<Cochera>();
            _lstCocheraAsignadas = new List<Proxy_LineaAsocCocheraMensual>();
            _lstVehiculosAsignados = new List<Vehiculo>();
        }
        public void Modificar(Proxy_Mensuales mensual)
        {
            _mensual = mensual;
            Inicializar();
            Cargar();
        }

        public void Nuevo()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
            {
                _mensual = new Proxy_Mensuales(this.IdSesion);
                _mensual.Cliente = exp.Nuevo();

            }
            Inicializar();
            Cargar();
        }

        protected void Cargar()
        {
            this.ucCliente.LLenarControles<Cliente>(_mensual.Cliente);

            
            if (!_mensual.EsNuevo)
            {
                // Para la modificacion
                foreach (var v in _mensual.Vehiculos)
                {
                    _lstVehiculosAsignados.Add((Vehiculo)v.ValLista1);
                }
                CargarVehiculos();
                foreach (var c in _mensual.Cocheras)
                {
                    _lstCocheraAsignadas.Add(new Proxy_LineaAsocCocheraMensual(c));
                }
                CargarCocheras();

            }

        }

        private void ActualizarCocherasDisponibles()
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
            {
                _lstCocheraDisp.Clear();
                //Obtiene las cocheras disponibles.
                _lstCocheraDisp.AddRange(exp.ListaCocherasDisponibles());
            }
            // quita las cocheras seleccionadas por el usuario.
            if (_lstCocheraAsignadas.Count > 0)
                _lstCocheraDisp.RemoveAll(c => _lstCocheraAsignadas.Select(h => h.Cochera.Id).Contains(c.Id));



        }

        private void CargarVehiculos()
        {
            this.lvVehiculos.Items.Clear();

            foreach (Vehiculo c in _lstVehiculosAsignados)
                this.lvVehiculos.Items.Add(new LVItemVehiculo(c));
            ActualizarAccion();
        }

        private Vehiculo ObtenerVehiculoSeleccionado()
        {
            Vehiculo v = null;
            var lvVehi = this.lvVehiculos.SelectedItem as LVItemVehiculo;
            if (lvVehi != null)
                v = lvVehi.Item;
           
            return v;

        }

        public override bool HayCambios()
        {
            bool rdo = false;

            rdo = this.ucCliente.HayCambios();

            return rdo;

        }

        internal override void CancelarUC()
        {
            if (HayCambios())
            {
                MessageBox.Show("Ha realizado cambios en los datos, si continua se perderán.\n¿Desea guardar los cambios?",
                    "Guardar cambios", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3,
                    new EventHandler(MessageHayCambiosHandler));
            }
            else
            {
                this.tbbCancelar_Click(this, new EventArgs());

            }

        }

        #endregion

        #region -- Eventos --

        #region -- Metodos y eventos para Asignacion de COCHERAS --
        private void btnAgregarCochera_Click(object sender, EventArgs e)
        {
            // Agrega un servicio de alquiler de cochera por periodo.
            ActualizarCocherasDisponibles();
            Proxy_LineaAsocCocheraMensual linea = new Proxy_LineaAsocCocheraMensual(_mensual.Cliente, null, null);
            linea.Desde = this.ucCliente.AltaCliente;

            FrmAMBServMensual f = new FrmAMBServMensual(FormBorderStyle.None, Color.White, linea, this._lstCocheraAsignadas, _lstCocheraDisp);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmAMBServMensual_FormClosed);
        }
        private void btnEditarCochera_Click(object sender, EventArgs e)
        {
            ActualizarCocherasDisponibles();
            Proxy_LineaAsocCocheraMensual linea;
            if (lvCocherasAsoc.SelectedItem != null)
            {
                linea = ((LVItemLineaAsocCochera)lvCocherasAsoc.SelectedItem).Item;
                FrmAMBServMensual f = new FrmAMBServMensual(FormBorderStyle.None, Color.White, linea, this._lstCocheraAsignadas, _lstCocheraDisp);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmAMBServMensual_FormClosed);
            }
            else
            { 
                MessageBox.Show("Debe seleccionar una cochera asociada para editar.");
            
            }
        }
        //private void btnBajaCochera_Click(object sender, EventArgs e)
        //{
        //    if (lvCocherasAsoc.SelectedItem == null)
        //    {
        //        MessageBox.Show("Debe seleccionar una cochera asociada para dar de baja.");
        //    }
        //    else
        //    {
        //        LVItemLineaAsocCochera item = lvCocherasAsoc.SelectedItem as LVItemLineaAsocCochera;
        //        lvCocherasAsoc.Items.Remove(item);
        //        if (item.Item.EsNuevo)
        //            _lstCocheraAsignadas.Remove(item.Item);
        //        else
        //        {
        //            item.Item.Hasta = DateTime.Now;
        //            lvCocherasAsoc.Update();
        //        }
               
        //    }

        //}
        void FrmAMBServMensual_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarCocheras();
        }

        private void CargarCocheras()
        {
            this.lvCocherasAsoc.Items.Clear();

            foreach (Proxy_LineaAsocCocheraMensual c in _lstCocheraAsignadas)
                if (c.Cochera != null)
                    this.lvCocherasAsoc.Items.Add(new LVItemLineaAsocCochera(c));
            
        }

        #endregion


        #region -- Metodos y evento para la pantalla de Edición de Vehículos --
        /// <summary>
        /// Metodo de evento para la pantalla de Edición de Vehículos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmABMVehiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                Vehiculo vehiculo = ((FrmAutoAbrev)sender).GetVehiculo();
                if( !_lstVehiculosAsignados.Contains(vehiculo))
                    _lstVehiculosAsignados.Add(vehiculo);
                CargarVehiculos();
            }
        }
        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = _expM.NuevoVehiculo();
            FrmAutoAbrev f = new FrmAutoAbrev(FormBorderStyle.None, Color.White, vehiculo, false);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmABMVehiculo_FormClosed);
        }
        private void btnModificarAuto_Click(object sender, EventArgs e)
        {

            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo != null)
            {
                FrmAutoAbrev f = new FrmAutoAbrev(FormBorderStyle.None, Color.White, vehiculo, false);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmABMVehiculo_FormClosed);
            }

        }
        private void btnBajaAuto_Click(object sender, EventArgs e)
        {

            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();

            if (vehiculo != null)
            {
                if (vehiculo.Baja.HasValue)
                {
                    MessageBox.Show("Va a 'Activar' al vehículo " + vehiculo.Nombre
                        + " - " + vehiculo.Marca + "\n¿Desea continuar?", "Baja de vehículos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2, new EventHandler(Baja_Vehiculo));
                }
                else
                {
                    MessageBox.Show("Va a 'Dar de baja' al vehículo " + vehiculo.Nombre
                        + " - " + vehiculo.Marca + "\n¿Desea continuar?", "Baja de vehículos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2, new EventHandler(Baja_Vehiculo));
                }
            }
        }

        private void Baja_Vehiculo(object sender, EventArgs e)
        {
            var rdo = ((Form)sender).DialogResult;

            if (rdo == DialogResult.Yes)
            {
                Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
                if (vehiculo != null)
                {
                    if (vehiculo.Baja.HasValue)
                        vehiculo.Baja = null;
                    else
                        vehiculo.Baja = DateTime.Now;

                    CargarVehiculos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vehículo para continuar.", "Edición de vehículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ActualizarAccion()
        {
            Vehiculo vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMensuales));
                if (vehiculo.Baja.HasValue)
                {
                    this.btnBajaAuto.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBajaAuto_Activo.Image"));
                    this.btnBajaAuto.TextAlign = ContentAlignment.MiddleCenter;
                    this.btnBajaAuto.Text = "Activar";
                }
                else
                {
                    this.btnBajaAuto.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnBajaAuto.Image"));
                    this.btnBajaAuto.TextAlign = ContentAlignment.MiddleRight;
                    this.btnBajaAuto.Text = "Dar de baja";

                }
            }
        }
        #endregion


        #region -- Eventos de Guardado y cancelacion --

        protected override void ClickOk(object sender, EventArgs e)
        {
            
            try
            {
                if (_mensual.Cliente.Id == 0)
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                    {
                        var cliente = _mensual.Cliente.Id != 0 ? exp.ObtenerCliente(_mensual.Cliente.Id) : _mensual.Cliente;
                        this.ucCliente.Cargar<Cliente>(cliente);

                        exp.NuevoMensual(cliente, this._lstCocheraAsignadas, _lstVehiculosAsignados);
                        this.MensajeUsuario = "Se han guardado correctamente los datos del cliente '" + _mensual.Cliente.NombreCompleto + "'.";
                        base.ClickOk(sender, e);
                    }
                }
                else
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                    {

                        this.ucCliente.Cargar<Cliente>(_mensual.Cliente);

                        exp.ModificarMensual(_mensual, _mensual.Cliente, this._lstCocheraAsignadas, _lstVehiculosAsignados);
                        this.MensajeUsuario = "Se han editado y guardado correctamente los datos del cliente '" + _mensual.Cliente.NombreCompleto + "'.";
                        base.ClickOk(sender, e);
                    }
                }
            }
            catch (ValidacionException ioe)
            {
                MessageBox.Show("No se pudieron guardar los datos.\n" + ioe.MessageComplete, "Guardando datos de Mensuales", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar.\n\nDetalle:\n" + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Inst.Error("Error al guardar: " + ex.Message + "\n\n" + ex.InnerException);
            }
        }

        //private void tbbGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_mensual.Cliente.Id == 0)
        //        {
        //            using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
        //            {
        //                var cliente = _mensual.Cliente.Id != 0 ? exp.ObtenerCliente(_mensual.Cliente.Id) : _mensual.Cliente;
        //                this.ucCliente.Cargar<Cliente>(cliente);

        //                exp.NuevoMensual(cliente, this._lstCocheraAsignadas, _lstVehiculosAsignados);
        //                this.MensajeUsuario = "Se han guardado correctamente los datos del cliente '" + _mensual.Cliente.NombreCompleto + "'.";
        //                OnGuardar_Click(e);
        //            }
        //        }
        //        else
        //        {
        //            using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
        //            {

        //                this.ucCliente.Cargar<Cliente>(_mensual.Cliente);

        //                exp.ModificarMensual(_mensual, _mensual.Cliente, this._lstCocheraAsignadas, _lstVehiculosAsignados);
        //                this.MensajeUsuario = "Se han editado y guardado correctamente los datos del cliente '" + _mensual.Cliente.NombreCompleto + "'.";
        //                OnGuardar_Click(e);
        //            }
        //        }
        //    }
        //    catch (ValidacionException ioe)
        //    {
        //        MessageBox.Show("No se pudieron guardar los datos.\n" + ioe.MessageComplete, "Guardando datos de Mensuales", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al guardar el cliente mensual.", ex);
        //    }

        //}

        private void tbbCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeUsuario = "Se canceló el alta de un cliente Mensual";
            OnCancelar_Click(e);
        }
        #endregion

        
        
        protected override void MessageHayCambiosHandler(object sender, EventArgs e)
        {
            DialogResult dr = ((Gizmox.WebGUI.Forms.Form)sender).DialogResult;

            switch (dr)
            {
                case DialogResult.No:
                    this.tbbCancelar_Click(this, new EventArgs());
                    break;
                case DialogResult.Yes:
                    this.GuardarUC();
                    break;
                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Retry:
                default:
                    break;
            }


        }
        private void lvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarAccion();
        }
        #endregion

        

        

    }

    #region Clases especiales para controles gráficos 
    /// <summary>
    /// Clase de items personalizados para listar las cocheras.
    /// </summary>
    class LVItemCochera : ListViewItem
    {
        public Cochera Item { get; set; }
        public LVItemCochera(Cochera c)
            :base(new string[]{c.NroCochera, c.Descripcion} )
        {
            Item = c;
            Tag = c;
            this.BackColor = Item.Baja != null ? Color.SlateGray : Color.White;
        }
    
    }

    class LVItemLineaAsocCochera : ListViewItem
    {
        public Proxy_LineaAsocCocheraMensual Item { get; set; }

        public LVItemLineaAsocCochera(Proxy_LineaAsocCocheraMensual linea)
            : base(new string[] { linea.Cochera.NroCochera
                                , linea.CptoIngresoMensual.Nombre
                                , linea.Desde.HasValue ? linea.Desde.Value.ToShortDateString() : string.Empty
                                , linea.Hasta.HasValue ? linea.Hasta.Value.ToShortDateString() : string.Empty 
                                }
                  )
        {
            Item = linea;
            Tag = linea;
            this.BackColor = Item.Baja ? Color.SlateGray : Color.White;

        }
    }

    class LVItemVehiculo : ListViewItem
    {
        public Vehiculo Item { get; set; }
        public LVItemVehiculo(Vehiculo c)
            : base(new string[] { c.Nombre, c.Marca, c.Modelo})
        {
            
            Item = c;
            Tag = c;
            this.BackColor = Item.Baja != null ? Color.SlateGray : Color.White;
        }


    }
#endregion
}