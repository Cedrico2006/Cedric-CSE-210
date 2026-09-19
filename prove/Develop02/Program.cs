using System.ComponentModel.DataAnnotations;
using System.Net;

class Program
{
  static void Main()
        {
            Journals run = new Journals();
            while (true)
           { 
            
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            string repsonse = Console.ReadLine();


            if (repsonse == "1")
            {
                run.Write();
            }
            else if(repsonse == "2")
            {
                run.Display();
            }
            else if(repsonse == "3")
            {
                run.Load();
            }
            else if(repsonse == "4")
            {
                run.Save();
            }
            else if(repsonse == "5")
            {
                break;
            }

            
        }

}}