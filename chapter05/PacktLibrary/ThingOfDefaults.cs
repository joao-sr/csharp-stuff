using System.Collections.Generic;
using System;

namespace Packt.Shared
{
    public class ThingsOfDefaults
    {
        public int Population;
        public DateTime When;
        public string? Name;
        public List<Person>? People;

        public ThingsOfDefaults()
        {
            Population = default(int);
            When = default(DateTime);
            Name = default(string);
            People = default(List<Person>);
        }
    }
}