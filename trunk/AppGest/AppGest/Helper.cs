using System;
using System.Collections.Generic;
using System.Linq;
using Gizmox.WebGUI.Forms;
using System.Drawing;
using AppGest.Datos.Persistencia;
using System.Security.Authentication;
using AppGest.Negocio.Modelo;
using AppGest.Util.Atributos;
using System.Web;
using AppGest.Negocio.Modelo.Reportes.Configuracion;
using AppGest.Negocio.Core;

namespace AppGest
{
    public static class Helper
    {
        /// <summary>
        /// Intenta cambiar el tipo de objeto pasado como parámetro al tipo especificado.
        /// En caso de que se presentara una InvalidCastException, o FormatException, u OverflowException o ArgumentNullException
        /// el metodo devolverá null.
        /// Culaquier otra excepción que se presenté será arrojada nuevamente.
        /// </summary>
        /// <param name="obj">objeto que se quiere convertir</param>
        /// <param name="type">tipo al que se quiere convertir el objeto</param>
        /// <returns>objeto convertido, null o excepcion</returns>
        public static object Parse(object obj, Type type)
        {
            try
            {
                return Convert.ChangeType(obj, type);
            }
            catch (Exception ex)
            {
                if (ex is InvalidCastException || ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        }

        /// <summary>
        /// Genera una cadena con las iniciales de cada palabra incluida en la lista
        /// </summary>
        /// <param name="cadenas">lista de palabras</param>
        /// <returns>Cadena con las iniciales de cada palabra</returns>
        public static string ObtenerIniciales(List<string> palabras)
        {
            string iniciales = string.Empty;
            foreach (string palabra in palabras)
            {
                iniciales += Helper.ObtenerIniciales(palabra);
            }

            return iniciales;
        }

        /// <summary>
        /// Genera una cadena con las iniciales de cada palabra incluida en la cadena
        /// </summary>
        /// <param name="cadenas">cadena de palabras</param>
        /// <returns>Cadena con las iniciales de cada palabra</returns>
        public static string ObtenerIniciales(string cadena)
        {
            return new string(cadena.Split(null).Where(c => !string.IsNullOrEmpty(c)).Select(c => c[0]).ToArray());
        }

        /// <summary>
        /// Cambia el color de fondo de la fila
        /// </summary>
        /// <param name="fila">Fila a cambiar el color de fondp</param>
        /// <param name="colorFondo">Color de fondo</param>
        public static void CambiarFondo(this DataGridViewRow fila, Color colorFondo)
        {
            foreach (DataGridViewCell celda in fila.Cells)
            {
                celda.Style.BackColor = colorFondo;
            }
        }

        public static bool TienePermiso(Guid idSesion, Type tipo, System.ComponentModel.ComponentResourceManager resources, bool showDialog = true, RptItemSettings configuracionReporte = null)
        {
            if (Guid.Empty == idSesion)
            {
                if (showDialog)
                {
                    MessageBox.Show(resources.GetString("SESION_VACIA"), "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                throw new AuthenticationException(resources.GetString("SESION_VACIA"));
            }
            else
            {
                Usuario usuario = null;
                using (var exp = IoC.Singleton.Experto<ExpUsuarios>(idSesion))
                {
                    usuario = exp.ObtenerUsuario(idSesion);
                }

                if (usuario == null)
                {
                    if (showDialog)
                    {
                        MessageBox.Show(resources.GetString("USUARIO_NULL"), "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    throw new AuthenticationException(resources.GetString("USUARIO_NULL"));
                }
                else
                {
                    TipoUsuario tipoUsuario = (TipoUsuario)usuario.Tipo;

                    if (!(tipoUsuario == TipoUsuario.ADMINISTRADOR && tipo.IsDefined(typeof(AdministradorAttribute), false) ||
                        tipoUsuario == TipoUsuario.SUPERVISOR && tipo.IsDefined(typeof(SupervisorAttribute), false) ||
                        tipoUsuario == TipoUsuario.OPERADOR && tipo.IsDefined(typeof(OperadorAttribute), false)))
                    {
                        if (showDialog)
                        {
                            MessageBox.Show(resources.GetString("SIN_PERMISOS"), "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        throw new AuthenticationException(resources.GetString("SIN_PERMISOS"));
                    }
                    else if (configuracionReporte != null &&
                            !(tipoUsuario == TipoUsuario.ADMINISTRADOR && configuracionReporte.Permiso.Contains(DescripcionEnumAttribute.ObtenerAbreviatura(TipoUsuario.ADMINISTRADOR)) ||
                            tipoUsuario == TipoUsuario.SUPERVISOR && configuracionReporte.Permiso.Contains(DescripcionEnumAttribute.ObtenerAbreviatura(TipoUsuario.SUPERVISOR)) ||
                            tipoUsuario == TipoUsuario.OPERADOR && configuracionReporte.Permiso.Contains(DescripcionEnumAttribute.ObtenerAbreviatura(TipoUsuario.OPERADOR))))
                    {
                        if (showDialog)
                        {
                            MessageBox.Show(resources.GetString("REPORTE_SIN_PERMISOS"), "Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        throw new AuthenticationException(resources.GetString("REPORTE_SIN_PERMISOS"));
                    }
                }
            }

            return true;
        }

        public static string AspNetBaseUrl(HttpContext myContext)
        {
            HttpRequest myRequest = myContext.Request;
            Uri myURI = myRequest.Url;
            
            //Get ASP.NET Application Path with trailing Slash
            string myApplicationPath = myRequest.ApplicationPath;
            
            if(!myApplicationPath.EndsWith("/"))
            {
                myApplicationPath += "/";
            }

            return myURI.Scheme + "://" + myURI.Host + ":" + myURI.Port + myApplicationPath;
        }

    }
}