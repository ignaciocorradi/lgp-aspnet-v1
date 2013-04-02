using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;

using AppGest.Negocio.Core;
using AppGest.Util.Atributos;

namespace AppGest.Negocio.Modelo.Inicializacion.Implementacion
{
    public class ExpInicializacionTest: ExpInicializacion
    {

        Random _rnd = new Random(27118392);
        public override void Inicializar()
        {
            base.Inicializar();

            Persistidor.Compartido = true;
            
            if (Persistidor.Contar<Usuario>() == 0)
            {
                CrearEmpresa(true);
                var empl = CrearEmpleadosYUsuarios();

                Persistidor.Confirmar();
                IdSesion = IniciarSesion();

                CrearServicios();
                Persistidor.Confirmar();
                
                var cl = CrearClientes(false);
                var ch = CrearCocheras(true);
                var vh = CrearVehiculos(false); 

                CrearMensuales(cl, ch, vh, empl);

                CrearMenuSistema();
                CerrarSesion();
            }


        }

        protected override void CrearConceptos()
        {
            base.CrearConceptos();

            if (Persistidor.Linq.Entidades<Concepto>().Where(c => c.Abreviatura == "REMU").FirstOrDefault() == null)
            {
                var cpto = new Concepto()
                {
                    Alta = DateTime.Now,
                    Nombre = "Remuneración",
                    Abreviatura = "REMU",
                    Descripcion = "Remuneración",
                    Clase = (int)TipoConcepto.ConceptoEgresos,
                    Valor = (int)ConceptoEgresos.EGRESOS_EMPLEADOS
                };
                Persistidor.GuardarEntidadNuevo(cpto);
            }

            Persistidor.Confirmar();
            
        }
        protected virtual  List<Empleado> CrearEmpleadosYUsuarios()
        {
            int cantUsuarios = 10;
            var rdo = new List<Empleado>();
            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(this.IdSesion))
            {
                for (int i = 0; i < cantUsuarios; i++)
                {
                    var emp = exp.Nuevo();
                    LlenarDatosEmpleados(i, emp);
                    exp.CrearUsuario(emp);
                    LlenarDatosUsuario(i,  emp.Usuario);
                    exp.Guardar(emp);
                }
            }
            Persistidor.Confirmar();
            return rdo;
        }
        

        protected virtual void LlenarDatosEmpleados(int i, Empleado emp)
        {
            emp.Apellido = _apellidos[_rnd.Next(0, _apellidos.Length - 1)];
            emp.Nombre2 = _nombres[_rnd.Next(50, _nombres.Length - 1)];
            emp.Nombre = _nombres[_rnd.Next(0, _nombres.Length - 1)];

            List<string> cadenas = emp.Nombre.Split().ToList<string>();
            cadenas.AddRange(emp.Apellido.Split().ToList<string>());
            emp.Abreviatura = new string(cadenas.Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());

            emp.Alta = DateTime.Now;
            emp.Id = 0;

            var domicilio = new Contacto();
            domicilio.Movil = "0261 154 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
            domicilio.Telefono = "0261 155 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
            domicilio.TelefonoTrabajo = "0261 156 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
            domicilio.Domicilio = "Domicilio " + i.ToString().PadLeft(2, '0');
            domicilio.Email = emp.Nombre[0].ToString().ToLower() + emp.Apellido.ToLower() + "@gmail.com";

            emp.Contacto = domicilio;
        }

        protected virtual void CerrarSesion()
        {
            ExpSeguridad.Instancia.CerrarSesion(IdSesion);
        }

        protected virtual Guid IniciarSesion()
        {
            return ExpSeguridad.Instancia.IniciarSesion("usu00", "123");
        }

        protected virtual IList<Empresa> CrearEmpresa(bool guardar)
        {
            var rdo = new List<Empresa>();
            for (int i = 0; i < 1; i++)
            {
                var empresa = new Empresa();
                empresa.Apellido = _apellidos[_rnd.Next(0, _apellidos.Length - 1)];
                empresa.Nombre2 = _nombres[_rnd.Next(50, _nombres.Length - 1)];
                empresa.Nombre = _nombres[_rnd.Next(0, _nombres.Length - 1)];

                List<string> cadenas = empresa.Nombre.Split().ToList<string>();
                cadenas.AddRange(empresa.Apellido.Split().ToList<string>());
                empresa.Abreviatura = new string(cadenas.Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());

                empresa.Alta = DateTime.Now;
                empresa.Id = 0;

                var domicilio = new Contacto();
                domicilio.Movil = "0261 154 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.Telefono = "0261 155 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.TelefonoTrabajo = "0261 156 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.Domicilio = "Domicilio " + i.ToString().PadLeft(2, '0');
                domicilio.Email = empresa.Nombre[0].ToString().ToLower() + empresa.Apellido.ToLower() + "@gmail.com";

                empresa.Contacto = domicilio;

                if (guardar)
                    Persistidor.GuardarEntidadNuevo(empresa);

                rdo.Add(empresa);
            }

            return rdo;
        }

