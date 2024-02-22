using System;
using System.Collections.Generic;

abstract class Goal
{
    protected string Name { get; set; }
    protected int Value { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public int GetValue() // Getter method to access Value property
    {
        return Value;
    }

    public abstract void RecordProgress();

    public abstract bool IsCompleted();

    public abstract string DisplayStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"Recording progress for {Name}");
    }

    public override bool IsCompleted()
    {
        return true;
    }

    public override string DisplayStatus()
    {
        return $"[Completed: {Name}]";
    }
}

class EternalGoal : Goal
{
    private int timesCompleted;

    public EternalGoal(string name, int value) : base(name, value)
    {
        timesCompleted = 0;
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"Recording progress for {Name}");
        timesCompleted++;
    }

    public override bool IsCompleted()
    {
        return false;
    }

    public override string DisplayStatus()
    {
        return $"[InProgress: {Name} ({timesCompleted} times completed)]";
    }
}

class ChecklistGoal : Goal
{
    private int totalTimes;
    private int timesCompleted;

    public ChecklistGoal(string name, int value, int totalTimes) : base(name, value)
    {
        this.totalTimes = totalTimes;
        timesCompleted = 0;
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"Recording progress for {Name}");
        timesCompleted++;
    }

    public override bool IsCompleted()
    {
        return timesCompleted >= totalTimes;
    }

    public override string DisplayStatus()
    {
        return $"[InProgress: {Name} (Completed {timesCompleted}/{totalTimes} times)]";
    }
}

class NegativeGoal : Goal
{
    public NegativeGoal(string name, int value) : base(name, value) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"Recording progress for {Name}");
    }

    public override bool IsCompleted()
    {
        return false;
    }

    public override string DisplayStatus()
    {
        return $"[InProgress: {Name}]";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        Goal goal1 = new SimpleGoal("Run a marathon", 1000);
        Goal goal2 = new EternalGoal("Read scriptures", 100);
        Goal goal3 = new ChecklistGoal("Attend the temple", 50, 10);
        Goal goal4 = new NegativeGoal("Avoid junk food", -50);

        goals.Add(goal1);
        goals.Add(goal2);
        goals.Add(goal3);
        goals.Add(goal4);

        int totalXP = 0;
        int currentLevel = 1;
        int[] xpThresholds = { 1000, 2500, 5000 };

        foreach (Goal goal in goals)
        {
            goal.RecordProgress();
            totalXP += goal.GetValue(); // Accessing the Value property using the getter method
        }

        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }

        for (int i = 0; i < xpThresholds.Length; i++)
        {
            if (totalXP >= xpThresholds[i])
            {
                currentLevel = i + 2;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"\nYou've reached Level {currentLevel} with {totalXP} XP!");
    }
}
