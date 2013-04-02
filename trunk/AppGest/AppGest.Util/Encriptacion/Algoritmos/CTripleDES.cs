using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AppGest.Util.Encriptacion.Algoritmos
{
    public class CTripleDES: IAlgoritmoEncriptador
    {
        // define the triple des provider
        private TripleDESCryptoServiceProvider m_des =
                 new TripleDESCryptoServiceProvider();

        // define the string handler
        private UTF8Encoding m_utf8 = new UTF8Encoding();

        // define the local property arrays
        private byte[] m_key;
        private byte[] m_iv;

        public void SetVectores(byte[] key, byte[] iv)
        {
            this.m_key = key;
            this.m_iv = iv;
        }

        public byte[] Encriptar(byte[] bytesPlanos)
        {
            return Transform(bytesPlanos,
                   m_des.CreateEncryptor(m_key, m_iv));
        }

        public byte[] Desencriptar(byte[] bytesEncriptados)
        {
            return Transform(bytesEncriptados,
                   m_des.CreateDecryptor(m_key, m_iv));
        }

        public string Encriptar(string textoPlano)
        {
            byte[] input = m_utf8.GetBytes(textoPlano);
            byte[] output = Transform(input,
                            m_des.CreateEncryptor(m_key, m_iv));
            return Convert.ToBase64String(output);
        }

        public string Desencriptar(string textoEncriptado)
        {
            byte[] input = Convert.FromBase64String(textoEncriptado);
            byte[] output = Transform(input,
                            m_des.CreateDecryptor(m_key, m_iv));
            return m_utf8.GetString(output);
        }

        private byte[] Transform(byte[] input,
                       ICryptoTransform CryptoTransform)
        {
            // create the necessary streams
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(memStream,
                         CryptoTransform, CryptoStreamMode.Write);
            // transform the bytes as requested
            cryptStream.Write(input, 0, input.Length);
            cryptStream.FlushFinalBlock();
            // Read the memory stream and
            // convert it back into byte array
            memStream.Position = 0;
            byte[] result = memStream.ToArray();
            // close and release the streams
            memStream.Close();
            cryptStream.Close();
            // hand back the encrypted buffer
            return result;
        }
    }
}
