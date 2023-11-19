public class EternalGoal : Goal
{
    public override void RecordCompletion(UserProfile user)
    {
        user.CurrentScore += this.Points;  
        IsCompleted = false;  
    }
}


