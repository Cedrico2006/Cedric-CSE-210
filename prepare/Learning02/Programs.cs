using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.start_year = 2019;
        job1.end_year = 2022;
        job1.title = "Software Engineer";
        job1.company = "Microsoft";

        Job job2 = new Job();
        job2.start_year = 2022;
        job2.end_year = 2023;
        job2.title = "Manager";
        job2.company = "Apple";

        Resume resume = new Resume();
        resume.person_name = "Allison Rose";
        resume.responsibities = [job1.output, job2.output];
        
        resume.display();
        




    }
   
}
    

