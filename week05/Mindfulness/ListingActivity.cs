using System;

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
        
    }

    public void GetRandomPrompt()
    {

    }

    public List<string> GetListFromUser()
    {
        
    }


}