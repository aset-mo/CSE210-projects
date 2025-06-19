using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run1 = new Running(new DateTime(2022, 11, 3), 30, 4.8);
        Cycling cycle1 = new Cycling(new DateTime(2022, 11, 5), 45, 25.0);
        Swimming swim1 = new Swimming(new DateTime(2022, 11, 7), 60, 40);

        activities.Add(run1);
        activities.Add(cycle1);
        activities.Add(swim1);

        Console.WriteLine("Fitness Activity Summaries:");
        Console.WriteLine("--------------------------");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine("Program execution complete.");
    }
}