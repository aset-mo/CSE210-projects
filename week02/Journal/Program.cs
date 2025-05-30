using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");
        Console.Write("Enter your journal name: ");
        myJournal._name = Console.ReadLine();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry newEntry = new Entry();
                    newEntry._prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {newEntry._prompt}");
                    Console.Write("Your response: ");
                    newEntry._response = Console.ReadLine();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    myJournal.AddEntry(newEntry);
                    break;
                case "2":
                    myJournal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        myJournal.SaveToFile(saveFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename.");
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        myJournal.LoadFromFile(loadFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename.");
                    }
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}