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
    public partial class UcEmpleadoAbrev : ucEmpleado
    {
        
        public UcEmpleadoAbrev()
        {
            InitializeComponent();
            this.MostrarBarra = false;
            this.MostrarCabecera = false;

        }

    }
}