using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to display.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    
    public void ListGoalNames()
    {
        Console.WriteLine("\nThe available goals are:");
         if (_goals.Count == 0)
        {
            Console.WriteLine(" there are no goals to display.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals you can create are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. List goal (Checklist)");
        Console.Write("What type of goal would you like to create?: ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the number of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times do you need to accomplish this goal for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for completing this goal? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Objective type not recognized. Please select a valid option.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
             Console.WriteLine("You have to create a goal before you can record an event.");
             return;
        }
      
        ListGoalNames();
        Console.Write("Wich goal did you accomplished?: ");
        int goalChoice = int.Parse(Console.ReadLine()) - 1;

        if (goalChoice >= 0 && goalChoice < _goals.Count)
        {
            if (_goals[goalChoice].IsComplete())
            {
                Console.WriteLine("This goal is already complete.");
            }
            else
            {
                int pointsEarned = _goals[goalChoice].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have won {pointsEarned} points!");
                Console.WriteLine($"Now you have {_score} points.");
            }
        }
        else
        {
            Console.WriteLine("Goal not found. Please select a valid goal.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the name of the file to save your goals? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the name of the file to load your goals from? ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("||");
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            switch (goalType)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(parts[4]);
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    if (isComplete)
                    {
                        simpleGoal.RecordEvent();
                    }
                    _goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "ChecklistGoal":
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    for(int j = 0; j < amountCompleted; j++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    _score -= (points * amountCompleted); 
                    if (amountCompleted == target) _score -= bonus;
                    _goals.Add(checklistGoal);
                    break;
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}