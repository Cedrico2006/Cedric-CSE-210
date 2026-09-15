using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
       void DisplayWelcome()
        {
            Console.WriteLine("Welcome to The Program");
        }
        string PromptUser()
        {
            Console.WriteLine("Whst is your name?");
            string name =Console.ReadLine();
            return name;
        }
        int PromptUserNumber()
        {
            Console.WriteLine("Whst is your number?");
            string inputnumber =Console.ReadLine();
            int number = int.Parse(inputnumber);
            return number;
        }
        int PromptUserBirth()
        {
            Console.WriteLine("Whst is your birth year?");
            string inputnumber =Console.ReadLine();
            int number = int.Parse(inputnumber);
            return number;
        }
        int squarenumber(int x)
        {
           int NumberSquared = x * x;

            return NumberSquared;
        }
        void DisplayResult(int numbersq, int Birthyear , string name)
        {
           int Age =2026 - Birthyear;

           Console.WriteLine($"{name} favorite number squared is {numbersq}");
           Console.WriteLine($"{name} will be {Age} this year");
        }
        void main()
        {
            DisplayWelcome();
            DisplayResult(squarenumber(PromptUserNumber()),PromptUserBirth(),PromptUser());
        }
        main();

        {

        }

    }
}