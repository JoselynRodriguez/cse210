//I added a list of scriptures to use in the program. There are three scriptures that will be randonly choose and displayed.//
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        List<Scripture> scriptureLibrary = BuildScriptureLibrary();
        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
                break;

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(2);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText()); // Final display with all words hidden
            Console.WriteLine("\nAll words are hidden. Great job!");
        }
    }

    static List<Scripture> BuildScriptureLibrary()
    {
        return new List<Scripture>
         {
             new Scripture(new Reference("Proverbs", 3, 5, 6),
                 "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
             new Scripture(new Reference("John", 3, 16),
                 "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
             new Scripture(new Reference("Enos", 1, 4),
                 "And my soul hungered; and I kneeled down before my Maker, and I cried unto him in mighty prayer and supplication for mine own soul; and all the day long did I cry unto him; yea, and when the night came I did still raise my voice high that it reached the heavens."),
         };
     }

}