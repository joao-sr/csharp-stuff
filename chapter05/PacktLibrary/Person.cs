using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared;
public class Person : IComparable<Person>
{
    // fields
    public string? Name;
    public DateOnly DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new List<Person>();
    public const string Species = "Homo Sapiens";
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;
    private string? favoritePrimaryColor;

    //constructor
    public Person()
    {
        //set default values for fields
        // including read-only fields
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        this.Name = initialName;
        this.HomePlanet = homePlanet;
        this.Instantiated = DateTime.Now; 
    }

    // methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on {HomePlanet}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    // properties
    public string Origin
    {
        get{return $"{Name} was born on {HomePlanet}";}
    }

    public string Greeting => $"{Name} says Hello!";

    public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

    public string? FavoriteIceCream {get;set;}
    public string? FavoritePrimaryColor 
    {
        get
        {
            return favoritePrimaryColor;
        }
        set
        {
            switch(value?.ToLower())
            {
                case "red":
                case "green":
                case "blue":
                    favoritePrimaryColor = value;
                    break;
                default:
                    throw new System.ArgumentException(
                        $"{value} is not a primary color" + "Choose from: red, green, blue"
                    );
            }
        }
    }

    // indexers
    public Person this[int index]
    {
        get
        {
            return Children[index];
        }
        set
        {
            Children[index] = value;
        }
    }

    // static method to "multiply"
    public static Person Procreate(Person p1, Person p2)
    {
        var baby = new Person{Name = $"Baby of {p1.Name} and {p2.Name}"};
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }

    // instance method to "multiply"
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    // operator to multiply 
    public static Person operator * (Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }

    //method with a local function
    public static int Factorial(int number)
    {
        if (number<0)
        {
            throw new ArgumentException(
                $"{nameof(number)} cannot be less than zero");
        }
        return localFactorial(number);

        int localFactorial(int localNumber) // local function
        {
            if (localNumber<1) return 1;
            return localNumber * localFactorial(localNumber-1);
        }
        
    }

    // impletemation of the CompareTo
    public int CompareTo(Person other)
    {
        return Name.CompareTo(other.Name);
    }

}
