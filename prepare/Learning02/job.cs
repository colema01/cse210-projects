using System;

public class Job
{
    public string jobTitle;
    public string company;
    public int startYear;
    public int endYear;

    public void Display()
    {
        Console.WriteLine($"{jobTitle} ({company}) {startYear}-{endYear}");
    }
}