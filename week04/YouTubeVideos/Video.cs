using System;
using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _lengthSeconds;

    public List<Video> videos = new List<Video>();
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public int NumberComments()
    {
        return comments.Count;
    }

     public List<Comment> GetComments()
    {
        return comments;
    }
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }
}