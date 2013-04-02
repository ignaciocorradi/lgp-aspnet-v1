#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using AppGest.Negocio.Modelo;
using System.Collections;
using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucEdicionVehiculo : UcEdicionBase
    {
        #region -- Contructores --
        public ucEdicionVehiculo()
        {
            InitializeComponent();
            this.EstablecerTitulo("Editar vehículo");
        }
        #endregion
        
        #region -- Metodos --


        public override void Listar()
        {

            this.CargarDatos("|||");
            ucGrilla1.ParametrosGrilla = ConfiguracionGrilla;

        }
        private void EditarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo != null)
            {
                FrmAutoAbrev f = new FrmAutoAbrev(FormBorderStyle.None, Color.White, vehiculo, true);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarClienteClose_FormClosed);
            }

        }
        private void BajaEntidad(Vehiculo vehiculo)
        {
            string msg = "";
            if (vehiculo.Baja.HasValue)
            {
                // Si esta dado de baja, se puede volver a activar.
                msg = "Va a 'Activar' el vehículo '{0}'. ¿Desea continuar?";
            }
            else
            {
                // Si no esta dado de baja, lo bajonea.
                msg = "Va a 'dar de baja' el vehículo '{0}'. ¿Desea continuar?";
            }
            msg = string.Format(msg, vehiculo.Nombre);

            MessageBox.Show(msg, "Baja / Activar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2,
                            new EventHandler(delegate(object sender, EventArgs e) { ActivarBaja(sender, vehiculo); }));


        }
        private void ActivarBaja(object sender, Vehiculo vehiculo)
        {
            var enEdicion = vehiculo;
            var rdo = ((Form)sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(IdSesion))
                {
                    var c = exp.ObtenerPorId(enEdicion.Id);

                    if (c.Baja.HasValue)
                        c.Baja = null;
                    else
                        c.Baja = DateTime.Now;

                    exp.Guardar(c);
                }
                this.CargarDatos();
            }

        }

        protected override void CrearColumnasDatos(List<ParametrosColumna> columnas)
        {


            var pCol = new ParametrosColumna("Nombre", "Dominio", true, 0, 100, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);

            columnas.Add(pCol);

            pCol = new ParametrosColumna("Marca", "Marca", true, 1, 300, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna("Modelo", "Modelo", true, 2, 350, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna("Observaciones", "Observaciones", true, 2, 100, true, false,
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);



        }
        protected override void CrearColumnasAccion(List<ParametrosColumna> columnas)
        {

            ParametrosColumnaAccion pcAccion = new ParametrosColumnaAccion("Acciones", "Acciones");
            pcAccion.AccionesColumna.Add(new AccionColumna("Editar", "Editar", "Editar el registro actual", TipoControlAccion.BotonEditar));
            pcAccion.AccionesColumna.Add(new AccionColumna("Baja", "Baja / Activar", "Dar de baja el registro actual", TipoControlAccion.BotonBaja));
            pcAccion.AlineacionEncabezado = DataGridViewContentAlignment.MiddleCenter;
            pcAccion.Redimensionable = false;
            pcAccion.Posicion = 5;
            pcAccion.Ancho = BotonBaja.Ancho + BotonEditar.Ancho;

            columnas.Add(pcAccion);

        }

        private void CargarDatos(string dominio = null, string marca = null, bool? activos = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(IdSesion))
            {
                this.MensajeUsuario = "Buscando...";
                var datos = exp.ListaTodos(dominio, marca, activos);
                ucGrilla1.DataSource = (IList)datos;
                if (datos.Count == 0)
                    this.MensajeUsuario = "No se encontraron datos.";
                else
                    this.MensajeUsuario = (datos.Count == 1 ? "Se encontró " : "Se encontraron ")
                                            + datos.Count.ToString()
                                            + (datos.Count == 1 ? " registro." : " registros.");
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


        #endregion

        #region -- Eventos --
        protected override void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    EditarVehiculo(this.ucGrilla1.DataSource[e.RowIndex] as Vehiculo);
                    break;

                case "Baja":
                    BajaEntidad(this.ucGrilla1.DataSource[e.RowIndex] as Vehiculo);
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
            bool? activos = null;
            if (this.rbtnActivos.Checked)
                activos = true;
            else if (this.rbtnDadosDeBaja.Checked)
                activos = false;

            this.CargarDatos(this.txtDominio.Text.Trim(), this.txtMarca.Text.Trim(), activos);
        }
        #endregion

    }
}