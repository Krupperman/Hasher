using System.Security.Cryptography;
using System.Text;

namespace Hasher
{
    public static class HasherSha256
    {     
        public static string GetSalt()
        {
            return (Guid.NewGuid()).ToString();
        }
        /// <summary>
        /// Compute hash of string with salt using sha256 algoritm
        /// </summary>
        /// <param name="myString">string to hash</param>
        /// <returns>returns hashed string </returns>
        public static string ComputeWithSalt(string myString,string salt)
        { 
            myString += salt;
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            for (int i = 0; i < 1000; i++)
            {


                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(myString));

                // Convert byte array to a string   
                StringBuilder builder = new();
                for (int j = 0; j < bytes.Length; j++)
                {
                    builder.Append(bytes[j].ToString("x2"));
                }
                myString = builder.ToString();
            }
            return myString;
        }
        /// <summary>
        /// Compute hash of string using sha256 algoritm
        /// </summary>
        /// <param name="myString">string to hash</param>
        /// <returns> type string, parametr hashedValue </returns>
        public static string Compute(string myString)
        {
            using SHA256 sha256Hash = SHA256.Create();
            for (int i = 0; i < 1000; i++)
            {


                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(myString));

                // Convert byte array to a string   
                StringBuilder builder = new();
                for (int j = 0; j < bytes.Length; j++)
                {
                    builder.Append(bytes[j].ToString("x2"));
                }
                myString = builder.ToString();
            }
            return myString;
        }
    }
}