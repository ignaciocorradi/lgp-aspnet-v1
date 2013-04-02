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
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Modelo;
using AppGest.Negocio.Core;
#endregion

namespace AppGest.Vista
{
    public partial class FrmNuevoUsuario : FrmBase
    {
        public FrmNuevoUsuario():base()
        {
            InitializeComponent();
            Inicializar();

        }


        private void Inicializar()
        {
            UcUsuarioNuevo1.Nuevo(FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion));

            this.UcUsuarioNuevo1.Cancelar_Click += new Controles.Click_EventHandler(ucDatosUsuario1_Cancelar_Click);
            this.UcUsuarioNuevo1.Guardar_Click += new Controles.Click_EventHandler(ucDatosUsuario1_Guardar_Click);
        }

        void ucDatosUsuario1_Guardar_Click(object sender, EventArgs e)
        {

            this.Close();
            this.IrA("FrmInicio");

        }

        void ucDatosUsuario1_Cancelar_Click(object sender, EventArgs e)
        {
            this.ucDatosUsuario1_Guardar_Click(sender, e);
        }


    }
}