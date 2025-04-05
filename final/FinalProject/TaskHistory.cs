using System;
using System.Collections.Generic;

public class TaskHistory
{
    private List<Task> taskHistory = new List<Task>();

    public void ArchiveCompletedTasks(List<Task> tasks)
    {
        foreach (var task in tasks)
        {
            if (task.IsCompleted)
            {
                taskHistory.Add(task);
            }
        }
    }

    public List<Task> RetrieveTaskHistory()
    {
        return taskHistory;
    }
}
