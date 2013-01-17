using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;

namespace Utilidades
{
    public static class EncriptorAES
    {
        private static void GenerarIV(SymmetricAlgorithm algoritmo)
        {
            byte[] ivByte = new byte[16];
            ivByte = Encoding.ASCII.GetBytes("EsteEsElVectorIn");
            algoritmo.IV = ivByte;

        }
        private static void GenerarClave(SymmetricAlgorithm algoritmo)
        {
            byte[] claveBytes = new byte[32];
            claveBytes = Encoding.ASCII.GetBytes("EstaEsUnaClaveMuySegura753.-{}´+");
            algoritmo.Key = claveBytes;
        }
        private static void ConfigurarAlgoritmo(SymmetricAlgorithm algoritmo)
        {
            algoritmo.KeySize = 256;
            algoritmo.BlockSize = 128;
            algoritmo.Mode = CipherMode.CBC;
            algoritmo.Padding = PaddingMode.PKCS7;
        }
        public static string Encriptar(string mensaje)
        {
            SymmetricAlgorithm algoritmo = SymmetricAlgorithm.Create("Rijndael");
            ConfigurarAlgoritmo(algoritmo);
            GenerarClave(algoritmo);
            GenerarIV(algoritmo);
            ICryptoTransform encriptador = algoritmo.CreateEncryptor();
            byte[] textoPlano = new byte[mensaje.Length];
            textoPlano = Encoding.Default.GetBytes(mensaje);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encriptador, CryptoStreamMode.Write);
            cryptoStream.Write(textoPlano, 0, textoPlano.Length);
            cryptoStream.FlushFinalBlock();
            memoryStream.Close();
            cryptoStream.Close();
            byte[] bytes = memoryStream.ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
            }
            return sb.ToString();
        }
        private static byte[] EliminarCeros(byte[] msg)
        {
            int i = 0;
            foreach (byte b in msg)
            {
                if (b == 0)
                    break;
                i++;
            }
            byte[] bytes = new byte[i];
            i = 0;
            foreach (byte b in msg)
            {
                if (b == 0)
                    break;
                bytes[i] = b;
                i++;
            }
            return bytes;
        }
        private static byte[] ConvertirEnBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
        }
        public static string Desencriptar(string msg)
        {
            byte[] mensajeEncriptado = ConvertirEnBytes(msg);
            SymmetricAlgorithm algoritmo = SymmetricAlgorithm.Create("Rijndael");
            ConfigurarAlgoritmo(algoritmo);
            GenerarClave(algoritmo);
            GenerarIV(algoritmo);

            byte[] mensajeDesencriptado = new byte[mensajeEncriptado.Length];
            ICryptoTransform desencriptador = algoritmo.CreateDecryptor();
            MemoryStream memoryStream = new MemoryStream(mensajeEncriptado);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, desencriptador, CryptoStreamMode.Read);
            int nroBytesDesencriptados = cryptoStream.Read(mensajeDesencriptado, 0, mensajeDesencriptado.Length);

            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(EliminarCeros(mensajeDesencriptado));
        }
    }
}
