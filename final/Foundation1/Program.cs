using System;

// Define the Video class to represent a YouTube video
public class Video
{
    // Properties
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }

    // Constructor
    public Video(string title, TimeSpan duration, int views, int likes, int comments)
    {
        Title = title;
        Duration = duration;
        Views = views;
        Likes = likes;
        Comments = comments;
    }

    // Method to display video details
    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Duration: {Duration}");
        Console.WriteLine($"Views: {Views}");
        Console.WriteLine($"Likes: {Likes}");
        Console.WriteLine($"Comments: {Comments}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a sample video
        Video video1 = new Video("Introduction to C#", TimeSpan.FromMinutes(10), 1000, 50, 10);

        // Display video details
        video1.DisplayDetails();
    }
}
