using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DailyTaskTimeTracker.Helpers
{
    public static class Encryption
    {
        private const int BytesLength = 32;
        private const int Iterations = 1000;

        public static string LegacyEncrypt(string input)
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();

                // Convert the input string to a byte array and compute the hash
                byte[] hashData = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder result = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                foreach (byte data in hashData)
                {
                    result.Append(data.ToString("x2").ToLower());
                }

                // Return the hexadecimal string.
                return result.ToString();
            }
        }

        public static Rfc2898 Encrypt(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            if (input.Length == 0)
                throw new ArgumentException("Cannot encrypt an empty string");

            byte[] newSalt = GenerateSalt();
            int iterations = Iterations;
            var hashedInput = Rfc2898Encrypt(input, newSalt, iterations);
            return new Rfc2898(hashedInput, newSalt, iterations);
        }

        public static Rfc2898 Encrypt(string input, string salt, int iterations)
        {
            byte[] saltAsBytes = Convert.FromBase64String(salt);
            var hashedInput = Rfc2898Encrypt(input, saltAsBytes, iterations);
            return new Rfc2898(hashedInput, saltAsBytes, iterations);
        }

        private static byte[] Rfc2898Encrypt(string input, byte[] salt, int iterations)
        {
            var hash = new Rfc2898DeriveBytes(input, salt, iterations);

            return hash.GetBytes(salt.Length);
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[BytesLength];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(salt);
            }

            return salt;
        }
    }
}
