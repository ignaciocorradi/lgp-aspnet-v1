using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using System.Globalization;

namespace AppGest.Configuracion.Message.ES
{
    /// <summary>
    /// Mensages traducidos al Castellano
    /// </summary>
    public class ReportMessage : IReportViewerMessages, IReportViewerMessages2, IReportViewerMessages3
    {
        // English value: Back to Parent Report
        public string BackButtonToolTip
        {
            get { return "Regresar al informe principal."; }
        }
        // English value: Change Credentials
        public string ChangeCredentialsText
        {
            get { return "Cambiar las credenciales de usuario"; }
        }
        // English value: Change Credentials
        public string ChangeCredentialsToolTip
        {
            get { return this.ChangeCredentialsText; }
        }
        // English value: Current Page
        public string CurrentPageTextBoxToolTip
        {
            get { return "Página actual"; }
        }
        // English value: Document Map
        public string DocumentMap
        {
            get { return "Mapa del informe"; }
        }

        public string DocumentMapButtonToolTip
        {
            get { return "Mostrar u Ocultar el " + this.DocumentMap; }
        }

        public string ExportButtonText
        {
            get { return "Exportar Informe"; }
        }

        public string ExportButtonToolTip
        {
            get { return this.ExportButtonText; }
        }

        public string ExportFormatsToolTip
        {
            get { return "Formatos a exportar"; }
        }

        public string FalseValueText
        {
            get { return "No"; }
        }

        public string FindButtonText
        {
            get { return "Buscar"; }
        }

        public string FindButtonToolTip
        {
            get { return "Buscar dentro del informe"; }
        }

        public string FindNextButtonText
        {
            get { return "Buscar siguiente"; }
        }

        public string FindNextButtonToolTip
        {
            get { return "Buscar la próxima coincidencia en el informe"; }
        }

        public string FirstPageButtonToolTip
        {
            get { return "Ir a la primera página"; }
        }

        public string InvalidPageNumber
        {
            get { return "Nro de página inválida. Ingrese un nro válido"; }
        }

        public string LastPageButtonToolTip
        {
            get { return "Ir a última página"; }
        }

        public string NextPageButtonToolTip
        {
            get { return "Próxima página"; }
        }

        public string NoMoreMatches
        {
            get { return "Se ha buscado en todo el informe"; }
        }

        public string NullCheckBoxText
        {
            get { return "No usar"; }
        }

        public string NullValueText
        {
            get { return "Sin valor"; }
        }

        public string PageOf
        {
            get { return "de"; }
        }

        // English value: Show / Hide Parameters
        public string ParameterAreaButtonToolTip
        {
            get { return "Mostrar u Ocultar los filtros"; }
        }

        public string PasswordPrompt
        {
            get { return "Contraseña"; }
        }

        public string PreviousPageButtonToolTip
        {
            get { return "Página anterior"; }
        }

        public string PrintButtonToolTip
        {
            get { return "Imprimir informe"; }
        }

        // English value: Loading...
        public string ProgressText
        {
            get { return "Cargando el informe..."; }
        }

        public string RefreshButtonToolTip
        {
            get { return "Actualizar datos del informe"; }
        }

        public string SearchTextBoxToolTip
        {
            get { return "Buscar el texto en el informe"; }
        }

        public string SelectAValue
        {
            get { return "<Seleccionar un valor de la lista>"; }
        }

        public string SelectAll
        {
            get { return "(Seleccionar todos los valores de la lista)"; }
        }

        public string SelectFormat
        {
            get { return "Seleccione un formato"; }
        }

        public string TextNotFound
        {
            get { return "No se encontró el texto buscado"; }
        }

        // English value: Today is {0}
        public string TodayIs
        {
            get { return "Hoy es {0}"; }
        }

        public string TrueValueText
        {
            get { return "Si"; }
        }
        // English value: Log In Name:
        public string UserNamePrompt
        {
            get { return "Nombre de usuario"; }
        }

        // English value: View Report
        public string ViewReportButtonText
        {
            get { return "Ver informe"; }
        }

        public string ZoomControlToolTip
        {
            get { return "Zoom"; }
        }

        public string ZoomToPageWidth
        {
            get { return "Ancho de página"; }
        }

        public string ZoomToWholePage
        {
            get { return "Ajustar al contenido"; }
        }

        // English value: Your browser does not support scripts or has been configured not to allow scripts.
        public string ClientNoScript
        {
            get { return "El navegador web utilizado no soporta la ejecución de scripts o no ha sido configurado. Activelo y vuelta a interntarlo."; }
        }

        // English value: Unable to load client print control.
        public string ClientPrintControlLoadFailed
        {
            get { return "No es posible cargar el controlador local de la impresora."; }
        }
        // English value: One or more data sources is missing a user name.
        public string CredentialMissingUserNameError(string dataSourcePrompt)
        {
            return "Los datos de usuario no han sido establecidos.";
        }


        public string GetLocalizedNameForRenderingExtension(string format)
        {

            switch (format)
            {
                case "XML": return "Archivo XML (.xml)";  // XML file with report data
                case "CSV": return "Archivo CSV (.csv)";  // CSV (comma delimited)
                case "PDF": return "Documento PDF (.pdf)";     // PDF
                case "MHTML": return "Arhivo web MHTML (.mhtml)";     // MHTML (web archive)
                case "EXCEL": return "Libro de Excel 97-2003 (.xls)";  // Excel
                case "IMAGE": return "Imagen TIFF (.tif)";       // TIFF file
                case "WORD": return "Documento de Word 97-2003 (.doc)";    // Word
                case "EXCELOPENXML": return "Libro de Excel 2007-2010 (.xlsx)";
                case "WORDOPENXML": return "Documento de Word 2007-2010 (.docx)";
                default: return null;
            }
        }

        public string ParameterDropDownToolTip
        {
            get { return "Seleccione un valor"; }
        }

        public string ParameterMissingSelectionError(string parameterPrompt)
        {
            string msg = "Porfavor seleccione un valor de la lista en el filtro '{0}'.";
            return String.Format(CultureInfo.CurrentCulture, msg, parameterPrompt);

        }

        public string ParameterMissingValueError(string parameterPrompt)
        {
            string msg = "Porfavor ingrese un valor para el filtro '{0}'.\nEste filtro debe tener un valor.";
            return String.Format(CultureInfo.CurrentCulture, msg, parameterPrompt);

        }

        public string CalendarLoading
        {
            get { return "Cargando el calendario"; }
        }

        public string CancelLinkText
        {
            get { return "Cancelar"; }
        }

        public string TotalPages(int pageCount, PageCountMode pageCountMode)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{1}", pageCount, pageCountMode == PageCountMode.Estimate ? " aprox." : String.Empty);

        }
    }

}