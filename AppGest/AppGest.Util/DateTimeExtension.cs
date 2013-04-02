using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Demo DateTime.DateDiff
    /// </summary>
    public static class DateTimeExtension
    {

        /// <summary>
        /// Devuelve un valor Long que especifica el número de
        /// intervalos de tiempo entre dos valores Date.
        /// Es la resta de date2 menos date1.
        /// </summary>
        /// <param name="interval">Obligatorio. Valor de enumeración
        /// DateInterval o expresión String que representa el intervalo
        /// de tiempo que se desea utilizar como unidad de diferencia
        /// entre Date1 y Date2.</param>
        /// <param name="date1">Obligatorio. Date. Primer valor de
        /// fecha u hora que se desea utilizar en el cálculo.</param>
        /// <param name="date2">Obligatorio. Date. Segundo valor de
        /// fecha u hora que se desea utilizar en el cálculo.</param>
        /// <returns>Regresa la resta de date2 menos date1</returns>
        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            long rs = 0;
            TimeSpan diff = date2.Subtract(date1);
            switch (interval)
            {
                case DateInterval.Day:
                case DateInterval.DayOfYear:
                    rs = (long)diff.TotalDays;
                    break;
                case DateInterval.Hour:
                    rs = (long)diff.TotalHours;
                    break;
                case DateInterval.Minute:
                    rs = (long)diff.TotalMinutes;
                    break;
                case DateInterval.Month:
                    rs = (date2.Month - date1.Month) + (12 * DateTimeExtension.DateDiff(DateInterval.Year, date1, date2));
                    break;
                case DateInterval.Quarter:
                    rs = (long)Math.Ceiling((double)(DateTimeExtension.DateDiff(DateInterval.Month, date1, date2) / 3.0));
                    break;
                case DateInterval.Second:
                    rs = (long)diff.TotalSeconds;
                    break;
                case DateInterval.Weekday:
                case DateInterval.WeekOfYear:
                    rs = (long)(diff.TotalDays / 7);
                    break;
                case DateInterval.Year:
                    rs = date2.Year - date1.Year;
                    break;
            }//switch
            return rs;
        }//DateDiff


        /// <summary>
        /// Devuelve una función que incrementa una fecha en el intervalo especificado.
        /// </summary>
        /// <param name="intervalo">Intervalo de salto</param>
        /// <param name="factor">Factor de salta. Piede ser positivo o negativo</param>
        /// <returns></returns>
        public static Func<DateTime, DateTime> FuncionIncremento(DateInterval intervalo, int factor)
        {
            switch (intervalo)
            {
                case DateInterval.Day:
                case DateInterval.Year:
                    return new Func<DateTime, DateTime>(x => x.AddDays(factor));
                case DateInterval.Hour:
                    return new Func<DateTime, DateTime>(x => x.AddHours(factor));
                case DateInterval.Minute:
                    return new Func<DateTime, DateTime>(x => x.AddMinutes(factor));
                case DateInterval.Month:
                    return new Func<DateTime, DateTime>(x => x.AddMonths(factor));
                case DateInterval.Second:
                    return new Func<DateTime, DateTime>(x => x.AddSeconds(factor));

                case DateInterval.DayOfYear:
                case DateInterval.Weekday:
                case DateInterval.WeekOfYear:
                case DateInterval.Quarter:
                default:
                    throw new NotImplementedException("No se ha implementado este opción");
            }
        }

        /// <summary>
        /// Expande el intervalo especificado.
        /// Usando el tamaño de paso predeterminado.
        /// </summary>
        /// <param name="desde">Valor mínmo del intervalo</param>
        /// <param name="hasta">Valor máximo del intervalo</param>
        /// <param name="intervalo">Tipo de incremento</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ExpandirIntervalo(DateTime? desde, DateTime? hasta, DateInterval intervalo)
        {
            return ExpandirIntervalo(desde, hasta, intervalo, +1);
        }
        /// <summary>
        /// Expande el intervalo especificado.
        /// </summary>
        /// <param name="desde">Valor mínmo del intervalo</param>
        /// <param name="hasta">Valor máximo del intervalo</param>
        /// <param name="intervalo">Tipo de incremento</param>
        /// <param name="paso">Tamaño de paso. El valor predeterminado es +1</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ExpandirIntervalo(DateTime? desde, DateTime? hasta, DateInterval intervalo, uint paso)
        {
            List<DateTime> expandido = new List<DateTime>();
            
            if (!desde.HasValue || !hasta.HasValue)
                return expandido;

            // el paso no puede ser cero
            paso = paso == 0 ? 1 : paso;

            // función de incremento y tamaño de paso
            var factor = desde <= hasta ? (int)paso : -(int)paso;
            var fnIncremento = FuncionIncremento(intervalo, factor);

            // generación de intervalos
            for (DateTime actual = desde.Value
                    ; factor == +1 && actual <= hasta.Value || factor == -1 && actual >= desde
                    ; actual = fnIncremento(actual))
            {
                expandido.Add(actual);
            }

            return expandido;
        }

        /// <summary>
        /// Devuelve un valor que indica si el valor es NULO o tiene o es igual a DateTime.MinValue.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNullOrMinValue(this DateTime? _this) // le hubiera puesto un nombre en castellano... pero no quedaba..
        {
            return _this == null || !_this.HasValue || _this.Value == DateTime.MinValue;
        }

        /// <summary>
        /// Devuelve un valor que indica si el valor es DateTime.MinValue.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsMinValue(this DateTime _this) // le hubiera puesto un nombre en castellano... pero no quedaba..
        {
            return _this == DateTime.MinValue;
        }
    }

    /// <summary>
    /// Enumerados que definen los tipos de
    /// intervalos de tiempo posibles.
    /// </summary>
    public enum DateInterval
    {
        Default,
        Maxima,
        Millisecond,
        Day,
        DayOfYear,
        Hour,
        Minute,
        Month,
        Quarter,
        Second,
        Weekday,
        WeekOfYear,
        Year
    }
}
