using System;
using System.Collections.Generic;
class Program
{
    private List<Activity> activities;

    public Program()
    {
        activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity()
        };
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            for (int i = 0; i < activities.Count; i++)
                Console.WriteLine($"{i + 1}. {activities[i].Name}");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Try again.");
                continue;
            }

            if (choice == 4) break;
            activities[choice - 1].Start();
        }

        Console.WriteLine("Thank you for using the mindfulness app!");
    }
}
