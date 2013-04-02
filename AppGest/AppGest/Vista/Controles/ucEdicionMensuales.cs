#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucEdicionMensuales : UcEdicionBase
    {
        public ucEdicionMensuales()
        {
            InitializeComponent();
            this.EstablecerTitulo("Editar clientes mensuales");
        }

        #region -- Metodos --
        public override void Listar()
        {
            CargarDatos(-2);
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;
        }

        private void CargarDatos(int? nroCliente = null, string nombre = null, string dominio = null, string cochera = null,  bool? activos = null)
        {
            var rowIndex = ucGrilla1.FilaActual != null ? ucGrilla1.FilaActual.Index : -1;

            using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
            {
                if (lblMensajes.Text.Length == 0) lblMensajes.Text = exp.InfoMensualesRegistrados();

                this.MensajeUsuario = "Buscando...";
                var datos = exp.ObtenerMensuales(nroCliente, nombre, dominio,cochera, activos);
                ucGrilla1.DataSource = datos;
                if (datos.Count == 0)
                    this.MensajeUsuario = "No se encontraron datos.";
                else
                    this.MensajeUsuario = (datos.Count == 1 ? "Se encontró " : "Se encontraron ")
                                            + datos.Count.ToString()
                                            + (datos.Count == 1 ? " registro." : " registros.");
            }

            ucGrilla1.SeleccionarFila(rowIndex);
        }

        private void EditarCliente(Proxy_Mensuales proxy)
        {
            if (proxy.BajaCliente)
            {
                MessageBox.Show("El Cliente que quiere editar esta dado de baja.\nActívelo y luego edite los datos nuevamente.", "Editar cliente mensual", MessageBoxButtons.OK);
            }
            else
            {
                if (proxy != null)
                {
                    FrmEdicionMensuales f = new FrmEdicionMensuales(FormBorderStyle.None, Color.White, proxy);
                    f.ShowDialog();
                    f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarClienteClose_FormClosed);
                }
            }
        }

        private void IntentarActivarBaja(Proxy_Mensuales proxy)
        {
            string msg = "";
            string accion = "";
            string titulo = "";
            bool mostrarFecha = true;
            if (proxy.Cliente.Baja.HasValue)
            {// Si esta dado de baja, se puede volver a activar.
                accion = "'Activar'";
                titulo = "Activar cliente mensual";
                mostrarFecha = false;
            }
            else
            { // Si no esta dado de baja, lo bajonea.
                accion = "'dar de Baja'";
                titulo = "Baja cliente mensual";
            }
            msg = "Va a {3} el cliente '{0}'.\n\t- Cocheras: {1}\n\t- Vehículos: {2}";
            msg = string.Format(msg, proxy.NombreCliente.ToUpper(), proxy.NombreCocheras, proxy.NombreVehiculos, accion);

            FrmBaja f = new FrmBaja(DateTime.Now, mostrarFecha, titulo, msg, proxy);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmBaja_FormClosed);  

        }

        void FrmBaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmBaja f = sender as FrmBaja;
            DialogResult r = f.DialogResult;
            Proxy_Mensuales proxy = f.Tag as Proxy_Mensuales;
            DateTime fechaAccion = f.FechaAccion.HasValue ? f.FechaAccion.Value : DateTime.Now;

            if (r == DialogResult.OK && proxy != null)
            {
                try
                {
                    using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                    {
                        if (proxy.Cliente.Baja.HasValue)
                            exp.ActivarClienteMensual(proxy);
                        else
                            exp.DarDeBajaMensual(proxy, fechaAccion);
                    }
                    this.btnBuscar_Click(this, new EventArgs());
                }
                catch (ValidacionException ve)
                {
                    MessageBox.Show("No se puede realizar la acción, verifique lo siguiente:\n" + ve.MessageComplete
                        , "Baja de cliente mensual"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede realizar la acción, comuniquese con el administrador del sistema."
                        , "Baja de cliente mensual"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Logger.Inst.Error("Error al dar de baja el cliente mensual", ex);


                }
            }
        }
        //private void IntentarActivarBaja1(Proxy_Mensuales proxy)
        //{
        //    string msg = "";
        //    string accion = "";
        //    if (proxy.Cliente.Baja.HasValue)
        //        // Si esta dado de baja, se puede volver a activar.
        //        accion = "'Activar'";
        //    else
        //        // Si no esta dado de baja, lo bajonea.
        //        accion = "'dar de Baja'";

        //    msg = "Va a {3} el cliente '{0}'.\n\t- Cocheras: {1}\n\t- Vehículos: {2}\n\n ¿Desea continuar?";
        //    msg = string.Format(msg, proxy.NombreCliente, proxy.NombreCocheras, proxy.NombreVehiculos, accion);

        //    MessageBox.Show(msg, "Modificar Cliente mensual",
        //                    MessageBoxButtons.YesNo,
        //                    MessageBoxIcon.Question,
        //                    MessageBoxDefaultButton.Button2,
        //                    new EventHandler(delegate(object sender, EventArgs e) { BajaCliente(sender, proxy); }));

        //}
        //private void BajaCliente_OLD(object sender, Proxy_Mensuales proxy)
        //{
          
        //    var rdo = ((Form)sender).DialogResult;
        //    if (rdo == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
        //            {
        //                if(proxy.Cliente.Baja.HasValue)
        //                    exp.ActivarClienteMensual(proxy);
        //                else
        //                    exp.DarDeBajaMensual(proxy);
        //            }
        //        }
        //        catch (ValidacionException ve)
        //        {
        //            MessageBox.Show("No se puede realizar la acción, verifique lo siguiente:\n" + ve.MessageComplete
        //                , "Baja de cliente mensual"
        //                , MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("No se puede realizar la acción, comuniquese con el administrador del sistema." 
        //                , "Baja de cliente mensual"
        //                , MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            Logger.Inst.Error("Error al dar de baja el cliente mensual", ex);

                   
        //        }

        //    }
        //}


        protected override void CrearColumnasDatos(List<ParametrosColumna> columnas)
        {
            var pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NroCliente, "Nro Cliente", true, 0, 80, true, false,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreCliente, "Clientes", true, 1, 170, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreVehiculos, "Vehículos asociados", true, 2, 350, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_NombreCocheras, "Cocheras asociadas", true, 3, 500, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna(Proxy_Mensuales.PROP_Baja, "Baja", true, 4, 60, true, false,
                DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);
        }

        protected override void CrearColumnasAccion(List<ParametrosColumna> columnas)
        {

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Baja", "Baja / Activar", "Dar de baja el cliente.", TipoControlAccion.BotonBaja));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 5;
            pcAccion.Ancho = BotonEditar.Ancho + BotonBaja.Ancho;

            columnas.Add(pcAccion);
            



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
        #endregion

        #region -- eventos --
        protected override void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    EditarCliente(this.ucGrilla1.DataSource[e.RowIndex] as Proxy_Mensuales);
                    break;

                case "Baja": 
                    // La baja de un mensual tiene que:
                    // Dar de baja el cliente, los vehículos (no las asociaciones) y las asociaciones con las cocheras

                    IntentarActivarBaja(this.ucGrilla1.DataSource[e.RowIndex] as Proxy_Mensuales);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int? nro = this.txtNroCliente.Text.Trim() == string.Empty ? (int?)null : Convert.ToInt32(this.txtNroCliente.Text.Trim());

            bool? activos = null;
            if (this.rbtnActivos.Checked)
            {
                activos = true;
            }
            else if (this.rbtnDadosDeBaja.Checked)
            {
                activos = false;
            }

            this.CargarDatos(nro, txtNombre.Text, txtVehiculo.Text, txtCochera.Text, activos );
        }        
        #endregion 
    }
}