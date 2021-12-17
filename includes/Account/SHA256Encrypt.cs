using System.Text;
using System.Security.Cryptography;

namespace IntegrateOS
{
    class SHA256Encrypt
    {
        /// <summary>
        /// Encryptes the password with SHA256 hashing
        /// </summary>
        /// <param name="password">Password</param>
        public SHA256Encrypt(string password)
        {
            SHA256 encryption = SHA256.Create();
            byte[] bytes = encryption.ComputeHash(Encoding.UTF8.GetBytes(password));
            Get = "";
            foreach (byte element in bytes) Get += element.ToString("x2");
        }
        /// <summary>
        /// Returns the encrypted password
        /// </summary>
        public string Get { get; }

    }
}
