using System;
class ChecklistGoal : Goal
{
    public int TargetCount;
    public int CurrentCount; 
    private int BonusPoints;

    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints)
        : base(name, description, basePoints)
    {
        TargetCount = targetCount;
        CurrentCount = 0; 
        BonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints, int currentCount, bool isCompleted)
        : base(name, description, basePoints)
    {
        TargetCount = targetCount;
        CurrentCount = currentCount;
        BonusPoints = bonusPoints;
        IsCompleted = isCompleted;
    }

    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints, bool isCompleted) : this(name, description, basePoints, targetCount, bonusPoints)
    {
    }

    public override int RecordEvent()
    { 
        CurrentCount++;

        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
            return BasePoints + BonusPoints; 
        }

        return BasePoints;
    }

    public override bool IsComplete() => IsCompleted;

    public override string GetStatus() 
    {
        return $"[{CurrentCount}/{TargetCount}] {Name} - {Description}";
    }


    public int GetCurrentCount() => CurrentCount;


    public void SetCurrentCount(int count) => CurrentCount = count;
}