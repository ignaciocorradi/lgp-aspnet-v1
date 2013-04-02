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

#endregion

namespace AppGest.Vista
{
    public partial class FrmEdicionMensuales : FrmBase
    {
        public FrmEdicionMensuales()
        {
            InitializeComponent();
            this.Width= 1020; 
            this.Height = 517;

    
        }

        public FrmEdicionMensuales(FormBorderStyle formBorderStyle, Color color, Negocio.Modelo.Proxy_Mensuales mensual)
            :this()
        {
            this.FormBorderStyle = formBorderStyle;
            this.BackColor = color;
            this.ucMensuales1.Cancelar_Click += new Controles.Click_EventHandler(Cancelar_Click);
            this.ucMensuales1.Guardar_Click += new Controles.Click_EventHandler(Guardar_Click); 
            this.ucMensuales1.Modificar(mensual);
        }

        void Guardar_Click(object sender, EventArgs e)
        {
            
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.CerrarForm();
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            // si se cancela, solo se cierra el formulario para
            if (this.ucMensuales1.HayCambios())
            {
                //TODO: Revisar si aplica.
                MessageBox.Show("Ha realizado cambios en los datos.\n¿Desea Guardar estos cambios?.", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3, new EventHandler(Guardar_Cerrar_Cancelar));
            }
            else
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
                Guardar_Cerrar_Cancelar(this, e);
            }
        }

        private void Guardar_Cerrar_Cancelar(object sender, EventArgs e)
        {
            // Guarda los cambios
            this.DialogResult = ((Gizmox.WebGUI.Forms.Form)sender).DialogResult;
            switch (((Gizmox.WebGUI.Forms.Form)sender).DialogResult)
            {
                case DialogResult.No:
                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.ucMensuales1.GuardarUC();
                    break;
                case DialogResult.Cancel:
                // No hace nada
                case DialogResult.Abort:
                case DialogResult.Ignore:
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Retry:
                default:
                    break;
            }

        }


        private void CerrarForm()
        {
            this.ucMensuales1.Dispose();
            this.Close();
        }
    }
}