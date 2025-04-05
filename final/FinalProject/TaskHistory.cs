using System;
using System.Collections.Generic;

public class TaskHistory
{
    private List<ToDoTask> taskHistory = new List<ToDoTask>();

    public void ArchiveCompletedTasks(List<ToDoTask> tasks)
    {
        foreach (var task in tasks)
        {
            if (task.IsCompleted)
            {
                taskHistory.Add(task);
            }
        }
    }

    public List<ToDoTask> RetrieveTaskHistory()
    {
        return taskHistory;
    }
}