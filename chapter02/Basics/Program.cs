using System;
using System.Linq;
using System.Reflection;

namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // loop through the assemblies that this apps refernces
            foreach(var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                var a = Assembly.Load(new AssemblyName(r.FullName));

                // declare a variable to count the number of methods
                int methodCount = 0;

                // loop through all the types in the assembly
                foreach(var t in a.DefinedTypes)
                {
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Console.WriteLine(
                    $"{a.DefinedTypes.Count()} types with {methodCount} methods in {r.Name} assembly"
                );
            }
        }
    }
}