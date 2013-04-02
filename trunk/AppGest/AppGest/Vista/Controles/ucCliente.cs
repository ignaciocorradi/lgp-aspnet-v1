#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucCliente : ucPersona
    {
        public ucCliente()
        {
            InitializeComponent();
            CrearValidaciones();
        }

        private void CrearValidaciones()
        {
            TextBoxValidation valInt = new TextBoxValidation(TextBoxValidation.IntegerValidator.ValueValidationExpression
                                            , "Debe ingresar un valor numérico"
                                            , TextBoxValidation.IntegerValidator.CharacterValidationMask);


            this.txtNroCliente.Validator = valInt;

        }

        protected override void ClickOk(object sender, EventArgs e)
        {
            try
            {

                using (var exp = FabExpertos.Inst.Obtener<ExpClientes>(IdSesion))
                {
                    var entidad = EntidadActualSegunAccion<ExpClientes, Cliente>(exp);
                    this.Cargar<Cliente>(entidad);
                    exp.Guardar(entidad);
                    MensajeUsuario = "Se creó correctamente el cliente '" + entidad.NombreCompleto + "'";
                    base.ClickOk(sender, e);
                }
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show("Revise los siguientes datos:\n" + ioe.Message, "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }
            catch (Exception ex)
            {
                MensajeUsuario = "Error al guardar un nuevo cliente.";
                throw new Exception(MensajeUsuario, ex);
            }

        }

        public bool VerdatoVehiculo
        {
            get
            { return _verDatoVehiculo; }
            set
            {
                _verDatoVehiculo = value;
                Visualizar(value);
            }
        }bool _verDatoVehiculo = false;

        private void Visualizar(bool value)
        {
            this.lblDatoVe.Visible = value;
            this.txtDomVe.Visible = value;
          
        }

        public override void Cargar<TEntidad>(TEntidad ent)
        {
            base.Cargar<TEntidad>(ent);
            var entidad = ent as Cliente;
            entidad.NroCliente = Convert.ToInt32(this.txtNroCliente.Text);
            entidad.RazonSocial = txtRazonSocial.Text;
            entidad.DomicilioFiscal = txtDomicilioFiscal.Text;
            entidad.CUIT = txtCUIT.Text;


        }
        public override void LLenarControles<TEntidad>(TEntidad ent)
        {
            base.LLenarControles<TEntidad>(ent);
            var entidad = ent as Cliente;
            this.txtNroCliente.Text = entidad.NroCliente.ToString();
            txtRazonSocial.Text = entidad.RazonSocial;
            txtDomicilioFiscal.Text = entidad.DomicilioFiscal;
            txtCUIT.Text = entidad.CUIT;
        }
          
    }
}