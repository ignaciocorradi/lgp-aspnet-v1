#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using AppGest.Negocio.Modelo;
using AppGest.Negocio.Core;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace AppGest.Vista
{
    public partial class FrmMigracion : Form
    {
        private List<ClienteMensualProxy> _clientes;
        private List<PagosMensuales> _pagos;
        public FrmMigracion()
        {
            InitializeComponent();
        }
        void confgrilla()
        {
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dgvCStyle = new DataGridViewCellStyle();
            dgvCStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dgvCStyle.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvCStyle.ForeColor = System.Drawing.Color.White;
            dgvCStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
            dgvCStyle.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgClientes.AlternatingRowsDefaultCellStyle = dgvCStyle;

        }
        protected Guid IdSesion
        {
            get
            {
                return (Guid)(this.Context.Session["idSesion"] ?? Guid.Empty);
            }
            set
            {
                this.Context.Session["idSesion"] = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpMigracionLGP>(IdSesion))
            {
                _clientes = exp.ObtenerClientes();
                dgClientes.DataSource = _clientes;
                _pagos = exp.ObtenerPagosMensuales();
                dgPagos.DataSource = _pagos;
            }
            
        }

        private void btnImportarClientes_Click(object sender, EventArgs e)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpMigracionLGP>(IdSesion))
            {
                exp.ImportarClientesMensuales(_clientes);
            }

            try
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpMigracionLGP>(IdSesion))
                {
                    exp.ImportarPagosMensuales(_clientes, _pagos);
                }

            }
            catch (ValidacionException vex)
            {
                MessageBox.Show(vex.MessageCompleteConTitulo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}