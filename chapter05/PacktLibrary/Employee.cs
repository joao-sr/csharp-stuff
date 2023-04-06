using System;
using static System.Console;
namespace Packt.Shared
{
    public class Employee : Person
    {
        public string? EmployeeCode {get; set;}
        public DateOnly HireDate {get; set;}

        public new void WriteToConsole()
        {
            WriteLine($"{this.Name} was born on {this.DateOfBirth:dd/MM/yy} and hired on {this.HireDate:dd/MM/yy}");
        }
    }
}