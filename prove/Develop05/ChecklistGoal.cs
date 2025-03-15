using System;
class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int BonusPoints;

    public ChecklistGoal(string name, string description, int basePoints, int targetCount, int bonusPoints)
        : base(name, description, basePoints)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
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

    public override string GetStatus() => $"[{CurrentCount}/{TargetCount}] {Name} - {Description}";
}