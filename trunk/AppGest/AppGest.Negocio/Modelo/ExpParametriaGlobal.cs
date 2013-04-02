using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Negocio.Core;
using System.Web.Configuration;
using System.Configuration;
using System.Web;

namespace AppGest.Negocio.Modelo
{
    /// <summary>
    /// Proporciona toda la funcionalidad de admintiracción de la
    /// configuración global del sistema.
    /// </summary>
    public class ExpParametriaGlobal: IDisposable
    {
        /// <summary>
        /// Devuelve la información de conexión de la base de datos actual
        /// del sistema.
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Devuelve la conexión de base de datos
        /// con el nombre especificado, o la primera de la colección
        /// </summary>
        /// <param name="key">Opcional. Nombre de la conexión</param>
        /// <returns></returns>
        public string ObtenerConexionBD(string key = null)
        {
            var seccion = (ConnectionStringsSection) WebConfigurationManager.GetSection("connectionStrings");
            var conexion = ObtenerConfiguracionConexionBD(key, seccion);

            if (conexion == null)
                return null;
            else
                return conexion.ConnectionString;
        }

        /// <summary>
        /// Devuelve la configuración conexión de base de datos con el key especificado, o la primera de la colección.
        /// </summary>
        /// <param name="key">Opcional. Nombre de la conexión</param>
        /// <param name="seccion">Sección de búsqueda</param>
        /// <returns></returns>
        ConnectionStringSettings ObtenerConfiguracionConexionBD(string key, ConnectionStringsSection seccion)
        {
            if (key == null)
                return seccion.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault();
            else
                return seccion.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(c => c.Name.Trim().ToUpper() == key.Trim().ToUpper());
        }

        /// <summary>
        /// Guarda la nueva conexión a la base de datos.
        /// </summary>
        /// <param name="key">Nombre de la conexión a actualizar, o la primera que encuentre</param>
        /// <param name="nuevaConexion">Nuevo string de conexión</param>
        /// <param name="testear">Opcional. Indica si se debe testear antes de actualizar el archivo de configuraciones</param>
        public void CambiarConexionBD(string key, string nuevaConexion, bool testear = true)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(null);
            var seccion = (ConnectionStringsSection) config.GetSection("connectionStrings");

            var conexion = ObtenerConfiguracionConexionBD(key, seccion);

            if (conexion != null)
            {
                conexion.ConnectionString = nuevaConexion;
                config.Save();
            }
        }

        /// <summary>
        /// Encripta las secciones de datos sensibles presentes en el archivo de configuración del sistema
        /// </summary>
        /// <param name="rutaVirtual">Opcional. Ruta virtual donde se encuentra el archivo de configuraciones.</param>
        public void EncriptarArchivoConfiguracion(string rutaVirtual = null)
        {
            if (rutaVirtual == null) 
                rutaVirtual = HttpRuntime.AppDomainAppVirtualPath;
            
            Configuration config = WebConfigurationManager.OpenWebConfiguration(rutaVirtual);
            EncriptarSeccion(config, "connectionStrings");
            config.Save();
        }

        /// <summary>
        /// Desencripta todas las secciones de datos encriptadas presentes en el archivo de configuración del sistema
        /// </summary>
        /// <param name="rutaVirtual">Opcional. Ruta virtual donde se encuentra el archivo de configuraciones.</param>
        public void DesencriptarArchivoConfiguracion(string rutaVirtual = null)
        {
            if (rutaVirtual == null)
                rutaVirtual = HttpRuntime.AppDomainAppVirtualPath;

            Configuration config = WebConfigurationManager.OpenWebConfiguration(rutaVirtual);
            DesencriptarSeccion(config, "connectionStrings");
            config.Save();
        }

        /// <summary>
        /// Encripta la sección especificada.
        /// </summary>
        /// <param name="config">Configuración de referencia</param>
        /// <param name="seccion">Nombre de la sección a encriptar</param>
        /// <param name="provider">Opcional. Provider a utilizar</param>
        private void EncriptarSeccion(Configuration config, string seccion, string provider = "DataProtectionConfigurationProvider")
        {
            ConfigurationSection section = config.GetSection(seccion);

            if (section != null && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(provider);
            }
        }

        /// <summary>
        /// Desencripta la sección especificada.
        /// </summary>
        /// <param name="config">Configuración de referencia</param>
        /// <param name="seccion">Nombre de la sección a desencriptar</param>
        private void DesencriptarSeccion(Configuration config, string seccion)
        {
            ConfigurationSection section = config.GetSection(seccion);

            if (section != null && section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
            }
        }

        public void Dispose()
        {
        }
    }
}
