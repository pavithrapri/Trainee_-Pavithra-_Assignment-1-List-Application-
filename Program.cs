using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nTask List Application");
            Console.WriteLine("1. Create a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ReadTasks();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    exit = true;
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(title, description));
        Console.WriteLine("Task created successfully!");
    }

    static void ReadTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("List of Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}");
            }
        }
    }

    static void UpdateTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to update.");
            return;
        }

        Console.Write("Enter the title of the task to update: ");
        string title = Console.ReadLine();

        Task taskToUpdate = tasks.Find(t => t.Title == title);

        if (taskToUpdate == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        Console.Write("Enter new title (press Enter to keep the same): ");
        string newTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTitle))
        {
            taskToUpdate.Title = newTitle;
        }

        Console.Write("Enter new description (press Enter to keep the same): ");
        string newDescription = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newDescription))
        {
            taskToUpdate.Description = newDescription;
        }

        Console.WriteLine("Task updated successfully!");
    }

    static void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to delete.");
            return;
        }

        Console.Write("Enter the title of the task to delete: ");
        string title = Console.ReadLine();

        Task taskToDelete = tasks.Find(t => t.Title == title);

        if (taskToDelete == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        tasks.Remove(taskToDelete);
        Console.WriteLine("Task deleted successfully!");
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
