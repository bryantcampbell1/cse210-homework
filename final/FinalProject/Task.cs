using System;

public class Task
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public string Priority { get; }
    public bool IsCompleted { get; private set; }

    public Task(string title, string description, DateTime dueDate, string priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}