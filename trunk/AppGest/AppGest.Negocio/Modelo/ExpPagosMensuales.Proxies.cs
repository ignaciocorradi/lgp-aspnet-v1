using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;


namespace AppGest.Negocio.Modelo
{
    public class ProxyExpPagosMensEncab: ProxyRegistroEncab<ProxyExpPagosMensLinea>
    {
    }

    public class ProxyExpPagosMensLinea : ProxyRegistroDet
    {
        public Cliente Cliente;
        public Cochera Cochera;
        public Concepto Concepto;
        public Reg_Det LineaPrecio;
        public Reg_Det LineaContratado;
        public DateTime Periodo;

        protected override Dictionary<string, object> ObtenerEstado()
        {
            var estado = base.ObtenerEstado();
            estado["_abonado"] = _abonado;
            estado["_bonificacion"] = _bonificacion;
            estado["_comentario"] = _comentario;
            estado["_fechaPago"] = _fechaPago;
            estado["_precioOrig"] = _precioOrig;
            estado["_recargo"] = _recargo;
            estado["_saldo"] = _saldo;
            estado["_saldoOrig"] = _saldoOrig;

            return estado;
        }
        protected override void RecuperarEstado(Dictionary<string, object> estado)
        {
            base.RecuperarEstado(estado);

            _abonado = estado.Obtener("_abonado", (Decimal?) null);
            _bonificacion = estado.Obtener("_bonificacion", (Decimal?) null);
            _comentario = estado.Obtener("_comentario", (string) null);
            _fechaPago = estado.Obtener("_fechaPago", (DateTime?) null);
            _precioOrig = estado.Obtener("_precioOrig", 0M);
            _recargo = estado.Obtener("_recargo", (Decimal?) null);
            _saldo = estado.Obtener("_saldo", 0M);
            _saldoOrig = estado.Obtener("_saldoOrig", 0M);
        }


        public DateTime AltaCliente
        {
            get
            {
                return SiNulo<DateTime, Cliente>(Cliente, c => c.Alta, DateTime.Now);
            }
        }
        public string NombreCompleto
        {
            get
            {
                return SiNulo<string, Cliente>(Cliente, c => c.NombreCompleto, string.Empty);
            }
        }
        public string NroCochera
        {
            get
            {
                return SiNulo<string, Cochera>(Cochera, c => c.NroCochera, string.Empty);
            }
        }
        public string ConceptoNombre
        {
            get 
            {
                return SiNulo<string, Concepto>(this.Concepto, c => c.Nombre, string.Empty);
            }
        }
        public string PeriodoStr
        {
            get
            {
                return SiNulo<string, DateTime>(this.Periodo, c => c.ToString("MM-yyyy"), string.Empty);
            }
        }
        public decimal Abonado
        {
            get
            {
                return _abonado.HasValue ? _abonado.Value : SiNulo<Decimal, Reg_Det>(this.LineaPrecio, l => (l.Precio ?? (decimal?) 0).Value, 0M);
            }
            set
            {
                _abonado = Decimal.Round(value, 2);
            }
        }   Decimal? _abonado;
        public decimal Recargo
        {
            get
            {
                return _recargo.HasValue ? _recargo.Value : SiNulo<Decimal, Reg_Det>(this.Linea, l => (l.ValNum3 ?? (decimal?)0).Value, 0M);
            }
            set
            {
                _recargo = Decimal.Round(value, 2);
            }
        }   Decimal? _recargo;
        public decimal Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = Decimal.Round(value, 2);
            }
        }   Decimal _saldo = 0;

        public decimal SaldoOrig
        {
            get
            {
                return _saldoOrig;
            }
            set
            {
                _saldoOrig = Decimal.Round(value, 2);
            }
        }   Decimal _saldoOrig = 0;
        public decimal PrecioOrig
        {
            get
            {
                return _precioOrig;
            }
            set
            {
                _precioOrig = Decimal.Round(value, 2);
            }
        }   Decimal _precioOrig;
        public decimal Bonificacion
        {
            get
            {
                return _bonificacion.HasValue ? _bonificacion.Value : SiNulo<Decimal, Reg_Det>(this.Linea, l => (l.ValNum1 ?? (decimal?)0).Value, 0M);
            }
            set
            {
                _bonificacion = Decimal.Round(value, 2);
            }
        }   Decimal? _bonificacion = 0M;
        public DateTime FechaPago
        {
            get
            {
                _fechaPago = _fechaPago ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.ValFecha1, null);
                return _fechaPago.HasValue ? _fechaPago.Value : (DateTime) DateTime.MinValue;
            }
            set
            {
                _fechaPago = value;
            }
        }   DateTime? _fechaPago;


        public string Comentario
        {
            get
            {
                _comentario = _comentario ?? SiNulo<string, Reg_Det>(this.Linea, l => l.ValText1, string.Empty);
                return _comentario;
            }
            set
            {
                _comentario = value;
            }
        }   string _comentario;

        public Concepto CptoRelVehiculo { get; set; }
        public string NombreVehiculo 
        {
            get
            {
                var Vehiculos = LineaContratado.Reg_encab.Reg_Det.Where(r => r.Concepto == this.CptoRelVehiculo).ToList();

                if (Vehiculos.Count == 0 || (Vehiculos.Count > 0 && Vehiculos[0].ValLista1 == null))
                    return " [Sin vehículos]";
                else
                    return string.Join(", ", Vehiculos.Select(x => " [" + ((Vehiculo)x.ValLista1).Nombre + " - " + ((Vehiculo)x.ValLista1).Marca + "]").ToArray());
            } 
        }
        public string ClienteYVehiculos { get { return this.NombreCompleto + this.NombreVehiculo; } }
    }

}

