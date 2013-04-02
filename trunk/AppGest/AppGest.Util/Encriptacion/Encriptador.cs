using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGest.Util.Encriptacion.Algoritmos;
using System.IO;

namespace AppGest.Util.Encriptacion
{
    /// <summary>
    /// Proporciona funcionalidad básica de encriptación y desencriptación de datos
    /// </summary>
    public static class Encriptador
    {
        /// <summary>
        /// Encriptador de datos predeterminado
        /// </summary>
        public static readonly IAlgoritmoEncriptador Predet = null;

        /// <summary>
        /// Vector KEY predeterminado, para todos los algoritmos instanciados sin especificación de KEY.
        /// </summary>
        internal static byte[] KeyPredet;

        /// <summary>
        /// Vector IV predeterminado, para todos los algoritmos instanciados sin especificación de IV.
        /// </summary>
        internal static byte[] IvPredet;

        static Encriptador()
        {
            KeyPredet = new  byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
            IvPredet = new byte[] { 8, 7, 6, 5, 4, 3, 2, 1 };

            Predet = new CTripleDES();
            Predet.SetVectores(KeyPredet, IvPredet);

        }

        /// <summary>
        /// Crea un encriptador del tipo especificado, asignando
        /// los vectores llave predeterminados.
        /// </summary>
        /// <typeparam name="TAlgoritmo">Tipo del algoritmo a crear</typeparam>
        /// <returns></returns>
        public static IAlgoritmoEncriptador Obtener<TAlgoritmo>()
            where TAlgoritmo: IAlgoritmoEncriptador, new()
        {
            var algoritmo = Obtener<TAlgoritmo>(KeyPredet, IvPredet);
            return algoritmo;
        }

        /// <summary>
        /// Crea un encriptador del tipo especificado, asignando
        /// los vectores llave predeterminados.
        /// </summary>
        /// <typeparam name="TAlgoritmo">Tipo del algoritmo a crear</typeparam>
        /// <param name="key">Key de encriptación a utilizar</param>
        /// <param name="iv">IV de encriptación a utilizar</param>
        /// <returns></returns>
        public static IAlgoritmoEncriptador Obtener<TAlgoritmo>(byte[] key, byte[] iv)
            where TAlgoritmo : IAlgoritmoEncriptador, new()
        {
            var algoritmo = new TAlgoritmo();
            algoritmo.SetVectores(key, iv);

            return algoritmo;
        }
    }
}
