using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    public class ExpFactura : ExpertoRegistro
    {
        #region -- Propiedades --
        /// <summary>
        /// Representa un concepto de transacción para el registro de Facturas.
        /// </summary>
        public Concepto CptoTransaccionFactura { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.REGISTRO_FACTURA); } }
        #endregion

        public Reg_encab Nuevo()
        {
            return this.Nuevo(this.CptoTransaccionFactura);
        }

        public List<ProxyPagoIngresosEgresosVariosDetalle> ListarCobros(Concepto cptoListaPrecioCobro, FiltrosDatos filtro, DateTime? fechaDesde = null,
            DateTime? fechaHasta = null, Persona cliente = null,
            DateTime? fVtoDesde = null, DateTime? fVtoHasta = null,
            DateTime? fRegDesde = null, DateTime? fRegHasta = null)
        {
            List<ProxyPagoIngresosEgresosVariosDetalle> rdoPago;
            List<ProxyPagoIngresosEgresosVariosDetalle> rdo = new List<ProxyPagoIngresosEgresosVariosDetalle>();
            using (var exp = FabExpertos.Inst.Obtener<ExpPagosIngresosEgresos>(this))
            {
                rdoPago =exp.ListarCobros(cptoListaPrecioCobro, filtro, fechaDesde,fechaHasta, cliente, fVtoDesde, fVtoHasta ,fRegDesde, fRegHasta );
            }
            var linFac = (from f in Persistidor.ListaRegDet<Reg_Det>()
                         where f.ValNum4.HasValue 
                         && (cliente == null || f.EntidadAfectada1.Id == cliente.Id)
                         && (cptoListaPrecioCobro == null || f.Concepto.Id == cptoListaPrecioCobro.Id)
                         select f.ValNum4).ToList();

            foreach (var item in rdoPago)
            {
                if (!linFac.Contains(item.IdRegistro))
                {
                    rdo.Add(item);
                }
            }

            return rdo;
        }


        public List<ProxyFacturaEncab> ListarFacturas(Persona cliente, FiltrosDatos filtro, string nrofactura,
            DateTime? fechaDesde = null,DateTime? fechaHasta = null, 
            DateTime? fVtoDesde = null, DateTime? fVtoHasta = null,
            DateTime? fRegDesde = null, DateTime? fRegHasta = null)
        {
            long idCliente = cliente.Id;
            long idCpto = this.CptoTransaccionFactura.Id;
            List<ProxyFacturaEncab> rdoPago;
            List<ProxyFacturaEncab> rdo = new List<ProxyFacturaEncab>();
            

            var reg = Persistidor.ListaRegEncab<Reg_encab>(d => d.Concepto.Id == idCpto
                && d.EntidadAfectada.Id == idCliente
                && ((nrofactura.Length==0)  || (d.Identificador.Contains(nrofactura)))
                && (fechaDesde == null   || d.FechaRegistro >= fechaDesde) //FechaPago
                && (fechaHasta == null   || d.FechaRegistro <= fechaHasta)
                ).ToList();

            return rdo;
        }

        public void Guardar(ProxyFacturaEncab proxy)
        {
            ValidarLineasAQuitar(proxy.LineasAQuitar);

            var encab = CargarPagos(proxy);

            Guardar(encab);

            Persistidor.Confirmar();

        }

        private void ValidarLineasAQuitar(IList<ProxyFacturaLinea> lineasAQuitar)
        {
            //TODO: Ver que hacemos.  
        }
        private Reg_encab CargarPagos(ProxyFacturaEncab proxy)
        {
            Reg_encab encab = null;
            if (proxy.Encabezado.Id == 0)
            {
                encab = this.Nuevo();
                encab.FechaAlta = DateTime.Now;

            }
            else
            {
                encab = Persistidor.ObtenerTransaccionPorId<Reg_encab>(proxy.Encabezado.Id);
                encab.FechaModif = DateTime.Now;
            }

            encab.Identificador = proxy.NroFactura;
            encab.Tipo = (int)proxy.TipoComprobante;
            encab.Comentario = proxy.Comentario;
            encab.FechaRegistro = proxy.FechaRegistro;

            //Elimino las lineas
            foreach (ProxyFacturaLinea lnElim in proxy.LineasAQuitar)
            {
                Reg_Det ln = (from r in encab.Reg_Det
                             where r.Id == lnElim.IdRegDet
                             select r).FirstOrDefault(); 

                if(ln != null)
                    encab.Reg_Det.Remove(ln);
            }

            //Actualizo las existentes
            foreach (ProxyFacturaLinea proxyDetalle in proxy.Detalles)
            {
                // Buscar todas las entidades y asignarlas ahora. 
                var cpto = this.Persistidor.ObtenerEntidadPorId<Concepto>(proxyDetalle.Concepto.Id);
                Reg_Det linea;
                if (proxyDetalle.EsNuevo)
                {
                    linea = this.NuevoDetalle();
                    linea.FechaAlta = DateTime.Now;

                }
                else
                {
                    linea = encab.Reg_Det.Where(r => r.Id == proxyDetalle.IdRegistro).FirstOrDefault();
                    linea.FechaModif = DateTime.Now;
                }

                //Realizo la actualizacion de los valores de las propiedades
                linea.Comentario = proxyDetalle.Comentario;
                linea.SetConcepto(cpto);
                linea.Cantidad = 1;
                linea.Precio = proxyDetalle.Importe;
                linea.Importe = proxyDetalle.Importe;
                linea.ValNum1 = proxyDetalle.Abonado;
                linea.ValFecha1 = proxyDetalle.FechaPago;
                linea.ValFecha3 = proxyDetalle.FechaServicio;
                linea.ValFecha2 = proxyDetalle.FechaVencimiento;
                //asignación de la linea de Ingreso o Egreso que se está facturando.
                linea.ValNum4 = proxyDetalle.LineaIE.IdRegistro;

                if (proxyDetalle.Cliente != null)
                {
                    var cli = this.Persistidor.ObtenerEntidadPorId<Cliente>(proxyDetalle.Cliente.Id);
                    linea.SetEntidadAfectada1(cli);
                }
               

                this.AsignarRegistroDetalle(encab, linea, cpto);

            }
            return encab;
        }


    }

    public class ProxyFacturaEncab : ProxyRegistroEncab<ProxyFacturaLinea>
    {
        List<ProxyFacturaLinea> _detalles = new List<ProxyFacturaLinea>();
         
        public ProxyFacturaEncab(Reg_encab enc)
            : base(enc)
        { }
        public string NroFactura { get; set; }
        public TipoFactura TipoComprobante { get; set; }
        public Cliente Cliente { get; set; }
        public string Comentario { get; set; }
        public Reg_encab RegEncab { get { return this.Encabezado; } }

        public List<ProxyFacturaLinea> Detalles
        {
            get
            {
                return _detalles;
            }
        }
        public List<ProxyFacturaLinea> LineasAQuitar = new List<ProxyFacturaLinea>();


        public void QuitarLinea(ProxyFacturaLinea linea)
        {
            // No se quita de la entidad, ya que de eso se encarga el experto.
            linea.DardeBaja();
            LineasAQuitar.Add(linea);
            this._detalles.Remove(linea);
        }
    }
    public class ProxyFacturaLinea : ProxyRegistroDet
    {
        protected Reg_Det _registroDetalle;
        public ProxyPagoIngresosEgresosVariosDetalle LineaIE { get; set; }

        #region Prop
        /// <summary>
        /// Nro de factura en la liena. ValText1
        /// </summary>
        public string NroFactura 
        {
            get
            {
                if (_nroFactura == null)
                {
                    _nroFactura = SiNulo<string, Reg_Det>(this._registroDetalle, d => d.ValText1, string.Empty);
                }

                
                return _nroFactura;
            }
            set { _nroFactura = value; } 
        }string _nroFactura = string.Empty;

        /// <summary>
        /// TipoComprobante en la linea. ValNum4
        /// </summary>
        public TipoFactura TipoComprobante
        {
            get
            {
                if (_tipoFactura == null)
                {
                    _tipoFactura =SiNulo<int, Reg_Det>(this._registroDetalle, d => (int)d.ValNum4, 0);
                }
                 
                return  (TipoFactura)_tipoFactura;
            }
            set { _tipoFactura = (int)value; }

        }int? _tipoFactura =  (int)TipoFactura.A;
        #endregion
        public ProxyFacturaLinea(Reg_Det registroDetalle, ProxyFacturaEncab parent, ProxyPagoIngresosEgresosVariosDetalle lineaIE)
            :this(registroDetalle, parent)
        {
            this.LineaIE = lineaIE;
            AsignarIE();
        }


        public ProxyFacturaLinea(Reg_Det registroDetalle, ProxyFacturaEncab parent)
        {
            this._registroDetalle = registroDetalle;
            this.Parent = parent;
            this.Parent.Detalles.Add(this);
        }


        private void AsignarIE()
        {
            if (_registroDetalle.Id == 0)
            {
                _registroDetalle.FechaAlta = DateTime.Now;
            }
            _registroDetalle.FechaModif = DateTime.Now;

            //Realizo la actualizacion de los valores de las propiedades
            _registroDetalle.Comentario = LineaIE.Comentario;
            _registroDetalle.SetConcepto(LineaIE.Concepto);
            _registroDetalle.Cantidad = LineaIE.Cantidad;
            _registroDetalle.Precio = LineaIE.Importe;
            _registroDetalle.Importe = LineaIE.Importe;
            _registroDetalle.ValNum1 = LineaIE.Abonado;
            _registroDetalle.ValFecha1 = LineaIE.FechaPago;
            _registroDetalle.ValFecha3 = LineaIE.FechaServicio;
            _registroDetalle.ValFecha2 = LineaIE.FechaVencimiento;
            //asignación de la linea de Ingreso o Egreso que se está facturando.
            _registroDetalle.ValNum4 = LineaIE.IdRegistro;

            if (LineaIE.Cliente != null)
            {
                _registroDetalle.SetEntidadAfectada1(LineaIE.Cliente);
            }
        }
        public const string PROP_NOMBRE_CLIENTE = "NombreCliente";
        public string NombreCliente
        {
            get
            {
                return SiNulo<string, Persona>(this.Cliente, p => p.NombreCompleto, string.Empty);
            }
        }

        public const string PROP_COMENTARIO = "Comentario";
        public string Comentario
        {
            get
            {
                if (_comentario == null)
                {
                    _comentario = SiNulo<string, Reg_Det>(this._registroDetalle, d => d.Comentario, string.Empty);
                }

                return _comentario;
            }
            set
            {
                _comentario = value;
            }
        } private string _comentario;

        public const string PROP_CONCEPTO_EGRESO = "ConceptoEgreso";
        public string ConceptoEgreso
        {
            get
            {
                return this.Concepto != null ? this.Concepto.Nombre : string.Empty;
            }
        }

        public Concepto Concepto
        {
            get
            {
                if (_concepto == null)
                {
                    _concepto = this._registroDetalle != null ? SiNulo<Concepto, Reg_Det>(this._registroDetalle, r => r.Concepto as Concepto, null) : null;

                    if (_concepto == null)
                    {
                        _concepto = this.LineaIE.Concepto;
                    }
                }
                return _concepto;
            }
            set
            {
                _concepto = value;
            }
        } private Concepto _concepto;

        public Persona Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = this._registroDetalle != null ? SiNulo<Persona, Reg_Det>(this._registroDetalle, r => r.EntidadAfectada1 as Persona, null) : null;

                    if (_cliente == null)
                    {
                        _cliente = this.LineaIE.Cliente;
                    }
                }
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        } private Persona _cliente;


        public const string PROP_FECHABAJA = "FechaBaja";
        public DateTime? FechaBaja
        {
            get
            {
               
                return SiNulo<DateTime?, Reg_Det>(this._registroDetalle, d => d.FechaBaja, null);;
            }

        } 

        
        public const string PROP_FECHA_PAGO = "FechaPago";
        public DateTime? FechaPago
        {
            get
            {
                if (_fechaPago == null)
                {
                    _fechaPago = SiNulo<DateTime?, Reg_Det>(this._registroDetalle, d => d.ValFecha1, null);
                }

                return _fechaPago;
            }
            set
            {
                _fechaPago = value;
            }
        } private DateTime? _fechaPago;

        public const string PROP_FECHA_SERVICIO = "FechaServicio";
        public DateTime? FechaServicio
        {
            get
            {
                if (_fechaServicio == null)
                {
                    _fechaServicio = SiNulo<DateTime?, Reg_Det>(this._registroDetalle, d => d.ValFecha3, null);
                }

                return _fechaServicio;
            }
            set
            {
                _fechaServicio = value;
            }
        } private DateTime? _fechaServicio;

        public const string PROP_FECHA_VENCIMIENTO = "FechaVencimiento";
        public DateTime? FechaVencimiento
        {
            get
            {
                if (_fechaVencimiento == null)
                {
                    _fechaVencimiento = SiNulo<DateTime?, Reg_Det>(this._registroDetalle, d => d.ValFecha2, null);
                }

                return _fechaVencimiento;
            }
            set
            {
                _fechaVencimiento = value;
            }
        } private DateTime? _fechaVencimiento;

        public const string PROP_IMPORTE = "Importe";
        public decimal Importe
        {
            get
            {
                if (!_importe.HasValue)
                {
                    _importe = SiNulo<decimal?, decimal?>(this._registroDetalle.Importe, i => i.Value, 0);
                }

                return _importe.Value;
            }
            set
            {
                _importe = value;
            }
        } private decimal? _importe;


        public bool EsNuevo { get { return _registroDetalle.Id == 0; } }

        public long IdRegistro { get { return _registroDetalle.Id; } }

        public const string PROP_ABONADO = "Abonado";
        public decimal Abonado
        {
            get
            {
                if (!_abonado.HasValue)
                {
                    _abonado = SiNulo<decimal?, decimal?>(this._registroDetalle.ValNum1, i => i.Value, 0);
                }

                return _abonado.Value;
            }
            set
            {
                _abonado = value;
            }
        } decimal? _abonado;

        public ProxyFacturaEncab Parent { get; set; }

        public Reg_Det GetRegistroDetalle()
        {
            _registroDetalle.Comentario = this.Comentario;
            _registroDetalle.SetConcepto(this.Concepto);
            _registroDetalle.Importe = this.Importe;
            _registroDetalle.ValNum1 = this.Abonado;
            _registroDetalle.ValFecha1 = this.FechaPago;
            _registroDetalle.ValFecha2 = this.FechaVencimiento;
            _registroDetalle.ValFecha3 = this.FechaServicio;
            _registroDetalle.ValNum4 = (decimal)this.TipoComprobante;
            _registroDetalle.ValText1 = this.NroFactura;

            if (this.Cliente != null && this.Cliente.Id > 0)
            {
                _registroDetalle.SetEntidadAfectada1(this.Cliente);
            }
            else
            {
                _registroDetalle.SetEntidadAfectada1(null);
            }

            return _registroDetalle;
        }



        public void ActualizarLinea(ProxyFacturaLinea linea)
        {
            var detDb = linea.GetRegistroDetalle();//enc.Detalles.First(d => d.IdRegistro  == _registroDetalle.Id);

            detDb.Comentario = this.Comentario;
            detDb.SetConcepto(this.Concepto);
            detDb.Importe = this.Importe;
            detDb.ValNum1 = this.Abonado;
            detDb.ValFecha1 = this._fechaPago;
            detDb.ValFecha2 = this._fechaVencimiento;
            detDb.ValFecha3 = this._fechaServicio;
            detDb.ValText1 = this.NroFactura;
            detDb.ValNum4 = (decimal)this.TipoComprobante;

            if (this.Cliente != null && this.Cliente.Id > 0)
            {
                detDb.SetEntidadAfectada1(this.Cliente);
            }
            else
            {
                detDb.SetEntidadAfectada1(null);
            }
        }


        public void DardeBaja()
        {
            this._registroDetalle.FechaBaja = DateTime.Now;
        }
    }
}
