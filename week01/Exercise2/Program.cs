using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string percentage = Console.ReadLine();

        int x = int.Parse(percentage);

        if (x >= 90)
        {
            Console.WriteLine("A");
        }
        else if (x >= 80)
        {
            Console.WriteLine("B");
        }
        else if (x >= 70)
        {
            Console.WriteLine("C");
        }
        else if (x >= 60)
        {
            Console.WriteLine("D");
        }
        else
        {
            Console.WriteLine("F");
        }

        if (x >= 70)
        {
            Console.WriteLine("Congratulation you pass the course!");
        }
        else
        {
            Console.WriteLine("Sorry, You need to try again. You can do it!");
        }
    }
}