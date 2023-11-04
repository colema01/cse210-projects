using System;
using System.Threading;

public abstract class Activity
{
    protected string Name { get; }
    protected string Description { get; }
    protected int Duration { get; private set; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        DisplayStartMessage();
        Duration = PromptForDuration();
        PauseWithAnimation(3); 
        RunActivity();
        DisplayEndMessage();
    }

    private void DisplayStartMessage()
    {
        Console.WriteLine($"Starting Activity: {Name}");
        Console.WriteLine(Description);
    }

    private int PromptForDuration()
    {
        Console.Write("Enter duration in seconds: ");
        return int.Parse(Console.ReadLine());
    }

    protected abstract void RunActivity();

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine("Well done! You have completed " + Name);
        PauseWithAnimation(2);
        Console.WriteLine($"Duration: {Duration} seconds");
        PauseWithAnimation(2);
    }
}
