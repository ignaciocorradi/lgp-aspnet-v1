using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

namespace AppGest
{
    /// <summary>
    /// Administra los parámetros de una sesión de usuario.
    /// </summary>
    public class ParamSesion
    {
        // Nombres
        public const string SESION_ID = "sesion_id";
        public const string RPT_SERV = "rpt_srv";
        public const string RPT_RUTA = "rpt_ruta";
        public const string RPT_NOMBRE = "rpt_nombre";

        /// <summary>
        /// Obtiene la sesión actual del usuario.
        /// </summary>
        /// <param name="pagina">Página que contiene los datos de la sesión actual del usuario</param>
        /// <returns></returns>
        public static Guid GetIdSesion(IContext contexto) { return ParamSesion.Get<Guid>(contexto, SESION_ID, Guid.Empty); }

        /// <summary>
        /// Obtiene la sesión actual del usuario.
        /// </summary>
        /// <param name="sesion">Página que contiene los datos de la sesión actual del usuario</param>
        /// <returns></returns>
        public static Guid GetIdSesion(HttpSessionState sesion) { return ParamSesion.Get<Guid>(sesion, SESION_ID, Guid.Empty); }

        /// <summary>
        /// Establece la sesión actual del usuario.
        /// </summary>
        /// <param name="pagina">Página que contiene los datos de la sesión actual del usuario</param>
        /// <param name="idSesion">ID de la sesión actual del usuario.</param>
        /// <returns></returns>
        public static void SetIdSesion(IContext contexto, Guid idSesion) { ParamSesion.Set<Guid>(contexto, SESION_ID, idSesion); }

        /// <summary>
        /// Devuelve un valor que indica si el usuario ha iniciado una sesión.
        /// </summary>
        /// <param name="contexto">Contexto que tendría los datos de la sesión actual del usuario</param>
        /// <returns></returns>
        public static bool GetHaySesion(IContext contexto) { return GetIdSesion(contexto) != Guid.Empty; }

        /// <summary>
        /// Devuelve un valor que indica si el usuario ha iniciado una sesión.
        /// </summary>
        /// <param name="sesion">Página que tendría los datos de la sesión actual del usuario</param>
        /// <returns></returns>
        public static bool GetHaySesion(HttpSessionState sesion) { return Get<Guid>(sesion, SESION_ID, Guid.Empty) != Guid.Empty; }

        /// <summary>
        /// Devuelve el valor de un parámetro especificado, o bien un valor predeterminado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del parámetro solicitado</typeparam>
        /// <param name="pagina">Página que contiene los parámetros.</param>
        /// <param name="parametro">Nombre del parámetro a recuperar</param>
        /// <param name="predet">Valor predeterminado. Este valor se devuelve si el parámetro solicitado no ha sido establecido.</param>
        /// <returns></returns>
        public static T Get<T>(IContext contexto, string parametro, T predet)
        {
            ISession sesion = contexto.Session;
            return Get<T>(sesion, parametro, predet);
        }
        /// <summary>
        /// Devuelve el valor de un parámetro especificado, o bien un valor predeterminado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del parámetro solicitado</typeparam>
        /// <param name="pagina">Sesión contiene los parámetros.</param>
        /// <param name="parametro">Nombre del parámetro a recuperar</param>
        /// <param name="predet">Valor predeterminado. Este valor se devuelve si el parámetro solicitado no ha sido establecido.</param>
        /// <returns></returns>
        public static T Get<T>(ISession sesion, string parametro, T predet)
        {
            object valor = sesion[parametro];
            if (valor == null)
                return predet;
            else
                return (T)valor;
        }

        public static T Get<T>(HttpSessionState sesion, string parametro, T predet)
        {
            object valor = sesion[parametro];
            if (valor == null)
                return predet;
            else
                return (T)valor;
        }

        /// <summary>
        /// Establece un valor de parámetro en la sesión actual del usuario.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del parámetro.</typeparam>
        /// <param name="pagina">Página que contiene los parámetros.</param>
        /// <param name="parametro">Nombre del parámetro a establecer</param>
        /// <param name="valor">Valor del parámetro</param>
        public static void Set<T>(IContext contexto, string parametro, T valor)
        {
            ISession sesion = contexto.Session;
            Set<T>(sesion, parametro, valor);
        }

        /// <summary>
        /// Establece un valor de parámetro en la sesión actual del usuario.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del parámetro.</typeparam>
        /// <param name="session">Sesión que contiene los parámetros.</param>
        /// <param name="parametro">Nombre del parámetro a establecer</param>
        /// <param name="valor">Valor del parámetro</param>
        public static void Set<T>(ISession session, string parametro, T valor)
        {
            session[parametro] = valor;
        }

        /// <summary>
        /// Establece un valor de parámetro en la sesión actual del usuario.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del parámetro.</typeparam>
        /// <param name="session">Sesión que contiene los parámetros.</param>
        /// <param name="parametro">Nombre del parámetro a establecer</param>
        /// <param name="valor">Valor del parámetro</param>
        public static void Set<T>(HttpSessionState session, string parametro, T valor)
        {
            session[parametro] = valor;
        }

    }
}