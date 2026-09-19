using System;
using System.IO;
using System.IO.Compression;
using System.IO.Enumeration;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;


public class Journals
{

    public string currentfile = "journal.txt";
    public List<string> localsave = new List<string>();
    public void Display()
    {    
        Console.WriteLine("Would you like to read whole journal or just unsaved?");
        Console.WriteLine("1. Read Whole Journal");
        Console.WriteLine("2. Just Unsaved");
        string response = Console.ReadLine();

        if (response == "1")
        { string[] lines = System.IO.File.ReadAllLines(currentfile);
        
        foreach (string line in lines)
        {
            string[] entrys = line.Split("||"); 
            
            Console.WriteLine($"Date: {entrys[0]}");
            Console.WriteLine($"Prompt: {entrys[2]}");
            Console.WriteLine($"Journal: {entrys[1]}");
            Console.WriteLine();
        }}

        else if (response == "2")
        {
            foreach (string item in localsave)
            {
                string[] entrys = item.Split("||"); 
                Console.WriteLine($"Date: {entrys[0]}");
                Console.WriteLine($"Prompt: {entrys[2]}");
                Console.WriteLine($"Journal: {entrys[1]}");
                Console.WriteLine();
                
            }
        }
    }
    public void Write()
    {
       List<string> prompts = [
        "What is one small thing I can do today to take care of myself?",
        "How am I really feeling right now, and why?",
        "What was the best part of my day?",
        "What challenge did I face today, and how did I handle it?",
        "What is one lie I believed for most of my life?",
        "What strengths or good qualities do I often forget I have?",
        "What activities made me lose track of time when I was a child?",
        "What would I do today if I felt completely fearless?",
        "What are three simple things that bring me joy?",
        "Who has made my life better or easier recently?",
        "What part of my daily routine am I most thankful for?",
        "Imagine yourself five years from now. What does your life look like?",
        "What is one small habit I would like to start this week?",
        "If I could achieve any single goal in the next year, what would it be?",
       ];
        int random_num = Random.Shared.Next(1, 14);
        Console.WriteLine(prompts[random_num]);
        string Response = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string date = theCurrentTime.ToShortDateString();
        string prompt = prompts[random_num];

        localsave.Add($"{date}||{Response}||{prompt}");
        }
    public void Load()
    {
        Console.WriteLine("Would you like to create a file? yes or no");
        string repsonse = Console.ReadLine();

        if (repsonse == "yes")
        {
            Console. WriteLine("What would you like to name the file?");
            string FileName = Console.ReadLine();
            FileName += ".txt";
            currentfile = FileName;
            Console.WriteLine("Please complete first entry");
            Write();
            Save();
        }
        else 
        {Console.WriteLine("What file would you like to load?");
        currentfile = Console.ReadLine();}
    }

    public void Save()
    {
        string path = currentfile;
        using (StreamWriter outputFile = new StreamWriter(path, true))
        {
           foreach (string i in localsave)
           {
            outputFile.WriteLine(i);
           }
        }
    }
}