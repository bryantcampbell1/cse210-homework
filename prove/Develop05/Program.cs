using System;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine($"Current Score: {goalManager.UserScore}");

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("The types of goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    
                    string goalTypeChoice = Console.ReadLine();

                    string name, description;
                    int basePoints;

                    Console.Write("Enter goal name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    description = Console.ReadLine();
                    Console.Write("Enter base points: ");
                    basePoints = int.Parse(Console.ReadLine());

                    Goal newGoal = null;

                    switch (goalTypeChoice)
                    {
                        case "1":
                            newGoal = new SimpleGoal(name, description, basePoints);
                            break;
                        case "2":
                            newGoal = new EternalGoal(name, description, basePoints);
                            break;
                        case "3":
                            int targetCount, bonusPoints;
                            Console.Write("Enter target count: ");
                            targetCount = int.Parse(Console.ReadLine());
                            Console.Write("Enter bonus points: ");
                            bonusPoints = int.Parse(Console.ReadLine());
                            newGoal = new ChecklistGoal(name, description, basePoints, targetCount, bonusPoints);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Returning to menu.");
                            continue;
                    }

                    if (newGoal != null)
                    {
                        goalManager.AddGoal(newGoal);
                        Console.WriteLine("Goal created successfully.");
                    }
                    break;

                case "2":
                    goalManager.DisplayGoals();
                    break;

                case "3":
                    Console.Write("Enter the filename to save goals: ");
                    string filename = Console.ReadLine();
                    goalManager.SaveGoals(filename);
                    break;

                case "4":
                    Console.Write("Enter the filename to load goals: ");
                    string filenameToLoad = Console.ReadLine();
                    goalManager.LoadGoals(filenameToLoad);
                    break;

                case "5":
                    goalManager.DisplayGoals();
                    Console.Write("Enter the number of the goal to record the event: ");
                    if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= goalManager.GoalsList.Count)
                    {
                        
                        Goal selectedGoal = goalManager.GoalsList[goalNumber - 1];  
                        goalManager.RecordEvent(selectedGoal.Name); 
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Please select a valid goal number.");
                    }
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
