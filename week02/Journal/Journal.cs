
using System;
using System.Collections.Generic;

public class Journal
{
    public string _name = "";
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Display()
    {
        Console.WriteLine($"Journal Name: {_name}");
        Console.WriteLine("Entries:");
        
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        // Implementation to save to file would go here
    }

    public void LoadFromFile(string file)
    {
        // Implementation to load from file would go here
    }
}
