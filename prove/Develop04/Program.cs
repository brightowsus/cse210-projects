using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
public abstract class Activity
{
    protected int durationInSeconds;

    // Constructor
    public Activity(int duration)
    {
        durationInSeconds = duration;
    }

    // Method to start the activity
    public abstract void Start();
}

// Class for Breathing Activity
public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity(int duration) : base(duration) { }

    // Method to start breathing activity
    public override void Start()
    {
        Console.WriteLine("Breathing Activity:");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Starting in 3...");
        Thread.Sleep(1000);
        Console.WriteLine("2...");
        Thread.Sleep(1000);
        Console.WriteLine("1...");
        Thread.Sleep(1000);
        
        Console.WriteLine("Begin:");
        for (int i = 0; i < durationInSeconds; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
        
        Console.WriteLine("Well done! You've completed the Breathing Activity for " + durationInSeconds + " seconds.");
    }
}

// Class for Reflection Activity
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public ReflectionActivity(int duration) : base(duration) { }

    // Method to start reflection activity
    public override void Start()
    {
        Console.WriteLine("Reflection Activity:");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Starting in 3...");
        Thread.Sleep(1000);
        Console.WriteLine("2...");
        Thread.Sleep(1000);
        Console.WriteLine("1...");
        Thread.Sleep(1000);
        
        Console.WriteLine("Begin:");

        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine(prompt);
        
        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
            // Display spinner or animation
        }

        Console.WriteLine("Well done! You've completed the Reflection Activity for " + durationInSeconds + " seconds.");
    }
}

// Class for Listing Activity
public class ListingActivity : Activity
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity(int duration) : base(duration) { }

    // Method to start listing activity
    public override void Start()
    {
        Console.WriteLine("Listing Activity:");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Starting in 3...");
        Thread.Sleep(1000);
        Console.WriteLine("2...");
        Thread.Sleep(1000);
        Console.WriteLine("1...");
        Thread.Sleep(1000);
        
        Console.WriteLine("Begin:");
        Random rnd = new Random();
        string prompt = listingPrompts[rnd.Next(listingPrompts.Count)];
        Console.WriteLine(prompt);
        
        Console.WriteLine("Start listing...");

        // Simulating user input for listing items
        Thread.Sleep(durationInSeconds * 1000); // Pause for specified duration
        
        Console.WriteLine("Well done! You've listed items for " + durationInSeconds + " seconds.");
    }
}

// Class for Gratitude Journaling Activity
public class GratitudeJournalingActivity : Activity
{
    private List<string> journalPrompts = new List<string>
    {
        "What are three things you're grateful for today?",
        "Who has done something kind for you recently?",
        "What is a happy memory you cherish?"
    };

    // Constructor
    public GratitudeJournalingActivity(int duration) : base(duration) { }

    // Method to start gratitude journaling activity
    public override void Start()
    {
        Console.WriteLine("Gratitude Journaling Activity:");
        Console.WriteLine("This activity will help you focus on the positive aspects of your life by journaling about things you're grateful for.");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
        
        Console.WriteLine("Starting in 3...");
        Thread.Sleep(1000);
        Console.WriteLine("2...");
        Thread.Sleep(1000);
        Console.WriteLine("1...");
        Thread.Sleep(1000);
        
        Console.WriteLine("Begin:");
        foreach (var prompt in journalPrompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(5000); // Pause for 5 seconds
            // Display spinner or animation
        }

        Console.WriteLine("Well done! You've completed the Gratitude Journaling Activity for " + durationInSeconds + " seconds.");
    }
}

// Main class
public class Program
{
    // Main method
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Menu for selecting activity
        Console.WriteLine("Select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Gratitude Journaling Activity");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter duration in seconds: ");
        int duration = Convert.ToInt32(Console.ReadLine());

        // Based on user choice, initiate corresponding activity
        switch (choice)
        {
            case 1:
                activities.Add(new BreathingActivity(duration));
                break;
            case 2:
                activities.Add(new ReflectionActivity(duration));
                break;
            case 3:
                activities.Add(new ListingActivity(duration));
                break;
            case 4:
                activities.Add(new GratitudeJournalingActivity(duration));
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

        // Perform selected activities
        foreach (var activity in activities)
        {
            activity.Start();
        }
    }
}
