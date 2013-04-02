#region Using

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using AppGest.Vista;
using AppGest.Negocio.Modelo;
using AppGest.Datos.Persistencia;
using AppGest.Negocio;
using AppGest.Vista.Controles;
using System.Collections;

using AppGest.Util;
using AppGest.Negocio.Core;
using System.Security.Authentication;
using AppGest.Util.Atributos;
using AppGest.Vista.Reportes;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using System.Configuration;

#endregion

namespace AppGest.Vista
{
    public partial class FrmPrincipal : FrmBase
    {
        System.ComponentModel.ComponentResourceManager _ucBaseResources = new System.ComponentModel.ComponentResourceManager(typeof(UcBase));

        public FrmPrincipal():base()
        {
            InitializeComponent();
            if (RunTime)
            {
                CrearRibbon();
            }
            this.FiltrarRibbon();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            tabControl1.SelectedIndexChanging += new TabControlCancelEventHandler(tabControl1_SelectedIndexChanging);
        }

        void tabControl1_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            TabPage tab = this.tabControl1.SelectedItem as TabPage;
            if (tab != null)
            {
                Font f = new Font(tab.Font.FontFamily.Name, tab.Font.Size, FontStyle.Regular);
                tab.Font = f;
                
            }

        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tab = this.tabControl1.SelectedItem as TabPage;
            if (tab != null)
            {
                Font f = new Font(tab.Font.FontFamily.Name, tab.Font.Size, FontStyle.Bold);
                tab.Font = f;
            }
        }
               

        /// <summary>
        /// Solapas que administra la pantalla principal
        /// </summary>
        /// 
        

        #region --- Metodos ---
        private void FiltrarRibbon()
        {
            foreach (RibbonBarPage page in this.rbarBarra.Pages)
            {
                page.Visible = false;
                foreach (RibbonBarGroup group in page.Groups)
                {
                    group.Visible = false;
                    foreach (RibbonBarItem item in group.Items)
                    {
                        try
                        {
                            RptItemSettings configuracionReporte = null;
                            item.Visible = false;

                            string tag = item.Tag.ToString();
                            if (tag.Contains("|"))
                            {
                                string[] prms = tag.Split('|');
                                configuracionReporte = ConfiguracionesReportes.CargarConfiguracionReporte(this.IdSesion, prms[1]);
                                tag = prms[0];
                            }

                            RibbonItemName ribbonItem = (RibbonItemName)Enum.Parse(typeof(RibbonItemName), tag);
                            Type ucType = UCAttribute.ObtenerTipo(ribbonItem);

                            if (ucType != null )
                            {
                                bool tienePermiso = Helper.TienePermiso(IdSesion, ucType, _ucBaseResources, false, configuracionReporte);

                                page.Visible = tienePermiso;
                                group.Visible = tienePermiso;
                                item.Visible = tienePermiso;
                            }
                        }
                        catch (ArgumentException argEx)
                        {
                            string cad = page.Text + "->" + group.Text + "->" + item.Text; 
                            Logger.Inst.Error("Ribbon Item Error en ["+cad+"] :", argEx);
                        }
                        catch (AuthenticationException ae)
                        {
                            item.Visible = false;
                            Logger.Inst.Error("Permiso Denegado.\n" + ae.Message, ae.InnerException);
                        }
                    }
                }
            }
        }

        void NuevaPestania(RibbonBarButtonItemArgs e  , string titulo, string keyPestania, string rptKey)
        {
            TabPage tabP = this._pestaActivas[keyPestania + rptKey] as TabPage;
            TabPage tab = this.tabControl1.SelectedItem as TabPage;
            if (tab != null)
            {
                Font f = new Font(tab.Font.FontFamily.Name, tab.Font.Size, FontStyle.Regular);
                tab.Font = f;
            }

            if (tabP == null)
            {
                UcBase uc = ObtenerUC(e, titulo, keyPestania , rptKey);
                if (uc != null)
                {
                    tabP = new TabPage(titulo);

                    IncializarPage(tabP);

                    this._pestaActivas.Add(keyPestania + rptKey, tabP);

                    uc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                    uc.KeySolapa = keyPestania + rptKey;
                    tabP.Controls.Add(uc);
                    tabP.Tag = uc;

                    tabControl1.TabPages.Add(tabP);

                    uc.Guardar_Click += new Click_EventHandler(uc_Guardar_Click);
                    uc.Cancelar_Click += new Click_EventHandler(uc_Cancelar_Click);
                    uc.MensageUsuario_Change += new Message_EventHandler(uc_MensageUsuario_Change);
                }
            }

            tabControl1.SelectedTab = tabP;
        }

