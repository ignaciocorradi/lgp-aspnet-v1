using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;

namespace AppGest.Negocio.Modelo
{
    /// <summary>
    /// Representa una linea de registro de para la asociacion de Cochera a Mensuales.
    /// </summary>
    public class Proxy_LineaAsocCocheraMensual
    {
       
        #region -- Constructores --

        public Proxy_LineaAsocCocheraMensual(Reg_Det linea)
            : this(linea.EntidadAfectada1 as Cliente, linea.ValLista1 as Cochera, linea.ValLista2 as Concepto)
        {
            Linea = linea;
        }

        public Proxy_LineaAsocCocheraMensual(Cliente cliente, Cochera cochera, Concepto cptoIngreso)
        {
            this.Cliente = cliente;
            this.Cochera = cochera;
            this.CptoIngresoMensual = cptoIngreso;
        }
        #endregion

        #region -- Propiedades --
        
        public bool Baja
        {
            get { return this.Hasta.HasValue; }
        }
        public bool EsNuevo
        {
            get { return Linea == null || Linea.Id == 0; }
        }
        public Reg_Det Linea { get; set; }
        public Cochera Cochera { get; set; }
        public DateTime? Desde
        {

            get
            {
                if (Linea == null)
                {
                   return _desde;
                }
                else
                    return Linea.ValFecha1;
            }
            set
            {
                var aux = value.IsNullOrMinValue() ? (DateTime?) null : value.Value.Inferior(DateInterval.Day);

                if (Linea == null)
                    _desde = aux;
                else
                    Linea.ValFecha1 = aux;
            }

        }DateTime? _desde;
        public DateTime? Hasta
        {

            get
            {
                if (Linea == null)
                    return _hasta;
                else
                    return Linea.ValFecha2;
            }
            set
            {
                var aux = value.IsNullOrMinValue() ? (DateTime?) null : value.Value.Superior(DateInterval.Day);

                if (Linea == null)
                    _hasta = aux;
                else
                    Linea.ValFecha2 = aux;
            }
        }DateTime? _hasta;
        public Concepto CptoIngresoMensual
        {
            get;
            set;
        }
        public Cliente Cliente
        {
            get;
            set;
        }
        #endregion
        
    }

    /// <summary>
    /// Proxy que encapsula el Encabezado de una registracion de Asociación de Mensuales conteniendo la lista de registros de 
    /// lineas de asociación de cocheras y de asociacion de vehículos.
    /// </summary>
    public class Proxy_Mensuales
    {

        #region -- Constantes --
        public const string PROP_NroCliente = "NroCliente";
        public const string PROP_NombreCliente = "NombreCliente";
        public const string PROP_NombreVehiculos = "NombreVehiculos";
        public const string PROP_NombreCocheras = "NombreCocheras";
        public const string PROP_Baja = "BajaCliente";
        #endregion

        #region -- Contructores
        /// <summary>
        /// Constructor para la modificación de un mensual. 
        /// </summary>
        /// <param name="idEncabezado">Id del registro de encabezado</param>
        public Proxy_Mensuales(Guid idSesion, Reg_encab encabezado)
        
        {
            IdSesion = idSesion;
            Cliente = encabezado.EntidadAfectada as Cliente;
            Cocheras = encabezado.Reg_Det.Where(r => r.Concepto == this.cptoRelCochera).ToList() ;
            Vehiculos = encabezado.Reg_Det.Where(r => r.Concepto == this.cptoRelCochera).ToList();
            Encabezado = encabezado;
        }

        public Proxy_Mensuales(Guid  idsesion):base()
        {
            IdSesion = idsesion;
        }
        public Proxy_Mensuales()
        {
            
            Cliente = new Cliente();
            Cocheras = new List<Reg_Det>() { new Reg_Det() };
            Vehiculos = new List<Reg_Det>() { new Reg_Det() };
            Encabezado = new Reg_encab();

        }
        #endregion

        #region -- Atributos --
        
        public Reg_encab Encabezado;
        public IList<Reg_Det> Vehiculos;
        public IList<Reg_Det> Cocheras;
        public Cliente Cliente;
        #endregion

        #region -- Propiedades --
        Guid IdSesion;
        public Concepto cptoTransaccion
        {
            get
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                {
                    return exp.cptoTransaccion;
                }

            }
        }
        public Concepto cptoRelVehiculo
        {
            get
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                {
                    return exp.cptoRelVehiculo;
                }
            }
        }
        public Concepto cptoRelCochera
        {
            get
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(IdSesion))
                {
                    return exp.cptoRelCochera;
                }
            }
        }

        
        public bool EsNuevo
        {
            get { return Encabezado == null || Encabezado.Id == 0; }

        }        
        public int NroCliente
        {
            get 
            {
                return Cliente == null ? -1 : Cliente.NroCliente ;
            }
        }
        public string NombreCliente { get { return Cliente == null ? string.Empty : Cliente.NombreCompleto; } }
        public bool BajaCliente { get { return Cliente == null ? false : Cliente.Baja.HasValue; } }

        public string NombreVehiculosSolos
        {
            get
            {
                if (Vehiculos.Count == 0 || (Vehiculos.Count > 0 && Vehiculos[0].ValLista1 == null))
                    return "(Sin vehículos asignados)";
                else
                    return string.Join(" ", Vehiculos.Select(x => ((Vehiculo)x.ValLista1).Nombre + " " + ((Vehiculo)x.ValLista1).Marca).ToArray());
            } 
        }
        public string NombreVehiculos
        {
            get 
            {
                if (Vehiculos.Count == 0 || (Vehiculos.Count > 0 && Vehiculos[0].ValLista1 == null))
                    return "(Sin vehículos asignados)";
                else
                    return string.Join(", ", Vehiculos.Select(x => "(" + ((Vehiculo)x.ValLista1).Nombre + " - " + ((Vehiculo)x.ValLista1).Marca + ")").ToArray());
            } 
        }
        public string NombreCocheras
        {
            get
            {
                if (Cocheras.Count == 0 || (Cocheras.Count > 0 && Cocheras[0].ValLista1 == null))
                    return "(Sin cocheras asignadas)";
                else
                    return string.Join(", ", Cocheras.OrderByDescending(y => y.ValFecha1).OrderBy(f => f.ValLista1.Nombre)
                                    .Select(x => "("+ x.ValLista1.Nombre + " - " 
                                        + (x.ValFecha1.HasValue ? "desde: "+ x.ValFecha1.Value.ToString("MMM - yyyy") : string.Empty)
                                        + (x.ValFecha2.HasValue ? " hasta: " + x.ValFecha2.Value.ToString("MMM - yyyy") : string.Empty) 
                                        + ")").ToArray()) ;
            }
        }
        public string NombreCocherasSolos
        {
            get
            {
                if (Cocheras.Count == 0 || (Cocheras.Count > 0 && Cocheras[0].ValLista1 == null))
                    return "(Sin cocheras asignadas)";
                else
                    return string.Join(" ", Cocheras.OrderByDescending(y => y.ValFecha1).OrderBy(f => f.ValLista1.Nombre)
                                    .Select(x => x.ValLista1.Nombre).ToArray());
            }
        }
        #endregion



    }
}
