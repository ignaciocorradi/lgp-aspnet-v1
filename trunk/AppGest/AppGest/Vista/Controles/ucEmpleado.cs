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
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucEmpleado : ucPersona
    {
        public ucEmpleado()
        {
            InitializeComponent();
        }
        public override void Cargar<TEntidad>(TEntidad ent)
        {
            base.Cargar<TEntidad>(ent);
            var entidad = ent as Persona;
            entidad.Alta = this.dtpFechaA.Value;

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
                    MensajeUsuario = "Se creó correctamente el empleado '" + entidad.NombreCompleto + "'";
                    base.ClickOk(sender, e);
                }
            }
            catch (Exception ex)
            {
                MensajeUsuario = "Error al guardar un nuevo empleado.";
                Logger.Inst.Error(ex.Message);
                throw new Exception(MensajeUsuario, ex);
            }

        }
    }
}