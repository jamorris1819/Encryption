using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using JEncryption;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptionKey = "&-!2.Uy!hNt$7gyZ";
            string text = "An example string.";

            Encryption.Initialise(encryptionKey);

            Console.WriteLine("Unencrypted: " + text);

            Encryption.Encrypt(text, out text);
            Console.WriteLine("Encrypted: " + text);

            Encryption.Decrypt(text, out text);
            Console.WriteLine("Decrypted: " + text);

            Console.ReadKey();
        }
    }
}
