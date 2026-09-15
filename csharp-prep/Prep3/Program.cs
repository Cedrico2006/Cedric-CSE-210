using System;
using System.Formats.Asn1;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("what is the magic number");
        string Number =Console.ReadLine();
        int Number1 = int.Parse(Number);

        Console.WriteLine("guess a number");
       
        string Guess =Console.ReadLine();
            int Guess1 = int.Parse(Guess);


        while (Guess1 != Number1)
        {
             if (Guess1 > Number1)
            {
                Console.WriteLine("lower");
            }
             else if (Guess1 < Number1)
            {
                Console.WriteLine("higher");
            }
             Console.WriteLine("guess a number");
            string Guess2 = Console.ReadLine();
            Guess1 = int.Parse(Guess2);
        } 
        Console.WriteLine("you got it!");
    

       
       

    }
}