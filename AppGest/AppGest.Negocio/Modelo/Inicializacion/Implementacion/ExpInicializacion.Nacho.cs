using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Datos.Persistencia;
using AppGest.Negocio.Core;
using AppGest.Util.Atributos;

namespace AppGest.Negocio.Modelo.Inicializacion.Implementacion
{
    public class ExpInicializacionNacho: ExpInicializacionTest
    {

        protected override IList<Empresa> CrearEmpresa(bool guardar)
        {

            var rdo = new List<Empresa>();

            var empresa = new Empresa();
            empresa.Apellido = "";
            empresa.Nombre2 = "";
            empresa.Nombre = "La Gran Playa";

            empresa.Abreviatura = "LGP";

            empresa.Alta = DateTime.Now;
            empresa.Id = 0;

            var domicilio = new Contacto();
            domicilio.Movil = "0261 154 0000000";
            domicilio.Telefono = "0261 155 00000";
            domicilio.TelefonoTrabajo = "0261 156 000000";
            domicilio.Domicilio = "San Martin y Morón";
            domicilio.Email = "info@lgp.com";

            empresa.Contacto = domicilio;

            if (guardar)
                Persistidor.GuardarEntidadNuevo(empresa);

            rdo.Add(empresa);


            return rdo;
        }
        protected override List<Datos.Persistencia.Cliente> CrearClientes(bool guardar)
        {
            var rdo = new List<Cliente>();
            return rdo;
        }

        
        protected override void CrearMensuales(List<Cliente> clientes, List<Cochera> cocheras, List<Vehiculo> vehiculos, List<Empleado> emp)
        {
            Persistidor.Confirmar();
        }

        protected override List<Vehiculo> CrearVehiculos(bool guardar)
        {
            var rdo = new List<Vehiculo>();
            return rdo;

        }
        protected override System.Guid IniciarSesion()
        {
            return ExpSeguridad.Instancia.IniciarSesion("admin", "123");
            
        }
        protected override List<Empleado> CrearEmpleadosYUsuarios()
        {
            
            var rdo = new List<Empleado>();

            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
            {

                var emp = exp.Nuevo();
                DatosEmpleadosAdministrador(emp);
                exp.CrearUsuario(emp);

                emp.Usuario.Abreviatura = "admin";
                emp.Usuario.Nombre = "admin";
                emp.Usuario.Clave = "123";
                emp.Usuario.Alta = DateTime.Now;
                emp.Usuario.Id = 0;
                emp.Usuario.Tipo = (byte) TipoUsuario.ADMINISTRADOR;
                emp.Lock = true;

                exp.Guardar(emp);
            }
            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
            {
                var empS = exp.Nuevo();
                DatosEmpleadosSupervisor(empS);
                exp.CrearUsuario(empS);

                empS.Usuario.Abreviatura = "ruben";
                empS.Usuario.Nombre = "ruben";
                empS.Usuario.Clave = "123456";
                empS.Usuario.Alta = DateTime.Now;
                empS.Usuario.Id = 0;
                empS.Usuario.Tipo = (byte)TipoUsuario.SUPERVISOR;

                exp.Guardar(empS);

            
            }
            using (var exp = FabExpertos.Inst.Obtener<ExpEmpleado>(IdSesion))
            {
                var empS = exp.Nuevo();
                DatosEmpleadosSupervisor(empS);
                exp.CrearUsuario(empS);

                empS.Nombre = "Jorge";
                empS.Apellido = "Privitera";
                empS.Dni = 12162485;
                empS.Contacto.Domicilio = "Jorge Newbery 258 ciudad Mendoza";
                empS.Contacto.Telefono = "4232118";
                empS.Contacto.Movil = "2614684682";

                empS.Usuario.Abreviatura = "JP";
                empS.Usuario.Nombre = "jorge";
                empS.Usuario.Clave = "123";
                empS.Usuario.Alta = DateTime.Now;
                empS.Usuario.Id = 0;
                empS.Usuario.Tipo = (byte)TipoUsuario.SUPERVISOR;

                exp.Guardar(empS);


            }
            //Persistidor.Confirmar();
            return rdo;

            
        }

