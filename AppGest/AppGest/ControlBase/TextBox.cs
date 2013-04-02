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
    /// A TextBox control
    /// </summary>
    [Skin(typeof(TextBoxSkin))]
    [Serializable()]
    public class TextBox : Gizmox.WebGUI.Forms.TextBox
    {
        public TextBox():base()
        {
            //this.CustomStyle = "TextBoxSkin";
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BorderColor =  new  Gizmox.WebGUI.Forms.BorderColor(Color.SlateGray);
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTextOnGotFocus = true;
        }

        /// <summary>
        /// Obtiene o establece si se selecciona todo el texto al obtener el foco.
        /// </summary>
        public bool SelectTextOnGotFocus { get { return _sel; } set { _sel = value; } }
        bool _sel = true;

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.SelectTextOnGotFocus)
                this.SelectAll();
        }

    }

}
