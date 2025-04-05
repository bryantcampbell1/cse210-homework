using System;

public class ErrandTask : Task
{
    public TimeSpan EstimatedTime { get; set; }

    public ErrandTask(string title, string description, DateTime dueDate, string priority, TimeSpan estimatedTime)
        : base(title, description, dueDate, priority)
    {
        EstimatedTime = estimatedTime;
    }

    public void SetEstimatedTime(TimeSpan estimatedTime)
    {
        EstimatedTime = estimatedTime;
    }
}
