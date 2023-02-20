using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared;
public class Person : object
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
    public string FavoritePrimaryColor 
    {
        get
        {
            return favoritePrimaryColor;
        }
        set
        {
            switch(value.ToLower())
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

}
