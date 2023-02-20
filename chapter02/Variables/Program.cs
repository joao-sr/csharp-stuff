using System;

namespace Variables // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88;
            object name = "Amir";

            Console.WriteLine($"{name} is {height} meters tall");

            //int length1 = name.Length;
            int length2 = ((string)name).Length;

            Console.WriteLine($"{name} has {length2} characters");

            // declare and assign variables
            int population = 66_000_000;
            double weight = 89.8;
            decimal price = 4.99M; // M suffix infers a decimal variable
            string fruit = "Apples";
            char letter = 'Z'; // char need to use single quotes.
            bool happy = true;

        }
    }
}