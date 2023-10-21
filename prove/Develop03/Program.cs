using System;
using System.Collections.Generic;

public class ScriptureWord
{
    public string Word { get; set; }
    public bool IsHidden { get; set; }
}

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int? VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
    }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
        : this(book, chapter, verseStart)
    {
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseEnd.HasValue ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}" : $"{Book} {Chapter}:{VerseStart}";
    }
}

public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    public List<ScriptureWord> Words { get; private set; }

    public Scripture(string text, ScriptureReference reference)
    {
        Reference = reference;
        Words = new List<ScriptureWord>();
        foreach (var word in text.Split(' '))
        {
            Words.Add(new ScriptureWord { Word = word });
        }
    }

    public void HideRandomWords(int count)
    {
        var rand = new Random();
        for (int i = 0; i < count; i++)
        {
            Words[rand.Next(Words.Count)].IsHidden = true;
        }
    }

    public bool AllWordsHidden => Words.TrueForAll(w => w.IsHidden);

    public override string ToString()
    {
        return $"{Reference} - " + string.Join(" ", Words.Select(w => w.IsHidden ? "___" : w.Word));
    }
}

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