        void DatosEmpleadosAdministrador(Empleado emp)
        {
            emp.Apellido = "Administrador";
            emp.Nombre2 = "";
            emp.Nombre = "Administrador";

            List<string> cadenas = emp.Nombre.Split().ToList<string>();
            cadenas.AddRange(emp.Apellido.Split().ToList<string>());
            emp.Abreviatura = new string(cadenas.Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());

            emp.Alta = DateTime.Now;
            emp.Id = 0;

            var domicilio = new Contacto();
            domicilio.Movil = "0";
            domicilio.Telefono = "0";
            domicilio.TelefonoTrabajo = "0";
            domicilio.Domicilio = "";
            domicilio.Email = "ic@gmail.com";
            emp.Contacto = domicilio;
        }
        void DatosEmpleadosSupervisor( Empleado emp)
        {
            emp.Apellido = "Sanchez";
            emp.Nombre2 = "";
            emp.Nombre = "Rubén";

            List<string> cadenas = emp.Nombre.Split().ToList<string>();
            cadenas.AddRange(emp.Apellido.Split().ToList<string>());
            emp.Abreviatura = new string(cadenas.Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());

            emp.Alta = new DateTime(2013,1,1);
            emp.Id = 0;

            var domicilio = new Contacto();
            domicilio.Movil = "0";
            domicilio.Telefono = "0";
            domicilio.TelefonoTrabajo = "0";
            domicilio.Domicilio = "San Martin xxx Ciudad";
            domicilio.Email = emp.Nombre[0].ToString().ToLower() + emp.Apellido.ToLower() + "@gmail.com";
            emp.Contacto = domicilio;
        }


        protected override void CrearServicios()
        {
            // Sobreescribo el metodo para dar de alta los servicios que tiene la playa.
            CrearServiciosPROD();
        }

        public Concepto cptoTransaccionPrecio { get { return HelperModelo.ObtenerConceptoSistema(this, ConceptoTransacciones.ALTA_LISTA_PRECIOS); } }

        public void CrearServiciosPROD()
        {
            DateTime fechaBase = DateTime.Now;
            // Obtengo la lista de servicios a persistir.
            var servicios = CrearServicios(fechaBase);

            var concepto = (from c in servicios where c.Abreviatura == "TM" select c).FirstOrDefault();

            Reg_encab encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            //Desde	        Hasta	    Precio	Servicio
            //01/03/2012	30/09/2012	    $ 260 	Mañana
            DateTime? desde = new DateTime(2012, 3, 1);
            DateTime? hasta = new DateTime(2012, 9, 30);
            var precio = 260M;

            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);

            //01/10/2012		            $ 290 	Mañana *
            desde = new DateTime(2012, 10, 1);
            hasta = null;
            precio = 290M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);


            Persistidor.GuardarTransaccionNuevo(encabezado);


