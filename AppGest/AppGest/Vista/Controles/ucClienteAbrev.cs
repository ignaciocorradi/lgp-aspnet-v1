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
    public partial class ucClienteAbrev : ucCliente
    {
        public ucClienteAbrev()
        {
            InitializeComponent();
            desHabilitarControles();
        }
        /// <summary>
        /// Deshabilita los controles que no son necesarios en la carga abreviada
        /// </summary>
        void desHabilitarControles()
        {
            // Datos del cliente
            txtAbreviatura.Enabled = false;
            txtAbreviatura.Visible = false;
            txtNombre2.Enabled = false;
            txtNombre2.Visible = false;
            txtNroCliente.Visible = false;
            
            // Datos de contacto
            txtMail.Enabled = false;
            txtMail.Visible = false;
            txtTel2.Enabled = false;
            txtTel2.Visible = false;
        }

        public DateTime? AltaCliente { get { return dtpFechaA.Value; } }
    }
}