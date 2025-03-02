using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "The purpose of this activity is to help you relax by guiding you through deep breathing exercise.") { }

    public override void Start()
    {
        ShowStandardStartMessage();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine("Breathe out...");
            Countdown(3);
        }
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
