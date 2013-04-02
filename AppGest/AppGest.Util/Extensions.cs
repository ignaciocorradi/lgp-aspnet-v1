using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class Extensions
    {
        /// <summary>
        /// Indica la precisión que se utilizará cuando se especifique la
        /// máxima precisión.
        /// </summary>
        public static DateInterval MaximaPrecision = DateInterval.Second;

        /// <summary>
        /// Indica la precisión que se utilizará cuando no se especifique explícitamente.
        /// </summary>
        public static DateInterval PrecisionPredeterminada = DateInterval.Second;

        /// <summary>
        /// Metodo de Extension cuya funcionalidad es similar a Compare de String, pero con la posibilidad de ignorar mayusculas y minusculas
        /// </summary>
        /// <param name="source">string origen</param>
        /// <param name="toCheck">string a comparar</param>
        /// <param name="comp">tipo de comparación</param>
        /// <returns>true si toCheck se incluye dentro del string de origen segun la condicion de comparacion</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Metodo de Extensión cuya finalidad es comparar si el valor de un objeto IComparable se encuentra entre los vlaores de otros dos
        /// </summary>
        /// <param name="valor">Valor a verificar</param>
        /// <param name="desde">Valor inicial</param>
        /// <param name="hasta">Valor final</param>
        /// <returns>true si valor se encuentra entre inicial y final, false en otro caso</returns>
        public static bool Between (this IComparable valor, IComparable desde, IComparable hasta) 
        {
            return valor.CompareTo(desde) >= 0 && valor.CompareTo(hasta) <= 0;
        } 

        /// <summary>
        /// Devuelve un límite inferior en relación a una fecha proporcionada, para un intervalo especificado.
        /// </summary>
        /// <param name="_this">Esta instancia</param>
        /// <param name="intervalo">Intervalo del límite</param>
        /// <param name="precision">Indica la precisión del resultado.</param>
        /// <returns></returns>
        public static DateTime Inferior(this DateTime _this, DateInterval intervalo, DateInterval precision = DateInterval.Maxima)
        {
            return Limite(_this, intervalo, false, precision);
        }
        /// <summary>
        /// Devuelve un límite superior en relación a una fecha proporcionada, para un intervalo especificado.
        /// </summary>
        /// <param name="_this">Esta instancia</param>
        /// <param name="intervalo">Intervalo del límite</param>
        /// <param name="precision">Indica la precisión del resultado.</param>
        /// <returns></returns>
        public static DateTime Superior(this DateTime _this, DateInterval intervalo, DateInterval precision = DateInterval.Maxima)
        {
            return Limite(_this, intervalo, true, precision);
        }
        /// <summary>
        /// Devuelve un límite en relación a una fecha proporcionada, para un intervalo especificado.
        /// </summary>
        /// <param name="_this">Esta instancia</param>
        /// <param name="intervalo">Intervalo del límite</param>
        /// <param name="superior">Indica si se debe proporcionar el límite superior.</param>
        /// <param name="precision">Indica la precisión del resultado.</param>
        /// <returns></returns>
        public static DateTime Limite(this DateTime _this, System.DateInterval intervalo, bool superior, DateInterval precision = DateInterval.Maxima)
        {
            switch (intervalo)
            {
                case DateInterval.Millisecond:
                    if (superior)
                        return _this.Date.Truncar(precision);
                    else
                        return _this.Date.Truncar(precision);
                case DateInterval.Day:
                    if (superior)
                        return _this.Date.AddDays(1).AddSeconds(-1).Truncar(precision);
                    else
                        return _this.Date.Truncar(precision);
                    if (superior)
                        return _this.Date.AddDays(1).AddSeconds(-1).Truncar(precision);
                    else
                        return _this.Date.Truncar(precision);
                case DateInterval.DayOfYear:
                case DateInterval.Year:
                    if (superior)
                        return new DateTime(_this.Year + 1, 1, 1).AddSeconds(-1).Truncar(precision);
                    else
                        return new DateTime(_this.Year, 1, 1).Truncar(precision);
                case DateInterval.Hour:
                    if (superior)
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, 0, 0, 0).AddHours(1).AddSeconds(-1).Truncar(precision);
                    else
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, 0, 0, 0).Truncar(precision);
                case DateInterval.Minute:
                    if (superior)
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, 0, 0, 0).AddMinutes(1).AddSeconds(-1).Truncar(precision);
                    else
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, 0, 0, 0).Truncar(precision);
                case DateInterval.Month:
                    if (superior)
                        return new DateTime(_this.Year, _this.Month, 1).AddMonths(1).AddSeconds(-1).Truncar(precision);
                    else
                        return new DateTime(_this.Year, _this.Month, 1).Truncar(precision);
                case DateInterval.Second:
                    if (superior)
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, _this.Minute, _this.Second, 0).AddSeconds(1).AddMilliseconds(-1).Truncar(precision);
                    else
                        return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, _this.Minute, _this.Second, 0).Truncar(precision);
                default:
                    throw new NotImplementedException("No se ha implementado esta opción");
            }
        }


        /// <summary>
        /// Trunca la información de la fecha y hora, para que se ajuste a la precición especificada.
        /// </summary>
        /// <param name="_this">Esta instancia</param>
        /// <param name="precision">Intervalo del límite</param>
        /// <returns></returns>
        public static DateTime Truncar(this DateTime _this, System.DateInterval precision = DateInterval.Default)
        {
            switch (precision)
            {
                case DateInterval.Default:
                    return Truncar(_this, PrecisionPredeterminada);
                case DateInterval.Maxima:
                    return Truncar(_this, MaximaPrecision);
                case DateInterval.Millisecond:
                    return _this;
                case DateInterval.Second:
                    return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, _this.Minute, _this.Second, 0);
                case DateInterval.Minute:
                    return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, _this.Minute, 0, 0);
                case DateInterval.Hour:
                    return new DateTime(_this.Year, _this.Month, _this.Day, _this.Hour, 0, 0, 0);
                case DateInterval.Day:
                    return _this.Date;
                case DateInterval.Month:
                        return new DateTime(_this.Year, _this.Month, 1);
                case DateInterval.Year:
                        return new DateTime(_this.Year, 1, 1);
                default:
                    throw new NotImplementedException("No se ha implementado esta opción");
            }
        }

    }
}
