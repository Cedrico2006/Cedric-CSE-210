using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What Percent is the Grade");
        string Grade = Console.ReadLine();
        float number = float.Parse(Grade);

        if (number >= 90)
        {Console.WriteLine('A');}

        else if (number >= 80 && number < 90)
        {Console.WriteLine('B');}

        else if (number >= 70 && number < 80)
        {Console.WriteLine('C');}

        else if (number >= 60 && number < 70)
        {Console.WriteLine('D');}

        else
        {Console.WriteLine('F');}


        

    }
}