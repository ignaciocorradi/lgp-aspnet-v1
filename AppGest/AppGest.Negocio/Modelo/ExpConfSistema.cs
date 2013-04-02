using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Core;
using AppGest.Datos.Persistencia;

namespace AppGest.Negocio.Modelo
{
    public class ExpConfSistema : Experto
    {
        /// <summary>
        /// Obtiene la configuracion de menu del sistema
        /// </summary>
        /// <returns></returns>
        public List<ConfMenuProxy> ObtenerConfMenuProxy()
        {
            string sql = "SELECT [Orden],[Paginas],[Grupos],[Items],[ImagenItem]"
                    + " ,[TagItem],[ToolTips],[AutoSize]"
                    + " FROM [LGP].[ConfMenu]";

            var rdo = Persistidor.ExecuteStoreQuery<ConfMenuProxy>(sql).ToList();

            return rdo;
        }
        public List<ConfMenu> ObtenerConfMenu()
        {

            var rdo = Persistidor.Linq.ConfigMenu().ToList();
            if (rdo.Count == 0)
                CrearMenuSistema();
            rdo = Persistidor.Linq.ConfigMenu().ToList();

            return rdo;
        }
        /// <summary>
        /// OBSOLETO
        /// </summary>
        /// <returns></returns>
        public List<ConfMenuProxy> ObtenerConfMenuInicial()
        {
            var rdo = new List<ConfMenuProxy>();

            rdo.Add(new ConfMenuProxy() { Orden = "1.1.1", Paginas = "Clientes", Grupos = "Mensuales", Items = "Nuevo Cliente\nMensual", ImagenItem = "32.mensual_alta.png", TagItem = "rbiAltasMensuales", ToolTips = "Nuevo mensual", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.1.2", Paginas = "Clientes", Grupos = "Mensuales", Items = "Editar Cliente\nMensual", ImagenItem = "32.mensual_editar.png", TagItem = "rbiEditarMensual", ToolTips = "Editar datos mensual", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.2.1", Paginas = "Clientes", Grupos = "Gestión mensual", Items = "Cobro mensual", ImagenItem = "32.pagos.png", TagItem = "rbiPagoMensual", ToolTips = "Cobro mensual", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.2.2", Paginas = "Clientes", Grupos = "Gestión mensual", Items = "Editar cobros mensuales", ImagenItem = "32.editar_pago.png", TagItem = "rbiEditarPagoMensual", ToolTips = "Editar cobros mensuales", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.3.1", Paginas = "Clientes", Grupos = "Datos Clientes particulares", Items = "Nuevo cliente particular", ImagenItem = "32.clientes_nuevo.png", TagItem = "rbiNuevoCliente", ToolTips = "Nuevo cliente", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.3.2", Paginas = "Clientes", Grupos = "Datos Clientes particulares", Items = "Editar clientes", ImagenItem = "32.clientes_editar.png", TagItem = "rbiModifCliente", ToolTips = "Editar clientes", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.3.3", Paginas = "Clientes", Grupos = "Datos Clientes particulares", Items = "Editar vehículos", ImagenItem = "32.Auto_editar.png", TagItem = "rbiModifAutos", ToolTips = "Editar vehículos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.4.1", Paginas = "Clientes", Grupos = "Informes", Items = "Listado de clientes", ImagenItem = "32.rpt_ClientesMensuales.png", TagItem = "rbiReportes|R1", ToolTips = "Listado de clientes", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.4.2", Paginas = "Clientes", Grupos = "Informes", Items = "Detalle cobros y deudas", ImagenItem = "32.reporte_CobroMensuales.png", TagItem = "rbiReportes|R3", ToolTips = "Detalle cobros y deudas", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "1.4.3", Paginas = "Clientes", Grupos = "Informes", Items = "Resumen cobros y deudas", ImagenItem = "32.reporte_plata_grafico.png", TagItem = "rbiReportes|R5", ToolTips = "Resumen cobros y deudas", AutoSize = "SI" });

            rdo.Add(new ConfMenuProxy() { Orden = "2.1.1", Paginas = "Ingresos", Grupos = "Gestión", Items = "Cobro de ingresos", ImagenItem = "32.cobro_ingresos.png", TagItem = "rbiAltasPagosIngresos", ToolTips = "Cobro de ingresos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "2.1.2", Paginas = "Ingresos", Grupos = "Gestión", Items = "Edición de cobros de ingresos", ImagenItem = "32.cobro_ingresos_edicion.png", TagItem = "rbiEdicionPagosIngresos", ToolTips = "Edición de cobros de ingresos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "2.1.3", Paginas = "Ingresos", Grupos = "Gestión", Items = "Asignar Factura", ImagenItem = "32.Factura.png", TagItem = "rbiAMBFactura", ToolTips = "Asignar Fatcura", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "2.1.3", Paginas = "Ingresos", Grupos = "Informes", Items = "Estado de cliente", ImagenItem = "32.rpt_ClientesMensuales.png", TagItem = "rbiReportes|R8", ToolTips = "Informe de estado de clientes", AutoSize = "SI" });

            rdo.Add(new ConfMenuProxy() { Orden = "2.1.3", Paginas = "Egresos", Grupos = "Gestión", Items = "Pago de egresos", ImagenItem = "32.Pago_egresos.png", TagItem = "rbiAltasPagosGastosVarios", ToolTips = "Pago de egresos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "2.1.4", Paginas = "Egresos", Grupos = "Gestión", Items = "Edición de pagos de egresos", ImagenItem = "32.Pago_egresos_edicion.png", TagItem = "rbiEdicionPagosGastosVarios", ToolTips = "Edición de pagos de egresos", AutoSize = "SI" });
            
            rdo.Add(new ConfMenuProxy() { Orden = "3.1.1", Paginas = "Empleados", Grupos = "Datos de empleados", Items = "Alta", ImagenItem = "32.empleado_nuevo.png", TagItem = "rbiNuevoEmpleado", ToolTips = "Alta", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.1.2", Paginas = "Empleados", Grupos = "Datos de empleados", Items = "Editar ", ImagenItem = "32.empleado_editar.png", TagItem = "rbiEditarEmpleado", ToolTips = "Editar ", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.2.1", Paginas = "Empleados", Grupos = "Gestión", Items = "Pago a empleados", ImagenItem = "", TagItem = "", ToolTips = "Pago a empleados", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.2.2", Paginas = "Empleados", Grupos = "Gestión", Items = "Editar pagos", ImagenItem = "", TagItem = "", ToolTips = "Editar pagos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.3.1", Paginas = "Empleados", Grupos = "Informes", Items = "Listado de Empleados", ImagenItem = "32.rpt_listadoEmpleados.png", TagItem = "rbiReportes|R2", ToolTips = "Listado de Empleados", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.4.1", Paginas = "Empleados", Grupos = "Parámetros", Items = "Nuevo Concepto", ImagenItem = "32.cptos_gastos_empleado.png", TagItem = "rbiNuevoCptoGastoEmpleado", ToolTips = "Nuevo Concepto", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.4.2", Paginas = "Empleados", Grupos = "Parámetros", Items = "Editar Concepto", ImagenItem = "32.editar_cptos_gastos_empleado.png", TagItem = "rbiModifCptoGastoEmpleado", ToolTips = "Editar datos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.4.3", Paginas = "Empleados", Grupos = "Parámetros", Items = "Configuración de Montos", ImagenItem = "32.editar_precio_gasto-empleado.png", TagItem = "rbiListaGastosEmpleados", ToolTips = "Configuración de montos asignables", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.4.4", Paginas = "Empleados", Grupos = "Parámetros", Items = "Asignar sueldo por Empleados", ImagenItem = "32.sueldo_por_empleado.png", TagItem = "rbiParamEgresoEmpleado", ToolTips = "Asignar sueldo por Empleados por periodo.", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.5.1", Paginas = "Empleados", Grupos = "Pagos", Items = "Pago a Empleados", ImagenItem = "32.pago_empleados.png", TagItem = "rbiPagoEgresoEmpleado", ToolTips = "Pago a empleadoa", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "3.5.2", Paginas = "Empleados", Grupos = "Pagos", Items = "Informe de pagos", ImagenItem = "32.informe.png", TagItem = "rbiReportes|R7", ToolTips = "Informe de pagos efectuados a empleados", AutoSize = "SI" });
            
            rdo.Add(new ConfMenuProxy() { Orden = "4.1.1", Paginas = "Parámetros generales", Grupos = "Datos de cocheras", Items = "Nuevo", ImagenItem = "32.garage_nuevo.png", TagItem = "rbiNuevaCochera", ToolTips = "Nuevo", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.1.2", Paginas = "Parámetros generales", Grupos = "Datos de cocheras", Items = "Editar datos", ImagenItem = "32.garage_editar.png", TagItem = "rbiEditarCocheras", ToolTips = "Editar datos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.1.3", Paginas = "Parámetros generales", Grupos = "Datos de cocheras", Items = "Listado de cochera", ImagenItem = "32.informe.png", TagItem = "rbiReportes|R6", ToolTips = "Listado de cochera", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.2.1", Paginas = "Parámetros generales", Grupos = "Datos de Ingresos", Items = "Nuevo Concepto", ImagenItem = "32.Nuevo_Serv_Ingresos2.png", TagItem = "rbiNuevoCptoIngreso", ToolTips = "Nuevo Concepto", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.2.2", Paginas = "Parámetros generales", Grupos = "Datos de Ingresos", Items = "Editar datos", ImagenItem = "32.Editar_Serv_Ingresos2.png", TagItem = "rbiModifCptoIngreso", ToolTips = "Editar datos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.2.3", Paginas = "Parámetros generales", Grupos = "Datos de Ingresos", Items = "Asignar Precio", ImagenItem = "32.Serv_Ingresos_Precios.png", TagItem = "rbiListaIngresos", ToolTips = "Asignar Precio", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.3.1", Paginas = "Parámetros generales", Grupos = "Datos de Egresos", Items = "Nuevo Concepto", ImagenItem = "32.banco_alta.png", TagItem = "rbiNuevoCptoGastoVario", ToolTips = "Nuevo Concepto", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.3.2", Paginas = "Parámetros generales", Grupos = "Datos de Egresos", Items = "Editar datos", ImagenItem = "32.banco_editar.png", TagItem = "rbiModifCptoGastoVario", ToolTips = "Editar datos", AutoSize = "SI" });
            rdo.Add(new ConfMenuProxy() { Orden = "4.3.3", Paginas = "Parámetros generales", Grupos = "Datos de Egresos", Items = "Asignar Precio", ImagenItem = "32.banco_precios.png", TagItem = "rbiListaGastos", ToolTips = "Asignar Precio", AutoSize = "SI" });



            return rdo;
        }

        internal void Guardar(ConfMenu item)
        {
            if (item.Id == 0)
            {
                Persistidor.GuardarConfiguracionNueva(item);
            }
            else
            {
                Persistidor.GuardarConfiguracionModif(item);
            }
           
            
        }


        public virtual void CrearMenuSistema()
        {
            var configs = ObtenerConfMenuInicial();

            var confsNuevas = (from conf in configs
                               select new ConfMenu()
                               {
                                   AutoSize = conf.AutoSize,
                                   Grupos = conf.Grupos,
                                   ImagenItem = conf.ImagenItem,
                                   Items = conf.Items,
                                   Orden = conf.Orden,
                                   Paginas = conf.Paginas,
                                   TagItem = conf.TagItem,
                                   ToolTips = conf.ToolTips
                               }).ToList();

            foreach (var item in confsNuevas)
            {
                Guardar(item);
                Persistidor.Confirmar();
            }
        }
    
    }

    public class ConfMenuProxy
    {
        public string Orden { get; set; }
        public string Paginas { get; set; }
        public string Grupos { get; set; }
        public string Items { get; set; }
        public string ImagenItem { get; set; }
        public string TagItem { get; set; }
        public string Estado { get; set; }
        public string ToolTips { get; set; }
        public string Tamaño { get; set; }
        public string AutoSize { get; set; }
        public string Tipo { get; set; }

    }

}
