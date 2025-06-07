using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _count = 0;
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }


    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
}