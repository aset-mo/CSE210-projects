using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;
        List<int> numbers = new List<int>();

        while (number != 0)
        {

            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
    }
}