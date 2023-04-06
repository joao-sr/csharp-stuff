using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Packt.Shared;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object graph
            var people = new List<Person>
            {
                new Person(30000M){FirstName="Alice", LastName="Smith", DateOfBirth=new DateTime(1974, 3, 14)},
                new Person(40000M){FirstName="Bob", LastName="Jones", DateOfBirth=new DateTime(1969, 11, 23)},
                new Person(20000M){FirstName="Charlie", LastName="Cox", DateOfBirth=new DateTime(1944, 8, 25), Children=new HashSet<Person>{new Person(0M){FirstName="Sally", LastName="Cox", DateOfBirth=new DateTime(2000, 7, 12)}}},
            };

            // create object that will format a list of Persons as XML
            var xs = new XmlSerializer(typeof(List<Person>));

            // create a file to write to
            string path = Combine(CurrentDirectory, "people.xml");

            using (FileStream stream = File.Create(path))
            {
                // serialize the object graph to the stream
                xs.Serialize(stream, people);
            }

            System.Console.WriteLine($"Writen {new FileInfo(path).Length} bytes of XML to {path}");

            System.Console.WriteLine();

            // Display the serialized object graph
            System.Console.WriteLine(File.ReadAllText(path));


            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                // desirialize and cast the object graph into a List of Person
                var loadPeople = (List<Person>)xs.Deserialize(xmlLoad);

                foreach(var item in loadPeople)
                {
                    System.Console.WriteLine($"{item.LastName} has children {item.Children.Count}");
                }
            }

            // create a file to write to
            string jsonPath = Combine(CurrentDirectory, "people.json");
            
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                // create an object that will format as JSON
                var jss = new Newtonsoft.Json.JsonSerializer();

                // serialize the object graph into a string
                jss.Serialize(jsonStream, people);
            }

            System.Console.WriteLine();
            System.Console.WriteLine($"Writen {new FileInfo(jsonPath).Length:N0} bytes of JSON to {jsonPath}");

            // Display the serilized object graph
            System.Console.WriteLine(File.ReadAllText(jsonPath)); 
        }
    }
}