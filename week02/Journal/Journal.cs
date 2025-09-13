using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries;

     public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file ="journal.txt")
    {
         using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.FormatForFile());
            }
        }
    }

    public void LoadFromFile(string file ="journal.txt")
    {
       _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            Entry entry = Entry.ParseFromFile(line);
            if (entry != null)
            {
                AddEntry(entry);
            }
        }
    }
}