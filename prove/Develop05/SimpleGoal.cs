public class SimpleGoal : Goal
{
    private const int MaxPoints = 10;  

    public override void RecordCompletion(UserProfile user)
    {
        if (!IsCompleted)
        {
            int pointsToAward = Math.Min(this.Points, MaxPoints); 
            user.CurrentScore += pointsToAward;
            IsCompleted = true;
        }
    }
}


