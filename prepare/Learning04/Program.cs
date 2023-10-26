using System;

using System;

class Program
{
    static void Main(string[] args)
    {
    
        Assignment a1 = new Assignment("Mitch Coleman", "Multiplication");
        Console.WriteLine(a1.GetSummary());

       
        MathAssignment a2 = new MathAssignment("Clayton Hailey", "Fractions", "4.0", "12-22");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Megan Kerr", "Europe", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
