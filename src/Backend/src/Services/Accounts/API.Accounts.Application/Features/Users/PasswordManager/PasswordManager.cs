using System.Security.Cryptography;

namespace API.Accounts.Application.Features.Users.PasswordManager
{
    internal class PasswordManager : IPasswordManager
    {
        private const int SALT_SIZE = 128;
        private const int HASH_SIZE = 256;
        private const int ITERATIONS = 1000;
        private readonly HashAlgorithmName HASH_ALGORITHM = HashAlgorithmName.SHA512;

        public string HashPassword(string password)
        {
            byte[] saltByteArray = RandomNumberGenerator.GetBytes(SALT_SIZE);
            string salt = Convert.ToBase64String(saltByteArray);

            byte[] hash = CreatePasswordHash(password, salt);
            byte[] finalHash = [..saltByteArray, .. hash];

            return Convert.ToBase64String(finalHash);
        }

        public bool VerifyPassword(string password, string hash)
        {
            byte[] hashBytes = Convert.FromBase64String(hash);

            byte[] passBytes = new byte[HASH_SIZE];
            Array.Copy(hashBytes, SALT_SIZE, passBytes, 0, HASH_SIZE);

            return CryptographicOperations.FixedTimeEquals(hashBytes, passBytes);
        }

        private byte[] CreatePasswordHash(string password, string salt)
        {
            return Rfc2898DeriveBytes.Pbkdf2(
                password,
                Convert.FromBase64String(salt),
                ITERATIONS,
                HASH_ALGORITHM,
                HASH_SIZE);
        }
    }
}
