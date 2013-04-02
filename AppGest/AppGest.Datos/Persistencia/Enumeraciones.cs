using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Util.Atributos;
using AppGest.Datos.Persistencia;

namespace AppGest.Datos.Persistencia
{
    public static class Enumeraciones
    {

        /// <summary>
        /// Crea en memoria y devuelve una lista de conceptos con Id = 0, cuyos valores
        /// de Clave y Valor se corresponden con la lista de conceptos fijos (del sistema).
        /// </summary>
        /// <returns></returns>
        public static IList<Concepto> CrearConceptos()
        {
            var tiposEnum = from tipoEnum in typeof(TipoConcepto).GetEnumValues().Cast<TipoConcepto>()
                            where tipoEnum != TipoConcepto.Ninguno
                            select new 
                            { 
                                IntClase = (int) tipoEnum, 
                                TipoClase = typeof(TipoConcepto).Assembly.GetType(typeof(TipoConcepto).Namespace + "." + tipoEnum.ToString())
                            };

            var conceptos = from tEnum in tiposEnum
                              from vEnum in Enum.GetValues(tEnum.TipoClase).Cast<Enum>()
                              where ValorEnumDeUsuarioAttribute.EsDeSistema(vEnum)
                              select new Concepto() { 
                                  Nombre = DescripcionEnumAttribute.ObtenerNombre(vEnum)
                                  , Abreviatura = DescripcionEnumAttribute.ObtenerAbreviatura(vEnum)
                                  , Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(vEnum)
                                  , Clase = tEnum.IntClase
                                  , Valor = Convert.ToInt32(vEnum)
                                  , DeSistema=true};

            return conceptos.ToList();
        }

        /// <summary>
        /// Devuelve una lista de KeyValuePair compuestos por los valores de una enumeracion y sus nombres
        /// </summary>
        /// <typeparam name="T">Tipo de Enumeracion</typeparam>
        /// <typeparam name="TVAL">Tipo de valor de enumeracion</typeparam>
        /// <returns>Lista de valores</returns>
        public static List<KeyValuePair<string, string>> ListarEnumeracion<T,TVAL>()
        {
            var tiposEnum = from val in typeof(T).GetEnumValues().Cast<T>()
                            select new KeyValuePair<string, string>(
                                Convert.ChangeType(val, typeof(TVAL)).ToString(), 
                                DescripcionEnumAttribute.ObtenerNombre(val).ToString());

            return tiposEnum.ToList();
        } 

    }

    public enum TipoServicio
    {
        EgresosEmpleados,
        EgresosVarios,
        Ingresos
    }
    public enum TipoConcepto
    {
        Ninguno = 0,
        ConceptoIngresos = 1,
        ConceptoEgresos = 2,
        ConceptoRelaciones = 3,
        ConceptoTransacciones = 4,
        ConceptoCualitativo = 5
    }

    public enum TipoFactura
    {
        [DescripcionEnum(Nombre = "Factura A", Descripcion = "Factura A")]
        A = 1,
        [DescripcionEnum(Nombre = "Factura B", Descripcion = "Factura B")]
        B = 2,
        [DescripcionEnum(Nombre = "Factura C", Descripcion = "Factura C")]
        C = 3,
        [DescripcionEnum(Nombre = "Recibo", Descripcion = "Recibo")]
        X = 4
    }
    public enum ConceptoIngresos
    {
        [DescripcionEnum(Nombre = "Alquiler Mensual", Descripcion = "Ingreso por alquiler mensual")]
        [ValorEnumDeUsuario]
        ALQUILER_MENSUAL = 1,
        
        [DescripcionEnum(Nombre = "Alquiler Diario", Descripcion = "Ingreso por alquiler diario")]
        ALQUILER_DIARIO = 2,
        
        [DescripcionEnum(Nombre = "Alquiler por Turno", Descripcion = "Ingreso por alquiler por turno")]
        ALQUILER_POR_TURNO = 3,
        
        [DescripcionEnum(Nombre = "Alquiler por Hora", Descripcion = "Ingreso por alquiler por hora")]
        ALQUILER_POR_HORA = 4,
        
