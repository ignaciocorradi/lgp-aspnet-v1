#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucVehiculoAbrev : ucVehiculo
    {
        
        public ucVehiculoAbrev()
        {
            InitializeComponent();
            // Especifico que este form no debe guardar, solo retornar la lista a guardar.
            DebeGuardar = false;
        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {
                base.ClickOk(sender, e);
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show("Revise los siguientes datos: \n" + ioe.Message
                        , "Datos incompletos"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error );

            }
        }
        private void pnlBase_Click(object sender, EventArgs e)
        {

        }
    }
}