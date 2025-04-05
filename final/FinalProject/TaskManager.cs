using System;
using System.Collections.Generic;

public class TaskManager
{
    private List<ToDoTask> tasks = new List<ToDoTask>();
    
    public List<ToDoTask> Tasks => tasks;
    
    public void AddTask(ToDoTask task)
    {
        tasks.Add(task);
    }
    
    public void RemoveTask(ToDoTask task)
    {
        tasks.Remove(task);
    }
    
    public void SortTasksByPriority()
    {
        tasks.Sort((x, y) => string.Compare(x.Priority, y.Priority));
    }
    
    public List<ToDoTask> FilterTasksByCategory(string category)
    {
        return tasks.FindAll(task => task.GetType().Name == category);
    }
}