        protected virtual void CrearServicios()
        {
            var fecha = new DateTime(2012, 1, 1);
            ExpConcepto.CrearServicios(IdSesion, fecha, _rnd);
        }

        protected virtual void CrearMensuales(List<Cliente> clientes, List<Cochera> cocheras, List<Vehiculo> vehiculos, List<Empleado> emp)
        {
            while (cocheras.Count != 0 && clientes.Count != 0 && vehiculos.Count != 0)
            {
                using (var exp = FabExpertos.Inst.Obtener<ExpMensuales>(this.IdSesion))
                {
                    List<Concepto> servicios = new List<Concepto>();
                    using (var expConcepto = FabExpertos.Inst.Obtener<ExpConcepto>(this))
                        servicios.AddRange(expConcepto.ListaConceptos(null, ConceptoIngresos.ALQUILER_MENSUAL));

                    if (servicios.Count == 0)
                        return;

                    var cant = _rnd.Next(1, Math.Min(cocheras.Count, cocheras.Count / clientes.Count));
                    var cliente = clientes[_rnd.Next(0, clientes.Count)];

                    var temp1 = new List<Proxy_LineaAsocCocheraMensual>();
                    var temp2 = new List<Vehiculo>();
                    
                    var expCpto = FabExpertos.Inst.Obtener<ExpConcepto>(this.IdSesion);

                    for(int i= 0; i < cant; i++)
                    {
                        var co = cocheras[_rnd.Next(0, cocheras.Count)];
                        var servicio = servicios[_rnd.Next(0, servicios.Count)];

                        var precios = expCpto.ObtenerLineasConcepto(servicio.Id, expCpto.CptoTransaccionPrecio.Id);
                        if (precios.Count() != 0)
                        {
                            var proxy = new Proxy_LineaAsocCocheraMensual(cliente, co, servicio);

                            var indexprecio = _rnd.Next(0, precios.Count());
                            var fecha = precios.ElementAt(indexprecio).ValFecha1;

                            proxy.Desde = fecha.Value.Inferior(DateInterval.Month);
                            proxy.Hasta = null;

                            temp1.Add(proxy);
                            cocheras.Remove(co);

                            var ve = vehiculos[_rnd.Next(0, vehiculos.Count)];
                            temp2.Add(ve);
                            vehiculos.Remove(ve);
                        }
                        else
                        {
                            cant--; // se vuelve a intentar
                        }
                    }

                    clientes.Remove(cliente);
                    if (temp1.Count * temp2.Count != 0)
                        exp.NuevoMensual(cliente, temp1, temp2);
                }

            }
        }

        //protected virtual List<Usuario> CrearUsuarios(List<Empleado> empleados, bool guardar)
        //{
        //    var usuarios = new List<Usuario>();
        //    int i = 0;
        //    foreach (var emp in empleados)
        //    {
                
        //        var usuario = new Usuario();
        //        LlenarDatosUsuario(i, usuario);
        //        emp.Usuario = usuario;

        //        if (guardar)
        //            Persistidor.GuardarEntidadNuevo(emp);
    
        //        usuarios.Add(usuario);
        //        i++;
        //    }

        //    return usuarios;
        //}

        private static void LlenarDatosUsuario(int i, Usuario usuario)
        {
            usuario.Abreviatura = "usu" + i.ToString().PadLeft(2, '0'); ;
            usuario.Nombre = "usu" + i.ToString().PadLeft(2, '0'); ;
            usuario.Clave = "123";
            usuario.Alta = DateTime.Now;
            usuario.Id = 0;
            usuario.Tipo = (byte)((i % 3) + 1);

            
        }

        protected virtual List<Vehiculo> CrearVehiculos(bool guardar)
        {
            var letra = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            var vehiculos = new List<Vehiculo>();
            for (int i = 0; i < 200; i++)
            {
                var letras = letra[_rnd.Next(0, letra.Length - 1)].ToString() + letra[_rnd.Next(0, letra.Length - 1)].ToString() + letra[_rnd.Next(0, letra.Length - 1)].ToString();
                var numeros = _rnd.Next(0, 9).ToString() + _rnd.Next(0, 9).ToString() + _rnd.Next(0, 9).ToString();
                var dom = string.Format("{0}-{1}", letras, numeros);

                var vehiculo = new Vehiculo();

                vehiculo.Abreviatura = dom;
                vehiculo.Nombre = dom;
                vehiculo.Marca = "Marca" + _rnd.Next(0, 9).ToString().PadLeft(2, '0');
                vehiculo.Modelo = "Mod" + _rnd.Next(0, 9).ToString().PadLeft(2, '0');
                vehiculo.Alta = DateTime.Now;
                vehiculo.Id = 0;

                if (guardar)
                    Persistidor.GuardarEntidadNuevo(vehiculo);

                vehiculos.Add(vehiculo);
            }

            return vehiculos;
        }

