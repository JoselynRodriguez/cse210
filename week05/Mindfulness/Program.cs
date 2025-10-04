using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine("");

        while (true)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity();
            }

            else if (choice == "2")
            {
                new ReflectingActivity();
            }

            else if (choice == "3")
            {
                new ListingActivity();
            }

            else if (choice == "4")
            {
                break;
            }

            else
            {
                Console.WriteLine("Write a number from 1 to 4");
            }

            

        }
       

    }

}