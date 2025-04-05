using System;

public class PersonalTask : ToDoTask
{
    public string Location { get; set; }
    public bool IsRecurring { get; set; }

    public PersonalTask(string title, string description, DateTime dueDate, string priority, string location, bool isRecurring)
        : base(title, description, dueDate, priority)
    {
        Location = location;
        IsRecurring = isRecurring;
    }

    public void SetRecurring(bool isRecurring)
    {
        IsRecurring = isRecurring;
    }

    public string GetPersonalTaskDetails()
    {
        return $"Location: {Location}, IsRecurring: {IsRecurring}";
    }
}