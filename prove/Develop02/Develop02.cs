using System;
using System.Collections.Generic;

public class Program
{
    private static List<string> prompts = new List<string>
    {
        "Who did I enjoy talking to the most today?",
        "What made today great?",
        "How did I see God in my life today?",
        "What was the hardest thing I did today?",
        "If I could do something twice today, what would have it been?",
    };

    public static void Main()
    {
        Journal journal = new Journal();
        
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var randomPrompt = prompts[new Random().Next(prompts.Count)];
                    Console.WriteLine(randomPrompt);
                    var response = Console.ReadLine();
                    var entry = new Entry(randomPrompt, response, DateTime.Now.ToShortDateString());
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.WriteLine("Enter filename to save:");
                    var saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.WriteLine("Enter filename to load:");
                    var loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}




