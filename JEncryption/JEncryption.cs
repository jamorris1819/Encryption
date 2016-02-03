using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEncryption
{
    /// <summary>
    /// Class used for encrypting and decrypting strings
    /// </summary>
    public static class Encryption
    {
        private static string key;
        private static List<int> offsetTable;
        private static Random random;

        /// <summary>
        /// Initialise and set up the encryption class
        /// </summary>
        /// <param name="encryptionKey"></param>
        public static void Initialise(string encryptionKey)
        {
            key = encryptionKey;
            offsetTable = new List<int>();
            random = new Random(Seed);
        }

        /// <summary>
        /// The current seed value
        /// </summary>
        static int Seed
        {
            get
            {
                int seed = 0;
                foreach (char character in key.ToCharArray())
                   seed += (int)character;
                return seed;
            }
        }

        /// <summary>
        /// This will manipulate a number so that it appears between 0 and 255
        /// </summary>
        /// <param name="number">Number to manipulate</param>
        /// <returns></returns>
        static int BringInRange(int number)
        {
            int correctNumber = number;
            while (correctNumber < 0)
                correctNumber += 256;
            while (correctNumber > 255)
                correctNumber -= 256;
            return correctNumber;
        }

        /// <summary>
        /// Encrypts a body of text
        /// </summary>
        /// <param name="message">Text to be encrypted</param>
        /// <returns>String of encrypted text</returns>
        public static string Encrypt(string message)
        {
            string encryptedMessage = string.Empty;
            for(int i = 0; i < message.Length; i++)
            {
                int offsetNumber = 0;
                if (offsetTable.Count <= i)
                {
                    offsetNumber = random.Next(0, 255);
                    offsetTable.Add(offsetNumber);
                }
                else
                {
                    offsetNumber = offsetTable[i];
                }
                encryptedMessage += (char)BringInRange((int)message[i] + offsetNumber);
            }
            return encryptedMessage;
        }

        /// <summary>
        /// Encrypts a body of text
        /// </summary>
        /// <param name="message">Text to be encrypted</param>
        /// <param name="output">String of encrypted text</param>
        public static void Encrypt(string message, out string output)
        {
            string encryptedMessage = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                int offsetNumber = 0;
                if (offsetTable.Count <= i)
                {
                    offsetNumber = random.Next(0, 255);
                    offsetTable.Add(offsetNumber);
                }
                else
                {
                    offsetNumber = offsetTable[i];
                }
                encryptedMessage += (char)BringInRange((int)message[i] + offsetNumber);
            }
            output = encryptedMessage;
        }

        /// <summary>
        /// Decrypts a body of text
        /// </summary>
        /// <param name="message">Text to be decrypted</param>
        /// <returns>String of decrypted text</returns>
        public static string Decrypt(string message)
        {
            string decryptedMessage = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage += (char)BringInRange((int)message[i] - offsetTable[i]);
            }
            return decryptedMessage;
        }

        /// <summary>
        /// Decrypts a body of text
        /// </summary>
        /// <param name="message">Text to be decrypted</param>
        /// <param name="output">String of decrypted text</param>
        public static void Decrypt(string message, out string output)
        {
            string decryptedMessage = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage += (char)BringInRange((int)message[i] - offsetTable[i]);
            }
            output = decryptedMessage;
        }
    }
}
