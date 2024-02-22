using System;

// Define the base Event class
public class Event
{
    // Properties
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }

    // Constructor
    public Event(string name, DateTime date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
    }

    // Method to display event details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Event: {Name}");
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Location: {Location}");
    }
}

// Define derived classes for specific event types
public class Wedding : Event
{
    // Additional properties and methods specific to weddings
    public string BrideName { get; set; }
    public string GroomName { get; set; }

    public Wedding(string brideName, string groomName, DateTime date, string location)
        : base("Wedding", date, location)
    {
        BrideName = brideName;
        GroomName = groomName;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Bride: {BrideName}");
        Console.WriteLine($"Groom: {GroomName}");
    }
}

public class BirthdayParty : Event
{
    // Additional properties and methods specific to birthday parties
    public int Age { get; set; }

    public BirthdayParty(int age, DateTime date, string location)
        : base("Birthday Party", date, location)
    {
        Age = age;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Age: {Age}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a wedding event
        Wedding wedding = new Wedding("Alice", "Bob", new DateTime(2024, 6, 15), "Grand Hotel");

        // Display wedding details
        wedding.DisplayDetails();

        // Create a birthday party event
        BirthdayParty birthdayParty = new BirthdayParty(30, new DateTime(2024, 8, 10), "Community Center");

        // Display birthday party details
        birthdayParty.DisplayDetails();
    }
}
