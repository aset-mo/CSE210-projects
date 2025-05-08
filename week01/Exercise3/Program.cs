using System;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = RandomNumberGenerator.GetInt32(1, 100); 



        int guess = -1; 

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string userGuess = Console.ReadLine();

            if (!int.TryParse(userGuess, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}