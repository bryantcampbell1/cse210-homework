using System;

public class WorkTask : ToDoTask
{
    public string AssignedTo { get; set; }
    public string ProjectName { get; set; }

    public WorkTask(string title, string description, DateTime dueDate, string priority, string taskType, string assignedTo, string projectName)
        : base(title, description, dueDate, priority, taskType)
    {
        AssignedTo = assignedTo;
        ProjectName = projectName;
    }


    public void AssignTo(string person)
    {
        AssignedTo = person;
    }
}