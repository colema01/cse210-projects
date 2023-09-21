using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptForUserName();

        int userNumber = PromptForUserNumber();

         int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);

    }
     static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to my program!");
    }
    static string PromptForUserName()
      {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptForUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {square}");
    }
}

