using System.Security.Cryptography;
using System.Text;

namespace Hasher
{
    public static class HasherSha256
    {     
        static string GetSalt()
        {
            return (Guid.NewGuid()).ToString();
        }
        /// <summary>
        /// Compute hash of string with salt guid and using sha256 algoritm
        /// </summary>
        /// <param name="myString">string</param>
        /// <returns>returns two strings- item1: hashedValue, item2: salt </returns>
        public static Tuple<string,string> ComputeWithSalt(string myString)
        { 
            string salt = GetSalt();
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
            return Tuple.Create(myString, salt);
        }
        /// <summary>
        /// Compute hash of string using sha256 algoritm
        /// </summary>
        /// <param name="myString">string</param>
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