        void uc_MensageUsuario_Change(object sender, EventArgs e)
        {
            var uc = sender as UcBase;
            ucStatusBar1.MensajeEstado = uc.MensajeUsuario;
        }

        private static void IncializarPage(TabPage tabP)
        {
            tabP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            tabP.AutoScroll = true;
            tabP.Location = new System.Drawing.Point(4, 22);
            tabP.Name = "tp_1";
            tabP.Size = new System.Drawing.Size(809, 275);
            tabP.AutoScroll = true;
            tabP.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            tabP.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            tabP.CustomStyle = "F";
            tabP.DockPadding.All = 2;
            tabP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            tabP.Padding = new Gizmox.WebGUI.Forms.Padding(2);
            
        }

        /// <summary>
        /// Evento que indica que se canceló la accion del usuaio sobre el UC.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void uc_Cancelar_Click(object sender, EventArgs e)
        {
            uc_Guardar_Click(sender, e);
        }

        /// <summary>
        /// Evento que indica que se guardó los datos editados por el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void uc_Guardar_Click(object sender, EventArgs e)
        {
            UcBase u = sender as UcBase;
            if (u != null)
            {
                TabPage tp = _pestaActivas[u.KeySolapa] as TabPage;
                if (tp != null)
                {
                    _pestaActivas.Remove(u.KeySolapa);
                    tabControl1.TabPages.Remove(tp);
                    ucStatusBar1.MensajeEstado = u.MensajeUsuario;

                    tp.Dispose();
                    u.Dispose();
                }
            }
            else
                throw new NotImplementedException();

        }
        void CargarInfo()
        {
            if (IdSesion != Guid.Empty)
            {
                Usuario usuario = null;
                using (var exp = IoC.Singleton.Experto<ExpUsuarios>(IdSesion))
                {
                    usuario = exp.ObtenerUsuario(IdSesion);
                }
                ucStatusBar1.MensajeInfo = " " + usuario.Persona.NombreCompleto + "\n(" + usuario.Nombre + ")";
                
            }
        }
        #endregion
        

        #region -- Enventos --


