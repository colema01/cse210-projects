using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This will help you relax by breathing in and out slowly.") { }

    protected override void RunActivity()
    {
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(4);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(4);
        }
    }
}
