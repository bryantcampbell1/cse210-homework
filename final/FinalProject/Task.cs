using System;

//Had an issue with the name 'Task'. Kept getting error messages saying it was a private
//constructor, even thought it was public. Used Ai to fix just by switching the name of the class
public class ToDoTask 
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public string Priority { get; }
    public bool IsCompleted { get; private set; }

    public ToDoTask(string title, string description, DateTime dueDate, string priority, string taskType)
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