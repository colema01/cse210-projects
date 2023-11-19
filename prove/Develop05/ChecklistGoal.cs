public class ChecklistGoal : Goal
{
    private const int MaxPoints = 1000;  
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public override void RecordCompletion(UserProfile user)
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            int pointsToAward = Math.Min(this.Points, MaxPoints); 
            user.CurrentScore += pointsToAward;

            if (CurrentCount == TargetCount)
            {
                int bonusToAward = Math.Min(this.BonusPoints, MaxPoints); 
                user.CurrentScore += bonusToAward;
                IsCompleted = true;
            }
        }
    }
}


