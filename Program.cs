using System;
using System.IO.Pipes;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;


    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Title must be between 1 and 100 characters");
        }
        Random random = new Random();
        this.id = random.Next(1000, 9999);

        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        if (count <= 0 || count > 10000000)
        {
            throw new ArgumentException("Count must be between 1 and 10000000");
        }

        if (this.playCount + count < 0)
        {
            throw new OverflowException("Play count melebihi batas maksimum");
        }
        this.playCount += count;
    }

    public void PrintVideoDetails() {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
    public static void Main(string[] args)
    {
        try
        { 
            SayaTubeVideo video = new SayaTubeVideo("Tutorial design by contract - Muhammad Farras");
            video.IncreasePlayCount(1000);
            video.IncreasePlayCount(500);

            video.PrintVideoDetails();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error ocurred: " + ex.Message);
        }
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public String username;

    public SayaTubeUser (string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 50)
        {
            throw new ArgumentException("Username must be between 1 and 50 characters");
        }
        Random random = new Random();
        this.id = random.Next(1000, 9999);
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (SayaTubeVideo video in this.uploadedVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentNullException("Video cannot be null");
        }
        this.uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount() {
        Console.WriteLine($"User: {username}"); 
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1}: {uploadedVideos[i].GetPlayCount()}");
        }
    }

    public static void Main(String[] args)
    {
        SayaTubeUser user = new SayaTubeUser("Muhammad Farras");
        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Fast and Furious 5");
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film Iron Man");
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film Spiderman");
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film Batman");
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film Thor");
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film Loki");
        SayaTubeVideo video7 = new SayaTubeVideo("Review Film One Piece");
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Marvel");
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Need For Speed");
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film Siksa Kubur");

        video1.IncreasePlayCount(1000);
        video2.IncreasePlayCount(1000);
        video3.IncreasePlayCount(1000);
        video4.IncreasePlayCount(1000);
        video5.IncreasePlayCount(1000);
        video6.IncreasePlayCount(1000);
        video7.IncreasePlayCount(1000);
        video8.IncreasePlayCount(1000);
        video9.IncreasePlayCount(1000);
        video10.IncreasePlayCount(1000);    

        user.AddVideo(video1);
        user.AddVideo(video2);
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);

        Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());

    }
}