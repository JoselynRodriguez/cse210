using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string percentage = Console.ReadLine();

        int x = int.Parse(percentage);

        string letter = "";
        string sign = "";

        if (x >= 90)
        {
            letter = "A";
        }
        else if (x >= 80)
        {
            letter = "B";
        }
        else if (x >= 70)
        {
            letter = "C";
        }
        else if (x >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int digit = x % 10;

        if (letter != "A" && letter != "F")
        {
            if (digit >= 7)
            {
                sign = "+";
            }
            else if (digit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && x < 93)
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is: {sign}{letter}");

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