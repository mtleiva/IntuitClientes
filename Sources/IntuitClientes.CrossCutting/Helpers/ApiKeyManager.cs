using System.Security.Cryptography;

namespace IntuitClientes.CrossCutting.Helpers
{
    public static class ApiKeyManager
    {
        public static string Generate()
        {
            var guid = new Guid();
            byte[] randomBytes = guid.ToByteArray();
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var shaHashFunction = SHA256.Create();
            byte[] hashedBytes = shaHashFunction.ComputeHash(randomBytes);
            string randomString = string.Empty;

            foreach (byte b in hashedBytes)
            {
                randomString += $"{b:x2}";
            }

            return randomString;
        }
    }
}
