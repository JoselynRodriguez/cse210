using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.Write("What is the magic number? ");
        string magic = Console.ReadLine();
        int magn = int.Parse(magic);

        Console.Write("What is your guess?");
        string guess = Console.ReadLine();
        int number = int.Parse(guess);

        if (number < magn)
        {
            Console.WriteLine("Higher");
        }
        else if (number > magn)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guess it!");
        }
        

    }
}