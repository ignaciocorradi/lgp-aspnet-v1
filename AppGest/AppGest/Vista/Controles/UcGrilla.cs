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
using AppGest.Datos.Persistencia;
using System.Configuration;
using System.Collections;
using AppGest.Util;

#endregion

namespace AppGest.Vista.Controles
{
    public partial class UcGrilla : UserControl
    {
        public delegate void ClickAccionEventHandler(object sender, AccionEventArgs e);

        public event ClickAccionEventHandler ClickAccion;

        private object tempFirstRow;
        bool inicializada;

        public UcGrilla()
        {
            InitializeComponent();

            inicializada = false;
            this.AutoAjustarAnchoColumnas = true;
            this.Load += new EventHandler(ucGrillaEntidades_Load);
            this.SizeChanged += new EventHandler(UcGrilla_SizeChanged);
        }

        void UcGrilla_SizeChanged(object sender, EventArgs e)
        {
            //this.AutoajustarColumnas();
        }

        public List<DataGridViewRow> Filas()
        {
            var rows = new ArrayList(dgvGrilla.Rows);
            return rows.Cast<DataGridViewRow>().ToList();
        }
        public IList DataSource
        { 
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                this.Recargar();
            } 
        } IList _dataSource;

        public bool AutoAjustarAnchoColumnas { get; set; }

        /// <summary>
        /// Agrega un item a la grilla
        /// </summary>
        /// <param name="item">Item a agregar</param>
        public void AddRow(object item)
        {
            var bs = ((BindingSource)this.dgvGrilla.DataSource);
            bs.Add(item);
        }

        ///// <summary>
        ///// Agrega una lista de items a la grilla
        ///// </summary>
        ///// <param name="listItem">Lista de items a agregar</param>
        //public void AddRows(IList listItem)
        //{
        //    var bs = ((BindingSource)this.dgvGrilla.DataSource);
        //    bs.List.(item);
        //}

        /// <summary>
        /// Quita un item de la grilla
        /// </summary>
        /// <param name="item">Item a quitar</param>
        public void RemoveRow(object item)
        {
            ((BindingSource)this.dgvGrilla.DataSource).Remove(item);
        }

        public ParametrosGrilla ParametrosGrilla { get; set; }

        private void ucGrillaEntidades_Load(object sender, EventArgs e)
        {
            Recargar();
            this.ConfigurarGrilla();

            //Aca elimino la fila temporal que se crea al cargar el DataSource (manganeta).
            ((BindingSource) this.dgvGrilla.DataSource).Remove(tempFirstRow);

            inicializada = true;
        }

        private void Recargar()
        {
            BindingSource bs1 = new BindingSource();
            bs1.DataSource = this.DataSource;

            //Este if es una manganeta para solucionar el inconveniente de la visualizacion
            //de la grilla cuando el data source viene vacio.
            if (this.DataSource == null || this.DataSource.Count == 0)
            {
                tempFirstRow = bs1.AddNew();
                this.dgvGrilla.DataSource = bs1;
               // bs1.Clear();
            }
            else
                this.dgvGrilla.DataSource = bs1;

            if (inicializada)
                ((BindingSource)this.dgvGrilla.DataSource).Remove(tempFirstRow);
        }

