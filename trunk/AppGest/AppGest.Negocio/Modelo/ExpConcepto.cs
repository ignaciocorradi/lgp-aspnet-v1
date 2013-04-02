using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Datos;
using AppGest.Util.Atributos;
using AppGest.Negocio.Core;
using AppGest.Util;


namespace AppGest.Negocio.Modelo
{
    /// <summary>
    /// Experto en conceptos. Gestiona ABM y todas las demas tareas sobre los conceptos
    /// </summary>
    public partial class ExpConcepto: ExpertoEB<Concepto>
    {
        /// <summary>
        /// Representa un concepto de transacción para el alta de precios.
        /// </summary>
        public Concepto CptoTransaccionPrecio { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.ALTA_LISTA_PRECIOS); } }


        /// <summary>
        /// Obtiene la consulta que devuelve las líneas de registros
        /// que corresponden al concepto de la línea y de la transacción especificados.
        /// </summary>
        /// <param name="idCptoLinea">ID del concepto de la línea buscada</param>
        /// <param name="idCptoTransaccion">ID del concepto de la transacción buscada (encabezado)</param>
        /// <param name="minValFecha1">(Opcional) Valor mínimo buscado en la propiedad ValFecha1. Si es nulo no se filtra</param>
        /// <param name="maxValFecha2">(Opcional) Valor máximo buscado en la propiedad ValFecha2. Si es nulo no se filtra</param>
        /// <returns></returns>
        public IEnumerable<Reg_Det> ObtenerLineasConcepto(long idCptoLinea, long idCptoTransaccion, DateTime? minValFecha1 = null, DateTime? maxValFecha2 = null)
        {

            var lineas = (from
                            regPrecio in Persistidor.Linq.Lineas<Reg_Det>()
                          where
                            regPrecio.Reg_encab.Concepto.Id == idCptoTransaccion
                            && regPrecio.Concepto.Id == idCptoLinea
                          select regPrecio
                                        );

            if (minValFecha1.HasValue)
                lineas = lineas.Where(linea => linea.ValFecha1.HasValue && minValFecha1.Value >= linea.ValFecha1.Value);

            if (maxValFecha2.HasValue)
                lineas = lineas.Where(linea => linea.ValFecha2.HasValue && maxValFecha2.Value >= linea.ValFecha2.Value);

            return lineas;
        }

        /// <summary>
        /// Obtiene un concepto de sistema a través de su valor enumerado. 
        /// </summary>
        /// <param name="valorEnum">valor de la enumeracion correspondiente al concepto de sistema a buscar</param>
        /// <returns>Concepto buscado</returns>
        public Concepto ObtenerConceptoSistema(Enum valorEnum)
        {
            int clase;
            int valor;

            Concepto.ObtenerClaseYValor(valorEnum, out clase, out valor);

            var cpto = Persistidor.Primero<Concepto>(c => c.Clase == clase && c.Valor == valor);
            return cpto;
        }


        /// <summary>
        /// Crea un nuevo Concepto con un Registro de Encabezado y un Registro de Detalle,
        /// especificando si el concepto creado es o no de sistema.
        /// El valor predeterminado es FALSE.
        /// </summary>
        /// <returns>Nuevo Concepto</returns>
        public Concepto Nuevo(bool deSistema)
        {
            var concepto = Nuevo();
            concepto.DeSistema = deSistema;

            return concepto;
        }

        public Reg_encab NuevoEncabPrecio(Concepto conceptoDeUsuario, bool agregarUnaFilaDetalle)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(IdSesion))
            {
                Reg_encab encab = exp.Nuevo(this.CptoTransaccionPrecio);
                if(agregarUnaFilaDetalle)
                    exp.Nuevo(encab,conceptoDeUsuario);
                return encab;
            }
        }


        public Reg_Det NuevoPrecio(Concepto conceptoDeUsuario, Reg_encab transaccion)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(IdSesion))
            {
                return exp.Nuevo(transaccion,conceptoDeUsuario);
            }
        }

        /// <summary>
        /// Guarda los precios de la transaccion y el concepto de sus detalles
        /// </summary>
        /// <param name="transaccion">Registro de encabezado de lista de precio</param>
        public void GuardarPrecios(Reg_encab transaccion)
        {
            using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(this))
            {
                exp.Guardar(transaccion);
                this.Persistidor.Confirmar();
            }
        }

        /// <summary>
        /// Devuelve el encabezado de cuyo concepto es de ALTA_LISTA_PRECIOS y cuyo id de concepto de sus detalles es igual al pasado como parámetro
        /// </summary>
        /// <param name="idCptoLinea">Id de concepto de detalle</param>
        /// <returns>Encabezado de transaccion de ALTA_LISTA_PRECIOS</returns>
        public Reg_encab ObtenerEncabPrecio(long idCptoLinea)
        {
            return this.Persistidor.ObtenerTransaccionPorKey(e => e.Concepto.Id == CptoTransaccionPrecio.Id && e.Reg_Det.Any(d => d.Concepto.Id == idCptoLinea));
        }

        ///// <summary>
        ///// Crea un nuevo Concepto con un Registro de Encabezado y la posibilidad de incluir un nuevo registro de detalle.
        ///// </summary>
        ///// <param name="incluirDetalle">Indica si se crea un registro de detalle en el registro de encabezado</param>
        ///// <returns>Nuevo Concepto</returns>
        //public Concepto NuevoEncDet(bool incluirDetalle)
        //{
        //    Concepto concepto = base.Nuevo();

        //    using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(IdSesion))
        //    {
        //        Reg_encab regEncab = exp.Nuevo(concepto);

        //        if (incluirDetalle)
        //        {
        //            regEncab.Reg_Det.Add(exp.Nuevo(regEncab, concepto));
        //        }
        //    }

        //    return concepto;

        //    //using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(IdSesion))
        //    //{
        //    //    Reg_encab regEncab = exp.Nuevo(cptoTransaccion);

        //    //    //cptoTransaccion.Reg_encab.Add(regEncab);   
        //    //    if (incluirDetalle)
        //    //    {
        //    //        Concepto concepto = base.Nuevo();
        //    //        regEncab.Reg_Det.Add(exp.Nuevo(regEncab, concepto));
        //    //    }
        //    //}

        //    //return concepto;
        //}

        //public Concepto NuevoEncCpto(Concepto conceptoEncabezado)
        //{
        //    Concepto concepto = base.Nuevo();

        //    using (var exp = FabExpertos.Inst.Obtener<ExpertoRegistro>(IdSesion))
        //    {
        //        Reg_encab regEncab = exp.Nuevo(conceptoEncabezado);

        //        //conceptoEncabezado.Reg_encab.Add(regEncab);
        //        concepto.Reg_encab.Add(regEncab);
        //        concepto.Reg_encab.First<Reg_encab>().Reg_Det.Add(exp.Nuevo(regEncab, concepto));
        //    }

        //    return concepto;
        //}

        protected override void ValidarNuevo(Concepto entidad)
        {
            var lstRdo = new List<EstructuraValidacion>();

            base.ValidarNuevo(entidad);

            if (entidad.Nombre == string.Empty)
                lstRdo.Add(new EstructuraValidacion()
                {
                    Mensage = "\n\t - No se puede guardar un concepto sin nombre.",
                    Tipo = EnumTipoError.Error
                });

            if (lstRdo.Count > 0)
                throw new ValidacionException("Datos inválidos al crear un nuevo concepto.", lstRdo);
            
        }
        protected override void ValidarModificar(Concepto entidad)
        {
            base.ValidarModificar(entidad);
        }

        ///// <summary>
        ///// Obtiene un concepto de usuario a través de su valor enumerado. 
        ///// </summary>
        ///// <param name="valorEnum">valor de la enumeracion correspondiente al conceptos de sistema a buscar</param>
        ///// <returns>Conceptos buscados</returns>
        //public List<Concepto> ObtenerConceptosUsuario(Enum valorEnum)
        //{
        //    int clase;
        //    int valor;

        //    Enumeraciones.ObtenerClaseYValor(valorEnum, out clase, out valor);

        //    var cptos = Persistidor.Linq.Entidades<Concepto>().Where(c => c.Clase == clase && c.Valor == valor).ToList<Concepto>();
        //    return cptos;
        //}

        protected override void Inicializar(Concepto entidad)
        {
            
            entidad.Alta = DateTime.Now;
            entidad.Baja = null;
        }

        /// <summary>
        /// Obtiene todos los conceptos del tipo pasado como parámetro
        /// </summary>
        /// <param name="tipoConcepto">Tipo de conceptos a obtener</param>
        /// <param name="nombre">nombre de conceptos a obtener</param>
        /// <returns>Conceptos obtenidos</returns>
 
               /// <summary>
        /// Obtiene todos los conceptos del tipo pasado como parámetro
        /// </summary>
        /// <param name="tipoConcepto">Tipo de conceptos a obtener</param>
        /// <param name="nombre">nombre de conceptos a obtener</param>
        /// <returns>Conceptos obtenidos</returns>
        public IList<Concepto> ListaConceptos(TipoConcepto tipoConcepto, string nombre = null)
        {
            //var cptos = this.ListaConceptos(true, nombre, tipoConcepto);
            return  this.ListaConceptos(true, nombre, tipoConcepto);
        }

        public List<ProxyCptoPrecio> ListaLineasPrecioConceptos(TipoConcepto tipoConcepto, long idCptoTransaccion, string nombre = null)
        {
            //var cptos = this.ListaConceptos(true, nombre, tipoConcepto);
            var cptos = this.ListaConceptos(true, nombre, tipoConcepto);

            // Crear un proxy para que regrese la linea
            var lineas = from c in cptos
                         join regPrecio in Persistidor.Linq.Lineas<Reg_Det>() on c.Id equals regPrecio.Concepto.Id into linea
                         from incluir in linea.DefaultIfEmpty()
                         where incluir == null || (incluir != null && incluir.Reg_encab.Concepto.Id == idCptoTransaccion)
                         select new ProxyCptoPrecio()
                                            {
                                                 Concepto = c,
                                                 Linea = incluir
                                            } ;


            var lineasMax = (from l in lineas
                             where l.Hasta.Value == DateTime.MaxValue
                             select l).ToList();

            return lineasMax;
        }



        /// <summary>
        /// Obtiene todos los conceptos cuyos valores son pasados como parámetros
        /// </summary>
        /// <param name="nombre">Nombre de los conceptos a obtener</param>
        /// <param name="valores">Valores de conceptos a obtener</param>
        /// <returns>Conceptos obtenidos</returns>
        public IList<Concepto> ListaConceptos(string nombre = null, params Enum[] valores)
        {
            return this.ListaConceptos(false, nombre, valores);
        }

        private IList<Concepto> ListaConceptos(bool esTipoConcepto, string nombre = null, params Enum[] valores)
        {
            if (valores.Length > 0)
            {
                List<Concepto> conceptos = new List<Concepto>();
                int clase = 0;
                int valor = 0;
                
                if (esTipoConcepto)
                {
                    clase = (int)((TipoConcepto)valores[0]);
                    conceptos = Persistidor.Linq.Entidades().OfType<Concepto>().Where(c => c.Clase == clase).ToList<Concepto>()
                        .Where(c => String.IsNullOrWhiteSpace(nombre) || c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList<Concepto>();
                }
                else
                {
                    List<Concepto> temp;
                    foreach (Enum valorEnum in valores)
                    {
                        Concepto.ObtenerClaseYValor(valorEnum, out clase, out valor);
                        temp = Persistidor.Linq.Entidades().OfType<Concepto>().Where(c => c.Clase == clase && c.Valor == valor).ToList<Concepto>();

                        if(temp != null)
                        {
                            conceptos.AddRange(temp.Where(c => String.IsNullOrWhiteSpace(nombre) || c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)));
                        }
                    }                
                }

                return conceptos;
            }

            return null;

        }

        public IList<Concepto> ListaTodos(List<string> keys, string nombre = null)
        {
            IEnumerable<Concepto> lstConceptos = Persistidor.Lista<Concepto>()
                .Where(c => keys.Contains(c.Abreviatura))
                .Where(c => String.IsNullOrEmpty(nombre) ? true : c.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) != -1);

            return new List<Concepto>(lstConceptos);
        }

        public static void CrearServicios(Guid idSession, DateTime fechaBase, Random rnd)
        {

            var servicios = CrearServiciosTEST(fechaBase);

            foreach (var concepto in servicios)
            {
                using (var exp = IoC.Singleton.Experto<ExpConcepto>(idSession))
                {
                    Reg_encab encabezado = exp.NuevoEncabPrecio(exp.CptoTransaccionPrecio, true);

                    encabezado.FechaAlta = fechaBase;
                    encabezado.FechaRegistro = fechaBase;

                    var fechaIni = fechaBase;
                    for (int i = 0; i < 12; i++)
                    {
                        Reg_Det detalle = exp.NuevoPrecio(concepto, encabezado);
                        detalle.Precio = 300M * 0.75M + (int)rnd.Next(0, (int)(300M * 0.25M));

                        detalle.ValFecha1 = fechaBase.AddMonths(i).Inferior(DateInterval.Month);
                        detalle.ValFecha2 = fechaBase.AddMonths(i).Superior(DateInterval.Month);
                    }
                    exp.GuardarPrecios(encabezado);
                }
            }

        }

        /// <summary>
        /// Obtiene una lista los conceptos de ingresos varios (todos los ingresos excepto los mensuales)
        /// </summary>
        /// <returns>Lista de Conceptos de Ingresos Varios</returns>
        public IList<Concepto> ListaConceptosIngresosVarios()
        {
            return this.ListaConceptos(null, ConceptoIngresos.ALQUILER_DIARIO, ConceptoIngresos.ALQUILER_POR_HORA, ConceptoIngresos.ALQUILER_POR_TURNO, ConceptoIngresos.ENCERADO,
                            ConceptoIngresos.LAVADO_AUTO_COMUN, ConceptoIngresos.LAVADO_AUTO_MOTOR, ConceptoIngresos.LAVADO_COMPLETO);
        }

        static IList<Concepto> CrearServiciosTEST(DateTime alta)
        {
            var servicios = new List<Concepto>();
            for (int i = 0; i < 5; i++)
            {
                var srv = new Concepto()
                {
                    Alta = alta
                    ,
                    Nombre = DescripcionEnumAttribute.ObtenerNombre(ConceptoIngresos.ALQUILER_MENSUAL) + " " + i
                    ,
                    Abreviatura = DescripcionEnumAttribute.ObtenerAbreviatura(ConceptoIngresos.ALQUILER_MENSUAL) + " " + i
                    ,
                    Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + i
                    ,
                    Clase = (int)TipoConcepto.ConceptoIngresos
                    ,
                    Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
                };

                servicios.Add(srv);
            }

            return servicios;
        }

        Concepto _cptoTranPrecio { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.ALTA_LISTA_PRECIOS); } }

        public IList<ProxyServicioMensual> ObtenerServiciosAlquilerMensual(DateTime periodo)
        
        {
            var ini = periodo.Inferior(DateInterval.Month);
            var fin = periodo.Superior(DateInterval.Month);

            int CL_SERV;
            int VL_SERV;

            Concepto.ObtenerClaseYValor(ConceptoIngresos.ALQUILER_MENSUAL, out CL_SERV, out VL_SERV);

            var precios = (from
                       regPrecio in Persistidor.Linq.Lineas<Reg_Det>()
                           where
                                   regPrecio.Reg_encab.Concepto.Id == _cptoTranPrecio.Id
                                   && regPrecio.Concepto.Clase == CL_SERV
                                   && regPrecio.Concepto.Valor == VL_SERV
                                    && (!regPrecio.ValFecha1.HasValue || ini >= regPrecio.ValFecha1.Value)
                                    && (!regPrecio.ValFecha2.HasValue || fin <= regPrecio.ValFecha2.Value)
                           select new ProxyServicioMensual()
                           {
                               Linea = regPrecio,
                           }
                ).ToList();

            return precios;
        }

        public IList<ProxyTipoFactura> ObtenerTiposComprobantes()
        {
            var r = Enum.GetNames(typeof(TipoFactura));

            var rdo = from e in r
                      select new ProxyTipoFactura()
                      {
                          Nombre = e,
                          EnumValue = (TipoFactura)Enum.Parse(typeof(TipoFactura), e)
                      };

            return rdo.ToList();

        }
    }
    public class ProxyServicioMensual
    {
        public const string PROP_NOMBRE_PRECIO = "NombreServicioPrecio";
        
        public ProxyServicioMensual()
        { 
        }
        public string NombreServicioPrecio { get { return NombreServicio +" [ " + Precio.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)+" ]" ; } }
        public string NombreServicio { get { return Linea.Concepto != null ? Linea.Concepto.Nombre : ""; } }
        
        public Concepto Servicio
        {
            get
            { return Linea.Concepto; }
        }
        public decimal Precio { get { return Linea.Precio.HasValue ? Linea.Precio.Value : 0; } }
        public Reg_Det Linea { get; set; }


    }
    public class ProxyCptoPrecio
    {
        public const string PROP_DETALLELINEAVIGENTE = "DetalleLineaVigente";


        public string DetalleLineaVigente
        {
            get 
            {
                string d = "Precio Vigente: ["+ (this.Precio == 0M ? "SIN PRECIO" : this.Precio.ToString(FormatHelper.ARCurrencyFormatCurrentCulture)) + "]"
                    + " (Desde: " +  (this.Desde.Value == DateTime.MinValue ? "indefinido" :  this.Desde.Value.ToString(FormatHelper.MonthShortNameYearFormat))
                    + " - Hasta: " + (this.Hasta.Value == DateTime.MaxValue ? "indefinido" : this.Hasta.Value.ToString(FormatHelper.MonthShortNameYearFormat)) + ")";

                return d;
            }
        }
        public string Servicio 
        {
            get
            {
                string serv = "(no asignado)";
                if (this.Concepto != null)
                    serv = this.Concepto.Nombre;

                return serv;
            }
        }
        public decimal Precio

        {
            get
            {
                decimal p = (Linea != null && Linea.Precio.HasValue) ? Linea.Precio.Value : 0M;
                return p;
            }
        }
        public DateTime? Desde
        {
            get
            {
                DateTime? d = DateTime.MinValue;
                if (Linea != null && Linea.ValFecha1.HasValue)
                    d = Linea.ValFecha1.Value;

                return d;
            }
        }
        public DateTime? Hasta
        {
            get
            {
                DateTime? hasta = DateTime.MaxValue;
                if (Linea != null && Linea.ValFecha2.HasValue)
                    hasta = Linea.ValFecha2.Value;

                return hasta;
            }
        }
        public Reg_Det Linea { get; set; }
        public Concepto Concepto { get; set; }
    }

    public class ProxyTipoFactura
    {
        public const string CONST_ENUMVALUE = "EnumValue";
        public const string CONST_NOMBRE = "Nombre";
        public const string CONST_DESCRIPCION = "Descripcion";
        public TipoFactura EnumValue { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get { return DescripcionEnumAttribute.ObtenerDescripcion(this.EnumValue);} }
    }
}
