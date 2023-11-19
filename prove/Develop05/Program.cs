using System;
using System.Linq;

public class Program
{    private static UserProfile userProfile;
    private static GoalManager goalManager;

    public static void Main(string[] args)
    {
        userProfile = Storage.LoadUserProfile() ?? new UserProfile { Name = "Mitch", CurrentScore = 0 };
        goalManager = new GoalManager { Goals = Storage.LoadGoals() };

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("Welcome to the Goal Tracker!");
            Console.WriteLine("1. Add Goal\n2. Record Goal Completion\n3. View Score\n4. Display Goals\n5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    RecordGoalCompletion();
                    break;
                case "3":
                    ViewScore();
                    break;
                case "4":
                    DisplayGoals();
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

       
        Storage.SaveUserProfile(userProfile);
        Storage.SaveGoals(goalManager.Goals);
    }

    private static void AddGoal()
    {
        Console.WriteLine("Choose the type of goal (Simple/Eternal/Checklist): ");
        string type = Console.ReadLine().ToLower();

        Console.Write("Enter Goal Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case "simple":
                goal = new SimpleGoal { Title = title, Points = points };
                break;
            case "eternal":
                goal = new EternalGoal { Title = title, Points = points };
                break;
            case "checklist":
                Console.Write("Enter Target Count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus Points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal { Title = title, Points = points, TargetCount = targetCount, BonusPoints = bonusPoints };
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goal.GoalID = goalManager.Goals.Count + 1;
        goalManager.Goals.Add(goal);
        Console.WriteLine("Goal added successfully!");

        
        Storage.SaveGoals(goalManager.Goals);
    }

    private static void RecordGoalCompletion()
    {
        Console.Write("Enter Goal ID to record completion: ");
        int goalId = int.Parse(Console.ReadLine());

        var goal = goalManager.Goals.FirstOrDefault(g => g.GoalID == goalId);
        if (goal != null)
        {
            goal.RecordCompletion(userProfile);
            goal.IsCompleted = true; 
            Console.WriteLine("Goal recorded successfully!");
            Storage.SaveGoals(goalManager.Goals); 
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    private static void ViewScore()
    {
        Console.WriteLine($"User: {userProfile.Name}, Score: {userProfile.CurrentScore}");
    }

private static void DisplayGoals()
{
    Console.WriteLine("List of Goals:");
    foreach (var goal in goalManager.Goals)
    {
        string status = goal switch
        {
            ChecklistGoal checklistGoal => $"Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount}",
            EternalGoal => "[ ]", 
            _ => goal.IsCompleted ? "[X]" : "[ ]"
        };

        Console.WriteLine($"ID: {goal.GoalID}, Title: {goal.Title}, Status: {status}");
    }
    }
}



