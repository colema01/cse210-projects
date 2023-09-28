using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.jobTitle = "Baseball Player";
        job1.company = "Red Sox";
        job1.startYear = 2020;
        job1.endYear = 2021;

        Job job2 = new Job();
        job2.jobTitle = "Developer";
        job2.company = "Microsoft";
        job2.startYear = 2000;
        job2.endYear = 2015;

        Resume myResume = new Resume();
        myResume.name = "Mitch Coleman";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);

        myResume.Display();
    }
}