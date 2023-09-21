using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = -1;
        while (inputNumber != 0)
        {
            Console.Write("Enter a List of Numbers! (0 to Quit): ");
            string inputResponse = Console.ReadLine();
            inputNumber = int.Parse(inputResponse);
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }

        }
                int add = 0;
        foreach (int number in numbers)
        {
            add += number;
        }

        Console.WriteLine($"The sum is: {add}");

        float average = ((float)add) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }


}
