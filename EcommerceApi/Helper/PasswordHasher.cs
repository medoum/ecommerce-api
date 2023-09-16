using System;
using System.Security.Cryptography;
using EcommerceApi.Abstract;

namespace EcommerceApi.Helper
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int Saltsize = 128 / 8;
        private const int keySize = 256 / 8;
        private const int Iterations = 1000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delimiter = ';';


        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(Saltsize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithmName, keySize);

            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            var elements = passwordHash.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithmName, keySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}

