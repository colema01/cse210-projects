public abstract class Goal
{
    public int GoalID { get; set; }
    public string Title { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }  

    public abstract void RecordCompletion(UserProfile user);
}

