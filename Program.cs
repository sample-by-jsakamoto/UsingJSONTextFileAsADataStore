using System;
using System.Linq;
using UsingJSONTextFileAsADataStore.Models;
using UsingJSONTextFileAsADataStore.Services;

class Program
{
    static void Main()
    {
        var store = new PeopleStore();
        var quit = false;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Enter command (list,add,update,delete,quit).");
            var command = Console.ReadLine();
            switch (command)
            {
                case "list":
                    ListPeople(store);
                    break;
                case "add":
                    AddPerson(store);
                    break;
                case "update":
                    UpdatePerson(store);
                    break;
                case "delete":
                    DeletePerson(store);
                    break;
                case "quit":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("ERROR: Unknown command.");
                    break;
            }
        } while (quit == false);

        Console.WriteLine("Good bye.");
    }

    private static void DeletePerson(PeopleStore store)
    {
        Console.Write("Enter id:");
        var id = default(int);
        if (int.TryParse(Console.ReadLine(), out id) == false) return;

        var found = store.Delete(id);
        if (found == false)
        {
            Console.WriteLine("ERROR: person not found.");
            return;
        }

        store.SaveChanges();

        Console.WriteLine("OK");
    }

    private static void UpdatePerson(PeopleStore store)
    {
        Console.Write("Enter id:");
        var id = default(int);
        if (int.TryParse(Console.ReadLine(), out id) == false) return;

        var person = store.People.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            Console.WriteLine("ERROR: person not found.");
            return;
        }
        Console.WriteLine(person);
        Console.WriteLine();

        Console.Write("Enter new name:");
        var newName = Console.ReadLine();
        if (newName == "") return;

        Console.Write("Enter new age:");
        var newAge = default(int);
        if (int.TryParse(Console.ReadLine(), out newAge) == false) return;

        person.Name = newName;
        person.Age = newAge;
        store.SaveChanges();

        Console.WriteLine("OK");
    }

    private static void AddPerson(PeopleStore store)
    {
        Console.Write("Enter name:");
        var name = Console.ReadLine();
        if (name == "") return;

        Console.Write("Enter age:");
        var age = default(int);
        if (int.TryParse(Console.ReadLine(), out age) == false) return;

        var person = new Person
        {
            Name = name,
            Age = age
        };

        store.Add(person);
        store.SaveChanges();

        Console.WriteLine("OK");
    }

    private static void ListPeople(PeopleStore store)
    {
        foreach (var persopn in store.People)
        {
            Console.WriteLine(persopn);
        }
        Console.WriteLine("OK");
    }
}
