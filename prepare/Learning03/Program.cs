using System;
using System.Threading.Tasks.Dataflow;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        int Count = 0;
        Fraction fraction = new Fraction();

        while (Count <= 20)
        {
            Random rand = new Random();
            
            int Number1 = rand.Next();
            int Number2 = rand.Next();

            fraction.SetTop(Number1);
            fraction.SetBottom(Number2);

            Console.WriteLine($"Fraction {Count}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");


            Count += 1;
        }
    }
}