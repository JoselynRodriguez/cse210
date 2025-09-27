using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Exploring Lima's Street Food", "Rosmeri", 420);
        videos.Add(video1);

        Video video2 = new Video("Python Tutorial for Beginners", "CodeMaster", 900);
        videos.Add(video2);

        Video video3 = new Video("Tour por Miraflores", "TravelPeru", 300);
        videos.Add(video3);
    
        video1.AddComment(new Comment("Luis", "Delicious food!"));
        video1.AddComment(new Comment("Ana", "tasty Ceviche"));
        video1.AddComment(new Comment("Carlos", "Good video, thanks for sharing"));

        video2.AddComment(new Comment("Julia", "Clear and Easy"));
        video2.AddComment(new Comment("Marco", "Do it one of Javascript"));
        video2.AddComment(new Comment("Sofía", "Thank for explaining step by step"));

        video3.AddComment(new Comment("Pedro", "I loved Kennedy park"));
        video3.AddComment(new Comment("Lucía", "I want to visit it soon!"));
        video3.AddComment(new Comment("Diego", "Great video"));

    foreach (Video video in videos)
        {
            Console.WriteLine($"Título: {video._title}");
            Console.WriteLine($"Autor: {video._author}");
            Console.WriteLine($"Duración: {video._lengthSeconds} segundos");
            Console.WriteLine($"Comentarios: {video.NumberComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment._name}: {comment._text}");
            }

            Console.WriteLine(); // Espacio entre videos
        }
    }
}