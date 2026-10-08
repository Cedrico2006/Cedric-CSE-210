using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;
public class Activity
{
    protected string _name = "";
    protected string _description = "";
    protected int _length = 0;

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _length = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Showtimer(3);
    }
   public void DisplayEndingMessage()
{
    Console.WriteLine();
    Console.WriteLine("Good job!");

    Showtimer(2);

    Console.WriteLine();
    Console.WriteLine($"You have completed the {_name} for {_length} seconds.");

    Showtimer(3);
}

    public void Showtimer(int seconds)
    {
        List<string> Spinner = ["|", "/", "-", "\\","|"];
        double counter = 0;
        
        while (counter != seconds)
        {
            foreach (string i in Spinner)
            {
            Console.Write("\b" + i);
            
            Thread.Sleep(100); // each loop is 500 miliseconds
            }
        counter = counter + .5;
        }
    }

}
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        
    }
    public void Run()
    {
        DisplayStartingMessage();

        int timePassed = 0;

        while (timePassed < _length)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            Showtimer(3);

            timePassed += 3;

            if (timePassed < _length)
            {
                Console.WriteLine();
                Console.Write("Breathe out...");
                Showtimer(3);

                timePassed += 3;
            }
        }

        DisplayEndingMessage();
    }


}
public class ReflectionActivity : Activity
{

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }
  List<string> _startingMessage = new List<string>
    {
      "Think of a time when you stood up for someone else."
        ,"Think of a time when you did something really difficult."
        ,"Think of a time when you helped someone in need."
        ,"Think of a time when you did something truly selfless.",  
    };

  List<string> reflectionQuestions = new List<string>
    {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };

   public void Run()
    {
        
        
        DisplayStartingMessage();
        int _timePassed = _length;

        Console.WriteLine();

        Console.WriteLine(_startingMessage[Random.Shared.Next(_startingMessage.Count)]);

        Console.WriteLine();
        Console.WriteLine("Press Enter when you are ready.");
        Console.ReadLine();

        while (_timePassed > 0)
        {
            Console.WriteLine();
            Console.WriteLine(reflectionQuestions[Random.Shared.Next(reflectionQuestions.Count)]);

            Showtimer(3);

            _timePassed -= 3;
        }

        DisplayEndingMessage();
    }
}

public class ListingActivity : Activity
{
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    } 

    List<string> listingPrompts = new List<string>
    {
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?"
    };

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();

        Console.WriteLine(
            listingPrompts[
                Random.Shared.Next(listingPrompts.Count)
            ]
        );

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Showtimer(5);

        Console.WriteLine();
        Console.WriteLine("Start listing:");

        List<string> answers = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_length);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                answers.Add(answer);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {answers.Count} items.");

        DisplayEndingMessage();
    }
}