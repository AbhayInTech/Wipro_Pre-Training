//need to include following packages:
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Net.Http.Headers;

public class Program
{
    static void Main(string[] args)
    {
        // a menu that shows options to get shorted
        while (true)
        {
            Console.WriteLine("\n Secure Message App - General Features");
            Console.WriteLine("1. Encrypt a message");
            Console.WriteLine("2. Decrypt a message");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the message to encrypt: ");
                    string? messageToEncrypt = Console.ReadLine();
                    Console.Write("Enter the 16 Digit encryption key: ");
                    string? KeyEncrypt = Console.ReadLine();
                    string encryptedMessage = Encrypt(messageToEncrypt, KeyEncrypt);
                    Console.WriteLine($"Encrypted Message: {encryptedMessage}");
                    break;
                case "2":
                    Console.Write("Enter the message to decrypt: ");//cipher Key
                    string? messageToDecrypt = Console.ReadLine();
                    Console.Write("Enter the 16 Digit decryption key: ");
                    string? KeyDecrypt = Console.ReadLine();
                    string decryptedMessage = Decrypt(messageToDecrypt,KeyDecrypt);
                    Console.WriteLine($"Decrypted Message: {decryptedMessage}");
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        static string Encrypt(string Plaintext, string key)
        {
            //Here we can use any algorithm
            //step1: Creating an AES Object
            //Step2: Setting up the encryption key
            //Step3: Generating a new IV for each encryption
            //Step4: Creating an encryptor object to encrypt the message
            //Step5: Creating a memory stream to write the encrypted data
            //Step6: Writing the IV to the beginning of the stream
            //Step7: Creating a CryptoStream to encrypt the data
            //Step8: Writing the plaintext to the CryptoStream
            //Step9: Converting the encrypted data to Base64 string


            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);//Encoding all char in a ssequence of bytes
            aes.GenerateIV(); // Generate a new IV for each encryption
            var iv = aes.IV;
            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            ms.Write(iv, 0, iv.Length); // Write IV to the beginning of the stream
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(Plaintext);
            }
            return Convert.ToBase64String(ms.ToArray());
        }
        static string Decrypt(string cipherText, string key)
        {
            //Here we can use any algorithm
            // using the encrypted text to  make it readable again
            // Step1: Convert the encrypted Base 64 test to Bytes
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            // Step2: Create ES object and Set the key
            byte[] iv = new byte[aes.BlockSize / 8];
            Array.Copy(fullCipher, iv, iv.Length); // Extract the IV from the beginning of the cipher text
            aes.IV = iv;
            // Step3: Extract the IV from the beginning of the cipher text
            using var decryptor = aes.CreateDecryptor();
            // Step4: Create a decryptor object to decrypt the message
            using var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length);
            // Step5 Create a memory stream to read the encrypted data
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            // Step6: Create a CryptoStream to decrypt the data
            using var sr = new StreamReader(cs);
            // Step7: Read the decrypted data and return it as a string
            return sr.ReadToEnd();
        }
    }
}