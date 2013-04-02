#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Modelo;
using AppGest.Negocio.Core;
using AppGest.Util;



#endregion

namespace AppGest.Vista.Controles
{


    public partial class ucDatosEntidad : UcToolbar
    {
        public ucDatosEntidad()
        {
            InitializeComponent();
            
        }
        protected Entidad _entidadOld;
        protected string _keyValues;

        #region  -- Susc Eventos ---

        #endregion 

        #region -- Metodos --
        /// <summary>
        /// Devuelve la entidad actual, según la acción en curso.
        /// </summary>
        /// <returns></returns>
        protected virtual TEntidad EntidadActualSegunAccion<TExpEntidad, TEntidad>(TExpEntidad experto)
            where TExpEntidad : ExpertoEntidad<TEntidad>
            where TEntidad: Entidad, new()
        {
            if (_entidadOld.Id == 0)
                return experto.Nuevo();
            else
                return experto.ObtenerPorId(_entidadOld.Id);
        }
        /// <summary>
        /// Crea una nueva instancia y llena los controles graficos.
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <param name="exp"></param>
        public void Nuevo<TEntidad>(ExpertoEntidad<TEntidad> exp)
            where TEntidad : Entidad, new()
        {
            var entidad = CrearNuevo<TEntidad>(exp);
            this.LLenarControles<TEntidad>(entidad);
            this.Cargar<TEntidad>(entidad);

            _entidadOld = entidad;
        }

        protected virtual TEntidad CrearNuevo<TEntidad>(ExpertoEntidad<TEntidad> exp) where TEntidad : Entidad, new()
        {
            var entidad = exp.Nuevo();
            return entidad;
        }        

        /// <summary>
        /// Carga la Entidad con los valores de los controles gráficos ingresados por el usuario.
        /// </summary>
        /// <typeparam name="TEntidad">Tipo de la entidad a cargar</typeparam>
        /// <param name="exp">Experto de ABM de entidades</param>
        /// <param name="entidad">entidad a cargar con los nuevos valores.</param>
        public virtual void Cargar<TEntidad>(TEntidad entidad)
               where  TEntidad: Entidad, new()
        {

            entidad.Nombre = this.txtNombre.Text;
            entidad.Abreviatura = this.txtAbreviatura.Text;
            entidad.Descripcion = this.txtDesc.Text;
            entidad.Observaciones = this.txtObservacion.Text;
            entidad.Alta = dtpFechaA.Value;
            

        }

        /// <summary>
        /// Llena los controles gráficos con los valores que tiene la entidad
        /// </summary>
        /// <typeparam name="TEntidad">Tipo de la entidad a utilizar</typeparam>
        /// <param name="entidad">Entidad desde la cual se obtiene los valores para cargar los controles gráficos</param>
        public virtual void LLenarControles<TEntidad>(TEntidad entidad)
            where TEntidad : Entidad, new()
        {
            _entidadOld = entidad;
            this.txtNombre.Text = entidad.Nombre ;
            this.txtAbreviatura.Text = entidad.Abreviatura;
            this.txtDesc.Text = entidad.Descripcion;
            this.txtObservacion.Text = entidad.Observaciones;
            

            this.dtpFechaA.Value = entidad.Alta;

            if (entidad.Baja.HasValue)
            {
                this.txtFechaB.Text = entidad.Baja.Value.ToString(FormatHelper.ShortDateFormatCurrentCulture);
                this.txtFechaB.Visible = true;
                this.lblFechaB.Visible = true;
            }
            else
            {
                this.txtFechaB.Visible = false;
                this.lblFechaB.Visible = false;
            }
                
        }

        public override bool HayCambios()
        {
            if (_entidadOld.Nombre == this.txtNombre.Text &&
                _entidadOld.Abreviatura == this.txtAbreviatura.Text)

                return false;
            else

                return true;
        }

        #endregion

    }
}