using System;
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int basePoints)
        : base(name, description, basePoints) { }

    public override int RecordEvent() => BasePoints;

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[] {Name} - {Description}";
}