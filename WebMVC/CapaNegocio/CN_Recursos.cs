using System;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace CapaNegocio
{
  
    public static class CN_Recursos
    {
        private const int Iteraciones = 1000; // Número de iteraciones para el algoritmo de hash
        private const int TamañoSal = 16; // Tamaño de la sal en bytes

        public static string ConvertirSha256(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("La entrada no puede ser vacía", nameof(input));
            }

            try
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var sal = GenerarSal(TamañoSal);
                var hash = CalcularHashSha256(bytes, sal, Iteraciones);
                var resultado = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return resultado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al calcular el hash SHA-256: {ex.Message}");
                throw;
            }
        }

        private static byte[] GenerarSal(int tamaño)
        {
            using var rng = RandomNumberGenerator.Create();
            var sal = new byte[tamaño];
            rng.GetBytes(sal);
            return sal;
        }

        private static byte[] CalcularHashSha256(byte[] bytes, byte[] sal, int iteraciones)
        {
            using var sha256 = SHA256.Create();
            var bytesConSal = CombinarBytes(bytes, sal);
            var hash = sha256.ComputeHash(bytesConSal);

            for (int i = 0; i < iteraciones - 1; i++)
            {
                hash = sha256.ComputeHash(hash);
            }

            return hash;
        }

        private static byte[] CombinarBytes(byte[] bytes1, byte[] bytes2)
        {
            var bytesCombinados = new byte[bytes1.Length + bytes2.Length];
            Array.Copy(bytes1, 0, bytesCombinados, 0, bytes1.Length);
            Array.Copy(bytes2, 0, bytesCombinados, bytes1.Length, bytes2.Length);
            return bytesCombinados;
        }
    }
}
