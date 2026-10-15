using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int points = 0;
        bool running = true;

        static int ReadINT()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        while (running)
        {
            Console.WriteLine($"\nYou have {points} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            int Choice = ReadINT();

            if (Choice == 1)
            {
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.Write("Choose a goal type: ");

                int ChoiceTwo = ReadINT();

                Goal goal = null;

                if (ChoiceTwo == 1)
                {
                    Console.Write("Goal name: ");
                    string GoalName = Console.ReadLine();
                    Console.Write("Description: ");
                    string Description = Console.ReadLine();
                    Console.Write("Points: ");
                    int goalPoints = ReadINT();

                    goal = new SimpleGoal(GoalName, Description, goalPoints);
                    Console.WriteLine("Goal created!");
                }
                else if (ChoiceTwo == 2)
                {
                    Console.Write("Goal name: ");
                    string GoalName = Console.ReadLine();
                    Console.Write("Description: ");
                    string Description = Console.ReadLine();
                    Console.Write("Points: ");
                    int goalPoints = ReadINT();

                    goal = new EternalGoal(GoalName, Description, goalPoints);
                    Console.WriteLine("Goal created!");
                }
                else if (ChoiceTwo == 3)
                {
                    Console.Write("Goal name: ");
                    string GoalName = Console.ReadLine();
                    Console.Write("Description: ");
                    string Description = Console.ReadLine();
                    Console.Write("Points: ");
                    int goalPoints = ReadINT();
                    Console.Write("How many times do you want to do it?: ");
                    int targetamount = ReadINT();
                    Console.Write("Bonus Points?: ");
                    int bonus = ReadINT();

                    goal = new ListGoal(GoalName, Description, goalPoints, targetamount, bonus);
                    Console.WriteLine("Goal created!");
                }

                if (goal != null)
                {
                    goals.Add(goal);
                }
            }
            else if (Choice == 2)
            {
                Console.WriteLine("\nYour Goals:");
                foreach (Goal goal in goals)
                {
                    Console.WriteLine(goal.Output());
                }
            }
            else if (Choice == 3)
            {
                using (StreamWriter outputFile = new StreamWriter("Goals.txt"))
                {
                    outputFile.WriteLine(points);

                    foreach (Goal goal in goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }

                Console.WriteLine("Goals saved!");
            }
            else if (Choice == 4)
            {
                string[] lines = File.ReadAllLines("Goals.txt");

                goals.Clear();
                points = int.Parse(lines[0]);

                int _number = 1;

               
                while (_number < lines.Length)
                {
                    string[] parts = lines[_number].Split("|");

                    if (parts[0] == "Simple")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), isComplete));
                    }
                    else if (parts[0] == "Eternal")
                    {
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (parts[0] == "Checklist")
                    {
                        goals.Add(new ListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    }
                    
                    _number += 1;
                }

                Console.WriteLine("Goals loaded!");
            }
            else if (Choice == 5)
            {
                if (goals.Count == 0)
                {
                    Console.WriteLine("You have no goals yet.");
                    continue;
                }

                int repeat = 1;

                foreach (Goal goal in goals)
                {
                    Console.WriteLine($"{repeat}. {goal.GetName()}");
                    repeat += 1;
                }
                
                
                Console.Write("Which goal did you accomplish? ");
                int goalIndex = ReadINT() - 1;

                if (goalIndex >= 0 && goalIndex < goals.Count)
                {
                    Goal selectedGoal = goals[goalIndex];

                    if (selectedGoal is SimpleGoal simple)
                    {
                        if (!simple.IsComplete())
                        {
                            simple.CompleteGoal();
                            points += simple.GetPoints();
                            Console.WriteLine($"You earned {simple.GetPoints()} points!");
                        }
                        else
                        {
                            Console.WriteLine("You already completed this goal!");
                        }
                    }
                    else if (selectedGoal is EternalGoal eternal)
                    {
                        points += eternal.GetPoints();
                        Console.WriteLine($"You earned {eternal.GetPoints()} points!");
                    }
                    else if (selectedGoal is ListGoal checklist)
                    {
                        if (!checklist.IsComplete())
                        {
                            checklist.RecordProgress();
                            points += checklist.GetPoints();
                            Console.WriteLine($"You earned {checklist.GetPoints()} points!");

                            if (checklist.IsComplete())
                            {
                                points += checklist.GetBonus();
                                Console.WriteLine($"Goal fully completed! You earned a bonus of {checklist.GetBonus()} points!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This checklist goal is already finished!");
                        }
                    }
                }
            
            }
            else if (Choice == 6)
            {
                running = false;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}