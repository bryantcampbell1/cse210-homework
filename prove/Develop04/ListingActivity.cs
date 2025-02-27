using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you list positive aspects of your life.") {}

    public override void Start()
    {
        ShowStandardStartMessage();
        Random rand = new();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);

        Console.WriteLine("Get ready to list items...");
        Countdown(3);

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items!");
        ShowStandardEndMessage();
    }

    private void Countdown(int seconds)
    {
        DateTime futureTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < futureTime)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