            // Creacion del precio para el Concepto de remuneracion. 
            concepto = (from c in servicios where c.Abreviatura == "REMU" select c).FirstOrDefault();
            encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            desde = new DateTime(2012, 3, 1);
            hasta = null;
            precio = 1M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);

            Persistidor.GuardarTransaccionNuevo(encabezado);


            concepto = (from c in servicios where c.Abreviatura == "TMyT" select c).FirstOrDefault();
            encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            //01/03/2012	30/09/2012	    $ 295 	Mañana y tarde
            desde = new DateTime(2012, 3, 1);
            hasta = new DateTime(2012, 9, 30);
            precio = 295M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);
            //01/10/2012		            $ 330 	Mañana y tarde
            desde = new DateTime(2012, 10, 1);
            hasta = null;
            precio = 330M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);

            Persistidor.GuardarTransaccionNuevo(encabezado);
            //Persistidor.Confirmar();



            concepto = (from c in servicios where c.Abreviatura == "TMyTN" select c).FirstOrDefault();
            encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            //01/03/2012	30/09/2012	    $ 320 	Mañana tarde y noche
            desde = new DateTime(2012, 3, 1);
            hasta = new DateTime(2012, 9, 30);
            precio = 320M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);
            //01/10/2012		            $ 360 	Mañana tarde y noche
            desde = new DateTime(2012, 10, 1);
            hasta = null;
            precio = 360M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);

            Persistidor.GuardarTransaccionNuevo(encabezado);
            //Persistidor.Confirmar();


            concepto = (from c in servicios where c.Abreviatura == "PEAGSM" select c).FirstOrDefault();
            encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            //01/03/2012	30/09/2012	    $ 270 	Para automotores (mañana y tarde)
            desde = new DateTime(2012, 3, 1);
            hasta = new DateTime(2012, 9, 30);
            precio = 270M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);
            //01/10/2012		            $ 310 	Para automotores (mañana y tarde)
            desde = new DateTime(2012, 10, 1);
            hasta = null;
            precio = 310M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);
            Persistidor.GuardarTransaccionNuevo(encabezado);
            //Persistidor.Confirmar();


            concepto = (from c in servicios where c.Abreviatura == "PER" select c).FirstOrDefault();
            encabezado = CrearEncabezado(fechaBase, cptoTransaccionPrecio);
            //01/03/2012	30/09/2012	    $ 305 	Rodriguez
            desde = new DateTime(2012, 3, 1);
            hasta = new DateTime(2012, 9, 30);
            precio = 305M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);
            //01/10/2012		            $ 340 	Rodriguez
            desde = new DateTime(2012, 10, 1);
            hasta = null;
            precio = 340M;
            CrearRegistro(encabezado, fechaBase, concepto, desde, hasta, precio);

            Persistidor.GuardarTransaccionNuevo(encabezado);
            //Persistidor.Confirmar();


        }

        private void CrearRegistro(Reg_encab encabezado, DateTime fechaBase, Concepto concepto, DateTime? desde, DateTime? hasta, decimal precio)
        {
          
            Reg_Det detalle = new Reg_Det();
            detalle.Precio = precio;
            detalle.FechaAlta = DateTime.Now;

            detalle.ValFecha1 = desde;
            detalle.ValFecha2 = hasta;
            detalle.SetConcepto(concepto);
            detalle.SetReg_encab(encabezado);
            encabezado.Reg_Det.Add(detalle);
       
        }

        private Reg_encab CrearEncabezado( DateTime fechaBase, Concepto concepto)
        {

            Reg_encab encabezado = new Reg_encab();
            encabezado.SetConcepto(concepto);
            encabezado.FechaAlta = fechaBase;
            encabezado.FechaRegistro = fechaBase;
            //encabezado.SetUsuario(ObtenerUsuario(),true);
            //encabezado.SetUsuario(Persistidor.Linq.Entidades<Usuario>().FirstOrDefault());
            encabezado.SetEntidadEmpresa(Persistidor.Linq.Entidades<Empresa>().FirstOrDefault());
            return encabezado;
        }

        IList<Concepto> CrearServicios(DateTime alta)
        {
            var servicios = new List<Concepto>();
            //Desde	        Hasta	    Precio	Servicio
            //01/03/2012	30/09/2012	    $ 260 	Mañana *
            //01/03/2012	30/09/2012	    $ 270 	Para automotores (mañana y tarde)
            //01/03/2012	30/09/2012	    $ 295 	Mañana y tarde
            //01/03/2012	30/09/2012	    $ 305 	Rodriguez
            //01/03/2012	30/09/2012	    $ 320 	Mañana tarde y noche

            //01/10/2012		            $ 290 	Mañana *
            //01/10/2012		            $ 310 	Para automotores (mañana y tarde)
            //01/10/2012		            $ 330 	Mañana y tarde
            //01/10/2012		            $ 340 	Rodriguez
            //01/10/2012		            $ 360 	Mañana tarde y noche

            Concepto srv;
            if (Persistidor.Linq.Entidades<Concepto>().Where(c => c.Abreviatura == "REMU").FirstOrDefault() == null)
            {
                srv = new Concepto()
                {
                    Alta = alta,
                    Nombre = "Remuneración",
                    Abreviatura = "REMU",
                    Descripcion = "Remuneración",
                    Clase = (int)TipoConcepto.ConceptoEgresos,
                    Valor = (int)ConceptoEgresos.EGRESOS_EMPLEADOS
                };
                servicios.Add(srv);
            }

            srv = new Concepto()
            {
                Alta = alta,
                Nombre = "Mañana",
                Abreviatura = "TM",
                Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + " Turno Mañana",
                Clase = (int)TipoConcepto.ConceptoIngresos,
                Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
            };

            servicios.Add(srv);

            srv = new Concepto()
            {
                Alta = alta,
                Nombre = "Mañana y tarde",
                Abreviatura = "TMyT",
                Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + " Turno Mañana y tarde",
                Clase = (int)TipoConcepto.ConceptoIngresos,
                Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
            };

            servicios.Add(srv);

            srv = new Concepto()
            {
                Alta = alta,
                Nombre = "Mañana tarde y noche",
                Abreviatura = "TMyTN",
                Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + " Turno Mañana tarde y noche",
                Clase = (int)TipoConcepto.ConceptoIngresos,
                Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
            };

            servicios.Add(srv);

            srv = new Concepto()
            {
                Alta = alta,
                Nombre = "Precio Especial Rodriguez",
                Abreviatura = "PER",
                Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + " Turno Precio Especial Rodriguez",
                Clase = (int)TipoConcepto.ConceptoIngresos,
                Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
            };

            servicios.Add(srv);

            srv = new Concepto()
            {
                Alta = alta,
                Nombre = "Precio Especial Aut. Gral. SM",
                Abreviatura = "PEAGSM",
                Descripcion = DescripcionEnumAttribute.ObtenerDescripcion(ConceptoIngresos.ALQUILER_MENSUAL) + " " + " Turno Precio Especial Aut. Gral. SM",
                Clase = (int)TipoConcepto.ConceptoIngresos,
                Valor = (int)ConceptoIngresos.ALQUILER_MENSUAL
            };

            servicios.Add(srv);

            foreach (var c in servicios)
            {
                
                //using (var exp = FabExpertos.Inst.Obtener<ExpConcepto>(IdSesion))
                //{
                //    exp.Guardar(c);
                //}
                Persistidor.GuardarEntidadNuevo(c);
               
            }
            Persistidor.Confirmar();

            servicios = Persistidor.Lista<Concepto>(c => c.Clase == (int)TipoConcepto.ConceptoIngresos 
                    && c.Valor == (int)ConceptoIngresos.ALQUILER_MENSUAL).ToList();

            return servicios;
        }
        
    }
}
