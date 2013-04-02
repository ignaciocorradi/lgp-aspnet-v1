#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace AppGest.ControlBase
{
    public partial class ucStatusBar : UserControl
    {
        public ucStatusBar()
        {
            InitializeComponent();
            this.lblEstado.AutoSize = false;
            this.lblInfo.AutoSize = false;
            //this.btnSalir.ImageAlign = ContentAlignment.MiddleCenter;

        }
        public string MensajeEstado { get { return this.lblEstado.Text; } set { this.lblEstado.Text = value; } }
        public string MensajeInfo { get { return this.lblInfo.Text; } set { this.lblInfo.Text = value; } }


    }
}