        protected virtual List<Cochera> CrearCocheras(bool guardar)
        {
            var rdo = new List<Cochera>();
            for (int i = 0; i < 200; i++)
            {
                var cochera = new Cochera();
                cochera.Descripcion = "Cochera " + i.ToString().PadLeft(2, '0');
                cochera.NroCochera = "C" + i.ToString().PadLeft(2, '0');
                cochera.Abreviatura = cochera.NroCochera;
                cochera.Alta = DateTime.Now;
                cochera.Id = 0;

                if (guardar)
                    Persistidor.GuardarEntidadNuevo(cochera);

                rdo.Add(cochera);
            }

            return rdo;
        }

        protected virtual List<Cliente> CrearClientes(bool guardar)
        {
            
            
            var rdo = new List<Cliente>();
            for (int i = 0; i < 100; i++)
            {
                var cliente = new Cliente();
                cliente.Apellido = _apellidos[_rnd.Next(0, _apellidos.Length - 1)];
                cliente.Nombre2 = _nombres[_rnd.Next(50, _nombres.Length - 1)];
                cliente.Nombre = _nombres[_rnd.Next(0, _nombres.Length - 1)];
                cliente.NroCliente = i;

                List<string> cadenas = cliente.Nombre.Split().ToList<string>();
                cadenas.AddRange(cliente.Apellido.Split().ToList<string>());
                cliente.Abreviatura = new string(cadenas.Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());

                cliente.Alta = DateTime.Now;
                cliente.Id = 0;

                var domicilio = new Contacto();
                domicilio.Movil = "0261 154 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.Telefono = "0261 155 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.TelefonoTrabajo = "0261 156 " + _rnd.Next(1, 999).ToString().PadLeft(3, '0') + " " + _rnd.Next(1, 999).ToString().PadLeft(3, '0');
                domicilio.Domicilio = "Domicilio " + i.ToString().PadLeft(2, '0');
                domicilio.Email = cliente.Nombre[0].ToString().ToLower() + cliente.Apellido.ToLower() + "@gmail.com";

                cliente.Contacto = domicilio;

                if (guardar)
                    Persistidor.GuardarEntidadNuevo(cliente);

                rdo.Add(cliente);
            }

            return rdo;
        }



        static string[] _nombres = new string[] {
            "Abby", 
            "Abeni", 
            "Abia", 
            "Abigail", 
            "Abijail", 
            "Abira", 
            "Abra", 
            "Adelaida", 
            "Adelburga", 
            "Adele", 
            "Adelfa", 
            "Easter", 
            "Eavan", 
            "Eber", 
            "Gaby", 
            "Gada", 
            "Galadriel", 
            "Galatea", 
            "Laina", 
            "Lais", 
            "Oletha", 
            "Olga", 
            "Taffi", 
            "Tahirah", 
            "Taiana", 
            "Taiel", 
            "Bader", 
            "Badir", 
            "Bahari", 
            "Bahiano", 
            "Bahich", 
            "Bailey", 
            "Bainbridge", 
            "Baird", 
            "Balarama", 
            "Gadi", 
            "Gadiel", 
            "Gael", 
            "Gaetano", 
            "Queremon", 
            "Querian", 
            "Querubin", 
            "Quetzal", 
            "Quetzalcoatl", 
            "Quiliano", 
            "Vadin", 
            "Vail", 
            "Val", 
            "Valabonso", 
            "Yahto", 
            "Yain", 
            "Yair", 
            "Yako", 
            "Yal", 
            "Yale", 
            "Yam", 
            "Yamal"
        };


        static string[] _apellidos = new string[] {

            "Abrego", 
            "Abreu", 
            "Abuin", 
            "Acaño", 
            "Acebal", 
            "Acebillo", 
            "Decordoba", 
            "Degranada", 
            "Delacerda", 
            "DelaCorte", 
            "Delacruz", 
            "Delafuente", 
            "Delarosa", 
            "Hernando", 
            "Hernani", 
            "Herran", 
            "Herrera", 
            "Herrerias", 
            "Herrero", 
            "Herreros", 
            "Hervas", 
            "Hidalgo", 
            "Hierro", 
            "Mancebo", 
            "Mancera", 
            "Mansilla", 
            "Manrique", 
            "Manzano", 
            "Marañon", 
            "Marco", 
            "Marcos", 
            "Paez", 
            "Palacio", 
            "Palacios", 
            "Palafox", 
            "Palencia", 
            "Pallas", 
            "Palma", 
            "Saenz", 
            "Saez", 
            "Salas", 
            "Salazar", 
            "Salcedo", 
            "Saldaña", 
            "Salgado", 
            "Salinas", 
            "Valverde", 
            "Vaquero", 
            "Varcarcel", 
            "Varela", 
            "Vargas", 
            "Vazquez", 
            "Vega", 
            "Velasco", 
            "Velez", 
            "Velilla", 
            "Vellugo", 
            "Zambrano", 
            "Zamora", 
            "Zarate", 
            "Zarza", 
            "Zurita"

        };
    }
}
