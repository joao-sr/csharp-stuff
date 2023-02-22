using static System.Console;
using Packt.Shared;

namespace PeopleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // defining Bob
            var bob = new Person();
            bob.Name = "Bob smith";
            bob.DateOfBirth = new DateOnly(1965, 12, 22);
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensofBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            WriteLine($"{bob.Name} was born {bob.DateOfBirth:d MMMM yyyy}");
            WriteLine($"{bob.Name}'s favorite wonder is {bob.FavoriteAncientWonder}. It's integer is {(int)bob.FavoriteAncientWonder}");
            WriteLine($"{bob.Name} is a {Person.Species}");
            WriteLine($"{bob.Name} was born in {bob.HomePlanet}");

            bob.Children.Add(new Person{Name = "Alfred"});
            bob.Children.Add(new Person{Name = "Zoe"});

            WriteLine($"{bob.Name} has {bob.Children.Count} children");
            for(int child =0; child < bob.Children.Count; child++)
            {
                WriteLine($"{bob.Children[child].Name}");
            }

            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"{fruitNamed.Name}, {fruitNamed.Number} there are.");

            // defining Alice
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateOnly(1998, 3, 7)
            };

            WriteLine($"{alice.Name} was born {alice.DateOfBirth:d MMMM yyyy}" );


            // bank account
            BankAccount.InterestRate = 0.012M;
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine($"{jonesAccount.AccountName} earned {jonesAccount.Balance*BankAccount.InterestRate:C}");

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance*BankAccount.InterestRate:C}");

            // working with constructors
            var blankPerson = new Person();
            WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}"); 

            var gunny = new Person("Gunny", "Mars");
            WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}"); 

            
            // defining Sam 
            var sam = new Person{
                Name = "Sam",
                DateOfBirth = new DateOnly(1972,1,27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            sam.FavoriteIceCream = "Chocolate fudge";
            WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}");

            sam.FavoritePrimaryColor = "Red";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");


            sam.Children.Add(new Person{Name="Charlie"});
            sam.Children.Add(new Person{Name="Ellie"});

            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");

            // testing the procreate methods
            var harry = new Person{Name="Harry"};
            var marry = new Person{Name="Marry"};
            var jill = new Person{Name="Jill"};

            // call instance method
            var baby1 = marry.ProcreateWith(harry);
            // call static method
            var baby2 = Person.Procreate(harry, jill);
            // call an operator
            var baby3 = harry*marry;

            WriteLine($"{harry.Name} has {harry.Children.Count} children");
            WriteLine($"{marry.Name} has {marry.Children.Count} children");
            WriteLine($"{jill.Name} has {jill.Children.Count} children");
            WriteLine($"{harry.Name}'s first child is named {harry.Children[0].Name}");

            // testing local function
            WriteLine($"5! is {Person.Factorial(5)}");

            // IMPLEMENTING INTERFACES
            Person[] people = 
            {
                new Person {Name = "Simon"},
                new Person {Name = "Jenny"},
                new Person {Name = "Adam"},
                new Person {Name = "Richard"}
            };

            WriteLine("Initial list of people");
            foreach(var person in people)
            {
                WriteLine(person.Name);
            }

            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine(person.Name);
            }

            // GENERICS
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Tihng with an integer: {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an Integer: {gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");


        }
    }
}