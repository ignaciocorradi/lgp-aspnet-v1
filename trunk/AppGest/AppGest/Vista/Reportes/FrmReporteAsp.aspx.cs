using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppGest.Util;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.RSReference;

namespace AppGest.Vista.Reportes
{
	public partial class FrmReporteAsp : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					string rptKey = Request["rptKey"];
					ConfigurarReporte(rptKey);
					ParametrizarReporte(rptKey);
				}
			}
			catch (Exception ex)
			{
				Logger.Inst.Error("FrmReporteAsp.aspx", ex);
			}

		}

		private void ParametrizarReporte(string keyReporteActual)
		{
			IList<Microsoft.Reporting.WebForms.ReportParameter> parametros = new List<Microsoft.Reporting.WebForms.ReportParameter>();
			RptItemSettings itemRpt = ConfiguracionesReportes.ObtenerConfiguracionReporte((Guid)this.Context.Session["idSesion"], keyReporteActual);

			foreach (Microsoft.Reporting.WebForms.ReportParameterInfo rpInfo in rptControl.ServerReport.GetParameters())
			{
				string valor = null;
				RptItemParams rptParams = itemRpt.Parametros.OfType<RptItemParams>().FirstOrDefault(p => p.Key.Equals(rpInfo.Name));

				if(rptParams != null)
				{
					valor = rptParams.Valor;
				}
				else
				{
					valor = ConfiguracionesReportes.ObtenerParametroGlobalReporte((Guid) this.Context.Session["idSesion"], rpInfo.Name);
				}

				if (valor != null)
				{
					parametros.Add(new Microsoft.Reporting.WebForms.ReportParameter(rpInfo.Name, valor));
				}
			}

			if (parametros != null && parametros.Count > 0)
			{
				rptControl.ServerReport.SetParameters(parametros);
			}

		}

		private void ConfigurarReporte(string keyReporteActual)
		{
			RptItemSettings itemRpt = ConfiguracionesReportes.ObtenerConfiguracionReporte((Guid)this.Context.Session["idSesion"], keyReporteActual);

			rptControl.ServerReport.ReportServerUrl = new Uri(itemRpt.UrlServidor);
			rptControl.ServerReport.ReportPath = itemRpt.Reporte;
            rptControl.ShowPrintButton = true;
			lblTitulo.Text = itemRpt.Nombre;
		}

		public enum ExportFormat
		{
			/// <summary>XML</summary>
			XML,
			/// <summary>Comma Delimitted File
			CSV,
			/// <summary>TIFF image</summary>
			Image,
			/// <summary>PDF</summary>
			PDF,
			/// <summary>HTML (Web Archive)</summary>
			MHTML,
			/// <summary>HTML 4.0</summary>
			HTML4,
			/// <summary>HTML 3.2</summary>
			HTML32,
			/// <summary>Excel</summary>
			Excel,
			/// <summary>Word</summary>
			Word
		}
	
		private static string GetExportFormatString(ExportFormat f)
		{
			switch (f)
			{
				case ExportFormat.XML: return "XML";
				case ExportFormat.CSV: return "CSV";
				case ExportFormat.Image: return "IMAGE";
				case ExportFormat.PDF: return "PDF";
				case ExportFormat.MHTML: return "MHTML";
				case ExportFormat.HTML4: return "HTML4.0";
				case ExportFormat.HTML32: return "HTML3.2";
				case ExportFormat.Excel: return "EXCEL";
				case ExportFormat.Word: return "WORD";

				default:
					return "PDF";
			}
		}

		public void InicializarServerReportes()
		{
			//rptControl.ServerReport.ReportServerUrl = new Uri(ConfiguracionesReportes.ObtenerURLServer(idSesion));
			//rptControl.ServerReport.ReportPath = "/LGP.Reportes/rpt_DatosClientesMensuales";
			//rptControl.ServerReport.
			var wcfEndpointConfigName = "ReportExecutionServiceSoap";
		

			using (var webServiceProxy = new ReportExecutionServiceSoapClient(wcfEndpointConfigName))
			{
                try
                {
                    //webServiceProxy.ClientCredentials.Windows.AllowNtlm = true;// System.Security.Principal.TokenImpersonationLevel.Identification;
                    //webServiceProxy.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential("nacho", "polipilialma");
                    //webServiceProxy.ClientCredentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;

                    // Init Report to execute
                    string report = "/LGP.Reportes/rptInit";
                    ExportFormat format = ExportFormat.CSV;
                    byte[] output;
                    string extension;
                    string mimeType;
                    string encoding;
                    Warning[] warnings;
                    string[] streamIds;
                    IList<ParameterValue> parameters = new List<ParameterValue>();

                    ServerInfoHeader serverInfoHeader;
                    ExecutionInfo executionInfo;
                    ExecutionHeader executionHeader = webServiceProxy.LoadReport(null, report, null, out serverInfoHeader, out executionInfo);

                    // Attach Report Parameters
                    webServiceProxy.SetExecutionParameters(executionHeader, null, parameters.ToArray(), null, out executionInfo);

                    // Render
                    webServiceProxy.Render(executionHeader, null, GetExportFormatString(format), null, out output
                        , out extension, out mimeType, out encoding, out warnings, out streamIds);
                }
                catch (Exception ex)
                {
                    var a = ex;
                }
            }


		}
	}
}