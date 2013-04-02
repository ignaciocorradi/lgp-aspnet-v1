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
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using AppGest.Vista.Controles;

#endregion

namespace AppGest.Vista
{
    public partial class FrmEdicionConceptos : FrmBase
    {
        private Concepto _concepto;
        private TipoServicio _tipoServicio;

        public FrmEdicionConceptos()
        {
            InitializeComponent();
        }

        public FrmEdicionConceptos(FormBorderStyle estiloBorde, Color fondo, Concepto concepto, TipoServicio tipoServicio)
            : this()
        {
            _concepto = concepto;
            _tipoServicio = tipoServicio;
            InicializarPantalla(estiloBorde, fondo);
            //this.ucConceptos1.Cargar<Concepto>(_concepto);
        }
        private void InicializarPantalla(FormBorderStyle estiloBorde, Color fondo)
        {
            this.FormBorderStyle = estiloBorde;
            this.ucConceptos1.BackColor = fondo;
            this.ucConceptos1.tbMenu.Visible = true;
            this.ucConceptos1.tbMenu.Enabled = true;
            this.ucConceptos1.CargarControles(_concepto, _tipoServicio);
            this.ucConceptos1.Cancelar_Click += new Controles.Click_EventHandler(uc_Cancelar_Click);
            this.ucConceptos1.Guardar_Click += new Controles.Click_EventHandler(uc_Guardar_Click);
        }

        void uc_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            //this.ucConceptos1.Cargar<Concepto>(_concepto);
            this.CerrarForm();
        }
        private void CerrarForm()
        {
            this.ucConceptos1.Dispose();
            this.Close();
        }
        void uc_Cancelar_Click(object sender, EventArgs e)
        {
            // si se cancela, solo se cierra el formulario para
            if (this.ucConceptos1.HayCambios())
            {
                MessageBox.Show("Ha realizado cambios, si continúa los perderá.\n¿Desea Guardar estos cambios?.", "¿Guardar cambios?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button3, new EventHandler(Guardar_Cerrar_Cancelar));
            }
            else
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
                Guardar_Cerrar_Cancelar(this, e);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {


            using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
            {
                var nuevoConcepto = exp.Nuevo();
                //ucConceptos1.Cargar<Concepto>(nuevoConcepto);
                try
                {
                    exp.Guardar(nuevoConcepto);
                    this.IrA("FrmPrincipal");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Los datos ingresados no son válidos. Verifique los datos.: \n\n\nRevisar:" + ex.Message + "\n" + ex.InnerException
                       , "Validación de datos"
                       , MessageBoxButtons.OK
                       , MessageBoxIcon.Exclamation);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el nuevo Concepto, intente de nuevo.\nEn caso de persistir el error dirigirse al Administrador del sistema.: \n\n\nError:" + ex.Message + "\n" + ex.InnerException
                        , "Error al guardar"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Stop);

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IrA("FrmPrincipal");
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
                    this.uc_Guardar_Click(sender, e);
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
    }
}