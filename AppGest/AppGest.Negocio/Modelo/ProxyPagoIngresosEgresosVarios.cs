using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo
{
    public class ProxyPagoIngresosEgresosVarios : ProxyExperto
    {
        private Reg_encab _transaccionPagoEgresosVarios;
        

        public ProxyPagoIngresosEgresosVarios(Reg_encab transaccionPagoEgresosVarios, TipoServicio tipo)
        {
            this.Tipo = tipo;
            this._transaccionPagoEgresosVarios = transaccionPagoEgresosVarios;
        }

        public TipoServicio Tipo { get; private set; }

        private List<ProxyPagoIngresosEgresosVariosDetalle> _detalles;
        public List<ProxyPagoIngresosEgresosVariosDetalle> Detalles
        {
            get
            {
                if (_detalles == null)
                {
                    this.CargarDetalles();
                }

                return _detalles;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return Encabezado.FechaRegistro.Value;
            }
        }
        public string Comentario
        {
            get
            {
                return Encabezado.Comentario;
            }
            set
            {
                Encabezado.Comentario = value;
            }

        }

        public decimal Total
        {
            get
            {
                return _detalles != null ? _detalles.Sum(d => d.Importe) : 0;
            }
        }

        private void CargarDetalles()
        {
            _detalles = new List<ProxyPagoIngresosEgresosVariosDetalle>();

            foreach (Reg_Det registroDetalle in Encabezado.Reg_Det)
            {
                _detalles.Add(new ProxyPagoIngresosEgresosVariosDetalle(registroDetalle, this));
            }
        }

        public Reg_encab Encabezado
        {
            get
            {
                return _transaccionPagoEgresosVarios;
            }
        }

    }

    public class ProxyPagoIngresosEgresosVariosDetalle : ProxyRegistroDet
    {
        protected Reg_Det _registroDetalle;

        public ProxyPagoIngresosEgresosVariosDetalle()
        {
        }

        public ProxyPagoIngresosEgresosVariosDetalle(Reg_Det registroDetalle, ProxyPagoIngresosEgresosVarios parent)
        {
            this._registroDetalle = registroDetalle;
            this.Parent = parent;
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
                }
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        } private Persona _cliente;

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
                _fechaServicio  = value;
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

        public const string PROP_CANTIDAD = "Cantidad";
        public decimal Cantidad
        {
            get
            {
                if (!_cantidad.HasValue)
                {
                    _cantidad = SiNulo<decimal?, decimal?>(this._registroDetalle.Cantidad, i => i.Value, 0);
                }

                return _cantidad.Value;
            }
            set
            {
                _cantidad = value;
            }
        } private decimal? _cantidad;
        

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

        public ProxyPagoIngresosEgresosVarios Parent { get; set; }

        public virtual Reg_Det GetRegistroDetalle()
        {
            _registroDetalle.Comentario = this.Comentario;
            _registroDetalle.SetConcepto(this.Concepto);
            _registroDetalle.Importe = this.Importe;
            _registroDetalle.ValNum1 = this.Abonado;
            _registroDetalle.ValFecha1 = this.FechaPago;
            _registroDetalle.ValFecha2 = this.FechaVencimiento;
            _registroDetalle.ValFecha3 = this.FechaServicio;


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
        
        public virtual void ActualizarLinea(ProxyPagoIngresosEgresosVariosDetalle linea)
        {
            var detDb = linea.GetRegistroDetalle();//enc.Detalles.First(d => d.IdRegistro  == _registroDetalle.Id);

            detDb.Comentario = this.Comentario;
            detDb.SetConcepto(this.Concepto);
            detDb.Importe = this.Importe;
            detDb.ValNum1 = this.Abonado;
            detDb.ValFecha1 = this._fechaPago;
            detDb.ValFecha2 = this._fechaVencimiento;
            detDb.ValFecha3 = this._fechaServicio;

            if (this.Cliente != null && this.Cliente.Id > 0)
            {
                detDb.SetEntidadAfectada1(this.Cliente);
            }
            else
            {
                detDb.SetEntidadAfectada1(null);
            }
        }


    }
}
