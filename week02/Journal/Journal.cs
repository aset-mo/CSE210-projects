using System;
using System.Collections.Generic;
using System.IO;

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
        try
        {
            using (StreamWriter writer = new StreamWriter(file, append: true))
            {
                writer.WriteLine(_name);
                foreach (Entry entry in _entries)
                {
                    // Save each entry as: date|prompt|response
                    writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                }
            }
            Console.WriteLine($"Journal saved to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(file);
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            _name = lines[0];
            _entries.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}