        protected override void MessageBoxHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.Salir();
                this.IrA("FrmInicio");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "¿Desea cerrar sesión?", "Cerrar sesión",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(MessageBoxHandler));

        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            base.FrmBase_Load(sender, e);
            CargarInfo();
        }
          
        private void rBtnEditUsuario_Click(object sender, EventArgs e)
        {
            //ucABMCliente uc = new ucABMCliente();
            //NuevaPestania(uc);
            
        }

        private Hashtable _pestaActivas = new Hashtable();
 
        /// <summary>
        /// Evento que administra todos los botones del menu Ribbon. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbarBarra_ButtonClick(object sender, RibbonBarButtonItemArgs e)
        {
            try
            {
                string tituloPage = "";
                if (e.Button.Tag != null && e.Button.Tag is string)
                {
                    string tag = e.Button.Tag.ToString();
                    string rptKey = string.Empty;
                    if (tag.Contains("|"))
                    {
                        string[] prms = tag.Split('|');
                        tag = prms[0];
                        rptKey = prms[1];
                    }
                    tituloPage += e.Button.Text;

                    NuevaPestania(e, tituloPage, tag, rptKey);
                       
                    ucStatusBar1.MensajeEstado = "Listo.";

                    this.Update();
                }
            }
            catch (AuthenticationException ae)
            {
                Logger.Inst.Error("Autenticación", ae);
            }
        }

        private UcBase ObtenerUC(RibbonBarButtonItemArgs e, string tituloPage, string tag, string rptKey)
        {
            UcBase u = null;
            switch (tag)
            {
                case "rbiAltasMensuales":
                    // Alta de mensuales (Cliente, autos y asociación de cocheras)
                    u = new ucMensuales();
                    ((ucMensuales)u).Nuevo();
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiEditarMensual":
                    u = new ucEdicionMensuales();
                    ((ucEdicionMensuales)u).Listar();
                    tituloPage = "Editar Clientes Mensuales - ";
                    break;

                case "rbiNuevaCochera":
                    u = new ucCocheras();
                    ((ucDatosEntidad)u).Nuevo<Cochera>(FabExpertos.Inst.Obtener<ExpCocheras>(IdSesion));
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiNuevoCliente":
                    u = new ucCliente();
                    ((ucDatosEntidad)u).Nuevo<Cliente>(FabExpertos.Inst.Obtener<ExpClientes>(IdSesion));

                    tituloPage = "Nuevo - ";
                    break;
                case "rbiModifCliente":
                    u = new ucEdicionCliente();
                    ((ucEdicionCliente)u).Listar();
                    break;
                case "rbiEditarCocheras":
                    u = new ucEdicionCochera();
                    ((ucEdicionCochera)u).ActualizarGrilla();
                    break;
                case "rbiPagoMensual":
                    u = new UcPagosMensuales();
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiNuevoAutos":
                    u = new ucVehiculo();
                    ((ucVehiculo)u).Nuevo<Vehiculo>(FabExpertos.Inst.Obtener<ExpVehiculos>(IdSesion));

                    tituloPage = "Nuevo - ";
                    break;
                case "rbiModifAutos":
                    u = new ucEdicionVehiculo();
                    ((ucEdicionVehiculo)u).Listar();
                    break;
                case "rbiListaIngresos":
                    u = new ucListaServicios(TipoServicio.Ingresos);
                    ((ucListaServicios)u).Listar();
                    break;
                case "rbiListaGastosEmpleados":
                    u = new ucListaServicios(TipoServicio.EgresosEmpleados);
                    ((ucListaServicios)u).Listar();
                    tituloPage = "Conceptos liquidación empleados -";
                    break;
                case "rbiListaGastos":
                    u = new ucListaServicios(TipoServicio.EgresosVarios);
                    ((ucListaServicios)u).Listar();
                    tituloPage = "Egresos Varios - ";
                    break;
                case "rbiReportes":
                    u = MostrarReporte(rptKey, e.Button.ToolTip);
                    break;
                case "rbiNuevoEmpleado":
                    u = new ucEmpleado();
                    ((ucEmpleado)u).Nuevo<Empleado>(FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion));
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiEditarEmpleado":
                    u = new ucEdicionEmpleado();
                    ((ucEdicionEmpleado)u).Listar();
                    tituloPage = "Empleados - ";
                    break;
                case "rbiNuevoCptoIngreso":
                    u = new ucConceptos(TipoServicio.Ingresos);
                    tituloPage = "Ingresos Mensuales - ";
                    break;
                case "rbiNuevoCptoGastoEmpleado":
                    u = new ucConceptos(TipoServicio.EgresosEmpleados);
                    tituloPage = "Egresos a Empleados - ";
                    break;
                case "rbiNuevoCptoGastoVario":
                    u = new ucConceptos(TipoServicio.EgresosVarios);
                    tituloPage = "Egresos Varios - ";
                    break;
                case "rbiModifCptoIngreso":
                    u = new ucEdicionConceptos(TipoServicio.Ingresos);
                    ((ucEdicionConceptos)u).Listar();
                    tituloPage = "Ingresos Mensuales - ";
                    break;
                case "rbiModifCptoGastoEmpleado":
                    u = new ucEdicionConceptos(TipoServicio.EgresosEmpleados);
                    ((ucEdicionConceptos)u).Listar();
                    tituloPage = "Egresos a Empleados - ";
                    break;
                case "rbiModifCptoGastoVario":
                    u = new ucEdicionConceptos(TipoServicio.EgresosVarios);
                    ((ucEdicionConceptos)u).Listar();
                    tituloPage = "Egresos Varios - ";
                    break;
                case "rbiEditarPagoMensual":
                    u = new ucEdicionPagoMensual();
                    ((ucEdicionPagoMensual)u).Inicializar();
                    break;
                case "rbiAltasPagosGastosVarios":
                    u = new UcPagosIngresosEgresos(TipoServicio.EgresosVarios);
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiEdicionPagosGastosVarios":
                    u = new UcEdicionPagoIngresosEgresos(TipoServicio.EgresosVarios);
                    ((UcEdicionPagoIngresosEgresos)u).Inicializar();
                    break;

                case "rbiParamEgresoEmpleado":
                    u = new UcDatosEgresosXEmpleado();
                    break;

                case "rbiPagoEgresoEmpleado":
                    u = new UcCargaPagoEgresoEmpleado();
                    break;

                case "rbiAMBFactura":
                    u = new ucAMBFactura();
                    break;

                case "rbiAltasPagosIngresos":
                    u = new UcPagosIngresosEgresos(TipoServicio.Ingresos);
                    tituloPage = "Nuevo - ";
                    break;
                case "rbiEdicionPagosIngresos":
                    u = new UcEdicionPagoIngresosEgresos(TipoServicio.Ingresos);
                    ((UcEdicionPagoIngresosEgresos)u).Inicializar();
                    break;
                default:
                    MessageBox.Show("Funcionalidad en construcción.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }
            return u;
        }

        private UcBase MostrarReporte(string rptKey, string tituloPage)
        {
            UcBase rdo = null;
            bool? reportesIntegrados = (bool?)Helper.Parse(ConfigurationManager.AppSettings["ReportesIntegrados"], typeof(bool));
            if (reportesIntegrados.HasValue && reportesIntegrados.Value)
                rdo = new ucReporte(rptKey);
            else

                AbrirRporteEnOtraVentana(rptKey, tituloPage);

            return rdo;

        }

        void AbrirRporteEnOtraVentana(string rptKey, string tituloPage)
        {
            var lnParam = new LinkParameters();
            lnParam.FullScreen = true;
            lnParam.Location = new Point(0,0);
            lnParam.WindowStyle = LinkWindowStyle.Normal;
            lnParam.Target = "ReceivingFrame";
            lnParam.Form["rptKey"] = rptKey;
            lnParam.Form["Titulo"] = tituloPage;
            var url = Helper.AspNetBaseUrl(this.Context.HttpContext) + "Post.FrmVisorReportes.wgx";
            Link.Open(url, lnParam);
            this.ucStatusBar1.MensajeEstado = "Se inició el informe en otra ventana.";
            this.Update();

        }
        #endregion

        #region --- CREACION AUTOMATICA del Menu ---

        RibbonBar rbarBarra;
        void CrearRibbon()
        {
            List<ConfMenu> _conf = null;
            using (var exp = FabExpertos.Inst.Obtener<ExpConfSistema>(IdSesion))
                _conf = exp.ObtenerConfMenu();

            this.SuspendLayout();
            this.rbarBarra = null;
            this.rbarBarra = CrearBarra();
            this.rbarBarra.ButtonClick += new System.EventHandler<Gizmox.WebGUI.Forms.RibbonBarButtonItemArgs>(this.rbarBarra_ButtonClick);

            var _paginas = (from p in _conf select new { Key = p.Paginas, Nombre = p.Paginas }).Distinct().ToList();


            foreach (var p in _paginas)
            {
                var confgrupos = (from l in _conf where l.Paginas == p.Key select l).ToList();
                CrearPaginas(confgrupos, p.Nombre, rbarBarra);
            }
            this.Controls.Add(this.rbarBarra);
            this.ResumeLayout(false);
        }

        private void CrearPaginas(List<ConfMenu> conf, string nombrePagina, RibbonBar rbarBarra)
        {
            var pag = CrearPagina(nombrePagina, rbarBarra);
            var gruposACrear = (from p in conf select p.Grupos).Distinct().ToList();
            foreach (var grup in gruposACrear)
            {
                var items = (from l in conf where l.Paginas == nombrePagina && l.Grupos == grup select l).ToList();
                CrearGrupos(items, grup, pag);
            }

        }

        private void CrearGrupos(List<ConfMenu> conf, string nombreGrupo, RibbonBarPage pag)
        {
            var nuevoGrupo = CrearGrupo(nombreGrupo, pag);
            foreach (var item in conf)
            {
                CrearItem(nuevoGrupo, item);
            }

        }

        private RibbonBarButtonItem CrearItem(RibbonBarGroup grupo, ConfMenu confitem)
        {
            var img = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(confitem.ImagenItem);
            var nuevoItem = new Gizmox.WebGUI.Forms.RibbonBarButtonItem();
            nuevoItem.Tag = confitem.TagItem;
            if (confitem.TagItem == "rbiAltasMensuales")
                Accion_NuevoMensual = nuevoItem;
            nuevoItem.Image = img;
            nuevoItem.Text = confitem.Items;
            nuevoItem.AutoSize = (confitem.AutoSize.ToUpper() == "SI");
            nuevoItem.ToolTip = confitem.ToolTips;
            grupo.Items.Add(nuevoItem);
            return nuevoItem;
        }

        private RibbonBarGroup CrearGrupo(string titulo, RibbonBarPage pagina)
        {
            var nuevoGrupo = new RibbonBarGroup();
            nuevoGrupo.AutoSize = true;
            nuevoGrupo.AutoSizeMode = Gizmox.WebGUI.Forms.AutoSizeMode.GrowAndShrink;
            nuevoGrupo.Text = titulo;
            pagina.Groups.Add(nuevoGrupo);
            return nuevoGrupo;
        }

        private RibbonBarPage CrearPagina(string titulo, RibbonBar barra)
        {
            var nuevaPag = new RibbonBarPage();
            nuevaPag.Text = titulo;
            nuevaPag.Visible = true;
            barra.Pages.Add(nuevaPag);
            return nuevaPag;
        }

        private RibbonBar CrearBarra()
        {
            var nuevaBarra = new Gizmox.WebGUI.Forms.RibbonBar();
            nuevaBarra.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            nuevaBarra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nuevaBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            nuevaBarra.Location = new System.Drawing.Point(3, 3);
            nuevaBarra.Name = "rbarBarra";
            nuevaBarra.SelectedIndex = 0;
            nuevaBarra.ShowExpandButton = true;
            nuevaBarra.StartButtonDiameterSize = 32;
            nuevaBarra.StartButtonOffset = 20;
            nuevaBarra.TabIndex = 5;
            nuevaBarra.ToolBarLocation = Gizmox.WebGUI.Forms.RibbonBar.QuickAccessToolBarLocation.BellowRibbon;
            return nuevaBarra;
        }
        #endregion

        internal void NuevoMensual()
        {
            if (Accion_NuevoMensual != null)
            {
                object sender = null;
                RibbonBarButtonItemArgs e = new RibbonBarButtonItemArgs(this.Accion_NuevoMensual);
                this.rbarBarra_ButtonClick(sender, e);
            }
            else
            {
                MessageBox.Show("Función no habilitada.\nNo tiene acceso al Alta de clientes mensuales. Revise los permisos.", "Nuevo Mensual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private RibbonBarButtonItem Accion_NuevoMensual { get; set; }
    }

    public enum RibbonItemName 
    {
        [UCAttribute(typeof(ucMensuales))]
        rbiAltasMensuales = 1,
        [UCAttribute(typeof(ucEdicionMensuales))]
        rbiEditarMensual = 2,
        [UCAttribute(typeof(ucCocheras))]
        rbiNuevaCochera =  3,
        [UCAttribute(typeof(ucCliente))]
        rbiNuevoCliente = 4,
        [UCAttribute(typeof(ucEdicionCliente))]
        rbiModifCliente = 5,
        [UCAttribute(typeof(ucEdicionCochera))]
        rbiEditarCocheras = 6,
        [UCAttribute(typeof(UcPagosMensuales))]
        rbiPagoMensual = 7,
        [UCAttribute(typeof(ucVehiculo))]
        rbiNuevoAutos = 8,
        [UCAttribute(typeof(ucEdicionVehiculo))]
        rbiModifAutos = 9,
        [UCAttribute(typeof(ucListaServicios))]
        rbiListaIngresos = 10,
        [UCAttribute(typeof(ucListaServicios))]
        rbiListaGastosEmpleados = 11,
        [UCAttribute(typeof(ucListaServicios))]
        rbiListaGastos = 12,
        [UCAttribute(typeof(ucEmpleado))]
        rbiNuevoEmpleado = 14,
        [UCAttribute(typeof(ucEdicionEmpleado))]
        rbiEditarEmpleado = 15,
        [UCAttribute(typeof(ucConceptos))]
        rbiNuevoCptoIngreso = 16,
        [UCAttribute(typeof(ucConceptos))]
        rbiNuevoCptoGastoEmpleado = 17,
        [UCAttribute(typeof(ucConceptos))]
        rbiNuevoCptoGastoVario = 18,
        [UCAttribute(typeof(ucEdicionConceptos))]
        rbiModifCptoIngreso = 19,
        [UCAttribute(typeof(ucEdicionConceptos))]
        rbiModifCptoGastoEmpleado = 20,
        [UCAttribute(typeof(ucEdicionConceptos))]
        rbiModifCptoGastoVario = 21,
        [UCAttribute(typeof(ucEdicionConceptos))]
        rbiEditarPagoMensual = 22,
        [UCAttribute(typeof(ucReporte))]
        rbiReportes = 23,
        [UCAttribute(typeof(UcPagosIngresosEgresos))]
        rbiAltasPagosGastosVarios = 24,
        [UCAttribute(typeof(UcEdicionPagoIngresosEgresos))]
        rbiEdicionPagosGastosVarios = 25,
        [UCAttribute(typeof(UcPagosIngresosEgresos))]
        rbiAltasPagosIngresos = 26,
        [UCAttribute(typeof(UcEdicionPagoIngresosEgresos))]
        rbiEdicionPagosIngresos = 27,
        [UCAttribute(typeof(UcDatosEgresosXEmpleado))]
        rbiParamEgresoEmpleado = 28,
        [UCAttribute(typeof(UcBase))]
        rbiAltaDiarios = 29,
        [UCAttribute(typeof(UcCargaPagoEgresoEmpleado))]
        rbiPagoEgresoEmpleado = 30,
        [UCAttribute(typeof(ucAMBFactura))]
        rbiAMBFactura = 31
    }

}