using System.Collections.Generic;

namespace WorkingWithList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Parins");
            cities.Add("Milan");

            System.Console.WriteLine("Initial List");
            foreach(string city in cities)
            {
                System.Console.WriteLine($"{city}");
            }

            System.Console.WriteLine($"The first city is {cities[0]}");
            System.Console.WriteLine($"The last city is {cities[cities.Count-1]}");

            cities.Insert(0, "Sydney");
            System.Console.WriteLine("After inserting Sydney at index 0");
            foreach (var city in cities)
            {
                System.Console.WriteLine(city);
            }

            cities.RemoveAt(1);
            cities.Remove("Milan");
            System.Console.WriteLine("After removing two cities");
            foreach(string city in cities)
            {
                System.Console.WriteLine(city);
            }
        }
    }
}