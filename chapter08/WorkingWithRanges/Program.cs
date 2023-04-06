using System;

namespace WorkingWithRanges
{
    class Program
    {
        public static void Main(string[] args)
        {
            string name = "Samantha Jones";
            int indexOfSpace = name.IndexOf(' ');

            string firstName = name.Substring(startIndex:0, length: indexOfSpace);

            string lastName = name.Substring(startIndex: name.Length - (name.Length - indexOfSpace - 1),
                                            length: name.Length - indexOfSpace - 1);

            System.Console.WriteLine($"First name: {firstName}, Last name: {lastName}");

            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];
            System.Console.WriteLine($"First name: {firstNameSpan.ToString()}, Last Name: {lastNameSpan}");
        }
    }
}