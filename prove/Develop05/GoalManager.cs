using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GoalManager
{
    private List<Goal> Goals = new List<Goal>();
    private int userScore = 0;

    public int UserScore
    {
        get { return userScore; }
    }

    public List<Goal> GoalsList  
    {
        get { return Goals; }
    }

    public void AddGoal(Goal goal) => Goals.Add(goal);

    public void RecordEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name == goalName)
            {
                userScore += goal.RecordEvent();
                Console.WriteLine($"Event recorded for goal: {goalName}. Total points: {userScore}");
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    public void RecordEventByIndex(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < Goals.Count)
        {
            Goal goal = Goals[goalIndex];
            userScore += goal.RecordEvent();
            Console.WriteLine($"Event recorded for goal: {goal.Name}. Total points: {userScore}");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");
        int index = 1;
        foreach (var goal in Goals)
        {
            Console.WriteLine($"{index++}. {goal.GetStatus()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(userScore); 
            foreach (Goal goal in Goals)
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.BasePoints}|{goal.IsCompleted}|{checklistGoal.GetCurrentCount()}|{checklistGoal.TargetCount}");
                }
                else
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.BasePoints}|{goal.IsCompleted}");
                }
            }
        }
        Console.WriteLine($"Goals saved successfully to {filename}");
    }

    public void LoadGoals(string filename)
{
    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found.");
        return;
    }

    Goals.Clear();
    string[] lines = File.ReadAllLines(filename);

    userScore = int.Parse(lines[0]); // Load the score

    foreach (string line in lines.Skip(1)) // Skip the first line (score)
    {
        string[] parts = line.Split('|');

        if (parts.Length >= 5) // Ensure there's at least the common 5 fields
        {
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int basePoints = int.Parse(parts[3]);
            bool isCompleted = bool.Parse(parts[4]);

            Goal goal = type switch
            {
                "SimpleGoal" => new SimpleGoal(name, description, basePoints),
                "EternalGoal" => new EternalGoal(name, description, basePoints),
                "ChecklistGoal" =>
                    // Ensure there are enough parts for a ChecklistGoal (7 parts)
                    parts.Length >= 7
                    ? new ChecklistGoal(name, description, basePoints, 
                        int.Parse(parts[5]), int.Parse(parts[6]), isCompleted)
                    : null,
                _ => null
            };

            if (goal != null)
            {
                // Set the current count for ChecklistGoal when loading from file
                if (goal is ChecklistGoal checklistGoal)
                {
                    checklistGoal.SetCurrentCount(int.Parse(parts[5]));  // Set the current count
                    checklistGoal.TargetCount = int.Parse(parts[6]);     // Set the target count
                }
                goal.IsCompleted = isCompleted;
                Goals.Add(goal);
            }
            else
            {
                Console.WriteLine($"Skipping invalid goal data: {line}");
            }
        }
    }
    Console.WriteLine("Goals loaded successfully.");
}

}