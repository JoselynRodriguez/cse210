using System;
using System.Collections.Generic;
using System.Threading;
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

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            CountDown(4);
            Console.WriteLine("Breathe out...");
            CountDown(6);
            elapsed += 10;
        }
        DisplayEndingMessage();
    }


}