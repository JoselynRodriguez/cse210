using System;

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

    }

    public void DisplayEndingMessage()
    {

    }

    public void ShowSpinner(int seconds)
    {

    }

    public void CountDown(int seconds)
    {
        
    }
}