using System;
using JobProject;
// homework #5

namespace JobFactoryProject
{
    public class JobFactory
    {
        public Job Create(string title)
        {
            return new Job(title);
        }
    }
    
    class Program
    {
        static void Main()
        {
            JobFactory jobFactory = new JobFactory();
            
            Job newJob = jobFactory.Create("Awesome title");
            
            Console.WriteLine($"Job Title: {newJob.Title}");
            newJob.DoWork();
        }
    }
}