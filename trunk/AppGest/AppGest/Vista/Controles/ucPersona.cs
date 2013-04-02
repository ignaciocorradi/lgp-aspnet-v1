#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Negocio.Modelo;

using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;

#endregion

namespace AppGest.Vista.Controles
{
    public partial class ucPersona : ucDatosEntidad
    {
        public ucPersona()
        {
            InitializeComponent();

            if (RunTime)
                CrearValidaciones();
        }

        #region -- Metodos --
        /// <summary>
        /// Validaciones de los controles visuales.
        /// </summary>
        private void CrearValidaciones()
        {
            TextBoxValidation valInt = new TextBoxValidation(TextBoxValidation.IntegerValidator.ValueValidationExpression
                                            , "Debe ingresar un valor numérico"
                                            , TextBoxValidation.IntegerValidator.CharacterValidationMask);


            this.txtTel.Validator = valInt;
            this.txtMovil.Validator = valInt;
            this.txtTel2.Validator = valInt;
            this.txtDni.Validator = valInt;
            this.txtMail.Validator = new TextBoxValidation(TextBoxValidation.EmailValidator.ValueValidationExpression
                                                           , "Ingrese una dirección de correo electrónico válida."
                                                           , TextBoxValidation.EmailValidator.CharacterValidationMask);
            
        }


        public override void Cargar<TEntidad>(TEntidad ent)
        {
            base.Cargar<TEntidad>(ent);
            var entidad = ent as Persona;

            entidad.Apellido = this.txtApellido.Text;
            entidad.Dni = Convert.ToInt32(this.txtDni.Text);
            entidad.Nombre2 = this.txtNombre2.Text;
            entidad.Contacto.Domicilio = this.txtDomicilio.Text;
            entidad.Contacto.Movil = this.txtMovil.Text;
            entidad.Contacto.Telefono = this.txtTel.Text;
            entidad.Contacto.TelefonoTrabajo = this.txtTel2.Text;
            entidad.Contacto.Email = this.txtMail.Text;
            

            if (String.IsNullOrWhiteSpace(entidad.Abreviatura))
            {
                List<string> cadenas = entidad.Nombre.Split().ToList<string>();
                cadenas.AddRange(entidad.Nombre2.Split().ToList<string>());
                cadenas.AddRange(entidad.Apellido.Split().ToList<string>());
                entidad.Abreviatura = Helper.ObtenerIniciales(cadenas);
            }

        }

        public override void LLenarControles<TEntidad>(TEntidad ent)
        {
            base.LLenarControles<TEntidad>(ent);
            var entidad = ent as Persona;

            this.txtNombre2.Text = entidad.Nombre2;
            this.txtApellido.Text = entidad.Apellido;
            this.txtDni.Text = entidad.Dni.ToString();
            this.txtDomicilio.Text = entidad.Contacto.Domicilio;
            this.txtMovil.Text = entidad.Contacto.Movil == null ? string.Empty : entidad.Contacto.Movil;
            this.txtTel.Text = entidad.Contacto.Telefono == null ? string.Empty : entidad.Contacto.Telefono;
            this.txtTel2.Text = entidad.Contacto.TelefonoTrabajo == null ? string.Empty : entidad.Contacto.TelefonoTrabajo;
            this.txtMail.Text = entidad.Contacto.Email;


        }

        public override bool HayCambios()
        {
            var entidad = _entidadOld as Persona;

            var cambios = base.HayCambios();
            return cambios ||
                (
                    entidad.Nombre2 != this.txtNombre2.Text
                || entidad.Apellido != this.txtApellido.Text
                || entidad.Dni.ToString() != this.txtDni.Text
                || entidad.Contacto.Domicilio != this.txtDomicilio.Text
                || entidad.Contacto.Movil != this.txtMovil.Text
                || entidad.Contacto.Telefono != this.txtTel.Text
                || entidad.Contacto.TelefonoTrabajo != this.txtTel2.Text
                || entidad.Contacto.Email != this.txtMail.Text
                );
        }
        #endregion
    }
}