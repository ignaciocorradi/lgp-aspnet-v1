using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Core;
using AppGest;
using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo
{
	public class ExpMigracionLGP : Experto
	{

		public List<ClienteMensualProxy> ObtenerClientes()
		{
			string sql = "SELECT convert(int, [NroCliente]) 'NroCliente',[Apellido]"
						+ ",[Nombre],[FechaIngreso],[Servicio],[dominio],[marca], [domicilio] "
						+ ", DomFiscal , Celular , Telefono , CUIT , RazonSocial, Id, Baja"
						+ " FROM [dbo].[Clientes_Mensuales] where id >= {0}"
						+ " order by NroCliente";
			
			var rdo = Persistidor.ExecuteStoreQuery<ClienteMensualProxy>(sql, 1).ToList();

			return rdo;
		}
		public List<PagosMensuales> ObtenerPagosMensuales()
		{
			string sql = "Select * from dbo.Pagos_Mensuales where Periodo >= 201207";
			var rdo = Persistidor.ExecuteStoreQuery<PagosMensuales>(sql).ToList();

			return rdo;
		}
		List<PreciosConceptos> ObtenerPrecios()
		{
			string sql = "Select v.Concepto_Id 'IdConcepto', v.Desde, v.Hasta, v.PeriodoDesde, v.PeriodoHasta, v.Precio, v.Importe, v.Concepto from [dbo].[v_REP_PreciosConcepto] v";
			var rdo = Persistidor.ExecuteStoreQuery<PreciosConceptos>(sql).ToList();

			return rdo;
		}
		/// <summary>
		/// Proceso de importacion de clients mensuales. 
		/// Crea los clientes, vehículos y asigna cocheras disponibles. 
		/// </summary>
		/// <param name="_clientes">Lista de clientes a importar</param>
		public void ImportarClientesMensuales(List<ClienteMensualProxy> _clientes)
		{
			var clientesEnCero = from c in _clientes
								 where c.NroCliente == 0
								 select c;

			var clientesConNro = from c in _clientes
								 where c.NroCliente > 0
								 select c;


			ImportarDatosMensuales(clientesConNro.ToList());
			ImportarDatosMensuales(clientesEnCero.ToList());

			
		}

		private void ImportarDatosMensuales(List<ClienteMensualProxy> _clientes)
		{
			foreach (var cli in _clientes)
			{
				using (var expMens = FabExpertos.Inst.Obtener<ExpMensuales>(this.IdSesion))
				{
					List<Concepto> servicios = ObtenerServicios();

					var cocheras = expMens.ListaCocherasDisponibles();

					var CptoAlquilerMensual = (from s in servicios where s.Nombre.Trim() == cli.Servicio.Trim() select s).FirstOrDefault();

					if (CptoAlquilerMensual == null)
						CptoAlquilerMensual = servicios[0];

					var maxNroCochera = cocheras.Count;
					int indexCochera = 0;


					var c = new Cliente();
					c.Nombre = cli.Nombre.Length == 0 ? "(sin nombre)" : cli.Nombre;
					c.Apellido = cli.Apellido.Length == 0 ? "(sin Apellido)" : cli.Apellido;
					c.NroCliente = cli.NroCliente;
					c.Alta = cli.FechaIngreso.Value;
					//c.Observaciones = "Fecha Ingreso: " + (cli.FechaIngreso.HasValue ? cli.FechaIngreso.Value.ToShortDateString(): ""); 
					c.Abreviatura = "IMPORTADO";
					c.Baja = cli.Baja;

					Contacto cto = new Contacto();
					cto.Domicilio = cli.Domicilio;
					cto.Telefono = cli.Telefono;
					cto.Movil = cli.Celular;
					c.Contacto = cto;

					c.DomicilioFiscal = cli.DomFiscal;
					c.CUIT = cli.CUIT;
					c.RazonSocial = cli.RazonSocial;

					var lineasCocheras = new List<Proxy_LineaAsocCocheraMensual>();
					var lineasVehiculos = new List<Vehiculo>();
					Cochera coche = cocheras[indexCochera];
					var l = new Proxy_LineaAsocCocheraMensual(c,coche , CptoAlquilerMensual);
					l.Desde = c.Alta.Inferior(DateInterval.Day);
					l.Hasta = !cli.Baja.IsNullOrMinValue() ? cli.Baja.Value.Superior(DateInterval.Day) : (DateTime?)null;
					lineasCocheras.Add(l);

					var v = new Vehiculo();
					v.Marca = cli.Marca.Length == 0 ? "(Sin Marca)" : cli.Marca;
					v.Abreviatura = "IMPORTADO";
					v.Modelo = "";
					v.Nombre = cli.Dominio.Length == 0 ? "(Sin Dominio)" : cli.Dominio;

					lineasVehiculos.Add(v);

					expMens.NuevoMensual(c, lineasCocheras, lineasVehiculos, false);
					indexCochera++;

					cli.IdCliente = c.Id;
					cli.IdConcepto = CptoAlquilerMensual.Id;
					cli.IdCochera = coche.Id;
				}
			}
		}

		private List<Concepto> ObtenerServicios()
		{
			List<Concepto> servicios = new List<Concepto>();
			using (var expConcepto = FabExpertos.Inst.Obtener<ExpConcepto>(this))
				servicios.AddRange(expConcepto.ListaConceptos(null, ConceptoIngresos.ALQUILER_MENSUAL));
			return servicios;
		}


		public void ImportarPagosMensuales(List<ClienteMensualProxy> _clientes, List<PagosMensuales> _regPagos)
		{
			// Crear N lienas de pagos por cada cliente.
			var precioBd = ObtenerPrecios();
			foreach (var c in _clientes)
			{

				using (var exp = FabExpertos.Inst.Obtener<ExpPagosMensuales>(IdSesion))
				{

					var clienteBD = Persistidor.Primero<Cliente>(cl => cl.Id == c.IdCliente);
					var cptoBD = Persistidor.Primero<Concepto>(cl => cl.Id == c.IdConcepto);
					var coche = Persistidor.Primero<Cochera>(cl => cl.Id == c.IdCochera);


					var pagosAImportar = (from r in _regPagos
										  where r.id == c.Id && r.FechaPago.HasValue
										  select new ProxyExpPagosMensLinea()
										  {
											  Cliente = clienteBD,
											  Bonificacion = 0,
											  Recargo = 0,
											  Concepto = cptoBD,
											  Cochera = coche,
											  Comentario = "Importado - " + r.Observaciones,
											  FechaPago = r.FechaPago.Value,
											  Periodo = r.PeriodoFecha,
											  Abonado = precioBd.Where(p => p.IdConcepto == cptoBD.Id && r.Periodo.Between(p.PeriodoDesde, p.PeriodoHasta)).FirstOrDefault().precio.Value, 
											  PrecioOrig = precioBd.Where(p => p.IdConcepto == cptoBD.Id && r.Periodo.Between(p.PeriodoDesde, p.PeriodoHasta)).FirstOrDefault().precio.Value
											  
										  }).ToList();


					exp.Guardar("Pago Importado para " + clienteBD.NombreCompleto, pagosAImportar);

				}
			}


		}

		
	   
	}


  

	public class ClienteMensualProxy
	{
		//public long id { get; set; }
		public int NroCliente { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime? FechaIngreso { get; set; }
		public string Servicio { get; set; }
		public string Dominio { get; set; }
		public string Marca { get; set; }
		public string Domicilio { get; set; }
		public string DomFiscal { get; set; }
		public string Celular { get; set; }
		public string Telefono { get; set; }
		public string CUIT { get; set; }
		public string RazonSocial { get; set; }
		
		public long Id { get; set; }

		public long IdCliente { get; set; }
		public long IdConcepto { get; set; }
		public long IdCochera { get; set; }
		public DateTime? Baja { get; set; }
		

	}
	public class PagosMensuales
	{
		public long id { get; set; }
		public int Periodo { get; set; }
		public DateTime? FechaPago { get; set; }
		public string Observaciones { get; set; }


		public DateTime PeriodoFecha
		{
			get
			{
				int a = Convert.ToInt32(Periodo.ToString().Substring(0,4));
				int m = (Periodo - (a * 100));

				return new DateTime(a, m, 1).AddMonths(1).AddDays(-1);
			}
		}
	}
	public class PreciosConceptos
	{
		public long IdConcepto { get; set; }
		public DateTime? Desde { get; set; }
		public DateTime? Hasta { get; set; }
		public int PeriodoDesde { get; set; }
		public int PeriodoHasta { get; set; }
		public decimal? precio { get; set; }
		public decimal? Importe { get; set; }
		public string Concepto { get; set; }
	}
}

