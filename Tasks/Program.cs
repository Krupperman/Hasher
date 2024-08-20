//using System;
using System.Text;
using System.Security.Cryptography;
using Hasher;

namespace HashConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.Write($"Input password: ");
                string? myString = Console.ReadLine();
                if(String.IsNullOrEmpty(myString)|| myString.Length < 6)
                {
                    Console.WriteLine("Error:Password must have at list  6 characters!");
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
                else
                {
                    var salt = HasherSha256.GetSalt();
                    var data = HasherSha256.ComputeWithSalt(myString,salt);
                    Console.WriteLine($"HashString: {myString}");
                    Console.WriteLine($"Salt:{salt}");
                    Console.WriteLine($"Hashed string:{data}");
                }
            }
            
        }
       
         
    }

}