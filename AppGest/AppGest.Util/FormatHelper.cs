using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Util
{
    public class FormatHelper
    {
        /// <summary>
        /// Regresa un string con el formato para numeros que representan valores con moneda. 
        /// Tiene en cuenta la configuración culturar actual de windows y coloca el simbolo para Argentina [AR].
        /// </summary>
        public static string ARCurrencyFormatCurrentCulture
        {
            get
            {
                string formato = "{0} #{1}###{2}{3}";
                var decimales = "".PadLeft(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits, '#');
                var sepGrupos = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                var sepDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                var simbolo = "$"; //System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;

                formato = string.Format(formato, simbolo, sepGrupos, sepDecimal, decimales);
                return formato;

            }
        }
        /// <summary>
        /// Regresa un string con el formato para numeros que representan valores con moneda. 
        /// Tiene en cuenta la configuración culturar actual de windows.
        /// </summary>
        public static string CurrencyFormatCurrentCulture
        {
            get
            {
                string formato = "{0} #{1}###{2}{3}";
                var decimales = "".PadLeft(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits, '#');
                var sepGrupos = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                var sepDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                var simbolo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;

                formato = string.Format(formato, simbolo, sepGrupos, sepDecimal, decimales);
                return formato;

            }
        }


        /// <summary>
        /// Formato corto de letras. "MM - yyyy"
        /// </summary>
        public static string MonthNumberYearFormat { get { return "MM - yyyy";}}

        /// <summary>
        /// Formato corto de letras. "MMMM - yyyy"
        /// </summary>
        public static string MonthNameYearFormat { get { return "MMMM - yyyy";}}
        /// <summary>
        /// Formato corto de letras. "MMM - yyyy"
        /// </summary>
        public static string MonthShortNameYearFormat { get { return "MMM - yyyy";}}

        public static string ShortDateFormat { get { return "dd/MM/yyyy"; } }
        public static string ShortDateFormatCurrentCulture
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
        }
    }
}
