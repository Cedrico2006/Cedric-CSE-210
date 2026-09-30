using System;
using System.Data;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        static (int number, string text) GatherData(string question, bool condition)
        {
            Console.WriteLine($"{question}");
            string data = Console.ReadLine();
            if (condition)
            {
                return (0, data);
            }
            else
            {
                int data2 = int.Parse(data);
                return (data2, string.Empty);
            }
        }  

        (int _, string book) = GatherData("What book?", true);
        (int chapter, _) = GatherData("What chapter?", false);
        (int startVerse, _) = GatherData("What starting verse?", false);
        (int endVerse, _) = GatherData("What ending verse?", false);
        (int _, string wholeVerse) = GatherData("what is the text of the verse?", true);
        


        Reference reference;

        if (startVerse == endVerse)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }

        Scriptures scripture = new Scriptures(reference, wholeVerse);

        while (!scripture.IsCompletelyHidden())
        {
            (int amountOfWords, _) = GatherData("How many words do you want to hide?", false);
            scripture.Replacement(amountOfWords);
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type quit to exit");

            string choice = Console.ReadLine();

            if (choice == "quit")
            {
                break;
            }
            else
            {
                Console.Clear();
                continue;
            }
        }








    }
}