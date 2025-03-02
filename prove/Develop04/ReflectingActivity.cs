using System;
using System.Collections.Generic;
using System.Threading;

class ReflectingActivity : Activity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };
    
    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?"
    };

    public ReflectingActivity() : base("Reflection Activity", "The purpose of this activity is to reflect on times when you showed strength and resilience.") {}

    public override void Start()
    {
        ShowStandardStartMessage();
        Random rand = new();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            Spinner(5);
        }
        ShowStandardEndMessage();
    }

    private void Spinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
