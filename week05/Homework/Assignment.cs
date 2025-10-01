using System;
using System.Dynamic;
using Microsoft.VisualBasic;

class Assignment
{
    private string _studentName;
    private string _topicName;

    public Assignment(string studentName, string topicName)
    {
        _studentName = studentName;
        _topicName = topicName;
    }
    
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topicName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topicName} ";
    }
}