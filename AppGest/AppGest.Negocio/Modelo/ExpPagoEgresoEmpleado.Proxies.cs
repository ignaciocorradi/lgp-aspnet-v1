using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;


namespace AppGest.Negocio.Modelo
{
    public class ProxyExpPagoEgresoEmpleadoEncab : ProxyRegistroEncab<ProxyExpPagoEgresoEmpleadoLinea>
    {
        public Empleado Empleado;
        public Empleado Registro;

        public string NombreCompleto
        {
            get
            {
                return SiNulo<string, Empleado>(Empleado, c => c.NombreCompleto, string.Empty);
            }
        }
    }

    public class ProxyExpPagoEgresoEmpleadoLinea : ProxyRegistroDet
    {
        public Empleado Empleado;
        public Concepto Concepto;
        public Concepto Momento;

        protected override Dictionary<string, object> ObtenerEstado()
        {
            var estado = base.ObtenerEstado();
            estado["_importe"] = _importe;
            estado["_alta"] = _alta;
            estado["_periodo"] = _periodo;
            estado["_fechaBaja"] = _fechaBaja;
            estado["_comentario"] = _comentario;
            estado["_momento"] = Momento;
            estado["_fechaPago"] = _fechaPago;

            return estado;
        }
        protected override void RecuperarEstado(Dictionary<string, object> estado)
        {
            base.RecuperarEstado(estado);

            _importe = estado.Obtener("_importe", (Decimal?) null);
            _alta = estado.Obtener("_alta", (DateTime?) null);
            _periodo = estado.Obtener("_periodo", (DateTime?)null);
            _comentario = estado.Obtener("_comentario", (string) null);
            _fechaBaja = estado.Obtener("_fechaBaja", (DateTime?) null);
            Momento = estado.Obtener("_momento", (Concepto) null);
            _fechaPago = estado.Obtener("_fechaPago", (DateTime?) null);
        }


        public string NombreCompleto
        {
            get
            {
                return SiNulo<string, Empleado>(Empleado, c => c.NombreCompleto, string.Empty);
            }
        }
        
        public string ConceptoNombre
        {
            get 
            {
                return SiNulo<string, Concepto>(this.Concepto, c => c.Nombre, string.Empty);
            }
        }
        public string MomentoNombre
        {
            get
            {
                return SiNulo<string, Concepto>(this.Momento, m => m.Nombre, string.Empty);
            }
        }
        
        public decimal Importe
        {
            get
            {
                return  _importe.HasValue ? _importe.Value : SiNulo<Decimal, Reg_Det>(this.Linea, l => (l.Precio ?? (decimal?) 0).Value, 0M);
            }
            set
            {
                _importe = (Decimal?) Decimal.Round(value, 2);
            }
        }   Decimal? _importe;
        public DateTime Alta
        {
            get
            {
                _alta = _alta ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.FechaAlta, null);
                return _alta.HasValue ? _alta.Value : (DateTime) DateTime.MinValue;
            }
            set
            {
                _alta = (DateTime?) value;
            }
        }   DateTime? _alta;
        public DateTime? FechaBaja
        {
            get
            {
                _fechaBaja = _fechaBaja ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.FechaBaja, null);
                return _fechaBaja;
            }
            set
            {
                _fechaBaja = value;
            }
        }   DateTime? _fechaBaja;
        public DateTime Periodo
        {
            get
            {
                _periodo = _periodo ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.ValFecha1, null);
                return _periodo.HasValue ? _periodo.Value : (DateTime)DateTime.MinValue;
            }
            set
            {
                _periodo = (DateTime?) value;
            }
        }   DateTime? _periodo;
        public string Comentario
        {
            get
            {
                _comentario = _comentario ?? SiNulo<string, Reg_Det>(this.Linea, l => l.Comentario, string.Empty);
                return _comentario;
            }
            set
            {
                _comentario = value;
            }
        }   string _comentario;

        public DateTime FechaPago
        {
            get
            {
                _fechaPago = _fechaPago ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.ValFecha2, null);
                return _fechaPago.HasValue ? _fechaPago.Value : (DateTime) DateTime.MinValue;
            }
            set
            {
                _fechaPago = (DateTime?)value;
            }
        }   DateTime? _fechaPago;
    }

}

