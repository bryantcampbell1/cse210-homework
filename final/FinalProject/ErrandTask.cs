using System;

public class ErrandTask : ToDoTask
{
    public TimeSpan EstimatedTime { get; set; }

    public ErrandTask(string title, string description, DateTime dueDate, string priority, string taskType, TimeSpan estimatedTime)
        : base(title, description, dueDate, priority, taskType)
    {
        EstimatedTime = estimatedTime;
    }

    public void SetEstimatedTime(TimeSpan estimatedTime)
    {
        EstimatedTime = estimatedTime;
    }
}