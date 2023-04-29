using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NASAAPI_Image_Handler
{
    public class clsPwHash
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }


        //public class PWHash
        //{
        //    public static string HashPassWort(string pw)
        //    {
        //        SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

        //        byte[] pwBytes = Encoding.ASCII.GetBytes(pw);
        //        byte[] encBytes = sha1.ComputeHash(pwBytes);
        //        return Convert.ToBase64String(encBytes);
        //    }
        //}
    }
}
