using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Storage
{
    private const string GoalsFilePath = "goals1.txt";
    private const string UserProfileFilePath = "userProfile.txt";

    public static void SaveGoals(List<Goal> goals)
    {
        var lines = goals.Select(goal =>
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                return $"{goal.GoalID},{goal.Title},{goal.Points},{goal.GetType().Name},{checklistGoal.TargetCount},{checklistGoal.CurrentCount},{checklistGoal.BonusPoints},{checklistGoal.IsCompleted}";
            }
            return $"{goal.GoalID},{goal.Title},{goal.Points},{goal.GetType().Name},{goal.IsCompleted}";
        });
        File.WriteAllLines(GoalsFilePath, lines);
    }

    public static List<Goal> LoadGoals()
    {
        var goals = new List<Goal>();
        if (!File.Exists(GoalsFilePath))
        {
            return goals;
        }

        var lines = File.ReadAllLines(GoalsFilePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length < 5)
            {
                continue; 
            }

            int goalID = int.Parse(parts[0]);
            string title = parts[1];
            int points = int.Parse(parts[2]);
            string type = parts[3];
            bool isCompleted = bool.Parse(parts[4]);

            Goal goal = null;
            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal();
                    break;
                case "EternalGoal":
                    goal = new EternalGoal();
                    break;
                case "ChecklistGoal":
                    if (parts.Length < 8) continue; 
                    int targetCount = int.Parse(parts[5]);
                    int currentCount = int.Parse(parts[6]);
                    int bonusPoints = int.Parse(parts[7]);
                    goal = new ChecklistGoal { TargetCount = targetCount, CurrentCount = currentCount, BonusPoints = bonusPoints };
                    break;
            }

            if (goal != null)
            {
                goal.GoalID = goalID;
                goal.Title = title;
                goal.Points = points;
                goal.IsCompleted = isCompleted;
                goals.Add(goal);
            }
        }

        return goals;
    }

    public static void SaveUserProfile(UserProfile userProfile)
    {
        var line = $"{userProfile.Name},{userProfile.CurrentScore}";
        File.WriteAllText(UserProfileFilePath, line);
    }

    public static UserProfile LoadUserProfile()
    {
        if (!File.Exists(UserProfileFilePath))
        {
            return null;
        }

        var line = File.ReadAllText(UserProfileFilePath);
        var parts = line.Split(',');
        if (parts.Length < 2) return null;

        return new UserProfile { Name = parts[0], CurrentScore = int.Parse(parts[1]) };
    }
}
