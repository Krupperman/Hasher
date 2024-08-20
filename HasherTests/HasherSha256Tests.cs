using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Tests
{
    [TestClass()]
    public class HasherSha256Tests
    {
        [TestMethod()]
        public void ComputeWithSaltTest()
        {
            string[] strings = { "1", "2", "3", "qwerty", "para diqdx vfcctc", "gyttTVT1236" };
            string[] salts = new string[6];
            for (int i = 0; i < salts.Length; i++)
                salts[i] = HasherSha256.GetSalt();
            // Test that hashing with the same string and same salt produces the same hash
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < salts.Length; j++)
                {
                    string hash1 = HasherSha256.ComputeWithSalt(strings[i], salts[j]);
                    string hash2 = HasherSha256.ComputeWithSalt(strings[i], salts[j]);

                    // Hashing the same string with the same salt should be identical
                    Assert.AreEqual(hash1, hash2);

                    // Test hashing with different salts
                    if (j < salts.Length - 1)
                    {
                        string hashWithDifferentSalt = HasherSha256.ComputeWithSalt(strings[i], salts[j + 1]);
                        Assert.AreNotEqual(hash1, hashWithDifferentSalt);
                    }

                    // Test hashing with different strings
                    if (i < strings.Length - 1)
                    {
                        string hashWithDifferentString = HasherSha256.ComputeWithSalt(strings[i + 1], salts[j]);
                        Assert.AreNotEqual(hash1, hashWithDifferentString);
                    }

                    // Test hashing with different strings and different salts
                    if (i < strings.Length - 1 && j < salts.Length - 1)
                    {
                        string hashWithDifferentStringAndSalt = HasherSha256.ComputeWithSalt(strings[i + 1], salts[j + 1]);
                        Assert.AreNotEqual(hash1, hashWithDifferentStringAndSalt);
                    }
                }

            }
        }
    }
}