        public TControl ObtenerControlAccion<TControl>(int rowIndex, string nombreAccion)
            where TControl : Control
        {
            var row = dgvGrilla.Rows[rowIndex];
            return ObtenerControlAccion<TControl>(row, nombreAccion);
        }
        public TControl ObtenerControlAccion<TControl>(DataGridViewRow row, string nombreAccion)
            where TControl : Control
        {
            var columna = ParametrosGrilla.ParametrosColumna.OfType<ParametrosColumnaAccion>().Where(c => c.Nombre == nombreAccion).First();
            var columnIndex = columna.Posicion;
            var panel = row.Cells[columnIndex].Panel.Controls.OfType<FlowLayoutPanel>().First();
            var control = panel.Controls.OfType<TControl>().First(c => c.Name == columna.Nombre);
            return control;
        }
        public DataGridView Grilla { get { return dgvGrilla; } }
        void dgvGrilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.dgvGrilla.Rows.Count)
            {
                ParametrosColumnaAccion pcAccion = this.ParametrosGrilla.ParametrosColumna.OfType<ParametrosColumnaAccion>().Where<ParametrosColumnaAccion>(a => a.Posicion == e.ColumnIndex).FirstOrDefault<ParametrosColumnaAccion>();

                if (pcAccion != null)
                {
                    this.dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Panel.Controls.Add(CrearAcciones(pcAccion, this.dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex]));
                    this.dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Panel.Colspan = 1;
                    this.dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Panel.Rowspan = 1;
                }
            }
        }

        private FlowLayoutPanel CrearAcciones(ParametrosColumnaAccion pcAccion, DataGridViewCell celda)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            panel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            panel.Padding = new Padding(0);
            panel.BackColor = Color.Transparent;
            panel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;

            CrearAcciones(pcAccion, panel, celda);

            return panel;
        }

        private void CrearAcciones(ParametrosColumnaAccion pcAccion, Panel panel, DataGridViewCell celda)
        {
            foreach (AccionColumna ac in pcAccion.AccionesColumna)
            {
                switch (ac.TipoControlAccion)
                {
                    case TipoControlAccion.Boton:
                        panel.Controls.Add(this.CrearAccionBoton(ac.Identificador, ac.Texto, celda));
                        break;
                    case TipoControlAccion.BotonEditar:
                        panel.Controls.Add(this.CrearAccionBotonEditar(ac.Identificador, ac.Texto, celda));
                        break;
                    case TipoControlAccion.BotonEliminar:
                        panel.Controls.Add(this.CrearAccionBotonEliminar(ac.Identificador, ac.Texto, celda));
                        break;
                    case TipoControlAccion.BotonBaja:
                        panel.Controls.Add(this.CrearAccionBotonBaja(ac.Identificador, ac.Texto, celda));
                        break;
                    case TipoControlAccion.Imagen:
                        panel.Controls.Add(this.CrearAccionImagen(ac.Identificador, ac.RutaImagen, ac.Tooltip, celda));
                        break;
                    case TipoControlAccion.Checkbox:
                        panel.Controls.Add(this.CrearAccionCheckbox(ac.Identificador, ac.Texto, celda));
                        break;
                }
            }
        }

        private Button CrearAccionBotonEditar(string id, string texto, DataGridViewCell celda)
        {
            Button b = new BotonEditar();
            b.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            b.ImageIndex = 1;
            b.ImageList = this.lstImagenes;
            b.Name = id;
            b.Click += new EventHandler(Accion_Click);

            return b;
        }


        private Button CrearAccionBotonEliminar(string id, string texto, DataGridViewCell celda)
        {
            Button b = new BotonEliminar();
            b.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            b.ImageIndex = 3;
            b.ImageList = this.lstImagenes;
            b.Name = id;
            b.Click += new EventHandler(Accion_Click);

            return b;
        }

        private Button CrearAccionBotonBaja(string id, string texto, DataGridViewCell celda)
        {
            Button b = new BotonBaja();
            b.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            b.ImageIndex = 2;
            b.ImageList = this.lstImagenes;
            b.Name = id;
            b.Click += new EventHandler(Accion_Click);

            return b;
        }


        private Button CrearAccionBoton(string id, string texto, DataGridViewCell celda)
        {
            Button b = new ControlBase.Button();
            b.Name = id;
            b.Text = texto;

            b.Click += new EventHandler(Accion_Click);

            return b;
        }

        void Accion_Click(object sender, EventArgs e)
        {
            if (ClickAccion != null)
            {
                string identificador = ((Control)sender).Name;
                int rowIndex = ((DataGridViewCellPanel)((FlowLayoutPanel)((Control)sender).Parent).Parent).OwnerCell.RowIndex;
                AccionEventArgs args = new AccionEventArgs(identificador, rowIndex);
                ClickAccion(this, args);            
            }
        }

        private PictureBox CrearAccionImagen(string id, string rutaImagen, string tooltip, DataGridViewCell celda)
        {
            PictureBox pb = new PictureBox();
            pb.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(rutaImagen);
            pb.Name = id;
            pb.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            pb.Text = tooltip;

            pb.Click += new EventHandler(Accion_Click);

            return pb;
        }

        private CheckBox CrearAccionCheckbox(string id, string texto, DataGridViewCell celda)
        {
            CheckBox cb = new CheckBox();
            cb.Name = id;
            cb.Text = texto;
            cb.TextAlign = ContentAlignment.MiddleCenter;

            cb.Click += new EventHandler(Accion_Click);
            return cb;
        }

        private void ConfigurarGrilla()
        {
            this.dgvGrilla.AutoGenerateColumns = false;
            //Valores fijos hasta que funcionen correctamente 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.ShowFilterRow = false;
            this.dgvGrilla.ShowGroupingDropArea = false;
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.RowHeadersWidth = 20;
            
            if (ParametrosGrilla != null)
            {
                this.dgvGrilla.ReadOnly = (ParametrosGrilla.Editable == EnumEditable.Predeterminado ? EnumEditable.NoEditable : ParametrosGrilla.Editable) == EnumEditable.NoEditable;
                this.dgvGrilla.AllowUserToOrderColumns = ParametrosGrilla.PermitirOrdenarColumnas;
                this.dgvGrilla.AllowUserToResizeColumns = ParametrosGrilla.PermitirRedimensionarColumnas;
                this.dgvGrilla.AllowUserToResizeRows = ParametrosGrilla.PermitirRedimensionarFilas;
                this.dgvGrilla.ColumnHeadersVisible = ParametrosGrilla.EncabezadoVisible;
                this.dgvGrilla.RowHeadersVisible = ParametrosGrilla.EncabezadoFilasVisible;

                this.dgvGrilla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
                this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (ParametrosGrilla.Fuente != null)
                {
                    this.dgvGrilla.Font = ParametrosGrilla.Fuente;
                }

                this.dgvGrilla.ScrollBars = ParametrosGrilla.ScrollBars;
                this.dgvGrilla.ShowColumnChooser = ParametrosGrilla.SelectorColumnas;
                this.dgvGrilla.UseInternalPaging = ParametrosGrilla.Paginar;

                this.dgvGrilla.AlternatingRowsDefaultCellStyle = ParametrosGrilla.EstiloCeldas;

                this.ConfigurarColumnas();
                this.AutoajustarColumnas();
            }

            this.dgvGrilla.CellEndEdit += new DataGridViewCellEventHandler(dgvGrilla_CellEndEdit);
        }

        [DefaultValue(ScrollBars.Both)]
        public ScrollBars ScrollBars
        {
            get
            {
                return this.dgvGrilla.ScrollBars;
            }
            set
          
            {
                this.dgvGrilla.ScrollBars = value;
            }
        }

        private void AutoajustarColumnas()
        {

            if (this.AutoAjustarAnchoColumnas && dgvGrilla.Columns.Count > 0)
            {
                this.dgvGrilla.BorderColor = ((this.dgvGrilla.ScrollBars == ScrollBars.Both ||
                        this.dgvGrilla.ScrollBars == ScrollBars.Vertical) ? new BorderColor(Color.Transparent) : this.dgvGrilla.BorderColor);
                this.dgvGrilla.BorderColor = new BorderColor(Color.Transparent);
                this.BackColor = ((this.dgvGrilla.ScrollBars == ScrollBars.Both ||
                    this.dgvGrilla.ScrollBars == ScrollBars.Vertical) ? Color.LightGray : this.BackColor);

                int anchoGrilla = this.dgvGrilla.Width;
                int anchoTotalCol = this.dgvGrilla.RowHeadersWidth + 
                    ((this.dgvGrilla.ScrollBars == ScrollBars.Both ||
                        this.dgvGrilla.ScrollBars == ScrollBars.Vertical) ? 17 : 0 );
                
                int nuevoAnchoTotalCol = anchoTotalCol;
                int ultimaColIndex = 0;
                foreach (DataGridViewColumn columna in dgvGrilla.Columns)
                {
                    if (columna.Visible && !(columna.Tag is ParametrosColumnaAccion))
                        anchoTotalCol += columna.Width;
                    else if (columna.Visible && columna.Tag is ParametrosColumnaAccion)
                        anchoGrilla -= columna.Width;
                }
                foreach (DataGridViewColumn columna in dgvGrilla.Columns)
                {
                    if (columna.Visible && !(columna.Tag is ParametrosColumnaAccion))
                    {
                        decimal PorcentajeAncho = Convert.ToDecimal(columna.Width) / Convert.ToDecimal(anchoTotalCol);
                        columna.Width = Convert.ToInt32(Math.Truncate(PorcentajeAncho * anchoGrilla));
                        ultimaColIndex = columna.Index;
                        nuevoAnchoTotalCol += columna.Width;
                    }
                }
                if (anchoGrilla - nuevoAnchoTotalCol > 2)
                    dgvGrilla.Columns[ultimaColIndex].Width += (anchoGrilla - nuevoAnchoTotalCol - 2);

            }

        }

        private void ConfigurarColumnas()
        {

            IEnumerable<ParametrosColumnaAccion> pcAccionesList = ParametrosGrilla.ParametrosColumna.OfType<ParametrosColumnaAccion>();

            //Si la cantidad de columnas de la grilla supera a la cantidad de parametros
            //recorro todas las columnas y las oculto, luego solo se mostrarán aquellas
            //columnas cuyo parametro indique que la columna debe ser visible
            if (this.dgvGrilla.Columns.Count > ParametrosGrilla.ParametrosColumna.Count - pcAccionesList.Count())
            {
                foreach (DataGridViewColumn col in this.dgvGrilla.Columns)
                {
                    col.Visible = false;
                    col.IsExcludedFromColumnChooser = true;
                }
            }

            bool colFija = true;
            ParametrosGrilla.ParametrosColumna.Sort();

            if (this.DataSource == null || this.DataSource.Count == 0)
            {
                foreach (ParametrosColumna paramCol in ParametrosGrilla.ParametrosColumna.Where(p => p.GetType() != typeof(ParametrosColumnaAccion)))
                {
                    this.InsertarColumna(paramCol);
                }
            }

            if (pcAccionesList.Count() > 0)
            {
                foreach (ParametrosColumnaAccion pcAccion in pcAccionesList)
                {
                    this.InsertarColumna(pcAccion);
                }
                
                this.dgvGrilla.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvGrilla_CellFormatting);
            }

            foreach (ParametrosColumna paramCol in ParametrosGrilla.ParametrosColumna)
            {
                this.dgvGrilla.Columns[paramCol.Nombre].HeaderText = paramCol.Encabezado;
                this.dgvGrilla.Columns[paramCol.Nombre].Visible = paramCol.Visible;
                this.dgvGrilla.Columns[paramCol.Nombre].IsExcludedFromColumnChooser = !paramCol.Visible;
                this.dgvGrilla.Columns[paramCol.Nombre].DisplayIndex = paramCol.Posicion;
                this.dgvGrilla.Columns[paramCol.Nombre].Resizable = paramCol.Resizable;
                this.dgvGrilla.Columns[paramCol.Nombre].Width = paramCol.Ancho;
                this.dgvGrilla.Columns[paramCol.Nombre].DefaultCellStyle = paramCol.Estilo;
                this.dgvGrilla.Columns[paramCol.Nombre].HeaderCell.Style.Alignment = paramCol.AlineacionEncabezado;
                this.dgvGrilla.Columns[paramCol.Nombre].HeaderCell.Style.BackColor = (paramCol.HeaderBackColor == null) ? this.dgvGrilla.Columns[paramCol.Nombre].HeaderCell.Style.BackColor : paramCol.HeaderBackColor ;
                this.dgvGrilla.Columns[paramCol.Nombre].ReadOnly = dgvGrilla.ReadOnly || (paramCol.Editable == EnumEditable.Predeterminado ? this.ParametrosGrilla.EditableColumnaPredet : paramCol.Editable) == EnumEditable.NoEditable;

                //this.dgvGrilla.Columns[paramCol.Nombre].AutoSizeMode = paramCol.AutoSizeMode;
                if (colFija)
                {
                    //Si almenos una columna no permanece fija, 
                    //el resto de las columnas hacia la derecha tampoco permaneceran fijascolFija = paramCol.Fija;
                    this.dgvGrilla.Columns[paramCol.Nombre].Frozen = paramCol.Fija;
                }
            }            
        }

        void dgvGrilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Update();
        }

        private void InsertarColumna(ParametrosColumna paramCol)
        {
            DataGridViewColumn dgvCol = new DataGridViewColumn();
            dgvCol.Name = paramCol.Nombre;
            dgvCol.CellTemplate = new DataGridViewTextBoxCell();
            dgvCol.ReadOnly = dgvGrilla.ReadOnly || (paramCol.Editable == EnumEditable.Predeterminado ? this.ParametrosGrilla.EditableColumnaPredet : paramCol.Editable) == EnumEditable.NoEditable;
            dgvCol.DefaultCellStyle = paramCol.Estilo;
            dgvCol.Tag = paramCol;

            if (paramCol.Posicion <= this.dgvGrilla.Columns.Count)
            {
                this.dgvGrilla.Columns.Insert(paramCol.Posicion, dgvCol);
            }
            else
            {
                throw new ApplicationException("Posicion de Columna erronea: " + paramCol.Posicion);
            }
        }



        internal void SeleccionarFila(int rowIndex)
        {
            if (rowIndex >= 0 && (rowIndex < Grilla.Rows.Count))
            {
                try
                {
                    var oldMode = Grilla.SelectionMode;
                    Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.Grilla.ClearSelection();
                    var rowSeleccionado = Grilla.Rows[rowIndex];
                    rowSeleccionado.Selected = true;
                    int indexCell = 0;
                    for (int i = 0; i < rowSeleccionado.Cells.Count; i++)
                    {
                        if (rowSeleccionado.Cells[i].Visible)
                        {
                            indexCell = i;
                            break;
                        }
                    }
                    Grilla.CurrentCell = rowSeleccionado.Cells[indexCell];
                    Grilla.SelectionMode = oldMode;
                    Grilla.Update(true);
                }
                catch (Exception ex)
                {
                    Logger.Inst.Error("Error al seleccionar la fila de la grilla", ex);
                }
            }
        }

        #region Propiedades
        public bool EncabezadoFilaVisible 
        { 
            get { 
                return dgvGrilla.RowHeadersVisible; 
            } 
            set 
            { 
                this.dgvGrilla.RowHeadersVisible = value;
            } 
        }
        public DataGridViewRow FilaActual { 
            get 
            {
                return this.dgvGrilla.CurrentRow;
            }
        }

        /// <summary>
        /// Estilo por defecto utilizado para la grilla.
        /// </summary>
        public static DataGridViewCellStyle EstiloDefectoGrilla
        {
            get
            {
                DataGridViewCellStyle dgvCStyle = new DataGridViewCellStyle();
                dgvCStyle.BackColor = System.Drawing.Color.DeepSkyBlue;
                dgvCStyle.SelectionBackColor = System.Drawing.Color.MediumBlue;
                

                dgvCStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dgvCStyle.ForeColor = System.Drawing.Color.White;
                dgvCStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
                dgvCStyle.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
                return dgvCStyle;


            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que representa los parametros que se pueen configurar en una grilla
    /// </summary>
    public class ParametrosGrilla
    {
        public ParametrosGrilla()
        {
            bool? encabezadoVisible = (bool?) Helper.Parse(ConfigurationManager.AppSettings["PG_Encabezado_Visible"], typeof(bool));
            this.EncabezadoVisible = encabezadoVisible ?? true;

            bool? encabezadoFilasVisible = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_EncabezadoFilas_Visible"], typeof(bool));
            this.EncabezadoFilasVisible = encabezadoFilasVisible ?? true;

            bool? paginar = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_Paginar"], typeof(bool));
            this.Paginar = paginar ?? false;

            this.ParametrosColumna = new List<ParametrosColumna>();
            
            bool? permitirOrdenarColumnas = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_Permitir_Ordenar_Columnas"], typeof(bool));
            this.PermitirOrdenarColumnas = permitirOrdenarColumnas ?? false;

            bool? permitirRedimensionarColumnas = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_Permitir_Redimensionar_Columnas"], typeof(bool));
            this.PermitirRedimensionarColumnas = permitirRedimensionarColumnas ?? false;

            bool? permitirRedimensionarFilas = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_Permitir_Redimensionar_Filas"], typeof(bool));
            this.PermitirRedimensionarFilas = permitirRedimensionarFilas ?? false;

            this.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;

            bool? selectorColumnas = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PG_Selector_Columnas"], typeof(bool));
            this.SelectorColumnas = selectorColumnas ?? false;
        }

        public ParametrosGrilla(List<ParametrosColumna> parametrosColumna) : this()
        {
            this.ParametrosColumna = parametrosColumna;
        }


        public ParametrosGrilla(List<ParametrosColumna> parametrosColumna, bool paginar, bool permitirOrdenarColumnas, bool permitirRedimensionarColumnas, bool permitirRedimensionarFilas, bool encabezadoVisible, ScrollBars scrollBars, bool selectorColumnas, EnumEditable editable)
            : this(parametrosColumna, paginar, permitirOrdenarColumnas, permitirRedimensionarColumnas, permitirRedimensionarFilas, encabezadoVisible, scrollBars, selectorColumnas, editable, EnumEditable.Predeterminado, null)
        {
        }

        public ParametrosGrilla(List<ParametrosColumna> parametrosColumna, bool paginar, bool permitirOrdenarColumnas, bool permitirRedimensionarColumnas, bool permitirRedimensionarFilas, bool encabezadoVisible, ScrollBars scrollBars, bool selectorColumnas)
            : this(parametrosColumna, paginar, permitirOrdenarColumnas, permitirRedimensionarColumnas, permitirRedimensionarFilas, encabezadoVisible, scrollBars, selectorColumnas, EnumEditable.Predeterminado, EnumEditable.Predeterminado, null)
        {
        }

        public ParametrosGrilla(List<ParametrosColumna> parametrosColumna, bool paginar, bool permitirOrdenarColumnas, bool permitirRedimensionarColumnas, bool permitirRedimensionarFilas, bool encabezadoVisible, ScrollBars scrollBars, bool selectorColumnas, EnumEditable editable, EnumEditable editableColPredet, DataGridViewCellStyle estiloCeldas)
            : this(parametrosColumna)
        {
            this.EncabezadoVisible = encabezadoVisible;
            this.Paginar = paginar;
            this.ParametrosColumna = parametrosColumna;
            this.PermitirOrdenarColumnas = permitirOrdenarColumnas;
            this.PermitirRedimensionarColumnas = permitirRedimensionarColumnas;
            this.PermitirRedimensionarFilas = permitirRedimensionarFilas;
            this.ScrollBars = scrollBars;
            this.SelectorColumnas = selectorColumnas;

            this.Editable = editable;
            this.EditableColumnaPredet = editableColPredet;

            this.EstiloCeldas = estiloCeldas == null ? this.EstiloCeldasDefault : estiloCeldas;
        }


        public DataGridViewCellStyle EstiloCeldasDefault { 
            get 
            {
                var dgvCStyle = new DataGridViewCellStyle();
                dgvCStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
                dgvCStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dgvCStyle.ForeColor = System.Drawing.Color.Black;
                dgvCStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
                dgvCStyle.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
                
                return dgvCStyle;
            } 
        }

        public DataGridViewCellStyle EstiloCeldas { get; set; }

        /// <summary>
        /// Devuelve o establece un valor que indica si la grilla editable.
        /// </summary>
        public EnumEditable Editable { get; set; }

        /// <summary>
        /// Devuelve o establece un valor que indica si de manera predeterminada
        /// las columnas serán editables.
        /// </summary>
        public EnumEditable EditableColumnaPredet { get; set; }

        /// <summary>
        /// Muestra u oculta el encabezado de la grilla
        /// </summary>
        public bool EncabezadoVisible { get; set; }

        /// <summary>
        /// Muestra u oculta el encabezado de las filas en la grilla
        /// </summary>
        public bool EncabezadoFilasVisible { get; set; }

        /// <summary>
        /// Especifica el tipo de fuente a utilizar en la grilla
        /// </summary>
        public Font Fuente { get; set; }

        /// <summary>
        /// Indica si se paginará la grilla o no
        /// </summary>
        public bool Paginar { get; set; }

        /// <summary>
        /// Parametros de configuracion de cada columna
        /// </summary>
        public List<ParametrosColumna> ParametrosColumna { get; set; }

        /// <summary>
        /// Permite que las columnas de la grilla cambien de lugar
        /// </summary>
        public bool PermitirOrdenarColumnas { get; set; }

        /// <summary>
        /// Permite cambiar el ancho de las columnas
        /// </summary>
        public bool PermitirRedimensionarColumnas { get; set; }

        /// <summary>
        /// Permite cambiar el alto de las filas
        /// </summary>
        public bool PermitirRedimensionarFilas { get; set; }

        /// <summary>
        /// Indica que barra de scroll se mostrará
        /// </summary>
        public Gizmox.WebGUI.Forms.ScrollBars ScrollBars { get; set; }

        /// <summary>
        /// Permite que el usuario seleccione las columnas a mostrar
        /// </summary>
        public bool SelectorColumnas { get; set; }

    }

    /// <summary>
    /// Clase que representa los parametros que se pueen configurar en cada columna de una grilla
    /// </summary>
    public class ParametrosColumna : IComparable<ParametrosColumna>
    {
        /// <summary>
        /// Crea un parametro de inicializacion de columna
        /// </summary>
        /// <param name="nombre">Indica el nombre de la columna a inicializar</param>
        /// <param name="encabezado">Encabezado visible de la columna indicada</param>
        public ParametrosColumna(string nombre, string encabezado)
        {
            this.Nombre = nombre;
            this.Encabezado = encabezado;

            bool? fija = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PC_Fija"], typeof(bool));
            this.Fija = fija ?? false;

            bool? redimensionable = (bool?)Helper.Parse(ConfigurationManager.AppSettings["PC_Redimensionable"], typeof(bool));
            this.Redimensionable = redimensionable ?? true;

            //Por defecto las columnas se visualizan
            this.Visible = true;
            //this.HeaderBackColor =
        }

        public ParametrosColumna(string nombre, string encabezado, bool visible, int posicion, int ancho, bool redimensionable, bool fija, DataGridViewContentAlignment alineacion, DataGridViewContentAlignment alineacionEncabezado, string formato, object valorNulo, bool ajusteDeLinea)
            : this(nombre, encabezado, visible, posicion, ancho, redimensionable, fija, alineacion, alineacionEncabezado, formato, valorNulo, ajusteDeLinea, EnumEditable.Predeterminado)
        {
        }
        public ParametrosColumna(string nombre, string encabezado, bool visible, int posicion, int ancho, bool redimensionable, bool fija, DataGridViewContentAlignment alineacion, DataGridViewContentAlignment alineacionEncabezado, string formato, object valorNulo, bool ajusteDeLinea, EnumEditable editable)
            : this(nombre, encabezado)
        {
            this.AlineacionEncabezado = alineacionEncabezado;
            this.Ancho = ancho;
            this.Estilo = this.GenerarEstilo(alineacion, formato, valorNulo, ajusteDeLinea);
            this.Fija = fija;
            this.Posicion = posicion;
            this.Redimensionable = redimensionable;
            this.Visible = visible;
            this.Editable = editable;
        }

        protected DataGridViewCellStyle GenerarEstilo(DataGridViewContentAlignment alineacion, string formato, object valorNulo, bool ajusteDeLinea)
        {
            DataGridViewCellStyle estilo = new DataGridViewCellStyle();
            estilo.Alignment = alineacion;
            estilo.Format = formato;
            estilo.NullValue = valorNulo;
            estilo.WrapMode = ajusteDeLinea ? DataGridViewTriState.True : DataGridViewTriState.False;

            return estilo;
        }

        
        public Color HeaderBackColor { get; set; }

        /// <summary>
        /// Alineacion del encabezado de la columna
        /// </summary>
        public DataGridViewContentAlignment AlineacionEncabezado { get; set; }

        /// <summary>
        /// Especifica la configuración de edición para la columna
        /// </summary>
        public EnumEditable Editable { get; set; }

        /// <summary>
        /// Ancho inicial de la columna (en pixeles).
        /// Solo se asigna el ancho inicial si la propiedad Autoajustable esta en false.
        /// </summary>
        public virtual int Ancho { get; set; }

        /// <summary>
        /// Encabezado visible de la columna.
        /// </summary>
        public string Encabezado { get; set; }

        /// <summary>
        /// Devuelve el estilo de la columna
        /// </summary>
        public DataGridViewCellStyle Estilo { get; protected set; }

        /// <summary>
        /// Indica si la columna permanecerá fija al mover el scroll, solamente pueden permanecer fijas
        /// las columnas consecutivas iniciales desde la izquierda
        /// </summary>
        public bool Fija { get; set; }

        /// <summary>
        /// Nombre de la columna.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Posicion de la columna, iniciando en cero.
        /// </summary>
        public int Posicion { get; set; }

        /// <summary>
        /// Indica si el usuario puede cambiar el tamaño de las columnas
        /// </summary>
        public bool Redimensionable { get; set; }

        /// <summary>
        /// Indica si el usuario puede cambiar el tamaño de las columnas (DataGridViewTriState)
        /// </summary>
        public DataGridViewTriState Resizable
        {
            get
            {
                return this.Redimensionable ? DataGridViewTriState.True : DataGridViewTriState.False;
            }
        }

        /// <summary>
        /// Indica si la columna se visualizara o no.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Indica si la columna ajusta automaticamente su tamaño segun el tamño disponible en la pantalla
        /// </summary>
        //public bool Autoajustable { get; set; }

        /// <summary>
        /// Indica si la columna ajusta automaticamente su tamaño segun el tamño disponible en la pantalla (DataGridViewAutoSizeColumnMode)
        /// </summary>
        //public DataGridViewAutoSizeColumnMode AutoSizeMode
        //{
        //    get
        //    {
        //        return this.Autoajustable ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.NotSet;
        //    }
        //}

        public int CompareTo(ParametrosColumna otro)
        {
            if(this.Posicion > otro.Posicion)
                return 1;
            else if (this.Posicion < otro.Posicion)
                return -1;
            else
                return 0;
        }
    }

    /// <summary>
    /// Clase que define columnas de acciones de una grilla.
    /// Las acciones pueden ser representadas mediante imagenes o botones, 
    /// pudiendo haber una o mas acciones por cada columna de acción
    /// </summary>
    public class ParametrosColumnaAccion : ParametrosColumna
    {
        public ParametrosColumnaAccion(string identificadorUnico, string encabezado)
            : base(identificadorUnico, encabezado)
        {
            AccionesColumna = new List<AccionColumna>();
            Estilo = GenerarEstilo(DataGridViewContentAlignment.NotSet, null, null, false);
        }

        public ParametrosColumnaAccion(string identificadorUnico, string encabezado, string texto, string tooltip)
            : base(identificadorUnico, encabezado)
        {
            AccionesColumna = new List<AccionColumna>();
            Estilo = GenerarEstilo(DataGridViewContentAlignment.NotSet, null, null, false);
            
            this.AgregarAccionBoton(identificadorUnico, texto, tooltip);
        }

        public ParametrosColumnaAccion(string identificadorUnico, string encabezado, string rutaImagen, string texto, string tooltip)
            : this(identificadorUnico, encabezado, texto, tooltip)
        {
            this.AccionesColumna[this.AccionesColumna.Count - 1].RutaImagen = rutaImagen;
        }

        public ParametrosColumnaAccion(string identificadorUnico, string encabezado, string texto)
            : base(identificadorUnico, encabezado)
        {
            AccionesColumna = new List<AccionColumna>();
            Estilo = GenerarEstilo(DataGridViewContentAlignment.NotSet, null, null, false);
            
            this.AgregarAccionCheckbox(identificadorUnico, texto);
        }

        internal List<AccionColumna> AccionesColumna { get; private set; }

        /// <summary>
        /// Agrega una nueva acción de tipo botón a la columna. Cada acción sera visualizada en el orden en que se agregan.
        /// </summary>
        /// <param name="identificadorUnico">Texto que representa el identificador único de la acción(debe ser único entre todas las acciones de la grilla)</param>
        /// <param name="texto">Representa el texto a mostrar en el botón</param>
        /// <param name="tooltip">Representa el tooltip que se mostrará cuando el usuario pone el cursor del mouse ensima del botón</param>
        public void AgregarAccionBoton(string identificadorUnico, string texto, string tooltip)
        {
            ValidarNuevaAccion(identificadorUnico);

            this.AccionesColumna.Add(new AccionColumna(identificadorUnico.Trim(), texto, tooltip, TipoControlAccion.Boton));
        }

        public void AgregarAccionBotonEditar(string identificadorUnico, string texto, string tooltip)
        {
            ValidarNuevaAccion(identificadorUnico);

            this.AccionesColumna.Add(new AccionColumna(identificadorUnico.Trim(), texto, tooltip, TipoControlAccion.BotonEditar));
        }

        public void AgregarAccionBotonEliminar(string identificadorUnico, string texto, string tooltip)
        {
            ValidarNuevaAccion(identificadorUnico);

            this.AccionesColumna.Add(new AccionColumna(identificadorUnico.Trim(), texto, tooltip, TipoControlAccion.BotonEliminar));
        }

        /// <summary>
        /// Agrega una nueva acción de tipo imagen a la columna. Cada acción sera visualizada en el orden en que se agregan.
        /// </summary>
        /// <param name="identificadorUnico">Texto que representa el identificador único de la acción(debe ser único entre todas las acciones de la grilla)</param>
        /// <param name="rutaImagen">Ruta relativa y nombre de la imagen a mostrar</param>
        /// <param name="texto">Representa el texto a mostrar en lugar de la imagen, si la imagen no se puede mostrar</param>
        /// <param name="tooltip">Representa el tooltip que se mostrará cuando el usuario pone el cursor del mouse ensima del botón</param>
        public void AgregarAccionImagen(string identificadorUnico, string rutaImagen, string texto, string tooltip)
        {
            ValidarNuevaAccion(identificadorUnico);

            this.AccionesColumna.Add(new AccionColumna(identificadorUnico, rutaImagen, texto, tooltip, TipoControlAccion.Imagen));
        }

        /// <summary>
        /// Agrega una nueva acción de tipo checkbox a la columna. Cada acción sera visualizada en el orden en que se agregan.
        /// </summary>
        /// <param name="identificadorUnico">Texto que representa el identificador único de la acción(debe ser único entre todas las acciones de la grilla)</param>
        /// <param name="texto">Representa el texto a mostrar al lado del checkbox</param>
        public void AgregarAccionCheckbox(string identificadorUnico, string texto)
        {
            ValidarNuevaAccion(identificadorUnico);

            this.AccionesColumna.Add(new AccionColumna(identificadorUnico.Trim(), texto, string.Empty, TipoControlAccion.Checkbox));
        }

        /// <summary>
        /// Verifica si la acción cuyo identificador se pasa como parámetro existe dentro de la lista de acciones de la columna.
        /// En caso de existir arroja una excepcion.
        /// </summary>
        /// <param name="identificadorUnico">Identificador único de la acción</param>
        private void ValidarNuevaAccion(string identificadorUnico)
        {
            if (String.IsNullOrWhiteSpace(identificadorUnico.Trim()) || this.AccionesColumna.Exists(a => a.Identificador.Equals(identificadorUnico.Trim())))
            {
                throw new ApplicationException("Ya existe una acción en la grilla con el identificador: " + identificadorUnico.Trim());
            }
        }

        //public override int Ancho
        //{
        //    get
        //    {
        //        int ancho = 0;
        //        foreach (var item in this.AccionesColumna)
        //        {
        //            ancho = item.a
                    
        //        }
        //        return base.Ancho;
        //    }
        //    set
        //    {
        //        base.Ancho = value;
        //    }
        //}

    }

    /// <summary>
    /// Especifica la configuración de editable para grillas o columnas
    /// </summary>
    public enum EnumEditable
    {
        Predeterminado = 0,
        Editable = 1,
        NoEditable = 2
    }

    /// <summary>
    /// Clase que representa la acción a insertar dentro de una columna accion de una grilla.
    /// </summary>
    internal class AccionColumna
    {
        private AccionColumna(string identificador, string tooltip, TipoControlAccion tipoControlAccion)
        {
            this.Identificador = identificador;
            this.TipoControlAccion = tipoControlAccion;
            this.Tooltip = tooltip;
        }

        public AccionColumna(string identificador, string texto, string tooltip, TipoControlAccion tipoControlAccion)
            : this(identificador, tooltip, tipoControlAccion)
        {
            this.Texto = texto;
        }

        public AccionColumna(string identificador, string rutaImagen, string texto, string tooltip, TipoControlAccion tipoControlAccion)
            : this(identificador, texto, tooltip, tipoControlAccion)
        {
            this.RutaImagen = rutaImagen;
        }

        public string Identificador { get; set; }

        public string RutaImagen { get; set; }

        public string Texto { get; set; }

        public TipoControlAccion TipoControlAccion { get; private set; }

        public string Tooltip { get; set; }
    }

    /// <summary>
    /// Enumeracion para indicar el tipo de control a utilizar en una acción.
    /// Por ahora solo se permiten 2 tipos de controles de acciones, luego seran mas.
    /// </summary>
    public enum TipoControlAccion
    {
        Boton,
        Imagen,
        Checkbox,
        BotonEditar,
        BotonEliminar,
        BotonBaja
    }

    /// <summary>
    /// Argumentos del evento Accion
    /// </summary>
    public class AccionEventArgs : EventArgs
    {
        public AccionEventArgs(string accion, int rowIndex)
        {
            this.Accion = accion;
            this.RowIndex = rowIndex;
        }

        public string Accion { get; private set; }

        public int RowIndex { get; private set; }
    }

    public class BotonEditar : AppGest.ControlBase.Button
    {
        public BotonEditar()
            :base()
        {
            this.Text = "Editar";
            this.BackColor = Color.Transparent;
            this.Width = 70;
        }
        public static int Ancho
        {
            get { return 70; }
        }
    }
    public class BotonEliminar : AppGest.ControlBase.Button
    {
        public BotonEliminar()
            : base()
        {
            this.Text = "Quitar";
            this.BackColor = Color.Transparent;
            this.Width = 70;
        }
        public static int Ancho
        {
            get { return 70; }
        }
    }
    public class BotonBaja : AppGest.ControlBase.Button
    {
        public BotonBaja()
            : base()
        {
            this.Text = "Activar/Baja";
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.BackColor = Color.Transparent;
            this.Width = 98;
        }

        public static int Ancho
        {
            get { return 98; }
        }
    }

}