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
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

#endregion

namespace AppGest.Vista.Controles
{
    public partial class ucDatosUsuario : ucDatosEntidad
    {
        public ucDatosUsuario()
        {
            InitializeComponent();
        }

        private void ucDatosUsuario_Load(object sender, EventArgs e)
        {

        }
        public void Nuevo(ExpUsuarios exp)
        {
 

        }
        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                
                using (var exp = FabExpertos.Inst.Obtener<ExpUsuarios>(IdSesion))
                {
                    Usuario u = exp.Nuevo();
                    
                    this.Cargar<Usuario>(u);
                    u.Nombre = this.txtNombre.Text;
                    u.Clave = this.txtClave.Text;

                    exp.Guardar(u);
                    base.ClickOk(sender, e);


                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar una nuevo Usuario.", ex);
                
            }

            
        }
    }
}