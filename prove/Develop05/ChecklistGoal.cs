using System;
class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount; // Track the number of times the goal has been completed
    private int BonusPoints;

    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints)
        : base(name, description, basePoints)
    {
        TargetCount = targetCount;
        CurrentCount = 0; // Initialize count to 0
        BonusPoints = bonusPoints;
    }

    // Load constructor (to load from file)
    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints, int currentCount, bool isCompleted)
        : base(name, description, basePoints)
    {
        TargetCount = targetCount;
        CurrentCount = currentCount;
        BonusPoints = bonusPoints;
        IsCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        // Increase the count each time the goal is completed
        CurrentCount++;

        // Check if the target count has been reached and mark goal as completed
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
            return BasePoints + BonusPoints; // Return the base points + bonus
        }

        // If target isn't reached, return the base points
        return BasePoints;
    }

    public override bool IsComplete() => IsCompleted;

    public override string GetStatus() 
    {
        // Display progress like "2/5" for 2 out of 5
        return $"[{CurrentCount}/{TargetCount}] {Name} - {Description}";
    }

    // Method to save the current count when saving the goals
    public int GetCurrentCount() => CurrentCount;

    // Method to set the current count (used when loading from file)
    public void SetCurrentCount(int count) => CurrentCount = count;
}