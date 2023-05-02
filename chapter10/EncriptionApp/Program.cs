using Packt.Shared;
using System;
using System.Security.Cryptography;

namespace EncriptionApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Write("Enter a message you want to encrypt: ");
            string? message = System.Console.ReadLine();
            System.Console.Write("Enter a password: ");
            string? password = System.Console.ReadLine();

            string cryptoText = Protector.Encrypt(message, password);

            System.Console.WriteLine($"Encrypted Text: {cryptoText}");
            System.Console.Write("Enter the password: ");
            string? password2 = System.Console.ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                System.Console.WriteLine($"Decrypted text: {clearText}");
            }
            catch (CryptographicException ex)
            {
                System.Console.WriteLine($"{"You entered the wrong password!"}\nMore details: {ex.Message}");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"Non-cryptographic exception: {ex.GetType().Name}, {ex.Message}");
            }           
        }
    }
}