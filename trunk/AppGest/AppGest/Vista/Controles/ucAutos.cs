#region Using


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Negocio.Modelo;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Util.Atributos;

#endregion

namespace AppGest.Vista.Controles
{
    [AdministradorAttribute]
    [SupervisorAttribute]
    [OperadorAttribute]
    public partial class ucVehiculo : ucDatosEntidad
    {
        /// <summary>
        /// Atributo que indica si la vista debe guardar o no.
        /// </summary>
        public bool DebeGuardar = true;
        public ucVehiculo()
        {
            InitializeComponent();
        }

        public override void Cargar<TEntidad>(TEntidad ent)
        {
            base.Cargar<TEntidad>(ent);

            var entidad = ent as Vehiculo;
            //Cargo solo la especialidad del vehículo.
            entidad.Marca = txtMarca.Text;
            entidad.Modelo = txtModelo.Text;

            if (String.IsNullOrWhiteSpace(entidad.Abreviatura))
            {
                List<string> cadenas = entidad.Marca.Split().ToList<string>();
                cadenas.AddRange(entidad.Modelo.Split().ToList<string>());
                entidad.Abreviatura = Helper.ObtenerIniciales(cadenas);
            }
        }
        public override bool HayCambios()
        {
            var entidadOld = _entidadOld as Vehiculo;
            return base.HayCambios()
                || txtMarca.Text != entidadOld.Marca
                || txtModelo.Text != entidadOld.Modelo;

        }
        public override void LLenarControles<TEntidad>(TEntidad ent)
        {
            base.LLenarControles<TEntidad>(ent);

            var entidad = ent as Vehiculo;
            txtMarca.Text = entidad.Marca;
            txtModelo.Text = entidad.Modelo;


        }
        protected override void ClickOk(object sender, EventArgs e)
        {

            try
            {

                using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(IdSesion))
                {
                    var entidad = EntidadActualSegunAccion<ExpVehiculos, Vehiculo>(exp);
                    this.Cargar<Vehiculo>(entidad);
                    exp.ValidarNuevo(entidad);
                    if (DebeGuardar)
                        exp.Guardar(entidad);

                    MensajeUsuario = "Se creó correctamente el vehículo '" + entidad.Detalle + "'";
                    base.ClickOk(sender, e);
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                MensajeUsuario = "Error al guardar un nuevo vehículo.";
                throw new Exception(MensajeUsuario, ex);
            }
            


        }

    }
}