using System.Security.Cryptography;
using System.Text;

namespace Trade_Site_Auth_WebAPI.Services
{
    public static class PasswordHasher
    {
        public static (string Hash, string Salt) HashPassword(string password)
        {
            var saltBytes = RandomNumberGenerator.GetBytes(16);
            var hashBytes = SHA256.HashData(Combine(saltBytes, Encoding.UTF8.GetBytes(password)));

            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var hashBytes = SHA256.HashData(Combine(saltBytes, Encoding.UTF8.GetBytes(password)));
            var computedHash = Convert.ToBase64String(hashBytes);

            return computedHash == storedHash;
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var result = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, result, 0, first.Length);
            Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
            return result;
        }
    }
}
