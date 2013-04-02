#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using AppGest.Negocio;
using AppGest.Negocio.Modelo;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;

#endregion

namespace AppGest.Vista
{
    public partial class FrmEmpleado : FrmBase
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }
        private Empleado _entidad; 
        public FrmEmpleado(FormBorderStyle estiloBorde, Color fondo, Empleado entidad)
            :this()
        {

            _entidad = entidad;
            InicializarPantalla(estiloBorde, fondo);
            this.ucEmpleado1.Cargar<Empleado>(_entidad);
        }
        private void InicializarPantalla(FormBorderStyle estiloBorde, Color fondo)
        {
            this.FormBorderStyle = estiloBorde;
            this.ucEmpleado1.BackColor = fondo;
            this.ucEmpleado1.tbMenu.Visible = true;
            this.ucEmpleado1.tbMenu.Enabled = true;
            this.ucEmpleado1.LLenarControles<Empleado>(_entidad);
            this.ucEmpleado1.Cancelar_Click += new Controles.Click_EventHandler(uc_Cancelar_Click);
            this.ucEmpleado1.Guardar_Click += new Controles.Click_EventHandler(uc_Guardar_Click);
        }

        void uc_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.ucEmpleado1.Cargar<Empleado>(_entidad);
            this.CerrarForm();
        }
        private void CerrarForm()
        {
            this.ucEmpleado1.Dispose();
            this.Close();
        }
        void uc_Cancelar_Click(object sender, EventArgs e)
        {
            // si se cancela, solo se cierra el formulario para
            if (this.ucEmpleado1.HayCambios())
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


             using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
             {
                 var nuevoEmpleado = exp.Nuevo();
                 ucEmpleado1.Cargar<Empleado>(nuevoEmpleado);
                 try
                 {
                     exp.Guardar(nuevoEmpleado);
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
                     MessageBox.Show("Ocurrió un error al guardar el nuevo Empleado, intente de nuevo.\nEn caso de persistir el error dirigirse al Administrador del sistema.: \n\n\nError:" + ex.Message + "\n" + ex.InnerException
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