        [DescripcionEnum(Nombre = "Lavado Auto Común", Descripcion = "Ingreso por lavado de auto común")]
        LAVADO_AUTO_COMUN = 5,
        
        [DescripcionEnum(Nombre = "Lavado de Motor del Auto", Descripcion = "Ingreso por lavado del motor del auto")]
        LAVADO_AUTO_MOTOR = 6,
        
        [DescripcionEnum(Nombre = "Lavado Completo del Auto", Descripcion = "Ingreso por lavado completo del auto")]
        LAVADO_COMPLETO = 7,
        
        [DescripcionEnum(Nombre = "Encerado", Descripcion = "Ingreso por encerado")]
        ENCERADO = 8
    }

    public enum ConceptoEgresos
    {
        [DescripcionEnum(Nombre = "Egresos de Empleados", Descripcion = "Conceptos de egresos de empleados")]
        [ValorEnumDeUsuario]
        EGRESOS_EMPLEADOS = 1,

        [DescripcionEnum(Nombre = "Egresos Varios", Descripcion = "Concepto de egresos varios")]
        [ValorEnumDeUsuario]
        EGRESOS_VARIOS = 2
    }

    public enum ConceptoRelaciones
    {
        [DescripcionEnum(Nombre = "Asociación Cliente Vehículo", Descripcion = "Asociación cliente vehículo")]
        ASOC_CLIENTE_VEHICULO = 1,

        [DescripcionEnum(Nombre = "Asociación Cliente Cochera", Descripcion = "Asociación cliente cochera")]
        ASOC_CLIENTE_COCHERA = 2,

        [DescripcionEnum(Nombre = "Asociación Lista de Precios", Descripcion = "Asociación lista de precios (Concepto ingreso con precios)")]
        LISTA_PRECIOS = 3
    }

    public enum ConceptoCualitativo
    {
        [DescripcionEnum(Nombre = "Anticipo", Descripcion = "Valor cualitativo de un ingreso/egreso anticipado")]
        ANTICIPO = 1,

        [DescripcionEnum(Nombre = "A Término", Descripcion = "Valor cualitativo de un ingreso/egreso a término")]
        A_TERMINO = 2,

        [DescripcionEnum(Nombre = "N/A", Descripcion = "No aplica")]
        NO_APLICA = 3
    }

    public enum ConceptoTransacciones
    {
        [DescripcionEnum(Nombre = "Alta Cliente Mensual", Descripcion = "Alta cliente mensual (usa las asociaciones entre cocheras y vehiculos)")]
        ALTA_CLIENTE_MENSUAL = 1,

        [DescripcionEnum(Nombre = "Alta de Lista de Precios", Descripcion = "Alta de lista de precios")]
        ALTA_LISTA_PRECIOS = 2,

        [DescripcionEnum(Nombre = "Pago Mensual", Descripcion = "Pago mensual")]
        PAGO_MENSUAL = 3,

        [DescripcionEnum(Nombre = "Registro de Ingresos", Descripcion = "Registro de ingresos")]
        REGISTRO_INGRESOS = 4,

        [DescripcionEnum(Nombre = "Registro de Egresos", Descripcion = "Registro de egresos")]
        REGISTRO_EGRESOS = 5,

        [DescripcionEnum(Nombre = "Parámetros de sueldo", Descripcion = "Parámetros de sueldo")]
        REGISTRO_PARAM_EGRESO_EMPLEADO = 6,

        [DescripcionEnum(Nombre = "Pago de sueldo", Descripcion = "Pago de sueldo")]
        REGISTRO_PAGO_EGRESO_EMPLEADO = 7,

        [DescripcionEnum(Nombre = "Factura", Descripcion = "Facturas")]
        REGISTRO_FACTURA = 8
    }

    public enum TipoUsuario : byte
    {
        [DescripcionEnum(Abreviatura = "qwaez")]
        ADMINISTRADOR = 1,

        [DescripcionEnum(Abreviatura = "wesrx")]
        SUPERVISOR = 2,

        [DescripcionEnum(Abreviatura = "erdtc")]
        OPERADOR = 3
    }

}

