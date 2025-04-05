using System;
using System.Collections.Generic;

public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public List<Task> Tasks => tasks;

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void SortTasksByPriority()
    {
        tasks.Sort((x, y) => string.Compare(x.Priority, y.Priority));
    }

    public List<Task> FilterTasksByCategory(string category)
    {
        return tasks.FindAll(task => task.GetType().Name == category);
    }
}
