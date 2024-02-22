using System;

// Define the base Exercise class
public class Exercise
{
    // Properties
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public int CaloriesBurnedPerHour { get; set; }

    // Constructor
    public Exercise(string name, TimeSpan duration, int caloriesBurnedPerHour)
    {
        Name = name;
        Duration = duration;
        CaloriesBurnedPerHour = caloriesBurnedPerHour;
    }

    // Method to calculate calories burned for the exercise
    public virtual int CalculateCaloriesBurned()
    {
        double hours = Duration.TotalHours;
        return (int)(hours * CaloriesBurnedPerHour);
    }
}

// Define derived classes for specific exercise types
public class Running : Exercise
{
    public Running(TimeSpan duration) : base("Running", duration, 600) { }
}

public class Cycling : Exercise
{
    public Cycling(TimeSpan duration) : base("Cycling", duration, 500) { }
}

public class Weightlifting : Exercise
{
    public Weightlifting(TimeSpan duration) : base("Weightlifting", duration, 400) { }
}

class Program
{
    static void Main(string[] args)
    {
        // Create different types of exercises
        Exercise running = new Running(TimeSpan.FromMinutes(30));
        Exercise cycling = new Cycling(TimeSpan.FromMinutes(45));
        Exercise weightlifting = new Weightlifting(TimeSpan.FromMinutes(60));

        // Calculate and display calories burned for each exercise
        Console.WriteLine($"Calories burned from {running.Name}: {running.CalculateCaloriesBurned()}");
        Console.WriteLine($"Calories burned from {cycling.Name}: {cycling.CalculateCaloriesBurned()}");
        Console.WriteLine($"Calories burned from {weightlifting.Name}: {weightlifting.CalculateCaloriesBurned()}");
    }
}
