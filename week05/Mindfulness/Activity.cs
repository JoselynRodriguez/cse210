using System;
using System.Collections.Generic;
using System.Threading;
public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;


    public Activity()
    {
        
    }

    public void DisplayStartingMessage()
    {
        Console.Write("How long, in seconds, would you like for your sesion? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get Ready...");

        ShowSpinner(8);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!!");

        ShowSpinner(5);

        Console.WriteLine();

        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");

        ShowSpinner(5);


    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrigs = new List<string>();
       
        animationStrigs.Add("|");
        animationStrigs.Add("/");
        animationStrigs.Add("-");
        animationStrigs.Add("\\");
        animationStrigs.Add("|");
        animationStrigs.Add("/");
        animationStrigs.Add("-");
        animationStrigs.Add("\\");
        animationStrigs.Add("|");
        animationStrigs.Add("/");

        foreach (string s in animationStrigs)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

    }

    public void CountDown(int seconds)
    {
        for (int i = 4; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }

            Console.WriteLine();
    }
}