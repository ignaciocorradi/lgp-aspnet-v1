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
    [Administrador]
    [Supervisor]
    public partial class UcEdicionFactura : UcToolbar
    {
        public UcEdicionFactura()
        {
            InitializeComponent();
        }
    }
}