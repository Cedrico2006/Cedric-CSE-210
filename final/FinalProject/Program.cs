using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Initialize and populate the deck from Deck.txt
        Deck deck = new Deck(new List<RecipeCard>());
        deck.MakeDeck();

        if (deck._deck.Count == 0)
        {
            Console.WriteLine("Deck is empty! Please check Deck.txt.");
            return;
        }

        
    }
}