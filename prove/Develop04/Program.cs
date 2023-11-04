using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Activity Program!");
        ActivityManager activityManager = new ActivityManager();

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();
            if (!activityManager.HandleInput(input))
            {
                break; // Exit the program when "3" is entered
            }
        }
    }
}
