using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var scripture = new Scripture("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.", new ScriptureReference("John", 3, 16));

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to hide some words or type 'finished' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "finished")
                break;

            scripture.HideRandomWords(3);
            if (scripture.AllWordsHidden)
            {
                Console.WriteLine("All words are hidden!");
                break;
            }
        }
    }
}
