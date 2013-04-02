/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace AppGest.ControlBase
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(ButtonSkin))]
    [Serializable()]
    public class Button : Gizmox.WebGUI.Forms.Button
    {
        public Button()
        {
            //this.CustomStyle = "ButtonSkin";
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Button
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CustomStyle = "F";
            this.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResumeLayout(false);

        }
    }

}
