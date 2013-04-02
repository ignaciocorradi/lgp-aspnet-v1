using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AppGest.Util.Atributos
{

    public class HelperAtributo: Attribute
    {
        /// <summary>
        /// Devuelve el atributo correspondiente al valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado</param>
        /// <returns></returns>
        protected static TAttribute Atributo<TAttribute>(object valor)
            where TAttribute : Attribute
        {
            var tipo = valor.GetType();
            var nombreCampo = Enum.GetName(tipo, valor);
            var miembroCampo = tipo.GetField(nombreCampo);

            var atrs = miembroCampo.GetCustomAttributes(typeof(TAttribute), false);
            if (atrs.Length != 0)
                return (TAttribute) atrs[0];
            else
                return default(TAttribute);
        }

        /// <summary>
        /// Devuelve valor del atributo correspondiente al valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado</param>
        /// <returns></returns>
        protected static TResultado ValorAtributo<TAttribute, TResultado>(object vEnum, Func<TAttribute, TResultado> selector, TResultado predeterminado)
            where TAttribute : Attribute
        {
            var atr = Atributo<TAttribute>(vEnum);
            if (atr != null)
            {
                var valor = selector.Invoke(atr);
                return valor == null ? predeterminado : valor;
            }
            else
                return predeterminado;
        }

    }

    /// <summary>
    /// Representa la descripción de un valor enumerado.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DescripcionEnumAttribute: HelperAtributo
    {
        /// <summary>
        /// Nombre de referencia para el valor enumerado.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Abriviatura de referencia para el valor enumerado.
        /// </summary>
        public string Abreviatura { get; set; }
        /// <summary>
        /// Descripción para el valor de referencia
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Devuelve el nombre proporcionado en la descripción del valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns></returns>
        public static string ObtenerNombre(object valor)
        {
            return ValorAtributo<DescripcionEnumAttribute, string>(valor, (a => a.Nombre), valor.ToString());
        }

        /// <summary>
        /// Devuelve la descripción proporcionada para el valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns></returns>
        public static string ObtenerDescripcion(object valor)
        {
            return ValorAtributo<DescripcionEnumAttribute, string>(valor, (a => a.Descripcion), valor.ToString());
        }

        /// <summary>
        /// Devuelve la abreviatura proporcionada para el valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns></returns>
        public static string ObtenerAbreviatura(object valor)
        {
            return ValorAtributo<DescripcionEnumAttribute, string>(valor, (a => a.Abreviatura), valor.ToString());
        }
    }

    /// <summary>
    /// Describe un valor enumerado que es instanciado por la aplicación
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ValorEnumDeUsuarioAttribute : HelperAtributo
    {

        /// <summary>
        /// Devuelve un valor que indica si el valor enumerado proporcionado no es un valor redefinido por el usuario.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns></returns>
        public static bool EsDeUsuario(Enum valor)
        {
            return Atributo<ValorEnumDeUsuarioAttribute>(valor) != null;
        }

        /// <summary>
        /// Devuelve un valor que indica si el valor enumerado proporcionado no es un valor fijo, del sistema.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns></returns>
        public static bool EsDeSistema(Enum valor)
        {
            return !EsDeUsuario(valor);
        }

        /// <summary>
        /// Devuelve la lista de valores enumerados que se consideran del usuario, es decir, que el 
        /// usuario puede crear varias instancias de este.
        /// </summary>
        /// <param name="tipoEnum">Tipo enumerado consultado</param>
        /// <returns></returns>
        public static IList<Enum> ObtenerValoresEnumDeUsuario(Type tipoEnum)
        {
            if (!tipoEnum.IsEnum)
                throw new ArgumentException("Se esperaba un tipo enum.");

            var rdo = new List<Enum>();
            foreach (var value in tipoEnum.GetEnumValues())
                if (EsDeUsuario((Enum) value))
                    rdo.Add((Enum) value);

            return rdo;
        }

        /// <summary>
        /// Devuelve la lista de valores enumerados que se consideran del usuario, es decir, que el 
        /// usuario puede crear varias instancias de este.
        /// </summary>
        /// <param name="tipoEnum">Tipo enumerado consultado</param>
        /// <returns></returns>
        public static IList<Enum> ObtenerValoresEnumDeSistema(Type tipoEnum)
        {
            if (!tipoEnum.IsEnum)
                throw new ArgumentException("Se esperaba un tipo enum.");

            var rdo = new List<Enum>();
            foreach (var value in tipoEnum.GetEnumValues())
                if (EsDeSistema((Enum) value))
                    rdo.Add((Enum)value);

            return rdo;
        }
    }

    #region Seguridad
    /// <summary>
    /// Describe un valor enumerado que es instanciado por la aplicación
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AdministradorAttribute : HelperAtributo
    {
    }
    
    /// <summary>
    /// Describe un valor enumerado que es instanciado por la aplicación
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SupervisorAttribute : HelperAtributo
    {
    }

    /// <summary>
    /// Describe un valor enumerado que es instanciado por la aplicación
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class OperadorAttribute : HelperAtributo
    {
    }

    /// <summary>
    /// Describe un valor enumerado que es instanciado por la aplicación
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class UCAttribute : HelperAtributo
    {
        public UCAttribute(Type type)
        {
            UCType = type;
        }

        private Type UCType { get; set; }

        /// <summary>
        /// Devuelve el Tipo proporcionado en el valor enumerado proporcionado.
        /// </summary>
        /// <param name="valor">Valor enumerado consultado.</param>
        /// <returns>Tipo del uc</returns>
        public static Type ObtenerTipo(object valor)
        {
            return ValorAtributo<UCAttribute, Type>(valor, (a => a.UCType), null);
        }
    }

    #endregion

}
