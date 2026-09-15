using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "go";
        List<int> Numbers = new List<int>();
        int total = 0;
        int bignum = 0;
        float average = 0;

        while (input != "stop")
        {
            Console.WriteLine("Type a Number");
            string user_number = Console.ReadLine();
            if (user_number == "stop")
            {
                foreach (int i in Numbers)
                {total += i;
                int ninlist = Numbers.Count();
                average = total / ninlist;}

                // Largest Number

                foreach (int i in Numbers)
                {
                    if (i > bignum)
                    {bignum = i;}

                }
                

                Console.WriteLine($"total is {total} ");
                Console.WriteLine($"The average is {average}");
                Console.WriteLine($"The biggest number is {bignum}");


                break;
            }
            else
            {
                int number = int.Parse(user_number);
                
                Numbers.Add(number);

            };



        }
    }
}