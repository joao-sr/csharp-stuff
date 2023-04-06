using System.Collections.Generic;
using System.Collections.Immutable;

namespace WorkingWithList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
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

            var immutableCities = cities.ToImmutableList();
            var newList = immutableCities.Add("Rio");
            System.Console.Write("Immutable list of cities: ");
            foreach(string city in immutableCities)
            {
                System.Console.Write($" {city}");
            }
            System.Console.WriteLine();

            System.Console.Write("New list of cities: ");
            foreach(string city in newList)
            {
                System.Console.Write($" {city}");
            }
            System.Console.WriteLine();
        }
    }
}