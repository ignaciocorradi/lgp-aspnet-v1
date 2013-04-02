using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;


namespace AppGest.Negocio.Modelo
{
    public class ProxyExpParamsEgresoEmpleadoEncab : ProxyRegistroEncab<ProxyExpParamsEgresoEmpleadoLinea>
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

    public class ProxyExpParamsEgresoEmpleadoLinea : ProxyRegistroDet
    {
        public Empleado Empleado;
        public Concepto Concepto;

        protected override Dictionary<string, object> ObtenerEstado()
        {
            var estado = base.ObtenerEstado();
            estado["_importe"] = _importe;
            estado["_alta"] = _alta;
            estado["_desde"] = _desde;
            estado["_hasta"] = _hasta;
            estado["_fechaBaja"] = _fechaBaja;
            estado["_comentario"] = _comentario;

            return estado;
        }

        protected override void RecuperarEstado(Dictionary<string, object> estado)
        {
            base.RecuperarEstado(estado);

            _importe = estado.Obtener("_importe", (Decimal?) null);
            _alta = estado.Obtener("_alta", (DateTime?) null);
            _desde = estado.Obtener("_desde", (DateTime?)null);
            _hasta = estado.Obtener("_hasta", (DateTime?)null);
            _comentario = estado.Obtener("_comentario", (string) null);
            _fechaBaja = estado.Obtener("_fechaBaja", (DateTime?) null);
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

        public DateTime Desde
        {
            get
            {
                _desde = _desde ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.ValFecha1, null);
                return _desde.HasValue ? _desde.Value : (DateTime)DateTime.MinValue;
            }
            set
            {
                _desde = (DateTime?) value;
            }
        }   DateTime? _desde;

        public DateTime Hasta
        {
            get
            {
                _hasta = _hasta ?? SiNulo<DateTime?, Reg_Det>(this.Linea, l => l.ValFecha2, null);
                return _hasta.HasValue ? _hasta.Value : (DateTime)DateTime.MinValue;
            }
            set
            {
                _hasta = (DateTime?) value;
            }
        }   DateTime? _hasta;

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
    }

}

