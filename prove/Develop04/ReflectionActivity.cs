using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        // Add more prompts as needed
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    protected override void RunActivity()
    {
        var random = new Random();
        int index = random.Next(Prompts.Count);
        Console.WriteLine(Prompts[index]);
        // Implement reflection questions and timing here, similar to the BreathingActivity
    }
}
