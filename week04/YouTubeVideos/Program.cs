using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Comment class
    class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    // Video class
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            var video1 = new Video("Amazing Cats", "CatLover123", 120);
            video1.Comments.Add(new Comment("Alice", "So cute!"));
            video1.Comments.Add(new Comment("Bob", "I love this!"));
            video1.Comments.Add(new Comment("Carol", "When is the next one?"));

            var video2 = new Video("Tech Talk", "TechGuru", 300);
            video2.Comments.Add(new Comment("Dave", "Very informative."));
            video2.Comments.Add(new Comment("Erin", "Thanks for sharing."));
            video2.Comments.Add(new Comment("Frank", "Great explanation."));
            video2.Comments.Add(new Comment("Grace", "I learned a lot."));

            var video3 = new Video("Nature Walk", "Explorer", 200);
            video3.Comments.Add(new Comment("Hannah", "Beautiful scenery."));
            video3.Comments.Add(new Comment("Ian", "This reminds me of home."));
            video3.Comments.Add(new Comment("Julia", "Where was this filmed?"));

            // Store videos in a list
            var videos = new List<Video>() { video1, video2, video3 };

            // Display video information
            foreach (var v in videos)
            {
                Console.WriteLine($"Title: {v.Title}");
                Console.WriteLine($"Author: {v.Author}");
                Console.WriteLine($"Length (s): {v.LengthInSeconds}");
                Console.WriteLine($"Number of comments: {v.GetCommentCount()}");

                foreach (var c in v.Comments)
                {
                    Console.WriteLine($" - {c.Name}: \"{c.Text}\"");
                }

                Console.WriteLine(); // blank line between videos
            }

            Console.WriteLine("=== End of program ===");
        }
    }
}
