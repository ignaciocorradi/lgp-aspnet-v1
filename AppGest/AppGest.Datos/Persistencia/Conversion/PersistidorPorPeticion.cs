using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using AppGest.Datos.Persistencia;
using System.Data.Objects.DataClasses;
using AppGest.Util;
using AppGest.Datos.Persistencia.Conversion;
using System.Data.Objects;
using System.Configuration;


namespace AppGest.Datos
{
    public class ModuloHttpPersistidorPorPeticion:IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ApplicationInstance_BeginRequest);
            context.EndRequest += new EventHandler(ApplicationInstance_EndRequest);
            AsignarContenedor();
        }

        static void ApplicationInstance_EndRequest(object sender, EventArgs e)
        {
            LiberarContenedor();
        }

        static void AsignarContenedor()
        {
            var context = HttpContext.Current != null ? HttpContext.Current.GetHashCode() : -1;
            var contenedor = null as Contendor_LGP;
            if (!Contenedores.TryGetValue(context, out contenedor))
            {
                var strConexion = PersistidorPorPeticion.ObtenerConexion();
                if (strConexion.Length == 0)
                    contenedor = new Contendor_LGP();
                else
                    contenedor = new Contendor_LGP(strConexion);

                contenedor.Aux();
                Contenedores.Add(context, contenedor);
            }
        }   internal static Dictionary<int, Contendor_LGP> Contenedores= new Dictionary<int, Contendor_LGP>();

        static void ApplicationInstance_BeginRequest(object sender, EventArgs e)
        {
            AsignarContenedor();
        }

        static void LiberarContenedor()
        {
            var context = HttpContext.Current != null ? HttpContext.Current.GetHashCode() : -1;
            if (Contenedores.ContainsKey(context))
                Contenedores.Remove(context);
        }

    }
    public class PersistidorPorPeticion:PersistidorPredet
    {
        protected override Contendor_LGP Contenedor
        {
            get
            {
                var context = HttpContext.Current != null ? HttpContext.Current.GetHashCode() : -1;
                var contenedor = null as Contendor_LGP;

                ModuloHttpPersistidorPorPeticion.Contenedores.TryGetValue(context, out contenedor);
                return contenedor;

            }
        }
    }
}