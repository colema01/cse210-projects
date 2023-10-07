using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> Entries { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void Display()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                sw.WriteLine(entry);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var parts = line.Split(" | ");
                var entry = new Entry(parts[1], parts[2], parts[0]);
                Entries.Add(entry);
            }
        }
    }
}
