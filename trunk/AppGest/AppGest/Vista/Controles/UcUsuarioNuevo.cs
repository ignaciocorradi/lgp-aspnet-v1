#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Modelo;
using AppGest.Negocio.Core;

#endregion

namespace AppGest.Vista.Controles
{
    public partial class UcUsuarioNuevo : ucPersona
    {
        public UcUsuarioNuevo()
        {
            InitializeComponent();
            cmbTipo.DataSource = Enumeraciones.ListarEnumeracion<TipoUsuario, byte>();
            cmbTipo.DisplayMember = "Value";
            cmbTipo.ValueMember = "Key";
            cmbTipo.SelectedIndex = 0;
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {

                using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
                {
                    var entidad = EntidadActualSegunAccion<ExpEmpleado, Empleado>(exp);
                    this.Cargar<Empleado>(entidad);
                    exp.Guardar(entidad);
                    MensajeUsuario = "Se agregó correctamnte a: '" + entidad.NombreCompleto + "'";
                    base.ClickOk(sender, e);
                }
            }
            catch (ValidacionException ve)
            {
                MessageBox.Show("No se puede crear el nuevo usuario, revise los siguientes datos: " + ve.MessageComplete
                    , "Nuevo usuario"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
 
            }
            catch (Exception ex)
            {
                MensajeUsuario = "Error al guardar los datos nuevos.";
                throw new Exception(MensajeUsuario, ex);
            }
            
        }
        protected override TEntidad EntidadActualSegunAccion<TExpEntidad, TEntidad>(TExpEntidad expEmpleado)
        {
            var experto = expEmpleado as ExpEmpleado;
            if (_entidadOld.Id == 0)
                return experto.Nuevo(true) as TEntidad;
            else
                return experto.ObtenerPorId(_entidadOld.Id) as TEntidad;
        }
        /// <summary>
        /// Crea una nueva instancia y llena los controles graficos.
        /// </summary>
        /// <param name="exp"></param>
        public void Nuevo(ExpEmpleado exp)
        {
            var entidad = exp.Nuevo(true);
            this.LLenarControles<Persona>(entidad);
            this.Cargar<Empleado>(entidad);

            _entidadOld = entidad;
        }
        public override void LLenarControles<TEntidad>(TEntidad ent)
        
        {
            base.LLenarControles<TEntidad>(ent);
            var entidad = ent as Persona;

            this.txtUsuario.Text = entidad.Usuario == null ? string.Empty : entidad.Usuario.Nombre;
            this.txtClave.Text = entidad.Usuario == null ? string.Empty : entidad.Usuario.Clave;

        }

        public override void Cargar<TEntidad>(TEntidad ent)
        {
            base.Cargar<TEntidad>(ent);
            var entidad = ent as Persona;

            entidad.Usuario.Nombre = txtUsuario.Text;
            entidad.Usuario.Abreviatura = txtUsuario.Text;
            entidad.Usuario.Clave = txtClave.Text;
            entidad.Usuario.Tipo = (byte) Convert.ChangeType(cmbTipo.SelectedValue, typeof(byte));

        }
        public override bool HayCambios()
        {
            var entidad = _entidadOld as Persona;

            var cambios = base.HayCambios();
            return cambios ||
                (
                   entidad.Usuario.Nombre!= this.txtUsuario.Text
                || entidad.Usuario.Clave != this.txtClave.Text

                );
        }

    }
}