using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write ("What is your percentage grade?");
           string value = Console.ReadLine();
    int number = int.Parse(value);

    string letter = "";

    if (number >= 90)
    {
        letter = "A";
    }
    else if (number >= 80)
    {
        letter = "B";
    }
    else if (number >= 70)
    {
        letter = "C";
    }
    else if (number >= 60)
    {
        letter = "D";
    }
    else
    {
        letter = "F";
    }

    Console.WriteLine($"Your grade is a {letter}");


    if (number >= 70)
    {
        Console.Write("You are passing! Great job!");
    }
    else
    {
        Console.WriteLine("You are failing. Better luck next time!");
    }





}




    }
