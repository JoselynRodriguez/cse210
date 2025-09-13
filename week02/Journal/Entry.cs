using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
    }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string FormatForFile()
    {
        return $"{_date} {_promptText} {_entryText}";
    }
    
     public static Entry ParseFromFile(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[0].Trim(), parts[1].Trim(), parts[2].Trim());
        }
        return null;
    }
}