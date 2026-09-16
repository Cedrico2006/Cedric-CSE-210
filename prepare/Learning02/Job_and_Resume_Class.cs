using System;
using System.Security.Cryptography.X509Certificates;

public class Job
{
    public string title = "";
    public string company = "";
    public int start_year;
    public int end_year; 
    
    public string output => $"{title} ({company}) {start_year}-{end_year}"; 
    
}
    

class Resume
{
    public string person_name = "";
    public List<string> responsibities;
    
    public void display()
    {
        Console.WriteLine($"Name:{person_name}");
        Console.WriteLine($"Jobs:");

        foreach (string i in responsibities)
        {Console.WriteLine($"{i}");}
    }

}