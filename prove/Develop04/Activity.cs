using System;

abstract class Activity
{
    public string Name { get; private set; }
    public int Duration { get; set; }
    public string Description { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void ShowStandardStartMessage()
    {
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
    }

    public void ShowStandardEndMessage()
    {
        Console.WriteLine($"{Name} completed! You spent {Duration} seconds on this activity.");
    }

    public abstract void Start();
}
