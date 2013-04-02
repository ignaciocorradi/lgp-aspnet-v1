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
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Vista.Controles;
using AppGest.Util;
#endregion

namespace AppGest.Vista
{
    public partial class FrmAMBServMensual : FrmBase
    {

        public Proxy_LineaAsocCocheraMensual LineaAsociada { get { return this.ucABMServMens.LineaAsociada; } }

        #region -- Constructores --
        public FrmAMBServMensual()
        {
            InitializeComponent();
            this.Width = 415;
            this.Height = 386;
        }

        public FrmAMBServMensual(FormBorderStyle estiloBorde, Color fondo, Proxy_LineaAsocCocheraMensual lineaNueva
            , List<Proxy_LineaAsocCocheraMensual> cocherasAsignadas, List<Cochera> cocherasDisponibles)
            :this()
        {
            this.ucABMServMens.LlenarControles(lineaNueva, cocherasDisponibles, cocherasAsignadas);
            InicializarPantalla(estiloBorde, fondo);
        }

        #endregion

        #region -- Metodos --
        private void InicializarPantalla(Gizmox.WebGUI.Forms.FormBorderStyle estiloBorde, Color fondo)
        {
            this.FormBorderStyle = estiloBorde;
            this.ucABMServMens.BackColor = fondo;
            this.ucABMServMens.HabilitarMenu(true, true, true);
            this.ucABMServMens.Cancelar_Click += new Controles.Click_EventHandler(ucABMServMens_Cancelar_Click);
            this.ucABMServMens.Guardar_Click += new Controles.Click_EventHandler(ucABMServMens_Guardar_Click);
        }

        
        private void CerrarForm()
        {
            this.ucABMServMens.Dispose();
            this.Close();
        }
        #endregion

        #region -- Eventos --
        void ucABMServMens_Guardar_Click(object sender, EventArgs e)
        {
            // Al Aceptar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.CerrarForm();         
        }
        void ucABMServMens_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.CerrarForm();
        }
        private void Guardar_Cerrar_Cancelar(object sender, EventArgs e)
        {
            // Guarda los cambios
            this.DialogResult = ((Gizmox.WebGUI.Forms.Form)sender).DialogResult;
            switch (this.DialogResult)
            {
                case DialogResult.No:
                    this.CerrarForm();
                    break;
                case DialogResult.Yes:
                    this.ucABMServMens_Guardar_Click(sender, e);
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
        
        #endregion
        
        
    }
}