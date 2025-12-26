using Microsoft.AspNetCore.Identity;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Projekt_WDC.Services
{
    public class Argon2PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        private readonly int _saltSize = 16;
        private readonly int _hashSize = 32;
        private readonly int _iterations = 4;
        private readonly int _memorySize = 65536;
        private readonly int _parallelism = 1;

        public string HashPassword(TUser user, string password)
        {
            byte[] salt = new byte[_saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = _parallelism,
                Iterations = _iterations,
                MemorySize = _memorySize
            };

            var hash = argon2.GetBytes(_hashSize);

            var saltBase64 = Convert.ToBase64String(salt);
            var hashBase64 = Convert.ToBase64String(hash);

            return $"{saltBase64}${hashBase64}";
        }

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            var parts = hashedPassword.Split('$');
            if (parts.Length != 2)
            {
                return PasswordVerificationResult.Failed;
            }

            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[1]);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(providedPassword))
            {
                Salt = salt,
                DegreeOfParallelism = _parallelism,
                Iterations = _iterations,
                MemorySize = _memorySize
            };

            var newHash = argon2.GetBytes(_hashSize);

            if (CryptographicOperations.FixedTimeEquals(hash, newHash))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}

