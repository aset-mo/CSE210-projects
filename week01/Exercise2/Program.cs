using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userResponse = Console.ReadLine();
        int grade = int.Parse(userResponse);


        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "C";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class. Well done :)");
        }
        else
        {
            Console.WriteLine("Sorry, you did not passed the class. Keep trying! You can do it");
        }
    }
}