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
using AppGest.Negocio;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucCocheras : ucDatosEntidad
    {
        public ucCocheras()
        {
            InitializeComponent();
            this.txtDesc.Focus();
        }

        /// <summary>
        /// Guarda los cambios realizados en la cochera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {

                using (var exp = FabExpertos.Inst.Obtener<ExpCocheras>(IdSesion))
                {
                    var c = EntidadActualSegunAccion<ExpCocheras, Cochera>(exp);
                
                    this.Cargar<Cochera>(c);
                    exp.Guardar(c);
                    base.ClickOk(sender, e);
                }
            }
            catch (InvalidOperationException io)
            {
                MessageBox.Show("No es posible guardar los datos, revise los siguientes datos: \n\n\t " + io.Message,
                  "Guardar cambios", MessageBoxButtons.OK,
                  MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar una nueva cochera.", ex);
            }
            
        }

    }
}