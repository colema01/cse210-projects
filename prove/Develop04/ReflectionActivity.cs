using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Where did you come from?",
        "Why are you here?",
    };

    public ReflectionActivity() : base("Reflection", "This will help you reflect on times in your life.") { }

    protected override void RunActivity()
    {
        var random = new Random();
        int index = random.Next(Prompts.Count);
        Console.WriteLine(Prompts[index]);
        
    }
}
