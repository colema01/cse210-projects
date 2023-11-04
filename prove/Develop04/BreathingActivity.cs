using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

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
