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
    public partial class ucEdicionCochera : UcEdicionBase
    {
        public ucEdicionCochera()
        {
            InitializeComponent();
            this.EstablecerTitulo("Editar cochera");
        }


        #region -- Metodos --
        public override void Listar()
        {
            this.CargarDatos("-1");
        }

        protected void Editar(Cochera cochera)
        {
            if (cochera != null)
            {
                var f = new FrmCochera(FormBorderStyle.None, Color.White, cochera);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frmEditarClose_FormClosed);
            }
        }   

        protected override void CrearColumnasDatos(List<ParametrosColumna>  columnas)
        {

            var pCol = new ParametrosColumna("NroCochera", "Nro. Cochera", true, 0, 120, true, false, 
                DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, null, null, true);
            columnas.Add(pCol);

            pCol = new ParametrosColumna("Descripcion", "Descripcion", true, 1, 350, true, false,
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
            pcAccion.Posicion = 3;
            pcAccion.Ancho = BotonBaja.Ancho + BotonEditar.Ancho;

            columnas.Add(pcAccion);


        }
        private void CargarDatos(string cochera = null, string desc = null, bool? activos = null)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpCocheras>(IdSesion))
            {
                this.MensajeUsuario = "Buscando...";
                var datos = exp.ListaTodos(cochera, desc , activos);
                ucGrilla1.DataSource = (IList)datos;
                if (datos.Count == 0)
                    this.MensajeUsuario = "No se encontraron datos.";
                else
                    this.MensajeUsuario = (datos.Count==1? "Se encontró " : "Se encontraron ")
                                            + datos.Count.ToString() 
                                            + (datos.Count == 1 ? " registro." : " registros.");
            }
        }

        private void BajaEntidad(Cochera cochera)
        {
            string msg = "";
            if (cochera.Baja.HasValue)
            {
                // Si esta dado de baja, se puede volver a activar.
                msg = "Va a 'Activar' la cochera '{0}'. ¿Desea continuar?";
            }
            else
            {
                // Si no esta dado de baja, lo bajonea.
                msg = "Va a 'dar de baja' la cochera '{0}'. ¿Desea continuar?";
            }
            msg = string.Format(msg, cochera.Nombre);

            MessageBox.Show(msg, "Baja / Activar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2,
                            new EventHandler(delegate(object sender, EventArgs e) { ActivarBaja(sender, cochera); }));


        }
        private void ActivarBaja(object sender, Cochera cochera)
        {
            var enEdicion = cochera;
            var rdo = ((Form)sender).DialogResult;
            if (rdo == DialogResult.Yes)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpCocheras>(IdSesion))
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

        #endregion 

        #region -- Eventos --
        protected override void ucGrilla1_ClickAccion(object sender, AccionEventArgs e)
        {

            switch (e.Accion)
            {
                case "Editar":
                    Editar(this.ucGrilla1.DataSource[e.RowIndex] as Cochera);
                    break;

                case "Baja":
                    BajaEntidad(this.ucGrilla1.DataSource[e.RowIndex] as Cochera);
                    break;

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool? activos = null;
            if (this.rbtnActivos.Checked)
                activos = true;
            else if (this.rbtnDadosDeBaja.Checked)
                activos = false;

            this.CargarDatos(this.txtNombre.Text.Trim(), this.txtDescripcion.Text.Trim(), activos);
            
        }
        #endregion


    }
}