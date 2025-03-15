using System;

abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int BasePoints { get; protected set; }
    public bool IsCompleted { get; set; }  

    protected Goal(string name, string description, int basePoints)
    {
        Name = name;
        Description = description;
        BasePoints = basePoints;
        IsCompleted = false;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
}