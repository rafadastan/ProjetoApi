using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.CrossCutting.Cryptography
{
    public class MD5Service
    {
        public static string Encrypt(string value)
        {
            //criptografando o valor recebido
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            //converter para string
            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("x2"); //Hexadecimal
            }

            return result;
        }
    }
}
