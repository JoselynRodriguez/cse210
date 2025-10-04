using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
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

      
    
        

    }
}