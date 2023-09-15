using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGen = new Random();
        int number = randomGen.Next (1,101);

        int guess = -1;

        while (guess != number)
        {
            Console.Write("What is the magic number? ");
            guess = int.Parse(Console.ReadLine());

            
            if (number > guess)
            {
                Console.WriteLine("Too low");
            }
            
            else if (number < guess)
            {
                Console.WriteLine("Too High");
            }
            else
            {
                Console.WriteLine("You've guessed it!");
            }
        }
        









    }
}