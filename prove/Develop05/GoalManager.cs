using System.Collections.Generic;
using System;
using System.IO;

class GoalManager
{
    private List<Goal> Goals = new List<Goal>();
    private int userScore = 0;

    public int UserScore
    {
        get { return userScore; }
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
    try
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(userScore); // Save the score
            foreach (Goal goal in Goals)
            {
                // Save each goal's completion status (IsCompleted)
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.BasePoints}|{goal.IsCompleted}");
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

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 5)
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
                    "ChecklistGoal" => new ChecklistGoal(name, description, basePoints, 10, 500),
                    _ => null
                };

                if (goal != null)
                {
                    goal.IsCompleted = isCompleted;
                    Goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}