using System;
// homework #5

namespace JobProject
{
    public class Job
    {
        public string Title { get; set; }

        public Job(string title)
        {
            Title = title;
        }

        public void DoWork()
        {
            Console.WriteLine($"Working on job: {Title}");
        }
    }
}