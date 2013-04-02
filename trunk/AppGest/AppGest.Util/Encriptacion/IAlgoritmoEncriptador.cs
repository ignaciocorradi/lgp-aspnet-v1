using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGest.Util.Encriptacion
{
    /// <summary>
    /// Define la funcionalidad básica de todos los algoritmos
    /// de cifrado implementados
    /// </summary>
    public interface IAlgoritmoEncriptador
    {
        /// <summary>
        /// Asigna los vectores KEY y IV para función de encriptación y desencriptación.
        /// </summary>
        /// <param name="key">Vector KEY a utilizar</param>
        /// <param name="iv">Vector IV a utilizar</param>
        void SetVectores(byte[] key, byte[] iv);

        /// <summary>
        /// Encripta el texto plano proporcionado.
        /// </summary>
        /// <param name="textoPlano">Texto a cifrar</param>
        /// <returns></returns>
        string Encriptar(string textoPlano);

        /// <summary>
        /// Desencripta el texto encriptado proporcionado, generado
        /// con este algoritmo.
        /// </summary>
        /// <param name="textoEncriptado">Texto a desencriptar</param>
        /// <returns></returns>
        string Desencriptar(string textoEncriptado);

        /// <summary>
        /// Encripta los bytes planos proporcionados.
        /// </summary>
        /// <param name="bytesPlanos">Bytes a encriptar</param>
        /// <returns></returns>
        byte[] Encriptar(byte[] bytesPlanos);

        /// <summary>
        /// Desencripta los bytes encriptados proporcionados, generados
        /// con este algoritmo
        /// </summary>
        /// <param name="bytesEncriptados">Bytes a desencriptar</param>
        /// <returns></returns>
        byte[] Desencriptar(byte[] bytesEncriptados);

    }
}
