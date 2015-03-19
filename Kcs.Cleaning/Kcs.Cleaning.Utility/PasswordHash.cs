using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kcs.Cleaning.Utility
{
    public static class PasswordHash
    {
        private const int SALT_SIZE = 10;

        private static string ByteArrayToString(byte[] byteArray)
        {
            var hex = new StringBuilder(byteArray.Length * 2);

            foreach (byte b in byteArray)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
        public static string GenerateHexSaltString()
        {
            var random = new Random();
            var saltValue = new byte[SALT_SIZE];

            random.NextBytes(saltValue);

            string saltValueString = ByteArrayToString(saltValue);
            return saltValueString;
        }
        public static string CreateHash(string clearData, string saltValue)
        {
            var hash = SHA512.Create();
            var encoding = new UnicodeEncoding();
            var hashedPassword = string.Empty;

            if (clearData != null && hash != null)
            {

                if (saltValue == null)
                {

                    saltValue = GenerateHexSaltString();
                }

                var binarySaltValue = new byte[SALT_SIZE];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                var valueToHash = new byte[SALT_SIZE + encoding.GetByteCount(clearData)];
                var binaryPassword = encoding.GetBytes(clearData);


                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, SALT_SIZE);

                var hashValue = hash.ComputeHash(valueToHash);


                return hashValue.Aggregate(saltValue, (current, hexdigit) => current + hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat));
            }

            return hashedPassword;
        }
    }
}
