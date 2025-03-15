using System;
class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int basePoints)
        : base(name, description, basePoints) { }

    public override int RecordEvent()
    {
        IsCompleted = true;
        return BasePoints;
    }

    public override bool IsComplete() => IsCompleted;
    
    public override string GetStatus() => $"[{(IsCompleted ? "X" : " ")}] {Name} - {Description}";
}