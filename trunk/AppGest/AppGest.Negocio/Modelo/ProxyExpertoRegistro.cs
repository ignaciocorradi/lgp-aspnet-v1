using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;

namespace AppGest.Negocio.Modelo
{
    public class ProxyExperto
    {
        Dictionary<string, object> _anterior = new Dictionary<string,object>();
        Dictionary<string, object> _original;
        public bool TieneCambios { get; private set;}

        public void IniciarCambios()
        {
            if (_original == null)
                GuardarOriginal();
            
            GuardarActual();
        }

        protected virtual Dictionary<string, object> ObtenerEstado()
        {
            var estado = new Dictionary<string, object>();
            return estado;
        }
        void GuardarOriginal()
        {
            var original = ObtenerEstado();
            _original = original;
        }
        void GuardarActual()
        {
            var actual = ObtenerEstado();
            _anterior = actual;
        }

        protected virtual void RecuperarEstado(Dictionary<string, object> estado)
        {
        }

        public void AceptarCambios()
        {
            _anterior.Clear();
            TieneCambios = true;
        }
        public void RechazarCambios()
        {
            if (_anterior.Count != 0)
                RecuperarEstado(_anterior);
        }

        public void VolverOriginal()
        {
            if (_original != null)
                RecuperarEstado(_original);
            
            TieneCambios = false;
        }

        protected TResultado SiNulo<TResultado, TEntidad>(TEntidad entidad, Func<TEntidad, TResultado> selector, TResultado valorSiNulo)
        {
            if (entidad == null)
                return valorSiNulo;
            else
                return selector.Invoke(entidad);

        }
    }
    public class ProxyRegistroEncab<TProxyLinea>: ProxyExperto
        where TProxyLinea: ProxyRegistroDet
    {
        internal Reg_encab Encabezado;

        public ProxyRegistroEncab(Reg_encab encabezado)
        {
            Encabezado = encabezado;
        }
        public ProxyRegistroEncab():this(null)
        {
        }
        protected override Dictionary<string, object> ObtenerEstado()
        {
            var estado = base.ObtenerEstado();
            estado["_fechaRegistro"] = _fechaRegistro;

            return estado;
        }
        protected override void RecuperarEstado(Dictionary<string, object> estado)
        {
            base.RecuperarEstado(estado);
            _fechaRegistro = estado.Obtener("_fechaRegistro", (DateTime?) null);
        }
        public long IdRegEncab
        {
            get
            {
                return SiNulo<long, Reg_encab>(Encabezado, l => l.Id, 0);
            }
        }

        public IList<TProxyLinea> Lineas = new List<TProxyLinea>();


        public DateTime? FechaRegistro
        {
            get
            {
                _fechaRegistro = _fechaRegistro ?? SiNulo<DateTime?, Reg_encab>(this.Encabezado, e => e.FechaRegistro, null);
                return _fechaRegistro;
            }
            set
            {
                _fechaRegistro = value;
            }
        }   DateTime? _fechaRegistro;

    }

    public class ProxyRegistroDet: ProxyExperto
    {
        internal Reg_Det Linea;
        internal Reg_encab Encabezado;
        public ProxyRegistroDet(Reg_encab encabezado, Reg_Det linea)
        {
            Encabezado = encabezado;
            Linea = linea;
        }
        public ProxyRegistroDet()
        {
            Encabezado = null;
            Linea = null;
        }

        public long IdRegDet
        {
            get
            {
                return SiNulo<long, Reg_Det>(Linea, l => l.Id, 0);
            }
        }

        internal static IList<TProxyLinea> CrearDesde<TProxyLinea, TProxyEncab, TMapeoProxy, TKeyEntidad>(IList<Reg_Det> lineas, PersistidorPredet persistidor)
            where TProxyLinea : ProxyRegistroDet, new()
            where TProxyEncab : ProxyRegistroEncab<TProxyLinea>
            where TKeyEntidad : KeyEntidad<TProxyEncab, TProxyLinea>,  new()
            where TMapeoProxy : MapeoRegistroProxy<TProxyEncab, TProxyLinea, TKeyEntidad>, new()
        {
            var proxies = new List<TProxyLinea>(lineas.Count);
            var mapeo = new TMapeoProxy();
            foreach (var linea in lineas)
            {
                var proxy = new TProxyLinea()
                {
                    Linea = linea,
                    Encabezado = linea.Reg_encab
                };

                mapeo.LLenarProxy(proxy, linea, persistidor);
                proxies.Add(proxy);
            }

            return proxies;
        }

        internal static IList<TProxyEncab> ObtenerEncabezados<TProxyLinea, TProxyEncab, TMapeoProxy, TKeyEntidad>(IList<TProxyLinea> lineas, PersistidorPredet persistidor)
            where TProxyLinea: ProxyRegistroDet
            where TProxyEncab: ProxyRegistroEncab<TProxyLinea>, new()
            where TKeyEntidad : KeyEntidad<TProxyEncab, TProxyLinea>, new()
            where TMapeoProxy : MapeoRegistroProxy<TProxyEncab, TProxyLinea, TKeyEntidad>, new()
        {
            var encabezados = new Dictionary<Reg_encab, TProxyEncab>();
            var mapeo = new TMapeoProxy();

            foreach(var linea in lineas)
            {
                TProxyEncab prxEncab;
                var key = linea.Encabezado;
                if (!encabezados.TryGetValue(key, out prxEncab))
                {
                    prxEncab = new TProxyEncab();
                    mapeo.LLenarProxy(prxEncab, linea.Encabezado, persistidor);
                    encabezados.Add(key, prxEncab);
                }
                prxEncab.Lineas.Add(linea);
            }

            return encabezados.Values.ToList(); ;
        }
    }

    public class ProxyExpertoEntidad : ProxyExperto
    {
    }
}
