using System;
using System.Collections.Generic;

class Program
{
    static TaskManager taskManager = new TaskManager();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Personal Task Manager");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Select a task to mark as completed");
            Console.WriteLine("3. View current tasks");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            
            string input = Console.ReadLine();
            Console.WriteLine();
            
            switch (input)
            {
                case "1":
                    AddNewTask();
                    break;
                case "2":
                    MarkTaskAsCompleted();
                    break;
                case "3":
                    ViewCurrentTasks();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

static void AddNewTask()
{
    Console.Write("Enter task title: ");
    string title = Console.ReadLine();
    Console.Write("Enter task description: ");
    string description = Console.ReadLine();
    Console.Write("Enter task due date (mm-dd): ");
    DateTime dueDate = DateTime.Parse(Console.ReadLine());
    Console.Write("Enter task priority (L, M, H): ");
    string priority = Console.ReadLine();

    Console.WriteLine("Select task type:");
    Console.WriteLine("1. Personal Task");
    Console.WriteLine("2. Work Task");
    Console.WriteLine("3. Errand Task");
    Console.Write("Enter your choice: ");
    string taskTypeChoice = Console.ReadLine();

    string taskType;
    switch (taskTypeChoice)
    {
        case "1":
            taskType = "Personal Task";
            break;
        case "2":
            taskType = "Work Task";
            break;
        case "3":
            taskType = "Errand Task";
            break;
        default:
            Console.WriteLine("Invalid choice. Defaulting to Personal Task.");
            taskType = "Personal Task";
            break;
    }

    ToDoTask newTask = new ToDoTask(title, description, dueDate, priority, taskType);
    taskManager.AddTask(newTask);
    Console.WriteLine("Task added successfully.\n");
}

    
    static void MarkTaskAsCompleted()
    {
        ViewCurrentTasks();
        Console.Write("Enter the number of the task to mark as completed: ");
        int taskNumber = int.Parse(Console.ReadLine());
        
        if (taskNumber > 0 && taskNumber <= taskManager.Tasks.Count)
        {
            ToDoTask task = taskManager.Tasks[taskNumber - 1];
            task.MarkAsCompleted();
            Console.WriteLine("Task marked as completed.\n");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please try again.\n");
        }
    }
    
    static void ViewCurrentTasks()
    {
        Console.WriteLine("Current Tasks:");
        for (int i = 0; i < taskManager.Tasks.Count; i++)
        {
            ToDoTask task = taskManager.Tasks[i];
            Console.WriteLine($"{i + 1}. {task.Title} - {task.Description} - Due: {task.DueDate.ToShortDateString()} - Priority: {task.Priority} - Completed: {task.IsCompleted}");
        }
        Console.WriteLine();
    }
}