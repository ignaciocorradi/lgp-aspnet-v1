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


#endregion

namespace AppGest.Vista
{
    public partial class FrmAutoAbrev : FrmBase
    {
        
        Vehiculo _entidad;
        
        #region Constructores
        /// <summary>
        /// Constructor que se utiliza para la creación de un vehículo nuevo o edición de uno existente. 
        /// </summary>
        /// <param name="estiloBorde">Indica si va a mostrar el borde del formulario al crear </param>
        /// <param name="fondo">indica el color de fondo del formulario</param>
        /// <param name="vehiculo">Vehículo que se editará</param>
        public FrmAutoAbrev(FormBorderStyle estiloBorde, Color fondo, Vehiculo vehiculo, bool guardar)
            :this()
        {

            _entidad = vehiculo;
            InicializarPantalla(estiloBorde, fondo);
            this.ucAutosAbrev1.Cargar<Vehiculo>(_entidad);
            this.ucAutosAbrev1.DebeGuardar = guardar;
            CargarInfo();
        }

        
        public FrmAutoAbrev()
        {
            InitializeComponent();
            InicializarUc();
        }
        #endregion

        #region -- Metodos --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estiloBorde">Indica si va a mostrar el borde del formulario al crear </param>
        /// <param name="fondo">indica el color de fondo del formulario</param>
        private void InicializarPantalla(FormBorderStyle estiloBorde, Color fondo)
        {
            this.FormBorderStyle = estiloBorde;
            this.ucAutosAbrev1.BackColor = fondo;
            this.panel1.BackColor = fondo;
            this.ucAutosAbrev1.tbMenu.Visible = true;
            this.ucAutosAbrev1.tbMenu.Enabled = true;
            this.ucAutosAbrev1.LLenarControles<Vehiculo>(_entidad);
        }

        private void InicializarUc()
        {
            ucAutosAbrev1.Cancelar_Click += new Controles.Click_EventHandler(ucAutosAbrev1_Cancelar_Click);
            ucAutosAbrev1.Guardar_Click += new Controles.Click_EventHandler(ucAutosAbrev1_Guardar_Click);
            
        }
        /// <summary>
        /// Regresa el vehículo que esta en edición
        /// </summary>
        /// <returns></returns>
        public Vehiculo GetVehiculo()
        {
            return _entidad;
        }
        private void CerrarForm()
        {
            this.ucAutosAbrev1.Dispose();
            this.Close();
        }

        /// <summary>
        /// Carga informacion 
        /// </summary>
        private void CargarInfo()
        {
            this.txtInfo.Text = "";
            using (var exp = FabExpertos.Inst.Obtener<ExpVehiculos>(IdSesion))
            {
                var info = exp.ObtenerInfoVehiculo(_entidad.Id);
                this.txtInfo.Text = info;
            }
        }

        #endregion

        #region -- Eventos --
        private void ucAutosAbrev1_Guardar_Click(object sender, EventArgs e)
        {
            // Al guardar, cargamos la instancia con los datos que ingresó el usuario. 
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
            this.ucAutosAbrev1.Cargar<Vehiculo>(_entidad);
            this.CerrarForm();
        }
        private void ucAutosAbrev1_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
            this.CerrarForm();
         }


        

        #endregion


    }
}