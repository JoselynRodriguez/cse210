using System;
using System.Collections.Generic;
using System.Threading;
public class ListingActivity : Activity
{
    protected int _count;
    protected List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "his activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get Ready...");
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

        Console.WriteLine();
        GetRandomPrompt();
        Console.WriteLine(GetRandomPrompt());
        CountDown(3);

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];

    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write(">");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        return items;
    }

}